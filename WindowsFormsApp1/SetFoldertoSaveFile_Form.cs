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

namespace IPCameraManager
{
    public partial class SetFoldertoSaveFile_Form : Form
    {
        public SetFoldertoSaveFile_Form()
        {
            InitializeComponent();
        }
        public void SetFolderName(string FolderPath)
        {
            string str = FolderPath;
            str.Replace("//", "\\");
            tbFolderName.Text = str;
        }
        public void GetFolderName(ref string FolderName)
        {
            string str = tbFolderName.Text;
            str.Replace("\\", "//");
            FolderName = str;
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new Ookii.Dialogs.WinForms.VistaFolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string str = fbd.SelectedPath;
                    str.Replace("//", "\\");
                    tbFolderName.Text = str;
                }
            }
        }

        private void btOK_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
