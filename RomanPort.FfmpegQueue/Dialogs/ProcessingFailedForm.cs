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
    public partial class ProcessingFailedForm : Form
    {
        public ProcessingFailedForm(QueuedFile file, ProcessStatus status)
        {
            this.file = file;
            this.status = status;
            InitializeComponent();
        }

        private QueuedFile file;
        private ProcessStatus status;
        private int countdown = 20;
        private Timer timer;

        private void ProcessingFailedForm_Load(object sender, EventArgs e)
        {
            //Set text
            UpdateText();

            //Start countdown
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (countdown-- == 0)
                Close();
            else
                UpdateText();
        }

        private void UpdateText()
        {
            mainText.Text = $"The following error was encountered while processing:\n\n{status.DisplayName}: {status.DetailedBody}\n\n{file.InputFileName}\n\nThis dialog will close automatically in {countdown} seconds...";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (checkIgnoreFurther.Checked)
                DialogResult = DialogResult.No;
            else
                DialogResult = DialogResult.Yes;
            Close();
        }

        private void checkIgnoreFurther_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
