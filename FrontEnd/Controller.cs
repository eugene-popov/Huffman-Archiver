using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackEnd;

namespace FrontEnd
{
    
    public class Controller
    {
        public bool ArchiveOpened = false;
        public MainWindow mainWindow;
        public static Controller controller;
        private Archive archive = null;
        private List<List<object>> filesInfo = null;
        private bool rowSelected = false;
        private DataGridViewRow row = null;

        public void CreateArchive()
        {
            if (mainWindow.createArchiveDialog.ShowDialog() == DialogResult.OK)
            {
                archive = new Archive(mainWindow.createArchiveDialog.FileName);
                ArchiveOpened = true;
                RefreshView();
                mainWindow.HideWelcome();
                mainWindow.ShowControlPanel();
                mainWindow.ShowViewer();
                mainWindow.ShowOpenedArchiveControls();
            }
            
        }

        public void OpenArchive()
        {
            void open(string path)
            {
                archive = new Archive(path);
                ArchiveOpened = true;
                RefreshView();
                mainWindow.HideWelcome();
                mainWindow.ShowControlPanel();
                mainWindow.ShowViewer();
                mainWindow.ShowOpenedArchiveControls();
                
            }
            var result = mainWindow.openArchiveDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var path = mainWindow.openArchiveDialog.FileName;
                if (ArchiveOpened)
                {
                    bool archiveHasBeenClosed = CloseArchive();
                    if (archiveHasBeenClosed)
                    {
                        open(path);
                    }
                }
                else
                {
                    open(path);
                }
            }
            
            
            
        }

        


        public void TestArchive()
        {

        }

        public void ExtractArchive()
        {

        }

        public bool CloseArchive()
        {
            if (ArchiveOpened)
            {
                var answer = MessageBox.Show("Do you want to close the opened archive?", "Confirm closing", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (answer == DialogResult.Yes)
                {
                    mainWindow.HideOpenedArchiveControls();
                    mainWindow.HideViewer();
                    archive.Close();
                    archive = null;
                    ArchiveOpened = false;
                    mainWindow.ArchiveVIEWER.Rows.Clear();
                    CheckSelection();
                    /* indicate that the archive is closed */
                    return true;
                }

                return false;

            }
            else
            {
                MessageBox.Show("No archive opened to be closed.", "Closing error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }
            
        }

        public void AddFile()
        {
            new AddFileWindow().ShowDialog();
        }

        public void CompressFile(string path)
        {
            archive.AddFile(path);
            return;
        }
        public void ExtractFile()
        {

        }

        public void TestFile()
        {

        }

        public void RemoveFile()
        {
            if (rowSelected)
            {
                var filename = (string) row.Cells[0].Value;
                var answer = MessageBox.Show("Do you want to remove "+ filename + " from the archive?", "Confirm removing", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (answer == DialogResult.Yes)
                {
                   /* find the file's uri */
                    var uri = (Uri) filesInfo.Find(element => ((string) element[1]).Equals(filename))[0];
                    /* remove file */
                    archive.DeleteFile(uri);
                    RefreshView();
                }
            }
            else
            {
                MessageBox.Show("No file selected to remove.", "Removing error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
        
        public void RefreshView()
        {
            filesInfo = archive.GetView();
            mainWindow.ArchiveVIEWER.Rows.Clear();
            foreach (var file in filesInfo)
            {
                mainWindow.ArchiveVIEWER.Rows.Add(file[1], file[2], file[3], file[4]);
            } 
            
        }

        public void SubscribeToStateUpdates(Archive.ReportStateChange methodToSubscribe)
        {
            archive.OnStateChange += methodToSubscribe;
        }

        public void SubscribeToPercentageUpdates(Archive.ReportProgress methodToSubscribe)
        {
            archive.OnProgressChange += methodToSubscribe;

        }
        public void Exit()
        {
            if (ArchiveOpened)
            {
                CloseArchive();
                Application.Exit();
            }
            else
            {
                Application.Exit();
            }
            
        }
        public void ShowArchiveViewerPanel()
        {
            mainWindow.AdjustArchiveViewerColumnsWidth();
        }

        public void CheckSelection()
        {
            if (mainWindow.ArchiveVIEWER.CurrentRow != null)
            {
                rowSelected = true;
                row = mainWindow.ArchiveVIEWER.CurrentRow;
                mainWindow.ShowSelectedFileControls();
            }
            else
            {
                rowSelected = false;
                row = null;
                mainWindow.HideSelectedFileControls();
            }
        }
    }
}
