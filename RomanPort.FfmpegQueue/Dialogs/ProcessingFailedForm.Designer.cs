
namespace RomanPort.FfmpegQueue.Dialogs
{
    partial class ProcessingFailedForm
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
            this.mainText = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.checkIgnoreFurther = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mainText
            // 
            this.mainText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainText.Location = new System.Drawing.Point(12, 9);
            this.mainText.Name = "mainText";
            this.mainText.Size = new System.Drawing.Size(531, 134);
            this.mainText.TabIndex = 0;
            this.mainText.Text = "label1";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(468, 146);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // checkIgnoreFurther
            // 
            this.checkIgnoreFurther.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkIgnoreFurther.Location = new System.Drawing.Point(340, 146);
            this.checkIgnoreFurther.Name = "checkIgnoreFurther";
            this.checkIgnoreFurther.Size = new System.Drawing.Size(122, 23);
            this.checkIgnoreFurther.TabIndex = 2;
            this.checkIgnoreFurther.Text = "Ignore Further Errors";
            this.checkIgnoreFurther.UseVisualStyleBackColor = true;
            this.checkIgnoreFurther.CheckedChanged += new System.EventHandler(this.checkIgnoreFurther_CheckedChanged);
            // 
            // ProcessingFailedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 181);
            this.Controls.Add(this.checkIgnoreFurther);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.mainText);
            this.Name = "ProcessingFailedForm";
            this.Text = "ProcessingFailedForm";
            this.Load += new System.EventHandler(this.ProcessingFailedForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label mainText;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox checkIgnoreFurther;
    }
}