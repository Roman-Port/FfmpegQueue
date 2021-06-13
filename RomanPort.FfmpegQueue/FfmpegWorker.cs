using Microsoft.VisualBasic.FileIO;
using RomanPort.FfmpegQueue.Dialogs;
using RomanPort.FfmpegQueue.Entities;
using RomanPort.FfmpegQueue.Entities.Statuses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.FfmpegQueue
{
    public partial class FfmpegWorker : UserControl
    {
        public FfmpegWorker(ProcessingForm ctx)
        {
            InitializeComponent();
            this.ctx = ctx;
            tooltip = new ToolTip();
        }

        public float AverageSpeed { get => avgSpeed; }

        private ProcessingForm ctx;
        private Process ffmpeg;
        private ToolTip tooltip;
        private float avgSpeed;

        private static bool disableErrorDialogs = false;

        public async Task RunWorker(CancellationToken token)
        {
            ProcessStatus status = null;
            while (status != ProcessStatusAborted.ABORTED && ctx.TryGetNextFile(out QueuedFile file))
            {
                //Update title
                statusFilename.Text = file.InputFile.Name;
                statusProgress.Text = "...";
                statusProgressBar.Value = 0;

                //Bind tooltip
                tooltip.RemoveAll();
                tooltip.SetToolTip(statusFilename, file.InputFile.FullName);

                //Process
                status = await ProcessFile(file, token);

                //If this was a success, apply the post-process action
                if (status.IsSuccessful)
                    ApplyPostProcess(file);
                else if (status != ProcessStatusAborted.ABORTED && !disableErrorDialogs && new ProcessingFailedForm(file, status).ShowDialog() == DialogResult.No)
                    disableErrorDialogs = true;

                //Delete failed files
                if (!status.IsSuccessful)
                    File.Delete(file.OutputFileName);

                //Send status update
                ctx.ReportFileFinishedStatus(file, status);
            }
        }

        private async Task<ProcessStatus> ProcessFile(QueuedFile file, CancellationToken token)
        {
            //If the output file exists, delete it
            if (File.Exists(file.TempFileName))
                File.Delete(file.TempFileName);

            //Make sure the output directory exists
            if (!file.OutputFile.Directory.Exists)
                file.OutputFile.Directory.Create();

            //Query media time
            TimeSpan duration = await file.QueryFileDuration();
            if (duration == TimeSpan.Zero)
                return new ProcessStatusDurationQueryFailed();

            //Create FFMPEG args
            string ffmpegArgs = "-progress - -loglevel quiet " +
                ctx.ProjectFile.FfmpegParams
                .Replace("%i", FfmpegUtil.EscapePathname(file.InputFileName))
                .Replace("%o", FfmpegUtil.EscapePathname(file.TempFileName));

            //Start FFMPEG
            ffmpeg = Process.Start(new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = ffmpegArgs,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            });

            //Begin monitoring events
            bool statusStale = true;
            TimeSpan progress = TimeSpan.Zero;
            while(true)
            {
                //Read line
                string line = await ffmpeg.StandardOutput.ReadLineAsync();
                if (line == null)
                    break;

                //Parse key=value
                string key = line.Split('=')[0];
                string value = line.Substring(key.Length + 1);

                //Handle
                switch(key)
                {
                    case "out_time_ms":
                        try
                        {
                            progress = TimeSpan.FromMilliseconds(double.Parse(value) / 1000);
                        } catch (OverflowException)
                        {
                            //For unknown reasons, sometimes I get a very large negative number here. Not sure why. For now, just ignore it.
                        }
                        statusStale = true;
                        break;
                    case "speed":
                        if(float.TryParse(value.Replace("x", "").Trim(' '), out float speed))
                            avgSpeed = avgSpeed == 0 ? speed : (avgSpeed + speed) / 2;
                        break;
                }

                //If progress is stale, update
                if(statusStale)
                {
                    statusProgressBar.Value = (int)(Math.Min(1, progress.TotalMilliseconds / duration.TotalMilliseconds) * statusProgressBar.Maximum);
                    statusProgress.Text = avgSpeed == 0 ? "..." : FfmpegUtil.FormatTime(TimeSpan.FromMilliseconds((duration - progress).TotalMilliseconds / avgSpeed));
                    statusStale = false;
                }

                //If cancel is requested, abort
                if(token.IsCancellationRequested)
                {
                    //Kill FFMPEG
                    ffmpeg.Kill();

                    //Delete the invalid file
                    if(File.Exists(file.OutputFileName))
                        File.Delete(file.OutputFileName);

                    //Return bad status code
                    return ProcessStatusAborted.ABORTED;
                }
            }

            //Check if it passed
            if (!ffmpeg.HasExited)
                return new ProcessStatusUnexpectedExit();
            if (ffmpeg.ExitCode != 0)
                return new ProcessStatusBadExitCode(ffmpeg.ExitCode);

            //Processing completed. Move from temp file to final filename
            File.Move(file.TempFileName, file.OutputFileName);

            return ProcessStatusSuccess.SUCCESS;
        }

        private void ApplyPostProcess(QueuedFile file)
        {
            //Copy date+time of old file
            new FileInfo(file.OutputFileName).LastWriteTimeUtc = new FileInfo(file.InputFileName).LastWriteTimeUtc;

            //Apply post-processing
            switch (ctx.ProjectFile.PostProcessAction)
            {
                case ProjectConfigPostProcess.NOTHING:
                    break;
                case ProjectConfigPostProcess.RECYCLE:
                    FileSystem.DeleteFile(file.InputFileName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    break;
                case ProjectConfigPostProcess.DELETE:
                    File.Delete(file.InputFileName);
                    break;
                case ProjectConfigPostProcess.MOVE:
                    FileInfo outputFile = FfmpegUtil.RemapDirectory(file.InputFile, "", new DirectoryInfo(ctx.ProjectFile.InputDir), new DirectoryInfo(ctx.ProjectFile.PostProcessExtra), file.InputFile.Extension.Trim('.'));
                    if (!outputFile.Directory.Exists)
                        outputFile.Directory.Create();
                    File.Move(file.InputFileName, outputFile.FullName);
                    break;
            }

            //Check if the folder that the input was in is now empty. Travel up the roots too
            DirectoryInfo parent = file.InputFile.Directory;
            while(parent != null && parent.Exists && parent.GetFiles().Length == 0 && parent.GetDirectories().Length == 0)
            {
                parent.Delete(false);
                parent = parent.Parent;
            }
        }
    }
}
