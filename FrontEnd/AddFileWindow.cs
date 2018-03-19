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
        private class Time
        {
            public int sec = 0;
            public int min = 0;

            public void Inc()
            {
                sec++;
                if (sec >= 60)
                {
                    min++;
                    sec = 0;
                }
            }
        }
        private bool selected = false;
        private string path;
        private string shortname;
        private string filename;
        private Time time;
        private Queue<string> messageQueue;
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
                if (filename.Length > 17)
                {
                    shortname = filename.Substring(0, 17) + "...";
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

                messageQueue = new Queue<string>();

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
                
                

                if (compressionCompleted && messageQueue.Count == 0)
                {
                    /* if all the messages have been printed and no more messages will appear, end timer and change screen */
                        timer1.Enabled = false;

                    

                }
                /* update time */
                time.Inc();
            }
        }

        private void ShowResultPanel()
        {

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
            MessageBox.Show("yeah!");
            compressionCompleted = true;
            Controller.controller.RefreshView();
           
            
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
    }
}
