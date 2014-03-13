namespace GamePerfReporter
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.GroupBoxGame = new System.Windows.Forms.GroupBox();
            this.findGameLabel = new System.Windows.Forms.Label();
            this.ckIncludeGameFiles = new System.Windows.Forms.CheckBox();
            this.cbGameList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckIncludeDxDiag = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckIncludeRTSS = new System.Windows.Forms.CheckBox();
            this.bRTSS = new System.Windows.Forms.Button();
            this.tbRTSSPath = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tBSuspectedIssueHotKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ckAnonSystemID = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSystemID = new System.Windows.Forms.TextBox();
            this.bSubmit = new System.Windows.Forms.Button();
            this.bWFindGame = new System.ComponentModel.BackgroundWorker();
            this.bwFindRTSSConfig = new System.ComponentModel.BackgroundWorker();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.systemCheck = new System.Windows.Forms.Label();
            this.bwCheckAPI = new System.ComponentModel.BackgroundWorker();
            this.labelFPS = new System.Windows.Forms.Label();
            this.chartFPS = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bwGetLiveFPSData = new System.ComponentModel.BackgroundWorker();
            this.gbLiveFPS = new System.Windows.Forms.GroupBox();
            this.ckUpdateScreen = new System.Windows.Forms.CheckBox();
            this.labelLogStatus = new System.Windows.Forms.Label();
            this.ckLiveFPS = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bwUpdateGraph = new System.ComponentModel.BackgroundWorker();
            this.bwFindMSIAfterburner = new System.ComponentModel.BackgroundWorker();
            this.GroupBoxGame.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFPS)).BeginInit();
            this.gbLiveFPS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBoxGame
            // 
            this.GroupBoxGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxGame.Controls.Add(this.findGameLabel);
            this.GroupBoxGame.Controls.Add(this.ckIncludeGameFiles);
            this.GroupBoxGame.Controls.Add(this.cbGameList);
            this.GroupBoxGame.ForeColor = System.Drawing.Color.White;
            this.GroupBoxGame.Location = new System.Drawing.Point(12, 166);
            this.GroupBoxGame.Name = "GroupBoxGame";
            this.GroupBoxGame.Size = new System.Drawing.Size(260, 72);
            this.GroupBoxGame.TabIndex = 0;
            this.GroupBoxGame.TabStop = false;
            this.GroupBoxGame.Text = "Game";
            // 
            // findGameLabel
            // 
            this.findGameLabel.AutoSize = true;
            this.findGameLabel.Location = new System.Drawing.Point(162, 49);
            this.findGameLabel.Name = "findGameLabel";
            this.findGameLabel.Size = new System.Drawing.Size(91, 13);
            this.findGameLabel.TabIndex = 2;
            this.findGameLabel.Text = "Looking for Game";
            // 
            // ckIncludeGameFiles
            // 
            this.ckIncludeGameFiles.AutoSize = true;
            this.ckIncludeGameFiles.Location = new System.Drawing.Point(7, 48);
            this.ckIncludeGameFiles.Name = "ckIncludeGameFiles";
            this.ckIncludeGameFiles.Size = new System.Drawing.Size(116, 17);
            this.ckIncludeGameFiles.TabIndex = 1;
            this.ckIncludeGameFiles.Text = "Include Game Files";
            this.ckIncludeGameFiles.UseVisualStyleBackColor = true;
            // 
            // cbGameList
            // 
            this.cbGameList.BackColor = System.Drawing.SystemColors.Window;
            this.cbGameList.FormattingEnabled = true;
            this.cbGameList.Location = new System.Drawing.Point(7, 20);
            this.cbGameList.Name = "cbGameList";
            this.cbGameList.Size = new System.Drawing.Size(247, 21);
            this.cbGameList.TabIndex = 0;
            this.cbGameList.SelectedValueChanged += new System.EventHandler(this.cbGameList_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ckIncludeDxDiag);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 42);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dx Diag";
            // 
            // ckIncludeDxDiag
            // 
            this.ckIncludeDxDiag.AutoSize = true;
            this.ckIncludeDxDiag.Location = new System.Drawing.Point(7, 19);
            this.ckIncludeDxDiag.Name = "ckIncludeDxDiag";
            this.ckIncludeDxDiag.Size = new System.Drawing.Size(130, 17);
            this.ckIncludeDxDiag.TabIndex = 0;
            this.ckIncludeDxDiag.Text = "Include DX Diag Data";
            this.ckIncludeDxDiag.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ckIncludeRTSS);
            this.groupBox2.Controls.Add(this.bRTSS);
            this.groupBox2.Controls.Add(this.tbRTSSPath);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 290);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 68);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MSI Afterburner / EVGA Precision X / RTSS";
            // 
            // ckIncludeRTSS
            // 
            this.ckIncludeRTSS.AutoSize = true;
            this.ckIncludeRTSS.Location = new System.Drawing.Point(6, 42);
            this.ckIncludeRTSS.Name = "ckIncludeRTSS";
            this.ckIncludeRTSS.Size = new System.Drawing.Size(110, 17);
            this.ckIncludeRTSS.TabIndex = 2;
            this.ckIncludeRTSS.Text = "Include FPS Data";
            this.ckIncludeRTSS.UseVisualStyleBackColor = true;
            // 
            // bRTSS
            // 
            this.bRTSS.ForeColor = System.Drawing.Color.Black;
            this.bRTSS.Location = new System.Drawing.Point(178, 38);
            this.bRTSS.Name = "bRTSS";
            this.bRTSS.Size = new System.Drawing.Size(75, 23);
            this.bRTSS.TabIndex = 1;
            this.bRTSS.Text = "Browse";
            this.bRTSS.UseVisualStyleBackColor = true;
            this.bRTSS.Click += new System.EventHandler(this.bRTSS_Click);
            // 
            // tbRTSSPath
            // 
            this.tbRTSSPath.BackColor = System.Drawing.Color.Gray;
            this.tbRTSSPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbRTSSPath.ForeColor = System.Drawing.Color.White;
            this.tbRTSSPath.Location = new System.Drawing.Point(6, 19);
            this.tbRTSSPath.Name = "tbRTSSPath";
            this.tbRTSSPath.Size = new System.Drawing.Size(247, 13);
            this.tbRTSSPath.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tBSuspectedIssueHotKey);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tbNotes);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 449);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 160);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Player Notes";
            // 
            // tBSuspectedIssueHotKey
            // 
            this.tBSuspectedIssueHotKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tBSuspectedIssueHotKey.BackColor = System.Drawing.SystemColors.GrayText;
            this.tBSuspectedIssueHotKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBSuspectedIssueHotKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBSuspectedIssueHotKey.ForeColor = System.Drawing.Color.White;
            this.tBSuspectedIssueHotKey.Location = new System.Drawing.Point(138, 139);
            this.tBSuspectedIssueHotKey.Name = "tBSuspectedIssueHotKey";
            this.tBSuspectedIssueHotKey.Size = new System.Drawing.Size(116, 15);
            this.tBSuspectedIssueHotKey.TabIndex = 2;
            this.tBSuspectedIssueHotKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBSuspectedIssueHotKey.Enter += new System.EventHandler(this.tBSuspectedIssueHotKey_Enter);
            this.tBSuspectedIssueHotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBSuspectedIssueHotKey_KeyDown);
            this.tBSuspectedIssueHotKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBSuspectedIssueHotKey_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Suspected Issue Hotkey";
            // 
            // tbNotes
            // 
            this.tbNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNotes.BackColor = System.Drawing.SystemColors.GrayText;
            this.tbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNotes.ForeColor = System.Drawing.Color.White;
            this.tbNotes.Location = new System.Drawing.Point(7, 20);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNotes.Size = new System.Drawing.Size(247, 113);
            this.tbNotes.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.linkLabel1.Location = new System.Drawing.Point(228, 704);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(44, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "License";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.linkLabel2.Location = new System.Drawing.Point(9, 704);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(35, 13);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "About";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.linkLabel3.Location = new System.Drawing.Point(116, 704);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(46, 13);
            this.linkLabel3.TabIndex = 6;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Website";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.ckAnonSystemID);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.tbSystemID);
            this.groupBox4.Controls.Add(this.bSubmit);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(12, 612);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(260, 92);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Submit";
            // 
            // ckAnonSystemID
            // 
            this.ckAnonSystemID.AutoSize = true;
            this.ckAnonSystemID.Location = new System.Drawing.Point(172, 15);
            this.ckAnonSystemID.Name = "ckAnonSystemID";
            this.ckAnonSystemID.Size = new System.Drawing.Size(81, 17);
            this.ckAnonSystemID.TabIndex = 3;
            this.ckAnonSystemID.Text = "Anonymous";
            this.ckAnonSystemID.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "System ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbSystemID
            // 
            this.tbSystemID.BackColor = System.Drawing.Color.Gray;
            this.tbSystemID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSystemID.ForeColor = System.Drawing.Color.White;
            this.tbSystemID.Location = new System.Drawing.Point(6, 38);
            this.tbSystemID.Name = "tbSystemID";
            this.tbSystemID.ReadOnly = true;
            this.tbSystemID.Size = new System.Drawing.Size(247, 13);
            this.tbSystemID.TabIndex = 1;
            this.tbSystemID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bSubmit
            // 
            this.bSubmit.ForeColor = System.Drawing.Color.Black;
            this.bSubmit.Location = new System.Drawing.Point(93, 57);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(75, 23);
            this.bSubmit.TabIndex = 0;
            this.bSubmit.Text = "Submit";
            this.bSubmit.UseVisualStyleBackColor = true;
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click);
            // 
            // bWFindGame
            // 
            this.bWFindGame.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWFindGame_DoWork);
            this.bWFindGame.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bWFindGame_RunWorkerCompleted);
            // 
            // bwFindRTSSConfig
            // 
            this.bwFindRTSSConfig.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwFindRTSSConfig_DoWork);
            this.bwFindRTSSConfig.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwFindRTSSConfig_RunWorkerCompleted);
            // 
            // systemCheck
            // 
            this.systemCheck.AutoSize = true;
            this.systemCheck.ForeColor = System.Drawing.Color.White;
            this.systemCheck.Location = new System.Drawing.Point(12, 13);
            this.systemCheck.Name = "systemCheck";
            this.systemCheck.Size = new System.Drawing.Size(169, 13);
            this.systemCheck.TabIndex = 9;
            this.systemCheck.Text = "Checking Web Service Availability";
            // 
            // bwCheckAPI
            // 
            this.bwCheckAPI.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCheckAPI_DoWork);
            this.bwCheckAPI.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCheckAPI_RunWorkerCompleted);
            // 
            // labelFPS
            // 
            this.labelFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFPS.AutoSize = true;
            this.labelFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFPS.Location = new System.Drawing.Point(142, 16);
            this.labelFPS.Name = "labelFPS";
            this.labelFPS.Size = new System.Drawing.Size(112, 42);
            this.labelFPS.TabIndex = 3;
            this.labelFPS.Text = "00.00";
            // 
            // chartFPS
            // 
            this.chartFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartFPS.BackColor = System.Drawing.Color.Black;
            this.chartFPS.Location = new System.Drawing.Point(12, 36);
            this.chartFPS.Name = "chartFPS";
            this.chartFPS.Size = new System.Drawing.Size(260, 322);
            this.chartFPS.TabIndex = 4;
            this.chartFPS.Text = "chart1";
            this.chartFPS.Visible = false;
            // 
            // bwGetLiveFPSData
            // 
            this.bwGetLiveFPSData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGetLiveFPSData_DoWork);
            // 
            // gbLiveFPS
            // 
            this.gbLiveFPS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLiveFPS.Controls.Add(this.ckUpdateScreen);
            this.gbLiveFPS.Controls.Add(this.labelLogStatus);
            this.gbLiveFPS.Controls.Add(this.ckLiveFPS);
            this.gbLiveFPS.Controls.Add(this.labelFPS);
            this.gbLiveFPS.ForeColor = System.Drawing.Color.White;
            this.gbLiveFPS.Location = new System.Drawing.Point(12, 364);
            this.gbLiveFPS.Name = "gbLiveFPS";
            this.gbLiveFPS.Size = new System.Drawing.Size(260, 79);
            this.gbLiveFPS.TabIndex = 10;
            this.gbLiveFPS.TabStop = false;
            this.gbLiveFPS.Text = "Live FPS Data";
            // 
            // ckUpdateScreen
            // 
            this.ckUpdateScreen.AutoSize = true;
            this.ckUpdateScreen.Location = new System.Drawing.Point(6, 39);
            this.ckUpdateScreen.Name = "ckUpdateScreen";
            this.ckUpdateScreen.Size = new System.Drawing.Size(98, 17);
            this.ckUpdateScreen.TabIndex = 6;
            this.ckUpdateScreen.Text = "Update Screen";
            this.ckUpdateScreen.UseVisualStyleBackColor = true;
            this.ckUpdateScreen.CheckedChanged += new System.EventHandler(this.ckUpdateScreen_CheckedChanged);
            // 
            // labelLogStatus
            // 
            this.labelLogStatus.AutoSize = true;
            this.labelLogStatus.Location = new System.Drawing.Point(6, 59);
            this.labelLogStatus.Name = "labelLogStatus";
            this.labelLogStatus.Size = new System.Drawing.Size(62, 13);
            this.labelLogStatus.TabIndex = 5;
            this.labelLogStatus.Text = "Log: Ready";
            // 
            // ckLiveFPS
            // 
            this.ckLiveFPS.AutoSize = true;
            this.ckLiveFPS.Location = new System.Drawing.Point(6, 19);
            this.ckLiveFPS.Name = "ckLiveFPS";
            this.ckLiveFPS.Size = new System.Drawing.Size(133, 17);
            this.ckLiveFPS.TabIndex = 4;
            this.ckLiveFPS.Text = "Include Live FPS Data";
            this.ckLiveFPS.UseVisualStyleBackColor = true;
            this.ckLiveFPS.CheckedChanged += new System.EventHandler(this.ckLiveFPS_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GamePerfReporter.Properties.Resources.Banner;
            this.pictureBox1.Location = new System.Drawing.Point(13, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(259, 124);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // bwUpdateGraph
            // 
            this.bwUpdateGraph.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwUpdateGraph_DoWork);
            // 
            // bwFindMSIAfterburner
            // 
            this.bwFindMSIAfterburner.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwFindMSIAfterburner_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 726);
            this.Controls.Add(this.chartFPS);
            this.Controls.Add(this.gbLiveFPS);
            this.Controls.Add(this.systemCheck);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupBoxGame);
            this.Name = "Form1";
            this.Text = "Game Performance Reporter";
            this.GroupBoxGame.ResumeLayout(false);
            this.GroupBoxGame.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFPS)).EndInit();
            this.gbLiveFPS.ResumeLayout(false);
            this.gbLiveFPS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxGame;
        private System.Windows.Forms.ComboBox cbGameList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bRTSS;
        private System.Windows.Forms.TextBox tbRTSSPath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bSubmit;
        private System.Windows.Forms.Label findGameLabel;
        private System.Windows.Forms.CheckBox ckIncludeGameFiles;
        private System.Windows.Forms.CheckBox ckIncludeDxDiag;
        private System.Windows.Forms.CheckBox ckIncludeRTSS;
        private System.ComponentModel.BackgroundWorker bWFindGame;
        private System.ComponentModel.BackgroundWorker bwFindRTSSConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSystemID;
        private System.Windows.Forms.CheckBox ckAnonSystemID;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label systemCheck;
        private System.ComponentModel.BackgroundWorker bwCheckAPI;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFPS;
        private System.Windows.Forms.Label labelFPS;
        private System.ComponentModel.BackgroundWorker bwGetLiveFPSData;
        private System.Windows.Forms.GroupBox gbLiveFPS;
        private System.Windows.Forms.Label labelLogStatus;
        private System.Windows.Forms.CheckBox ckLiveFPS;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker bwUpdateGraph;
        private System.Windows.Forms.TextBox tBSuspectedIssueHotKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckUpdateScreen;
        private System.ComponentModel.BackgroundWorker bwFindMSIAfterburner;
    }
}

