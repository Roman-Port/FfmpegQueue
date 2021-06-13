
namespace RomanPort.FfmpegQueue
{
    partial class FfmpegWorker
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusProgress = new System.Windows.Forms.Label();
            this.statusFilename = new System.Windows.Forms.Label();
            this.statusProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // statusProgress
            // 
            this.statusProgress.AutoSize = true;
            this.statusProgress.Dock = System.Windows.Forms.DockStyle.Right;
            this.statusProgress.Location = new System.Drawing.Point(428, 0);
            this.statusProgress.Name = "statusProgress";
            this.statusProgress.Size = new System.Drawing.Size(24, 13);
            this.statusProgress.TabIndex = 1;
            this.statusProgress.Text = "test";
            this.statusProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusFilename
            // 
            this.statusFilename.AutoSize = true;
            this.statusFilename.Dock = System.Windows.Forms.DockStyle.Left;
            this.statusFilename.Location = new System.Drawing.Point(0, 0);
            this.statusFilename.Name = "statusFilename";
            this.statusFilename.Size = new System.Drawing.Size(24, 13);
            this.statusFilename.TabIndex = 2;
            this.statusFilename.Text = "test";
            this.statusFilename.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusProgressBar.Location = new System.Drawing.Point(0, 16);
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.Size = new System.Drawing.Size(452, 23);
            this.statusProgressBar.TabIndex = 3;
            // 
            // FfmpegWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusProgressBar);
            this.Controls.Add(this.statusFilename);
            this.Controls.Add(this.statusProgress);
            this.Name = "FfmpegWorker";
            this.Size = new System.Drawing.Size(452, 45);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusProgress;
        private System.Windows.Forms.Label statusFilename;
        private System.Windows.Forms.ProgressBar statusProgressBar;
    }
}
