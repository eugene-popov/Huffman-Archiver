using System;
using System.Collections.Generic;
using System.Linq;
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

        public void CreateArchive()
        {
            ArchiveOpened = true;
        }

        public void OpenArchive(string path)
        {
            archive = new Archive(path);
            ArchiveOpened = true;
        }
        

        public void TestArchive()
        {

        }

        public void ExtractArchive()
        {

        }

        public void CloseArchive()
        {
            ArchiveOpened = false;
        }

        public void AddFile()
        {

        }

        public void ExtractFile()
        {

        }

        public void TestFile()
        {

        }

        public void RemoveFile()
        {

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

        public void Exit()
        {
            Application.Exit();
        }
        public void ShowArchiveViewerPanel()
        {
            mainWindow.AdjustArchiveViewerColumnsWidth();
        }
    }
}
