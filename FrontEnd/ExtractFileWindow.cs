using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FrontEnd
{
    public partial class ExtractFileWindow : Form
    {
        private readonly string extractedFileName;

        private readonly Time time = new Time();
        private bool extractionCompleted;

        private bool extractionStarted;
        private string filename;
        private int filledTaskLabels;
        private string path;
        private bool selected;
        private string shortname;

        public ExtractFileWindow(string filename)
        {
            extractedFileName = filename;
            InitializeComponent();
        }

        private void select_Click(object sender, EventArgs e)
        {
            ChoosePathDialog.FileName = extractedFileName;
            if (ChoosePathDialog.ShowDialog() == DialogResult.OK)
            {
                path = ChoosePathDialog.FileName;
                var shortPath = Path.GetFileName(Path.GetDirectoryName(path)) + "\\" + Path.GetFileName(path);
                if (shortPath.Length > 23) shortPath = shortPath.Substring(0, 23) + "...";


                file.Text = shortPath;
                extract.ForeColor = Color.FromArgb(64, 64, 64);
                toolTip1.SetToolTip(extract, "");
                toolTip1.SetToolTip(file, path);
                selected = true;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void backgroundExtractor_DoWork(object sender, DoWorkEventArgs e)
        {
            extractionStarted = true;
            Controller.controller.SubscribeToStateUpdates(UpdateState);
            Controller.controller.SubscribeToPercentageUpdates(backgroundExtractor.ReportProgress);
            Controller.controller.ExtractSelectedFile(path);
        }

        private void UpdateState(string next)
        {
            BeginInvoke((Action) delegate { addTask(next); });
        }

        private void addTask(string state)
        {
            switch (filledTaskLabels)
            {
                case 0:
                    taskOne.Text = state;
                    filledTaskLabels++;
                    break;
                case 1:
                    taskTwo.Text = state;
                    filledTaskLabels++;
                    break;
                case 2:
                    taskThree.Text = state;
                    filledTaskLabels++;
                    break;
                case 3:
                    taskFour.Text = state;
                    filledTaskLabels++;
                    break;
                default:
                    taskOne.Text = taskTwo.Text;
                    taskTwo.Text = taskThree.Text;
                    taskThree.Text = taskFour.Text;
                    taskFour.Text = state;
                    break;
            }
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

        private void backgroundExtractor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            extractionCompleted = true;
            Controller.controller.UnsubscribeFromStateUpdates(UpdateState);
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
            percentage.Text = "progress: " + e.ProgressPercentage + "%";
        }

        private void extract_Click(object sender, EventArgs e)
        {
            if (selected)
            {
                timer1.Enabled = true;
                backgroundExtractor.RunWorkerAsync();
                selectionPanel.Visible = false;
                selectionPanel.Enabled = false;
                progressPanel.Visible = true;
            }
        }

        private void okErrorButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okResultButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExtractFileWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!extractionStarted && extractionStarted) e.Cancel = true;
        }
    }
}