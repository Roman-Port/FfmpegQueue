using RomanPort.FfmpegQueue.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.FfmpegQueue.Dialogs
{
    public partial class SummaryForm : Form
    {
        public SummaryForm(List<QueuedFile> files)
        {
            this.files = files;
            InitializeComponent();
        }

        private List<QueuedFile> files;

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            //Sort files by their path
            files.Sort((QueuedFile a, QueuedFile b) => a.DisplayPath.CompareTo(b.DisplayPath));

            //Determine counts
            int successfulCount = 0;
            int unsuccessfulCount = 0;
            foreach(var f in files)
            {
                if (f.Status.IsSuccessful)
                    successfulCount++;
                else
                    unsuccessfulCount++;
            }

            //Build text
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Processed {successfulCount} files successfully, {unsuccessfulCount} failed.");
            sb.AppendLine();
            if(unsuccessfulCount > 0)
            {
                sb.AppendLine("THE FOLLOWING FILES FAILED:");
                foreach(var f in files)
                {
                    if (!f.Status.IsSuccessful)
                        sb.AppendLine($"{f.DisplayPath} - {f.Status.ToString()}");
                }
                sb.AppendLine();
            }
            if (unsuccessfulCount > 0)
            {
                sb.AppendLine("THE FOLLOWING FILES PROCESSED SUCCESSFULLY:");
                foreach (var f in files)
                {
                    if (f.Status.IsSuccessful)
                        sb.AppendLine($"{f.DisplayPath}");
                }
            }

            //Apply
            summaryText.Text = sb.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
