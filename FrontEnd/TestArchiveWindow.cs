using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FrontEnd
{
    public partial class TestArchiveWindow : Form
    {
        private readonly Time time = new Time();
        private bool result;
        private bool testCompleted;

        public TestArchiveWindow()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (testCompleted) timer1.Enabled = false;

            if (timer1.Enabled)
            {
                /* update timer in the corner */
                var res = "";
                if (time.min > 0) res += time.min + "m ";

                res += time.sec + "s";
                timerText.Text = res;
                /* update progress message */
                var reminder = time.sec % 3;
                progressMessage.Text = "The archive is being tested";
                for (var i = 0; i <= reminder; i++) progressMessage.Text += ".";

                /* check if time is too long to be shown */
                if (time.sec > 2 && !timerText.Visible) timerText.Visible = true;

                /* update time */
                time.Inc();
            }
        }

        private void UpdateProgress(string newState)
        {
            BeginInvoke((Action) delegate { currentFileNumber.Text = newState; });
        }

        private void backgroundTester_DoWork(object sender, DoWorkEventArgs e)
        {
            Controller.controller.SubscribeToFileUpdates(UpdateProgress);
            result = Controller.controller.TestFilesInArchive();
        }

        private void backgroundTester_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Controller.controller.UnsubscribeFromFileUpdates(UpdateProgress);
            testCompleted = true;
            if (e.Error == null)
            {
                progressPanel.Visible = false;
                progressPanel.Enabled = false;
                resultMessage.Text = result ? "The archive contents are correct." : "The archive contents are damaged.";
                resultPanel.Visible = true;
            }
            else
            {
                progressPanel.Visible = false;
                progressPanel.Enabled = false;
                timerText.Visible = false;
                error.Text = e.Error.Message;
                errorPanel.Visible = true;
            }
        }

        private void okError_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okErrorButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TestArchiveWindow_Load(object sender, EventArgs e)
        {
            backgroundTester.RunWorkerAsync();
        }

        private void TestArchiveWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void TestArchiveWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!testCompleted) e.Cancel = true;
        }
    }
}