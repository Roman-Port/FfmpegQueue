using RomanPort.FfmpegQueue.Dialogs;
using RomanPort.FfmpegQueue.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.FfmpegQueue.Dialogs
{
    public partial class ProcessingForm : Form
    {
        public ProcessingForm(ProjectConfig file)
        {
            InitializeComponent();
            ProjectFile = file;
        }

        public ProjectConfig ProjectFile { get; private set; }
        public long TotalBytesProcessed { get; set; }
        public long TotalBytesQueued { get; set; }

        private FfmpegWorker[] workers;
        private CancellationTokenSource token;
        private ConcurrentQueue<QueuedFile> queuedFiles = new ConcurrentQueue<QueuedFile>();
        private List<QueuedFile> files = new List<QueuedFile>();
        private long totalBytesQueued;
        private int filesRemaining;
        private int filesSuccessful;
        private int filesFailed;
        private bool finished;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Create cancellation token
            token = new CancellationTokenSource();

            //Seek for input files
            SeekContent(new DirectoryInfo(ProjectFile.InputDir));

            //If no files were found, exit now
            if(files.Count == 0)
            {
                MessageBox.Show("No files were found to process. Check your settings.", "No Files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                finished = true;
                Close();
                return;
            }

            //Spawn workers and place them in the view
            workers = new FfmpegWorker[ProjectFile.WorkerCount];
            workerPanel.ColumnCount = 1;
            workerPanel.RowCount = ProjectFile.WorkerCount;
            for (int i = 0; i < ProjectFile.WorkerCount; i++)
            {
                workers[i] = new FfmpegWorker(this);
                workerPanel.Controls.Add(workers[i], 0, i);
                workers[i].Dock = DockStyle.Top;
            }

            //Set status
            totalProgress.Maximum = filesRemaining;
            UpdateProgress();

            //Start all the workers and wait for them to finish
            Run();
        }

        private void SeekContent(DirectoryInfo dir)
        {
            //Fetch directories and seek all of them recursively
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (var d in dirs)
                SeekContent(d);

            //Fetch files and seek them
            FileInfo[] files = dir.GetFiles();
            foreach (var f in files)
            {
                //Create the queued file (although it might not actually be added!)
                var file = new QueuedFile(f, ProjectFile);

                //Check if the output file already exists. If it does, skip
                if (file.OutputFile.Exists)
                    continue;

                //Queue
                queuedFiles.Enqueue(file);
                this.files.Add(file);
                totalBytesQueued += f.Length;
                filesRemaining++;
            }
        }

        private async Task Run()
        {
            //Start all
            List<Task> tasks = new List<Task>();
            foreach (var worker in workers)
                tasks.Add(worker.RunWorker(token.Token));

            //Wait for all
            await Task.WhenAll(tasks);

            //Show summary dialog
            new SummaryForm(files).ShowDialog();

            //Exit
            finished = true;
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!finished)
            {
                //Request cancel
                token.Cancel();

                //Do not allow form to close
                e.Cancel = true;
            }
        }

        public bool TryGetNextFile(out QueuedFile file)
        {
            return queuedFiles.TryDequeue(out file);
        }

        public void ReportFileFinishedStatus(QueuedFile file, ProcessStatus status)
        {
            //Update state
            filesRemaining--;
            if (status.IsSuccessful)
                filesSuccessful++;
            else
                filesFailed++;
            file.SetStatus(status);

            //Update progress text
            UpdateProgress();
        }

        private void UpdateProgress()
        {
            projectStatus.Text = $"{filesRemaining} remaining, {filesSuccessful} successful, {filesFailed} failed";
            totalProgress.Value = files.Count - filesRemaining;
        }
    }
}
