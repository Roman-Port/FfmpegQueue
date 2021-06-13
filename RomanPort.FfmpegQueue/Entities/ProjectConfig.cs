using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.FfmpegQueue.Entities
{
    public class ProjectConfig
    {
        [JsonProperty("ffmpeg_params")]
        public string FfmpegParams { get; set; }

        [JsonProperty("input_dir")]
        public string InputDir { get; set; }

        [JsonProperty("output_dir")]
        public string OutputDir { get; set; }

        [JsonProperty("output_ext")]
        public string OutputExtension { get; set; }

        [JsonProperty("worker_count")]
        public int WorkerCount { get; set; } = 1;

        [JsonProperty("post_processed")]
        public ProjectConfigPostProcess PostProcessAction { get; set; } = ProjectConfigPostProcess.NOTHING;

        [JsonProperty("post_processed_extra")]
        public string PostProcessExtra { get; set; }

        [JsonIgnore]
        public string filename;

        public static ProjectConfig LoadFile(string path)
        {
            return JsonConvert.DeserializeObject<ProjectConfig>(File.ReadAllText(path));
        }

        public void SaveFile()
        {
            File.WriteAllText(filename, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
