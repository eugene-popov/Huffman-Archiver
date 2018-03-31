namespace FrontEnd
{
    partial class ExtractFileWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtractFileWindow));
            this.selectionPanel = new System.Windows.Forms.Panel();
            this.file = new System.Windows.Forms.Label();
            this.select = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Label();
            this.extract = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.taskFour = new System.Windows.Forms.Label();
            this.taskTwo = new System.Windows.Forms.Label();
            this.taskOne = new System.Windows.Forms.Label();
            this.taskThree = new System.Windows.Forms.Label();
            this.percentage = new System.Windows.Forms.Label();
            this.timerText = new System.Windows.Forms.Label();
            this.resultPanel = new System.Windows.Forms.Panel();
            this.totalTime = new System.Windows.Forms.Label();
            this.okResultButton = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.Label();
            this.errorPanel = new System.Windows.Forms.Panel();
            this.error = new System.Windows.Forms.Label();
            this.okErrorButton = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ChoosePathDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundExtractor = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.selectionPanel.SuspendLayout();
            this.progressPanel.SuspendLayout();
            this.resultPanel.SuspendLayout();
            this.errorPanel.SuspendLayout();
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
            this.selectionPanel.Size = new System.Drawing.Size(532, 188);
            this.selectionPanel.TabIndex = 0;
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
            this.select.Location = new System.Drawing.Point(426, 84);
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
            this.cancel.Location = new System.Drawing.Point(259, 152);
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
            this.extract.Location = new System.Drawing.Point(394, 152);
            this.extract.Name = "extract";
            this.extract.Size = new System.Drawing.Size(109, 29);
            this.extract.TabIndex = 7;
            this.extract.Text = "extract";
            this.toolTip1.SetToolTip(this.extract, "select a path to extract the file to");
            this.extract.Click += new System.EventHandler(this.extract_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Extract the file";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // progressPanel
            // 
            this.progressPanel.Controls.Add(this.taskFour);
            this.progressPanel.Controls.Add(this.taskTwo);
            this.progressPanel.Controls.Add(this.taskOne);
            this.progressPanel.Controls.Add(this.taskThree);
            this.progressPanel.Controls.Add(this.percentage);
            this.progressPanel.Controls.Add(this.timerText);
            this.progressPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressPanel.Location = new System.Drawing.Point(0, 0);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Size = new System.Drawing.Size(532, 188);
            this.progressPanel.TabIndex = 1;
            this.progressPanel.Visible = false;
            // 
            // taskFour
            // 
            this.taskFour.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.taskFour.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.taskFour.Location = new System.Drawing.Point(3, 119);
            this.taskFour.Name = "taskFour";
            this.taskFour.Size = new System.Drawing.Size(526, 28);
            this.taskFour.TabIndex = 18;
            this.taskFour.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // taskTwo
            // 
            this.taskTwo.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.taskTwo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.taskTwo.Location = new System.Drawing.Point(3, 48);
            this.taskTwo.Name = "taskTwo";
            this.taskTwo.Size = new System.Drawing.Size(526, 29);
            this.taskTwo.TabIndex = 17;
            this.taskTwo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // taskOne
            // 
            this.taskOne.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.taskOne.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.taskOne.Location = new System.Drawing.Point(4, 8);
            this.taskOne.Name = "taskOne";
            this.taskOne.Size = new System.Drawing.Size(526, 33);
            this.taskOne.TabIndex = 16;
            this.taskOne.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // taskThree
            // 
            this.taskThree.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.taskThree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.taskThree.Location = new System.Drawing.Point(4, 77);
            this.taskThree.Name = "taskThree";
            this.taskThree.Size = new System.Drawing.Size(526, 36);
            this.taskThree.TabIndex = 15;
            this.taskThree.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // percentage
            // 
            this.percentage.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.percentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.percentage.Location = new System.Drawing.Point(258, 147);
            this.percentage.Name = "percentage";
            this.percentage.Size = new System.Drawing.Size(262, 35);
            this.percentage.TabIndex = 14;
            this.percentage.Text = "processed: 0%";
            this.percentage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timerText
            // 
            this.timerText.AutoSize = true;
            this.timerText.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timerText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.timerText.Location = new System.Drawing.Point(8, 147);
            this.timerText.Name = "timerText";
            this.timerText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.timerText.Size = new System.Drawing.Size(44, 35);
            this.timerText.TabIndex = 13;
            this.timerText.Text = "0s";
            // 
            // resultPanel
            // 
            this.resultPanel.Controls.Add(this.totalTime);
            this.resultPanel.Controls.Add(this.okResultButton);
            this.resultPanel.Controls.Add(this.message);
            this.resultPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPanel.Location = new System.Drawing.Point(0, 0);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(532, 188);
            this.resultPanel.TabIndex = 2;
            this.resultPanel.Visible = false;
            // 
            // totalTime
            // 
            this.totalTime.AutoSize = true;
            this.totalTime.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.totalTime.Location = new System.Drawing.Point(8, 88);
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
            this.okResultButton.Location = new System.Drawing.Point(481, 152);
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
            this.message.Location = new System.Drawing.Point(3, 49);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(528, 35);
            this.message.TabIndex = 12;
            this.message.Text = "The file has been successfully extracted \r\n";
            this.message.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorPanel
            // 
            this.errorPanel.Controls.Add(this.error);
            this.errorPanel.Controls.Add(this.okErrorButton);
            this.errorPanel.Controls.Add(this.label3);
            this.errorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorPanel.Location = new System.Drawing.Point(0, 0);
            this.errorPanel.Name = "errorPanel";
            this.errorPanel.Size = new System.Drawing.Size(532, 188);
            this.errorPanel.TabIndex = 3;
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
            this.okErrorButton.Location = new System.Drawing.Point(475, 152);
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
            this.label3.Location = new System.Drawing.Point(17, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(421, 35);
            this.label3.TabIndex = 14;
            this.label3.Text = "Extraction failed due to an error\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChoosePathDialog
            // 
            this.ChoosePathDialog.Title = "Extract the file to";
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
            // ExtractFileWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 188);
            this.ControlBox = false;
            this.Controls.Add(this.errorPanel);
            this.Controls.Add(this.progressPanel);
            this.Controls.Add(this.selectionPanel);
            this.Controls.Add(this.resultPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExtractFileWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extract the file";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExtractFileWindow_FormClosing);
            this.selectionPanel.ResumeLayout(false);
            this.selectionPanel.PerformLayout();
            this.progressPanel.ResumeLayout(false);
            this.progressPanel.PerformLayout();
            this.resultPanel.ResumeLayout(false);
            this.resultPanel.PerformLayout();
            this.errorPanel.ResumeLayout(false);
            this.errorPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel selectionPanel;
        private System.Windows.Forms.Panel progressPanel;
        private System.Windows.Forms.Panel resultPanel;
        private System.Windows.Forms.Panel errorPanel;
        private System.Windows.Forms.Label file;
        private System.Windows.Forms.Label select;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label cancel;
        private System.Windows.Forms.Label extract;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog ChoosePathDialog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.BackgroundWorker backgroundExtractor;
        private System.Windows.Forms.Label taskFour;
        private System.Windows.Forms.Label taskTwo;
        private System.Windows.Forms.Label taskOne;
        private System.Windows.Forms.Label taskThree;
        private System.Windows.Forms.Label percentage;
        private System.Windows.Forms.Label timerText;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.Label okErrorButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totalTime;
        private System.Windows.Forms.Label okResultButton;
        private System.Windows.Forms.Label message;
    }
}