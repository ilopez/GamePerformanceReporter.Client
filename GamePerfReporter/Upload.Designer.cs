namespace GamePerfReporter
{
    partial class Upload
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
            this.pbUpload = new System.Windows.Forms.ProgressBar();
            this.pbPrep = new System.Windows.Forms.ProgressBar();
            this.bCancel = new System.Windows.Forms.Button();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.tbUploadLog = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbUpload);
            this.groupBox1.Controls.Add(this.pbPrep);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(13, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 84);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // pbUpload
            // 
            this.pbUpload.Location = new System.Drawing.Point(7, 50);
            this.pbUpload.Name = "pbUpload";
            this.pbUpload.Size = new System.Drawing.Size(246, 23);
            this.pbUpload.TabIndex = 1;
            // 
            // pbPrep
            // 
            this.pbPrep.Location = new System.Drawing.Point(7, 20);
            this.pbPrep.Name = "pbPrep";
            this.pbPrep.Size = new System.Drawing.Size(246, 23);
            this.pbPrep.TabIndex = 0;
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(103, 262);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 2;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker1_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker1_ProgressChanged);
            // 
            // tbUploadLog
            // 
            this.tbUploadLog.BackColor = System.Drawing.Color.Black;
            this.tbUploadLog.ForeColor = System.Drawing.Color.White;
            this.tbUploadLog.Location = new System.Drawing.Point(13, 13);
            this.tbUploadLog.Multiline = true;
            this.tbUploadLog.Name = "tbUploadLog";
            this.tbUploadLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbUploadLog.Size = new System.Drawing.Size(259, 153);
            this.tbUploadLog.TabIndex = 3;
            // 
            // Upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 299);
            this.Controls.Add(this.tbUploadLog);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.groupBox1);
            this.Name = "Upload";
            this.Text = "Upload";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar pbUpload;
        private System.Windows.Forms.ProgressBar pbPrep;
        private System.Windows.Forms.Button bCancel;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.TextBox tbUploadLog;
    }
}