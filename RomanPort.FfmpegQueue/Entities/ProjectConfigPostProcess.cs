using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.FfmpegQueue.Entities
{
    public enum ProjectConfigPostProcess
    {
        NOTHING = 0,
        RECYCLE = 1,
        DELETE = 2,
        MOVE = 3,
    }
}
