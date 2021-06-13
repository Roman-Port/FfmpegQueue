using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.FfmpegQueue.Entities.Statuses
{
    public class ProcessStatusDurationQueryFailed : ProcessStatus
    {
        public bool IsSuccessful => false;

        public string DisplayName => "DURATION QUERY FAILED";

        public string DetailedBody => "FFPROBE failed to return the duration of the file. Either FFPROBE isn't installed or the file is incompatible or corrupt.";
    }
}
