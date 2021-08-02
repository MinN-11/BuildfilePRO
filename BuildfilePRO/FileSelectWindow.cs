using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildfilePRO
{
    public partial class FileSelectWindow : Form
    {
        public string filePath;
        public bool filePathSet = false;

        public FileSelectWindow()
        {
            InitializeComponent();
            CheckForSettings();
        }

        private void CheckForSettings()
        {
            if (Properties.Settings.Default["LastFolder"] != null && Directory.Exists(Properties.Settings.Default["LastFolder"].ToString())) {
                fileText.Text = Properties.Settings.Default["LastFolder"].ToString();
                advanceWindow.Enabled = true;
                advanceWindow.Select();
            } else {
                var cwd = Directory.GetCurrentDirectory();
                Console.WriteLine(cwd);
                if (IsBuildfileFolder(Directory.GetFiles(cwd))) {
                    fileText.Text = cwd;
                    advanceWindow.Enabled = true;
                    advanceWindow.Select();
                }
            }
        }

        private void fileSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (Properties.Settings.Default["LastFolder"] != null)
            {
                folderBrowserDialog.SelectedPath = Properties.Settings.Default["LastFolder"].ToString();
            }
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string[] directory = Directory.GetFiles(folderBrowserDialog.SelectedPath);
                if (IsBuildfileFolder(directory))
                {
                    fileText.Text = folderBrowserDialog.SelectedPath;
                    advanceWindow.Enabled = true;
                }
                else
                {
                    fileText.Text = "This folder is not valid buildfile folder.";
                    advanceWindow.Enabled = false;
                }

            }
            else if (result == DialogResult.Cancel) {} // QoL: clicking browse then cancel doesn't remove the path or the ability to click go
            else 
            {
                fileText.Text = "Invalid directory.";
                advanceWindow.Enabled = false;
            }
        }

        private bool IsBuildfileFolder(string[] filePath)
        {
            foreach (string file in filePath)
            {
                string fileName = Path.GetFileName(file);
                if (fileName.Equals("ROMBuildfile.event"))
                {
                    return true;
                }
            }
            return false;
        }

        private void advanceWindow_Click(object sender, EventArgs e)
        {
            filePath = fileText.Text;
            filePathSet = true;
            this.Close();
        }
    }
}
