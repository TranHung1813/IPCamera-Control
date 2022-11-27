using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPCameraManager
{
    public partial class FormSetTemplateDirectory : Form
    {
        public FormSetTemplateDirectory()
        {
            InitializeComponent();
        }
        private string MauPhieuKham_Path = @"D:\Hinh_Anh\MauPhieuKham\";
        private string FolderPath = "";

        private void btOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btBrowse1_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "File word (*.doc)|*.doc";
                openFileDialog.Title = "Chọn mẫu phiếu khám 1";
                openFileDialog.Multiselect = false;
                openFileDialog.FileName = "";

                if (FolderPath != "")
                {
                    openFileDialog.InitialDirectory = FolderPath;
                }
                else
                {
                    openFileDialog.InitialDirectory = MauPhieuKham_Path;
                }

                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    tbFileTemplate1.Text = openFileDialog.FileName;
                }
            }
        }

        private void btBrowse2_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "File word (*.doc)|*.doc";
                openFileDialog.Title = "Chọn mẫu phiếu khám 2";
                openFileDialog.Multiselect = false;
                openFileDialog.FileName = "";

                if (FolderPath != "")
                {
                    openFileDialog.InitialDirectory = FolderPath;
                }
                else
                {
                    openFileDialog.InitialDirectory = MauPhieuKham_Path;
                }

                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    tbFileTemplate2.Text = openFileDialog.FileName;
                }
            }
        }
    }
}
