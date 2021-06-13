using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.FfmpegQueue.Entities
{
    public interface ProcessStatus
    {
        bool IsSuccessful { get; }
        string DisplayName { get; }
        string DetailedBody { get; }
    }
}
