using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildfilePRO
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
            FileSelectWindow fileSelectWindow = new FileSelectWindow();
            Application.Run(fileSelectWindow);

            if (fileSelectWindow.filePathSet)
            {
                string filePath = fileSelectWindow.filePath;
                if (filePath != Properties.Settings.Default["LastFolder"].ToString())
                {
                    Properties.Settings.Default["LastFolder"] = filePath;
                    Properties.Settings.Default.Save();
                }

                Editor editor = new Editor(filePath);
                Application.Run(editor);
            }

            Application.Exit();
        }
    }
}
