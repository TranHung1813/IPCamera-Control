using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPCameraManager
{
    public partial class FormSetting_KeyboardShortcut : Form
    {
        public FormSetting_KeyboardShortcut()
        {
            InitializeComponent();
        }

        private void btExit_F12_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Key_TabKhamBenh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == false && e.Shift == false && e.Alt == false)
            {
                Key_TabKhamBenh.Text = e.KeyData.ToString();
            }
        }

        private void Key_TabInPhieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == false && e.Shift == false && e.Alt == false)
            {
                Key_TabInPhieu.Text = e.KeyData.ToString();
            }
        }

        private void Key_TabSettingCamera_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == false && e.Shift == false && e.Alt == false)
            {
                Key_TabSettingCamera.Text = e.KeyData.ToString();
            }
        }

        private void Key_TabFindPatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == false && e.Shift == false && e.Alt == false)
            {
                Key_TabFindPatient.Text = e.KeyData.ToString();
            }
        }

        private void Key_ChupAnh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == false && e.Shift == false && e.Alt == false)
            {
                Key_ChupAnh.Text = e.KeyData.ToString();
            }
        }

        private void Key_CaPhong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == false && e.Shift == false && e.Alt == false)
            {
                Key_CaPhong.Text = e.KeyData.ToString();
            }
        }

        private void Key_InPhieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == false && e.Shift == false && e.Alt == false)
            {
                Key_InPhieu.Text = e.KeyData.ToString();
            }
        }

        private void Key_Exit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == false && e.Shift == false && e.Alt == false)
            {
                Key_Exit.Text = e.KeyData.ToString();
            }
        }
    }
}
