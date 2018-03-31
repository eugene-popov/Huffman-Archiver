namespace FrontEnd
{
    partial class ExtractArchiveWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtractArchiveWindow));
            this.selectionPanel = new System.Windows.Forms.Panel();
            this.file = new System.Windows.Forms.Label();
            this.select = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Label();
            this.extract = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ChoosePathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.progressPanel = new System.Windows.Forms.Panel();
            this.progressMessage = new System.Windows.Forms.Label();
            this.currentFileIndex = new System.Windows.Forms.Label();
            this.currentFileName = new System.Windows.Forms.Label();
            this.percentage = new System.Windows.Forms.Label();
            this.timerText = new System.Windows.Forms.Label();
            this.backgroundExtractor = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.errorPanel = new System.Windows.Forms.Panel();
            this.error = new System.Windows.Forms.Label();
            this.okErrorButton = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.resultPanel = new System.Windows.Forms.Panel();
            this.totalTime = new System.Windows.Forms.Label();
            this.okResultButton = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.Label();
            this.selectionPanel.SuspendLayout();
            this.progressPanel.SuspendLayout();
            this.errorPanel.SuspendLayout();
            this.resultPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectionPanel
            // 
            this.selectionPanel.Controls.Add(this.file);
            this.selectionPanel.Controls.Add(this.select);
            this.selectionPanel.Controls.Add(this.label4);
            this.selectionPanel.Controls.Add(this.cancel);
            this.selectionPanel.Controls.Add(this.extract);
            this.selectionPanel.Controls.Add(this.label1);
            this.selectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectionPanel.Location = new System.Drawing.Point(0, 0);
            this.selectionPanel.Name = "selectionPanel";
            this.selectionPanel.Size = new System.Drawing.Size(548, 188);
            this.selectionPanel.TabIndex = 1;
            // 
            // file
            // 
            this.file.AutoSize = true;
            this.file.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.file.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.file.Location = new System.Drawing.Point(112, 82);
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(142, 29);
            this.file.TabIndex = 11;
            this.file.Text = "not selected";
            // 
            // select
            // 
            this.select.AutoSize = true;
            this.select.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.select.Location = new System.Drawing.Point(453, 82);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(92, 29);
            this.select.TabIndex = 10;
            this.select.Text = "select";
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(15, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 45);
            this.label4.TabIndex = 9;
            this.label4.Text = "Path:";
            // 
            // cancel
            // 
            this.cancel.AutoSize = true;
            this.cancel.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cancel.Location = new System.Drawing.Point(301, 150);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(98, 29);
            this.cancel.TabIndex = 8;
            this.cancel.Text = "cancel";
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // extract
            // 
            this.extract.AutoSize = true;
            this.extract.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extract.ForeColor = System.Drawing.Color.Silver;
            this.extract.Location = new System.Drawing.Point(436, 150);
            this.extract.Name = "extract";
            this.extract.Size = new System.Drawing.Size(109, 29);
            this.extract.TabIndex = 7;
            this.extract.Text = "extract";
            this.toolTip1.SetToolTip(this.extract, "Select a path to extract the archive to");
            this.extract.Click += new System.EventHandler(this.extract_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(20, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Extract the archive";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // progressPanel
            // 
            this.progressPanel.Controls.Add(this.progressMessage);
            this.progressPanel.Controls.Add(this.currentFileIndex);
            this.progressPanel.Controls.Add(this.currentFileName);
            this.progressPanel.Controls.Add(this.percentage);
            this.progressPanel.Controls.Add(this.timerText);
            this.progressPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressPanel.Location = new System.Drawing.Point(0, 0);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Size = new System.Drawing.Size(548, 188);
            this.progressPanel.TabIndex = 2;
            this.progressPanel.Visible = false;
            this.progressPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.progressPanel_Paint);
            // 
            // progressMessage
            // 
            this.progressMessage.AutoSize = true;
            this.progressMessage.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.progressMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.progressMessage.Location = new System.Drawing.Point(89, 27);
            this.progressMessage.Name = "progressMessage";
            this.progressMessage.Size = new System.Drawing.Size(397, 35);
            this.progressMessage.TabIndex = 23;
            this.progressMessage.Text = "The archive is being extracted";
            // 
            // currentFileIndex
            // 
            this.currentFileIndex.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentFileIndex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.currentFileIndex.Location = new System.Drawing.Point(103, 151);
            this.currentFileIndex.Name = "currentFileIndex";
            this.currentFileIndex.Size = new System.Drawing.Size(189, 35);
            this.currentFileIndex.TabIndex = 22;
            this.currentFileIndex.Text = "file 1 of 10";
            this.currentFileIndex.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // currentFileName
            // 
            this.currentFileName.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentFileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.currentFileName.Location = new System.Drawing.Point(4, 84);
            this.currentFileName.Name = "currentFileName";
            this.currentFileName.Size = new System.Drawing.Size(541, 28);
            this.currentFileName.TabIndex = 21;
            this.currentFileName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.currentFileName.Click += new System.EventHandler(this.taskFour_Click);
            // 
            // percentage
            // 
            this.percentage.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.percentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.percentage.Location = new System.Drawing.Point(282, 151);
            this.percentage.Name = "percentage";
            this.percentage.Size = new System.Drawing.Size(264, 35);
            this.percentage.TabIndex = 20;
            this.percentage.Text = "(processed: 0%)";
            this.percentage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timerText
            // 
            this.timerText.AutoSize = true;
            this.timerText.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timerText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.timerText.Location = new System.Drawing.Point(1, 151);
            this.timerText.Name = "timerText";
            this.timerText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.timerText.Size = new System.Drawing.Size(44, 35);
            this.timerText.TabIndex = 19;
            this.timerText.Text = "0s";
            // 
            // backgroundExtractor
            // 
            this.backgroundExtractor.WorkerReportsProgress = true;
            this.backgroundExtractor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundExtractor_DoWork);
            this.backgroundExtractor.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundExtractor_ProgressChanged);
            this.backgroundExtractor.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundExtractor_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // errorPanel
            // 
            this.errorPanel.Controls.Add(this.error);
            this.errorPanel.Controls.Add(this.okErrorButton);
            this.errorPanel.Controls.Add(this.label3);
            this.errorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorPanel.Location = new System.Drawing.Point(0, 0);
            this.errorPanel.Name = "errorPanel";
            this.errorPanel.Size = new System.Drawing.Size(548, 188);
            this.errorPanel.TabIndex = 4;
            this.errorPanel.Visible = false;
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.error.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.error.Location = new System.Drawing.Point(19, 71);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(51, 23);
            this.error.TabIndex = 16;
            this.error.Text = "error";
            this.error.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // okErrorButton
            // 
            this.okErrorButton.AutoSize = true;
            this.okErrorButton.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okErrorButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.okErrorButton.Location = new System.Drawing.Point(485, 152);
            this.okErrorButton.Name = "okErrorButton";
            this.okErrorButton.Size = new System.Drawing.Size(45, 29);
            this.okErrorButton.TabIndex = 15;
            this.okErrorButton.Text = "ok";
            this.okErrorButton.Click += new System.EventHandler(this.okErrorButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(17, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(421, 35);
            this.label3.TabIndex = 14;
            this.label3.Text = "Extraction failed due to an error\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // resultPanel
            // 
            this.resultPanel.Controls.Add(this.totalTime);
            this.resultPanel.Controls.Add(this.okResultButton);
            this.resultPanel.Controls.Add(this.message);
            this.resultPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPanel.Location = new System.Drawing.Point(0, 0);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(548, 188);
            this.resultPanel.TabIndex = 5;
            this.resultPanel.Visible = false;
            // 
            // totalTime
            // 
            this.totalTime.AutoSize = true;
            this.totalTime.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.totalTime.Location = new System.Drawing.Point(3, 84);
            this.totalTime.Name = "totalTime";
            this.totalTime.Size = new System.Drawing.Size(71, 35);
            this.totalTime.TabIndex = 14;
            this.totalTime.Text = "time";
            this.totalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // okResultButton
            // 
            this.okResultButton.AutoSize = true;
            this.okResultButton.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okResultButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.okResultButton.Location = new System.Drawing.Point(482, 152);
            this.okResultButton.Name = "okResultButton";
            this.okResultButton.Size = new System.Drawing.Size(45, 29);
            this.okResultButton.TabIndex = 13;
            this.okResultButton.Text = "ok";
            this.okResultButton.Click += new System.EventHandler(this.okResultButton_Click);
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.message.Location = new System.Drawing.Point(2, 48);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(528, 35);
            this.message.TabIndex = 12;
            this.message.Text = "The file has been successfully extracted \r\n";
            this.message.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExtractArchiveWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 188);
            this.ControlBox = false;
            this.Controls.Add(this.progressPanel);
            this.Controls.Add(this.selectionPanel);
            this.Controls.Add(this.resultPanel);
            this.Controls.Add(this.errorPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExtractArchiveWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extract the archive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExtractArchiveWindow_FormClosing);
            this.Load += new System.EventHandler(this.ExtractArchiveWindow_Load);
            this.selectionPanel.ResumeLayout(false);
            this.selectionPanel.PerformLayout();
            this.progressPanel.ResumeLayout(false);
            this.progressPanel.PerformLayout();
            this.errorPanel.ResumeLayout(false);
            this.errorPanel.PerformLayout();
            this.resultPanel.ResumeLayout(false);
            this.resultPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel selectionPanel;
        private System.Windows.Forms.Label file;
        private System.Windows.Forms.Label select;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label cancel;
        private System.Windows.Forms.Label extract;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog ChoosePathDialog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel progressPanel;
        private System.Windows.Forms.Label currentFileName;
        private System.Windows.Forms.Label percentage;
        private System.Windows.Forms.Label timerText;
        private System.Windows.Forms.Label currentFileIndex;
        private System.Windows.Forms.Label progressMessage;
        private System.ComponentModel.BackgroundWorker backgroundExtractor;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel errorPanel;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.Label okErrorButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel resultPanel;
        private System.Windows.Forms.Label totalTime;
        private System.Windows.Forms.Label okResultButton;
        private System.Windows.Forms.Label message;
    }
}