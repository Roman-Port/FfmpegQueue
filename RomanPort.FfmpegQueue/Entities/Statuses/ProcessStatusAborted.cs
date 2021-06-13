using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.FfmpegQueue.Entities.Statuses
{
    public class ProcessStatusAborted : ProcessStatus
    {
        public bool IsSuccessful => false;

        public string DisplayName => "ABORTED";

        public string DetailedBody => "The processing was aborted by the user.";

        public static ProcessStatusAborted ABORTED = new ProcessStatusAborted();
    }
}
