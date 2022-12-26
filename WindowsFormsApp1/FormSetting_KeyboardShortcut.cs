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

        private void Key_TabKhamBenh_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Key_TabKhamBenh_KeyDown(object sender, KeyEventArgs e)
        {
            //Key_TabKhamBenh.Text = "";
            //Key_TabKhamBenh.Text += e.KeyCode.ToString();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            button1.Text = e.KeyData.ToString();
        }
    }
}
