using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.FfmpegQueue.Entities.Statuses
{
    public class ProcessStatusSuccess : ProcessStatus
    {
        public bool IsSuccessful => true;

        public string DisplayName => "OK";

        public string DetailedBody => "";

        public static ProcessStatusSuccess SUCCESS = new ProcessStatusSuccess();
    }
}
