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
    public partial class FormSetTemplateDirectory : Form
    {
        public FormSetTemplateDirectory()
        {
            InitializeComponent();
        }
        private string MauPhieuKham_Path = @"D:\Hinh_Anh\MauPhieuKham\";
        private string MauPhieuKham1_Path = "";
        private string MauPhieuKham2_Path = "";

        public void SetMauPhieuKhamPath (string FileName1, string FileName2)
        {
            MauPhieuKham1_Path = FileName1;
            MauPhieuKham2_Path = FileName2;
            tbFileTemplate1.Text = MauPhieuKham1_Path;
            tbFileTemplate2.Text = MauPhieuKham2_Path;

        }
        public void GetMauPhieuKhamPath(ref string FileName1, ref string FileName2)
        {
            MauPhieuKham1_Path = tbFileTemplate1.Text;
            MauPhieuKham2_Path = tbFileTemplate2.Text;
            FileName1 = MauPhieuKham1_Path;
            FileName2 = MauPhieuKham2_Path;
        }
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

                if (MauPhieuKham1_Path != "")
                {
                    try
                    {
                        openFileDialog.InitialDirectory = Path.GetDirectoryName(MauPhieuKham1_Path);
                    }
                    catch
                    {
                        openFileDialog.InitialDirectory = MauPhieuKham_Path;
                    }
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

                if (MauPhieuKham2_Path != "")
                {
                    try
                    {
                        openFileDialog.InitialDirectory = Path.GetDirectoryName(MauPhieuKham2_Path);
                    }
                    catch
                    {
                        openFileDialog.InitialDirectory = MauPhieuKham_Path;
                    }
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
