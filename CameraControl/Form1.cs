using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public uint iLastErr = 0;

        UserControl_TabKhamBenh uc_KhamBenh = new UserControl_TabKhamBenh();
        FormLoginCamera formLoginCam;
        private void Form1_Load(object sender, EventArgs e)
        {
            Controls.Add(xtraTabControl1);
            Add_UserControl(xtTabPage_KhamBenh, uc_KhamBenh);
            formLoginCam = new FormLoginCamera(uc_KhamBenh.LoginStatus, uc_KhamBenh.Live_Status);
        }
        private void Add_UserControl(XtraTabPage tabPage, UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            tabPage.Controls.Clear();
            tabPage.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btDangnhapCamera_Click(object sender, EventArgs e)
        {
            formLoginCam.ShowDialog();
        }
    }
}
