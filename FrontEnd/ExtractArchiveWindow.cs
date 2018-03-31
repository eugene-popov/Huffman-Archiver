using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FrontEnd
{
    public partial class ExtractArchiveWindow : Form
    {
        private readonly Time time = new Time();
        private bool extractionCompleted;
        private bool extractionStarted;
        private string path;
        private bool selected;

        public ExtractArchiveWindow()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void select_Click(object sender, EventArgs e)
        {
            if (ChoosePathDialog.ShowDialog() == DialogResult.OK)
            {
                path = ChoosePathDialog.SelectedPath;
                var shortPath = Path.GetFileName(path);
                if (shortPath.Length > 20) shortPath = shortPath.Substring(0, 20) + "...";


                file.Text = shortPath;
                extract.ForeColor = Color.FromArgb(64, 64, 64);
                toolTip1.SetToolTip(extract, "");
                toolTip1.SetToolTip(file, path);
                selected = true;
            }
        }

        private void taskFour_Click(object sender, EventArgs e)
        {
        }

        private void extract_Click(object sender, EventArgs e)
        {
            if (selected)
            {
                selectionPanel.Visible = false;
                selectionPanel.Enabled = false;

                progressPanel.Visible = true;
                timer1.Enabled = true;
                backgroundExtractor.RunWorkerAsync();
            }
        }

        private void UpdateState(string next)
        {
            BeginInvoke((Action) delegate
            {
                var shortName = next;
                if (shortName.Length > 25) shortName = shortName.Substring(0, 25) + "...";

                currentFileName.Text = shortName;
                toolTip1.SetToolTip(currentFileName, next);
            });
        }

        private void UpdateFile(string next)
        {
            BeginInvoke((Action) delegate { currentFileIndex.Text = next; });
        }

        private void backgroundExtractor_DoWork(object sender, DoWorkEventArgs e)
        {
            extractionStarted = true;
            Controller.controller.SubscribeToStateUpdates(UpdateState);
            Controller.controller.SubscribeToFileUpdates(UpdateFile);
            Controller.controller.SubscribeToPercentageUpdates(backgroundExtractor.ReportProgress);

            Controller.controller.ExtractArchiveTo(path);
        }

        private void backgroundExtractor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            extractionCompleted = true;
            Controller.controller.UnsubscribeFromStateUpdates(UpdateState);
            Controller.controller.UnsubscribeFromFileUpdates(UpdateFile);
            Controller.controller.UnsubscribeToPercentageUpdates(backgroundExtractor.ReportProgress);
            if (e.Error == null)
            {
                progressPanel.Visible = false;
                progressPanel.Enabled = false;
                ShowResultPanel();
            }
            else
            {
                progressPanel.Visible = false;
                progressPanel.Enabled = false;
                error.Text = e.Error.Message;
                errorPanel.Visible = true;
            }
        }

        private void backgroundExtractor_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            percentage.Text = "(progress: " + e.ProgressPercentage + "%)";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (extractionCompleted) timer1.Enabled = false;

            if (timer1.Enabled)
            {
                /* update timer in the corner */
                var res = "";
                if (time.min > 0) res += time.min + "m ";

                res += time.sec + "s";
                timerText.Text = res;
                /* update progress message */
                var reminder = time.sec % 3;
                progressMessage.Text = "The archive is being extracted";
                for (var i = 0; i <= reminder; i++) progressMessage.Text += ".";

                /* update time */
                time.Inc();
            }
        }

        private void ShowResultPanel()
        {
            totalTime.Text = "in ";
            if (time.min > 0)
            {
                totalTime.Text += time.min + " ";
                if (time.min == 1)
                    totalTime.Text += "minute ";
                else
                    totalTime.Text += "minutes ";
            }

            if (time.sec > 0)
            {
                totalTime.Text += time.sec + " ";
                if (time.sec == 1)
                    totalTime.Text += "second ";
                else
                    totalTime.Text += "seconds ";
            }

            if (time.min == 0 && time.sec == 0) totalTime.Text += "less than a second";

            resultPanel.Visible = true;
        }

        private void okErrorButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExtractArchiveWindow_Load(object sender, EventArgs e)
        {
        }

        private void okResultButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void progressPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ExtractArchiveWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!extractionCompleted && extractionStarted) e.Cancel = true;
        }
    }
}