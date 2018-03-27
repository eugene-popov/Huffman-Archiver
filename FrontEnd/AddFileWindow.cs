using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackEnd;

namespace FrontEnd
{
    public partial class AddFileWindow : Form
    {
        
        private bool selected = false;
        private string path;
        private string shortname;
        private string filename;
        private Time time;
        private int filledTaskLabels = 0;
        private bool compressionCompleted = false;

        public AddFileWindow()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void select_Click(object sender, EventArgs e)
        {
            if (addFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = addFileDialog.FileName;
                filename = Path.GetFileName(path);
                if (filename.Length > 15)
                {
                    shortname = filename.Substring(0, 15) + "...";
                }
                else
                {
                    shortname = filename;
                }

                file.Text = shortname;
                compress.ForeColor = Color.FromArgb(64, 64, 64);
                toolTip1.SetToolTip(compress, "");
                toolTip1.SetToolTip(file, filename);
                selected = true;

            }
        }

        private void compress_Click(object sender, EventArgs e)
        {
            if (selected)
            {
                Text = "Compressing the file...";
                selectionPanel.Visible = false;
                selectionPanel.Enabled = false;
                compressionPanel.Visible = true;
                time = new Time();
                timer1.Enabled = true;

                backgroundCompressor1.RunWorkerAsync(path);
            }



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

        private void updateColors()
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (compressionCompleted)
            {
                /* if all the messages have been printed and no more messages will appear, end timer and change screen */
                timer1.Enabled = false;
            }
            if (timer1.Enabled)
            {
                /* update timer in the corner */
                string res = "";
                if (time.min > 0)
                {
                    res += time.min + "m ";
                }
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
                {
                    totalTime.Text += "minute ";
                }
                else
                {
                    totalTime.Text += "minutes ";
                }
            }
            if (time.sec > 0)
            {
                totalTime.Text += time.sec + " ";
                if (time.sec == 1)
                {
                    totalTime.Text += "second ";
                }
                else
                {
                    totalTime.Text += "seconds ";
                }
            }

            if (time.min == 0 && time.sec == 0)
            {
                totalTime.Text += "less than a second";
            }

                resultPanel.Visible = true;
        }

        private void ShowErrorPanel(string message)
        {
            error.Text = message;
            errorPanel.Visible = true;
        }

        private void backgroundCompressor1_DoWork(object sender, DoWorkEventArgs e)
        {
            Controller.controller.SubscribeToStateUpdates(UpdateState);
            Controller.controller.SubscribeToPercentageUpdates(backgroundCompressor1.ReportProgress);
            Controller.controller.CompressFile(path);
        }

        private void UpdateState(string next)
        {
            this.BeginInvoke((Action) delegate
            {
                addTask(next);
            });
            
        }
        private void backgroundCompressor1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            compressionCompleted = true;
            Controller.controller.RefreshView();
            Controller.controller.UnsubscribeFromStateUpdates(UpdateState);
            Controller.controller.UnsubscribeToPercentageUpdates(backgroundCompressor1.ReportProgress);
            if (e.Error == null)
            {
                compressionPanel.Visible = false;
                compressionPanel.Enabled = false;
                ShowResultPanel();
            }
            else
            {
                ShowErrorPanel(e.Error.Message);
                compressionPanel.Visible = false;
                compressionPanel.Enabled = false;
            }        
        }

        private void backgroundCompressor1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            percentage.Text = "progress: " + e.ProgressPercentage + "%";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AddFileWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void okResultButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okErrorButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
