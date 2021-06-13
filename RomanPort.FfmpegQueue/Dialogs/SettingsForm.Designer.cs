
namespace RomanPort.FfmpegQueue.Dialogs
{
    partial class SettingsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ffmpegPostProcess = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ffmpegWorkerCount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.inputDirPicker = new System.Windows.Forms.Button();
            this.ffmpegOutputDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ffmpegInputDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ffmpegExt = new System.Windows.Forms.TextBox();
            this.ffmpegArgs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ffmpegWorkerCount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ffmpegPostProcess);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ffmpegWorkerCount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.inputDirPicker);
            this.groupBox1.Controls.Add(this.ffmpegOutputDir);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ffmpegInputDir);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ffmpegExt);
            this.groupBox1.Controls.Add(this.ffmpegArgs);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 222);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // ffmpegPostProcess
            // 
            this.ffmpegPostProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ffmpegPostProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ffmpegPostProcess.FormattingEnabled = true;
            this.ffmpegPostProcess.Items.AddRange(new object[] {
            "Do Nothing",
            "Recycle Original",
            "Delete Original",
            "Move Original To..."});
            this.ffmpegPostProcess.Location = new System.Drawing.Point(9, 188);
            this.ffmpegPostProcess.Name = "ffmpegPostProcess";
            this.ffmpegPostProcess.Size = new System.Drawing.Size(434, 21);
            this.ffmpegPostProcess.TabIndex = 13;
            this.ffmpegPostProcess.SelectedIndexChanged += new System.EventHandler(this.ffmpegPostProcess_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Worker Count";
            // 
            // ffmpegWorkerCount
            // 
            this.ffmpegWorkerCount.Location = new System.Drawing.Point(9, 149);
            this.ffmpegWorkerCount.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.ffmpegWorkerCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ffmpegWorkerCount.Name = "ffmpegWorkerCount";
            this.ffmpegWorkerCount.Size = new System.Drawing.Size(434, 20);
            this.ffmpegWorkerCount.TabIndex = 10;
            this.ffmpegWorkerCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ffmpegWorkerCount.ValueChanged += new System.EventHandler(this.SettingChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Worker Count";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(449, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Browse...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inputDirPicker
            // 
            this.inputDirPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inputDirPicker.Location = new System.Drawing.Point(449, 70);
            this.inputDirPicker.Name = "inputDirPicker";
            this.inputDirPicker.Size = new System.Drawing.Size(75, 23);
            this.inputDirPicker.TabIndex = 7;
            this.inputDirPicker.Text = "Browse...";
            this.inputDirPicker.UseVisualStyleBackColor = true;
            this.inputDirPicker.Click += new System.EventHandler(this.inputDirPicker_Click);
            // 
            // ffmpegOutputDir
            // 
            this.ffmpegOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ffmpegOutputDir.Location = new System.Drawing.Point(9, 110);
            this.ffmpegOutputDir.Name = "ffmpegOutputDir";
            this.ffmpegOutputDir.Size = new System.Drawing.Size(434, 20);
            this.ffmpegOutputDir.TabIndex = 6;
            this.ffmpegOutputDir.TextChanged += new System.EventHandler(this.SettingChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output Directory";
            // 
            // ffmpegInputDir
            // 
            this.ffmpegInputDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ffmpegInputDir.Location = new System.Drawing.Point(9, 71);
            this.ffmpegInputDir.Name = "ffmpegInputDir";
            this.ffmpegInputDir.Size = new System.Drawing.Size(434, 20);
            this.ffmpegInputDir.TabIndex = 4;
            this.ffmpegInputDir.TextChanged += new System.EventHandler(this.SettingChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Input Directory";
            // 
            // ffmpegExt
            // 
            this.ffmpegExt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ffmpegExt.Location = new System.Drawing.Point(449, 32);
            this.ffmpegExt.Name = "ffmpegExt";
            this.ffmpegExt.Size = new System.Drawing.Size(75, 20);
            this.ffmpegExt.TabIndex = 2;
            this.ffmpegExt.Text = "mp4";
            this.ffmpegExt.TextChanged += new System.EventHandler(this.SettingChanged);
            // 
            // ffmpegArgs
            // 
            this.ffmpegArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ffmpegArgs.Location = new System.Drawing.Point(9, 32);
            this.ffmpegArgs.Name = "ffmpegArgs";
            this.ffmpegArgs.Size = new System.Drawing.Size(434, 20);
            this.ffmpegArgs.TabIndex = 1;
            this.ffmpegArgs.TextChanged += new System.EventHandler(this.SettingChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FFMPEG Arguments (use %i for input, %o for output)";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(421, 245);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(343, 245);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(72, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 280);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsForm";
            this.Text = "ProjectLoadForm";
            this.Load += new System.EventHandler(this.ProjectLoadForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ffmpegWorkerCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ffmpegExt;
        private System.Windows.Forms.TextBox ffmpegArgs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ffmpegOutputDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ffmpegInputDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button inputDirPicker;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.NumericUpDown ffmpegWorkerCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ffmpegPostProcess;
        private System.Windows.Forms.Label label5;
    }
}