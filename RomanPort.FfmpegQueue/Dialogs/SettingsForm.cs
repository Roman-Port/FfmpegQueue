using Newtonsoft.Json;
using RomanPort.FfmpegQueue.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.FfmpegQueue.Dialogs
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            config = new ProjectConfig();
        }

        private ProjectConfig config;
        private bool loading;

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Set
            config.FfmpegParams = ffmpegArgs.Text;
            config.OutputExtension = ffmpegExt.Text;
            config.InputDir = ffmpegInputDir.Text.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
            config.OutputDir = ffmpegOutputDir.Text.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
            config.WorkerCount = (int)ffmpegWorkerCount.Value;
            config.PostProcessAction = (ProjectConfigPostProcess)ffmpegPostProcess.SelectedIndex;

            //Save
            if (config.filename == null)
            {
                SaveFileDialog fd = new SaveFileDialog();
                fd.Filter = "Project Files (*.ffq)|*.ffq";
                fd.Title = "Save Project";
                if (fd.ShowDialog() != DialogResult.OK)
                    return;
                else
                    config.filename = fd.FileName;
            }

            //Save
            File.WriteAllText(config.filename, JsonConvert.SerializeObject(config, Formatting.Indented));

            //Go
            ProcessingForm w = new ProcessingForm(config);
            Hide();
            w.ShowDialog();
            Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Project Files (*.ffq)|*.ffq";
            fd.Title = "Load Project";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                loading = true;
                config = ProjectConfig.LoadFile(fd.FileName);
                config.filename = fd.FileName;
                btnSave.Text = "Continue";
                ffmpegArgs.Text = config.FfmpegParams;
                ffmpegExt.Text = config.OutputExtension;
                ffmpegInputDir.Text = config.InputDir;
                ffmpegOutputDir.Text = config.OutputDir;
                ffmpegWorkerCount.Value = config.WorkerCount;
                ffmpegPostProcess.SelectedIndex = (int)config.PostProcessAction;
                RevalidateSettings();
                loading = false;
            }
        }

        private void ProjectLoadForm_Load(object sender, EventArgs e)
        {
            ffmpegPostProcess.SelectedIndex = 0;
            RevalidateSettings();
        }

        private void SettingChanged(object sender, EventArgs e)
        {
            RevalidateSettings();
        }

        private void RevalidateSettings()
        {
            bool ok = ffmpegArgs.Text.Contains("%i") &&
                ffmpegArgs.Text.Contains("%o") &&
                ffmpegExt.Text.Length > 0 &&
                ffmpegInputDir.Text.Length > 0 &&
                Directory.Exists(ffmpegInputDir.Text) &&
                ffmpegOutputDir.Text.Length > 0 &&
                Directory.Exists(ffmpegOutputDir.Text);
            btnSave.Enabled = ok;
        }

        private void OpenDirBrowser(TextBox attached)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                attached.Text = dialog.SelectedPath + Path.DirectorySeparatorChar;
            RevalidateSettings();
        }

        private void inputDirPicker_Click(object sender, EventArgs e)
        {
            OpenDirBrowser(ffmpegInputDir);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenDirBrowser(ffmpegOutputDir);
        }

        private void ffmpegPostProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch((ProjectConfigPostProcess)ffmpegPostProcess.SelectedIndex)
            {
                case ProjectConfigPostProcess.NOTHING:
                    config.PostProcessAction = ProjectConfigPostProcess.NOTHING;
                    break;
                case ProjectConfigPostProcess.RECYCLE:
                    config.PostProcessAction = ProjectConfigPostProcess.RECYCLE;
                    break;
                case ProjectConfigPostProcess.DELETE:
                    config.PostProcessAction = ProjectConfigPostProcess.DELETE;
                    break;
                case ProjectConfigPostProcess.MOVE:
                    if(!loading)
                    {
                        FolderBrowserDialog dialog = new FolderBrowserDialog();
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            config.PostProcessAction = ProjectConfigPostProcess.MOVE;
                            config.PostProcessExtra = dialog.SelectedPath.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
                        }
                        else
                        {
                            config.PostProcessAction = ProjectConfigPostProcess.NOTHING;
                            ffmpegPostProcess.SelectedIndex = 0;
                            MessageBox.Show("An output is required.");
                        }
                    }
                    break;
            }
        }
    }
}
