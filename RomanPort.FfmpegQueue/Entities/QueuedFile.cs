using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.FfmpegQueue.Entities
{
    public class QueuedFile
    {
        public QueuedFile(FileInfo input, ProjectConfig config)
        {
            //Configure
            this.config = config;
            this.input = input;

            //Create paths
            output = GetOutputPath("");
            temp = GetOutputPath("FFWIP_");
        }

        private ProjectConfig config;
        private FileInfo input;
        private FileInfo temp;
        private FileInfo output;

        private ProcessStatus status = Statuses.ProcessStatusAborted.ABORTED;

        public string InputFileName { get => input.FullName; }
        public string TempFileName { get => temp.FullName; }
        public string OutputFileName { get => output.FullName; }

        public FileInfo InputFile { get => input; }
        public FileInfo TempFile { get => temp; }
        public FileInfo OutputFile { get => output; }

        public string DisplayPath { get => InputFileName.Substring(config.InputDir.TrimEnd('/').TrimStart('\\').Length); }
        public ProcessStatus Status { get => status; }

        public Task<TimeSpan> QueryFileDuration()
        {
            return FfmpegUtil.QueryMediaDuration(InputFileName);
        }

        public void SetStatus(ProcessStatus status)
        {
            this.status = status;
        }

        private FileInfo GetOutputPath(string namePrefix)
        {
            return new FileInfo(input.Directory.FullName.Replace(config.InputDir, config.OutputDir) + Path.DirectorySeparatorChar + namePrefix + input.Name.Substring(0, input.Name.Length - input.Extension.Length) + "." + config.OutputExtension);
        }
    }
}
