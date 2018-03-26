namespace FrontEnd
{
    partial class TestArchiveWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestArchiveWindow));
            this.progressPanel = new System.Windows.Forms.Panel();
            this.currentFileNumber = new System.Windows.Forms.Label();
            this.progressMessage = new System.Windows.Forms.Label();
            this.timerText = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundTester = new System.ComponentModel.BackgroundWorker();
            this.resultPanel = new System.Windows.Forms.Panel();
            this.resultMessage = new System.Windows.Forms.Label();
            this.okErrorButton = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorPanel = new System.Windows.Forms.Panel();
            this.error = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.okError = new System.Windows.Forms.Label();
            this.progressPanel.SuspendLayout();
            this.resultPanel.SuspendLayout();
            this.errorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressPanel
            // 
            this.progressPanel.Controls.Add(this.currentFileNumber);
            this.progressPanel.Controls.Add(this.progressMessage);
            this.progressPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressPanel.Location = new System.Drawing.Point(0, 0);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Size = new System.Drawing.Size(440, 131);
            this.progressPanel.TabIndex = 0;
            // 
            // currentFileNumber
            // 
            this.currentFileNumber.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentFileNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.currentFileNumber.Location = new System.Drawing.Point(280, 92);
            this.currentFileNumber.Name = "currentFileNumber";
            this.currentFileNumber.Size = new System.Drawing.Size(158, 35);
            this.currentFileNumber.TabIndex = 16;
            this.currentFileNumber.Text = "file 1 of 10";
            this.currentFileNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // progressMessage
            // 
            this.progressMessage.AutoSize = true;
            this.progressMessage.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.progressMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.progressMessage.Location = new System.Drawing.Point(42, 27);
            this.progressMessage.Name = "progressMessage";
            this.progressMessage.Size = new System.Drawing.Size(358, 35);
            this.progressMessage.TabIndex = 14;
            this.progressMessage.Text = "The archive is being tested";
            // 
            // timerText
            // 
            this.timerText.AutoSize = true;
            this.timerText.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timerText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.timerText.Location = new System.Drawing.Point(3, 93);
            this.timerText.Name = "timerText";
            this.timerText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.timerText.Size = new System.Drawing.Size(44, 35);
            this.timerText.TabIndex = 15;
            this.timerText.Text = "0s";
            this.timerText.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundTester
            // 
            this.backgroundTester.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundTester_DoWork);
            this.backgroundTester.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundTester_RunWorkerCompleted);
            // 
            // resultPanel
            // 
            this.resultPanel.Controls.Add(this.resultMessage);
            this.resultPanel.Controls.Add(this.okErrorButton);
            this.resultPanel.Controls.Add(this.label3);
            this.resultPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPanel.Location = new System.Drawing.Point(0, 0);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(440, 131);
            this.resultPanel.TabIndex = 17;
            this.resultPanel.Visible = false;
            // 
            // resultMessage
            // 
            this.resultMessage.AutoSize = true;
            this.resultMessage.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.resultMessage.Location = new System.Drawing.Point(12, 55);
            this.resultMessage.Name = "resultMessage";
            this.resultMessage.Size = new System.Drawing.Size(208, 35);
            this.resultMessage.TabIndex = 14;
            this.resultMessage.Text = "test result here";
            this.resultMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // okErrorButton
            // 
            this.okErrorButton.AutoSize = true;
            this.okErrorButton.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okErrorButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.okErrorButton.Location = new System.Drawing.Point(391, 95);
            this.okErrorButton.Name = "okErrorButton";
            this.okErrorButton.Size = new System.Drawing.Size(45, 29);
            this.okErrorButton.TabIndex = 13;
            this.okErrorButton.Text = "ok";
            this.okErrorButton.Click += new System.EventHandler(this.okErrorButton_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(423, 36);
            this.label3.TabIndex = 12;
            this.label3.Text = "Test result";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorPanel
            // 
            this.errorPanel.Controls.Add(this.error);
            this.errorPanel.Controls.Add(this.label2);
            this.errorPanel.Controls.Add(this.okError);
            this.errorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorPanel.Location = new System.Drawing.Point(0, 0);
            this.errorPanel.Name = "errorPanel";
            this.errorPanel.Size = new System.Drawing.Size(440, 131);
            this.errorPanel.TabIndex = 15;
            this.errorPanel.Visible = false;
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.error.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.error.Location = new System.Drawing.Point(12, 62);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(51, 23);
            this.error.TabIndex = 16;
            this.error.Text = "error";
            this.error.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(51, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 35);
            this.label2.TabIndex = 15;
            this.label2.Text = "Test failed due to an error";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // okError
            // 
            this.okError.AutoSize = true;
            this.okError.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.okError.Location = new System.Drawing.Point(387, 97);
            this.okError.Name = "okError";
            this.okError.Size = new System.Drawing.Size(45, 29);
            this.okError.TabIndex = 14;
            this.okError.Text = "ok";
            this.okError.Click += new System.EventHandler(this.okError_Click);
            // 
            // TestArchiveWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 131);
            this.ControlBox = false;
            this.Controls.Add(this.timerText);
            this.Controls.Add(this.resultPanel);
            this.Controls.Add(this.progressPanel);
            this.Controls.Add(this.errorPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestArchiveWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test the archive";
            this.progressPanel.ResumeLayout(false);
            this.progressPanel.PerformLayout();
            this.resultPanel.ResumeLayout(false);
            this.resultPanel.PerformLayout();
            this.errorPanel.ResumeLayout(false);
            this.errorPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel progressPanel;
        private System.Windows.Forms.Label progressMessage;
        private System.Windows.Forms.Label currentFileNumber;
        private System.Windows.Forms.Label timerText;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundTester;
        private System.Windows.Forms.Panel resultPanel;
        private System.Windows.Forms.Label resultMessage;
        private System.Windows.Forms.Label okErrorButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel errorPanel;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label okError;
    }
}