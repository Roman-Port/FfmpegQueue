using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.FfmpegQueue.Entities.Statuses
{
    public class ProcessStatusUnexpectedExit : ProcessStatus
    {
        public bool IsSuccessful => false;

        public string DisplayName => "UNEXPECTED EXIT";

        public string DetailedBody => "FFMPEG exited incorrectly.";
    }
}
