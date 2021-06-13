using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.FfmpegQueue
{
    public static class FfmpegUtil
    {
        public static Process CreateFfmpegProcess(string exec, string arguments)
        {
            return Process.Start(new ProcessStartInfo
            {
                FileName = exec,
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            });
        }
        
        public static string EscapePathname(string s)
        {
            return "\"" + s.Replace("\"", "\\\"") + "\"";
        }

        public static string FormatTime(TimeSpan time)
        {
            return $"{((time.Days * 24) + time.Hours).ToString().PadLeft(2, '0')}:{time.Minutes.ToString().PadLeft(2, '0')}:{time.Seconds.ToString().PadLeft(2, '0')}";
        }

        public static FileInfo RemapDirectory(FileInfo input, string namePrefix, DirectoryInfo inputDir, DirectoryInfo outputDir, string outputExtension)
        {
            return new FileInfo(input.Directory.FullName.Replace(inputDir.FullName, outputDir.FullName) + Path.DirectorySeparatorChar + namePrefix + input.Name.Substring(0, input.Name.Length - input.Extension.Length) + "." + outputExtension);
        }

        public static async Task<TimeSpan> QueryMediaDuration(string filename)
        {
            //Start ffprobe
            string args = $"-loglevel quiet -show_entries format=duration {EscapePathname(filename)}";
            var probe = CreateFfmpegProcess("ffprobe", args);

            //Begin monitoring events
            bool inFormat = false;
            while (true)
            {
                //Read line
                string line = await probe.StandardOutput.ReadLineAsync();
                if (line == null)
                    break;

                //Check
                if (line == "[FORMAT]")
                    inFormat = true;
                else if (line == "[/FORMAT]")
                    inFormat = false;
                else if (line.StartsWith("duration=") && inFormat && double.TryParse(line.Substring("duration=".Length), out double duration))
                    return TimeSpan.FromSeconds(duration);
            }

            return TimeSpan.Zero;
        }
    }
}
