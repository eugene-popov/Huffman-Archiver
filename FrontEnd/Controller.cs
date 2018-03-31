using System;
using System.IO;
using System.Windows.Forms;
using BackEnd;

namespace FrontEnd
{
    public class Controller
    {
        public static Controller controller;
        private Archive archive;
        public bool ArchiveOpened;
        public MainWindow mainWindow;
        private DataGridViewRow row;
        private bool rowSelected;

        public void CreateArchive()
        {
            if (mainWindow.createArchiveDialog.ShowDialog() == DialogResult.OK)
            {
                void create()
                {
                    try
                    {
                        archive = new Archive(mainWindow.createArchiveDialog.FileName);
                        ArchiveOpened = true;
                        RefreshView();
                        mainWindow.emptyPanel.Visible = true;
                        mainWindow.HideWelcome();
                        mainWindow.ShowControlPanel();
                        mainWindow.ShowViewer();
                        mainWindow.ShowOpenedArchiveControls();
                        mainWindow.HideClosedPanel();
                    }
                    catch
                    {
                        MessageBox.Show("Selected file has incorrect structure or is empty.", "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }

                if (ArchiveOpened)
                {
                    var archiveHasBeenClosed = CloseArchive();
                    if (archiveHasBeenClosed)
                    {
                        if (File.Exists(mainWindow.createArchiveDialog.FileName))
                            File.Delete(mainWindow.createArchiveDialog.FileName);

                        create();
                    }
                }
                else
                {
                    create();
                }
            }
        }

        public void OpenArchive()
        {
            void open(string path)
            {
                try
                {
                    archive = new Archive(path);
                    ArchiveOpened = true;
                    RefreshView();
                    if (mainWindow.ArchiveVIEWER.Rows.Count == 0) mainWindow.emptyPanel.Visible = true;

                    mainWindow.HideWelcome();
                    mainWindow.ShowControlPanel();
                    mainWindow.ShowViewer();
                    mainWindow.ShowOpenedArchiveControls();
                    mainWindow.HideClosedPanel();
                }
                catch
                {
                    MessageBox.Show("Selected file has incorrect structure or is empty.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }

            var result = mainWindow.openArchiveDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var path = mainWindow.openArchiveDialog.FileName;
                if (ArchiveOpened)
                {
                    var archiveHasBeenClosed = CloseArchive();
                    if (archiveHasBeenClosed) open(path);
                }
                else
                {
                    open(path);
                }
            }
        }

        public void TestArchive()
        {
            if (ArchiveOpened)
                new TestArchiveWindow().ShowDialog();
            else
                MessageBox.Show("No archive opened to be tested.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        public bool TestFilesInArchive()
        {
            return archive.TestArchive(out var damaged);
        }

        public void ExtractArchive()
        {
            if (ArchiveOpened)
                new ExtractArchiveWindow().ShowDialog();
            else
                MessageBox.Show("No archive opened to be extracted.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        public void ExtractArchiveTo(string path)
        {
            archive.ExtractArchive(path);
        }

        public bool CloseArchive()
        {
            if (ArchiveOpened)
            {
                var answer = MessageBox.Show("Do you want to close the opened archive?", "Confirm closing",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (answer == DialogResult.Yes)
                {
                    mainWindow.HideOpenedArchiveControls();
                    mainWindow.emptyPanel.Visible = false;
                    mainWindow.HideViewer();
                    archive.Close();
                    archive = null;
                    ArchiveOpened = false;
                    mainWindow.ArchiveVIEWER.Rows.Clear();
                    CheckSelection();
                    rowSelected = false;
                    row = null;
                    mainWindow.ShowClosedPanel();
                    /* indicate that the archive is closed */
                    return true;
                }

                return false;
            }

            MessageBox.Show("No archive opened to be closed.", "Closing error", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            return true;
        }

        public void AddFile()
        {
            if (ArchiveOpened)
                new AddFileWindow().ShowDialog();
            else
                MessageBox.Show("No archive opened to add a file to.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        public void CompressFile(string path)
        {
            archive.AddFile(path);
            mainWindow.emptyPanel.Visible = false;
        }

        public void ExtractFile()
        {
            if (rowSelected)
                new ExtractFileWindow((string) row.Cells[1].Value).ShowDialog();
            else
                MessageBox.Show("No file chosen to be extracted.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        public void ExtractSelectedFile(string path)
        {
            var selectedFileUri = (Uri) row.Cells[0].Value;
            archive.ExtractFile(selectedFileUri, path, true);
        }

        public void TestFile()
        {
            if (rowSelected)
                new TestFileWindow().ShowDialog();
            else
                MessageBox.Show("No file chosen to be tested.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        public bool TestSelectedFile()
        {
            var selectedFileUri = (Uri) row.Cells[0].Value;
            return archive.TestFile(selectedFileUri);
        }

        public void RemoveFile()
        {
            if (rowSelected)
            {
                var filename = (string) row.Cells[1].Value;
                var answer = MessageBox.Show("Do you want to remove " + filename + " from the archive?",
                    "Confirm removing", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (answer == DialogResult.Yes)
                {
                    /* find the file's uri */
                    var uri = (Uri) row.Cells[0].Value;
                    /* remove file */
                    archive.DeleteFile(uri);
                    RefreshView();
                    CheckSelection();
                    if (mainWindow.ArchiveVIEWER.Rows.Count == 0) mainWindow.emptyPanel.Visible = true;
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
            var filesInfo = archive.GetView();
            mainWindow.ArchiveVIEWER.Rows.Clear();
            foreach (var file in filesInfo)
                mainWindow.ArchiveVIEWER.Rows.Add(file[0], file[1], file[2], file[3], file[4]);
        }

        public void Exit()
        {
            if (ArchiveOpened)
            {
                if (CloseArchive()) Application.Exit();
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
            if (mainWindow.ArchiveVIEWER.Rows.Count != 0 && mainWindow.ArchiveVIEWER.CurrentRow != null)
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

        #region EventSubscribtion

        public void SubscribeToStateUpdates(Archive.ReportStateChange methodToSubscribe)
        {
            archive.OnStateChange += methodToSubscribe;
        }

        public void UnsubscribeFromStateUpdates(Archive.ReportStateChange methodToUnsubscribe)
        {
            archive.OnStateChange -= methodToUnsubscribe;
        }

        public void SubscribeToFileUpdates(Archive.ReportCurrentFileChange methodToSubscribe)
        {
            archive.OnCurrentFileChange += methodToSubscribe;
        }

        public void UnsubscribeFromFileUpdates(Archive.ReportCurrentFileChange methodToUnsubscribe)
        {
            archive.OnCurrentFileChange -= methodToUnsubscribe;
        }

        public void SubscribeToPercentageUpdates(Archive.ReportProgress methodToSubscribe)
        {
            archive.OnProgressChange += methodToSubscribe;
        }

        public void UnsubscribeToPercentageUpdates(Archive.ReportProgress methodToUnsubscribe)
        {
            archive.OnProgressChange -= methodToUnsubscribe;
        }

        #endregion
    }
}