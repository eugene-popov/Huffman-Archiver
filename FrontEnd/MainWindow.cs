using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void AdjustArchiveViewerColumnsWidth()
        {
            ArchiveVIEWER.Columns[0].Width = 300; // Name
            ArchiveVIEWER.Columns[1].Width = 116; // Compressed
            ArchiveVIEWER.Columns[2].Width = 125; // Uncompressed
            ArchiveVIEWER.Columns[3].Width = 116; // Ratio
        }

        private void welcomeLabel1_Click(object sender, EventArgs e)
        {

        }

        private void welcomePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void welcomeLabel2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ButtonsPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void ArchiveViewerPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void aboutHuffmanArchiverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutWindow().Show();
        }

        

        

        

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void archiveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void extrToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #region Create Archive
        private void CreateArchiveButton_Click(object sender, EventArgs e)
        {
            Controller.controller.CreateArchive();
        }

        private void newArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.controller.CreateArchive();
        }
        #endregion

        #region Open Archive

        private void openArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.controller.OpenArchive();
        }

        private void OpenArchiveButton_Click(object sender, EventArgs e)
        {
            Controller.controller.OpenArchive();
        }

        #endregion

        #region Test Archive

        private void testTheArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.controller.TestArchive();
        }
        private void TestArchiveButton_Click(object sender, EventArgs e)
        {
            Controller.controller.TestArchive();
        }

        #endregion

        #region Extract Archive

        private void theFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.controller.ExtractArchive();
        }

        private void ExtractArchiveButton_Click(object sender, EventArgs e)
        {
            Controller.controller.ExtractArchive();
        }

        #endregion

        #region Close Archive

        private void CloseArchiveButton_Click(object sender, EventArgs e)
        {
            Controller.controller.CloseArchive();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.controller.CloseArchive();
        }

        #endregion

        #region Add File

        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.controller.AddFile();
        }

        private void addFileButton_Click(object sender, EventArgs e)
        {
            Controller.controller.AddFile();
        }



        #endregion

        #region Extract File

        private void theArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.controller.ExtractFile();
        }

        private void ExtractFileButton_Click(object sender, EventArgs e)
        {
            Controller.controller.ExtractFile();

        }

        #endregion


        #region Test File

        private void testTheFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Controller.controller.TestFile();
        }

        private void TestFileButton_Click(object sender, EventArgs e)
        {
            Controller.controller.TestFile();

        }

        #endregion

        #region Remove File

        private void removeTheFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.controller.RemoveFile();
        }

        private void RemoveFileButton_Click(object sender, EventArgs e)
        {
            Controller.controller.RemoveFile();

        }

        #endregion

        #region Exit

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Controller.controller.Exit();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.controller.Exit();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Controller.controller.Exit();
            }
        }



        #endregion

        #region Shortcuts

        private void shortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ShortcutsWindow().Show();
        }

        #endregion

        #region Show Hide Controls

        public void ShowWelcome()
        {
            welcomePanel.Visible = true;
        }

        public void HideWelcome()
        {
            welcomePanel.Visible = false;
        }

        public void ShowControlPanel()
        {
            ArchiveViewerPanel.Visible = true;

        }

        public void HideControlPanel()
        {
            ArchiveViewerPanel.Visible = false;
        }
        public void ShowViewer()
        {
            ArchiveVIEWER.Visible = true;
        }

        public void HideViewer()
        {
            ArchiveVIEWER.Visible = false;
        }

        public void ShowOpenedArchiveControls()
        {
            TestArchiveButton.BackgroundImage = Properties.Resources.TestArchive;
            ExtractArchiveButton.BackgroundImage = Properties.Resources.ExtractArchive;
            CloseArchiveButton.BackgroundImage = Properties.Resources.CloseArchive;
            addFileButton.BackgroundImage = Properties.Resources.AddFile;
            TestArchiveButton.Enabled = true;
            ExtractArchiveButton.Enabled = true;
            CloseArchiveButton.Enabled = true;
            testTheArchiveToolStripMenuItem.Enabled = true;
            theFileToolStripMenuItem.Enabled = true;
            closeToolStripMenuItem.Enabled = true;
            addFileToolStripMenuItem.Enabled = true;
            addFileButton.Enabled = true;
            
        }
        public void HideOpenedArchiveControls()
        {
            TestArchiveButton.BackgroundImage = Properties.Resources.TestArchiveINACTIVE;
            ExtractArchiveButton.BackgroundImage = Properties.Resources.ExtractArchiveINACTIVE;
            CloseArchiveButton.BackgroundImage = Properties.Resources.CloseArchiveINACTIVE;
            addFileButton.BackgroundImage = Properties.Resources.AddFileINACTIVE;
            TestArchiveButton.Enabled = false;
            ExtractArchiveButton.Enabled = false;
            CloseArchiveButton.Enabled = false;
            testTheArchiveToolStripMenuItem.Enabled = false;
            theFileToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = false;
            addFileToolStripMenuItem.Enabled = false;
            addFileButton.Enabled = false;
            
        }



        public void ShowSelectedFileControls()
        {
            RemoveFileButton.BackgroundImage = Properties.Resources.RemoveFile;
            TestFileButton.BackgroundImage = Properties.Resources.TestFile;
            ExtractFileButton.BackgroundImage = Properties.Resources.ExtractFile;
            ExtractFileButton.Enabled = true;
            TestFileButton.Enabled = true;
            RemoveFileButton.Enabled = true;
            theArchiveToolStripMenuItem.Enabled = true;
            testTheFileToolStripMenuItem1.Enabled = true;
            removeTheFileToolStripMenuItem.Enabled = true;

        }

        public void HideSelectedFileControls()
        {
            RemoveFileButton.BackgroundImage = Properties.Resources.RemoveFileINACTIVE;
            TestFileButton.BackgroundImage = Properties.Resources.TestFileINACTIVE;
            ExtractFileButton.BackgroundImage = Properties.Resources.ExtractFileINACTIVE;
            ExtractFileButton.Enabled = false;
            TestFileButton.Enabled = false;
            RemoveFileButton.Enabled = false;
            theArchiveToolStripMenuItem.Enabled = false;
            testTheFileToolStripMenuItem1.Enabled = false;
            removeTheFileToolStripMenuItem.Enabled = false;
        }

        #endregion

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ShowWelcome();
            HideControlPanel();
            HideOpenedArchiveControls();
            HideSelectedFileControls();
        }

        private void ArchiveVIEWER_SelectionChanged(object sender, EventArgs e)
        {
            Controller.controller.CheckSelection();
        }

        private void ArchiveVIEWER_VisibleChanged(object sender, EventArgs e)
        {
            Controller.controller.CheckSelection();
        }
    }
}
