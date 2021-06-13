using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.FfmpegQueue.Entities.Statuses
{
    public class ProcessStatusBadExitCode : ProcessStatus
    {
        public ProcessStatusBadExitCode(int code)
        {
            this.code = code;
        }

        private int code;

        public bool IsSuccessful => false;

        public string DisplayName => $"EXIT CODE BAD ({code})";

        public string DetailedBody => $"FFMPEG exited with status code {code}.";
    }
}
