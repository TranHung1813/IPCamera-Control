using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPCameraManager
{
    public partial class FormLoginCamera : Form
    {
        public FormLoginCamera(int loginStatus, int liveStatus)
        {
            InitializeComponent();
            Init_Button();
            Login_Info.LoginStatus = loginStatus;
            Live_Status = liveStatus;
        }
        public LoginCameraInfo_Type Login_Info;
        private int Live_Status;
        private uint Err_Return;

        private const int ERR_OK = 0;
        private const int ERR_NOT_OK = 1;
        private void Init_Button()
        {
            btLogin.GotFocus += (s, a) =>
            {
                btLogin.BorderColor = Color.RoyalBlue;
                btLogin.BorderThickness = 2;
            };
            btLogin.LostFocus += (s, a) =>
            {
                btLogin.BorderThickness = 1;
                btLogin.BorderColor = SystemColors.ControlDark;
            };
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (textBoxIP.Text == "" || textBoxPort.Text == "" ||
                textBoxUserName.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!", "WARNING",
                                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Luu thong tin tu textbox vao Login_Info de xu ly Login_Camera
            Login_Info.IP_Address = textBoxIP.Text;
            Login_Info.Port = textBoxPort.Text;
            Login_Info.Username = textBoxUserName.Text;
            Login_Info.Password = textBoxPassword.Text;
            if(Login_Info.LoginStatus < 0)
            {
                if (ERR_OK == Login_Camera(Login_Info))
                {
                    btLogin.Text = "Đăng xuất";
                    MessageBox.Show("Kết nối Camera thành công!");
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                if (ERR_OK == Logout_Camera(Login_Info))
                {
                    btLogin.Text = "Đăng nhập";
                }
            }

        }
        public int Login_Camera(LoginCameraInfo_Type info)
        {
            if (info.LoginStatus < 0)
            {
                string DVRIPAddress = info.IP_Address;
                Int16 DVRPortNumber = Int16.Parse(info.Port);
                string DVRUserName = info.Username;
                string DVRPassword = info.Password;

                try
                {
                    IPAddress address = IPAddress.Parse(DVRIPAddress);
                }
                catch
                {
                    MessageBox.Show("Địa chỉ IP không xác định!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return ERR_NOT_OK;
                }

                CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

                //Login the device
                Login_Info.LoginStatus = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                if (Login_Info.LoginStatus < 0)
                {
                    Err_Return = CHCNetSDK.NET_DVR_GetLastError();
                    string str = "NET_DVR_Login_V30 failed, error code= " + Err_Return; // Print Error Name through Message Box
                    MessageBox.Show(str);
                    return ERR_NOT_OK;
                }
                else
                {
                    //Login Success
                    return ERR_OK;
                }

            }
            else
            {
                // Already Login
                return ERR_NOT_OK;
            }
        }
        public int Logout_Camera(LoginCameraInfo_Type info)
        {
            if (info.LoginStatus < 0)
            {
                return ERR_NOT_OK;
            }
            else
            {
                // Logout the device
                if (Live_Status >= 0)
                {
                    MessageBox.Show("Hãy tắt Camera trước khi ngắt kết nối!", "WARNING",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return ERR_NOT_OK;
                }

                if (!CHCNetSDK.NET_DVR_Logout(info.LoginStatus))
                {
                    Err_Return = CHCNetSDK.NET_DVR_GetLastError();
                    string str = "NET_DVR_Logout failed, error code= " + Err_Return;
                    MessageBox.Show(str);
                    return ERR_NOT_OK;
                }
                else
                {
                    //Logout Success
                    Login_Info.LoginStatus = -1;
                    return ERR_OK;
                }
            }
        }
        public void Load_Database_Info(LoginCameraInfo_Type info)
        {
            textBoxIP.Text = info.IP_Address;
            textBoxPort.Text = info.Port;
            textBoxUserName.Text = info.Username;
            textBoxPassword.Text = info.Password;
        }
        public void Get_Login_Status(ref LoginCameraInfo_Type info)
        {
            info = Login_Info;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
    public struct LoginCameraInfo_Type
    {
        public string IP_Address;
        public string Port;
        public string Username;
        public string Password;
        public int LoginStatus;
    }
}
