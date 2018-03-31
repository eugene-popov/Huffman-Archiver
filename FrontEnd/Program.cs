using System;
using System.Windows.Forms;

namespace FrontEnd
{
    public static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Controller.controller = new Controller();
            Controller.controller.mainWindow = new MainWindow();
            Application.Run(Controller.controller.mainWindow);
        }
    }
}