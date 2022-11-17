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
    public partial class FormLoginCamera : Form
    {
        public FormLoginCamera(Int32 loginStatus, Int32 liveStatus)
        {
            InitializeComponent();
            LoginStatus = loginStatus;
            Live_Status = liveStatus;
        }
        private Int32 LoginStatus;
        private Int32 Live_Status;
        private uint Err_Return;
        private void btLogin_Click(object sender, EventArgs e)
        {
            if (textBoxIP.Text == "" || textBoxPort.Text == "" ||
                textBoxUserName.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Please input IP, Port, User name and Password!");
                return;
            }
            if (LoginStatus < 0)
            {
                string DVRIPAddress = textBoxIP.Text;
                Int16 DVRPortNumber = Int16.Parse(textBoxPort.Text);
                string DVRUserName = textBoxUserName.Text;
                string DVRPassword = textBoxPassword.Text;

                CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

                //Login the device
                LoginStatus = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                if (LoginStatus < 0)
                {
                    Err_Return = CHCNetSDK.NET_DVR_GetLastError();
                    string str = "NET_DVR_Login_V30 failed, error code= " + Err_Return; // Print Error Name through Message Box
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    //Login Success
                    MessageBox.Show("Kết nối Camera thành công!");
                    btLogin.Text = "Đăng xuất";
                }

            }
            else
            {
                // Logout the device
                if (Live_Status >= 0)
                {
                    MessageBox.Show("Please stop live view firstly");
                    return;
                }

                if (!CHCNetSDK.NET_DVR_Logout(LoginStatus))
                {
                    Err_Return = CHCNetSDK.NET_DVR_GetLastError();
                    string str = "NET_DVR_Logout failed, error code= " + Err_Return;
                    MessageBox.Show(str);
                    return;
                }
                LoginStatus = -1;
                btLogin.Text = "Đăng nhập";
            }
        }
    }
}
