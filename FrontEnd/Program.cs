using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
          
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Controller.controller = new Controller();
            Controller.controller.mainWindow = new MainWindow();
            Controller.controller.OpenArchive("D:\\Huffman-Archiver\\BackEndTests\\bin\\Debug\\archive");
            Controller.controller.RefreshView();
            Application.Run(Controller.controller.mainWindow);
        }
    }
}
