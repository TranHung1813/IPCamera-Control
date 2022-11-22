using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPCameraManager
{
    public partial class ShowCamera2Form : Form
    {
        public ShowCamera2Form(LoginCameraInfo_Type info)
        {
            InitializeComponent();
            Init_IPCamera();
            Login_Info = info;
        }
        private bool InitCam_Status = false;
        public Int32 Live_Status = -1;
        public Int32 LoginStatus = -1;
        CHCNetSDK.REALDATACALLBACK RealData = null;

        public LoginCameraInfo_Type Login_Info;

        private uint Err_Return;
        private const int ERR_OK = 0;
        private const int ERR_NOT_OK = 1;

        private void Init_IPCamera()
        {
            InitCam_Status = CHCNetSDK.NET_DVR_Init();
            if (InitCam_Status == false)
            {
                MessageBox.Show("NET_DVR_Init error!");
                return;
            }
            else
            {
                //Set Folder to save the SDK log
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog_Cam2\\", true);
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (Live_Status >= 0)
            {
                CHCNetSDK.NET_DVR_StopRealPlay(Live_Status);
            }
            if (InitCam_Status == true)
            {
                CHCNetSDK.NET_DVR_Cleanup();
            }
            if (LoginStatus >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(LoginStatus);
            }
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        public int Start_PlayCam()
        {
            if (LoginStatus < 0)
            {
                MessageBox.Show("Camera chưa kết nối!\rHãy kết nối camera trước.", "Lỗi: Chưa kết nối camera", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ERR_NOT_OK;
            }

            if (Live_Status < 0)
            {
                CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                lpPreviewInfo.hPlayWnd = pictureBox1.Handle;
                lpPreviewInfo.lChannel = 1;
                lpPreviewInfo.dwStreamType = 0;
                lpPreviewInfo.dwLinkMode = 0x0000;
                lpPreviewInfo.bBlocked = true;
                lpPreviewInfo.dwDisplayBufNum = 1;
                lpPreviewInfo.byProtoType = 0;
                lpPreviewInfo.byPreviewMode = 0;

                if (RealData == null)
                {
                    RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);
                }

                IntPtr pUser = new IntPtr();

                //Start live view 
                Live_Status = CHCNetSDK.NET_DVR_RealPlay_V40(LoginStatus, ref lpPreviewInfo, null/*RealData*/, pUser);
                if (Live_Status < 0)
                {
                    Err_Return = CHCNetSDK.NET_DVR_GetLastError();
                    string str = "Camera phụ: Load video thất bại, error code = " + Err_Return;
                    MessageBox.Show(str);
                    ResetImage();
                    return ERR_NOT_OK;
                }
                else
                {
                    ResetImage();
                    return ERR_OK;
                }
            }
            return ERR_NOT_OK;
        }
        public void ResetImage()
        {
            pictureBox1.Image = null;
        }
        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            if (dwBufSize > 0)
            {
                byte[] sData = new byte[dwBufSize];
                Marshal.Copy(pBuffer, sData, 0, (Int32)dwBufSize);

                string str = "Hi.ps";
                FileStream fs = new FileStream(str, FileMode.Create);
                int iLen = (int)dwBufSize;
                fs.Write(sData, 0, iLen);
                fs.Close();
            }
        }
        public int Stop_PlayCam()
        {
            if (LoginStatus < 0)
            {
                MessageBox.Show("Camera chưa kết nối!\rHãy kết nối camera trước.", "Lỗi: Chưa kết nối camera", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ERR_NOT_OK;
            }
            if (Live_Status < 0)
            {
                return ERR_NOT_OK;
            }
            // Stop live view 
            if (!CHCNetSDK.NET_DVR_StopRealPlay(Live_Status))
            {
                Err_Return = CHCNetSDK.NET_DVR_GetLastError();
                string str = "Camera phụ: Dừng video thất bại, error code = " + Err_Return;
                MessageBox.Show(str);
                return ERR_NOT_OK;
            }
            else
            {
                Live_Status = -1;
                return ERR_OK;
            }
        }
        public int Login_Camera(LoginCameraInfo_Type info)
        {
            if (LoginStatus < 0)
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
                LoginStatus = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                if (LoginStatus < 0)
                {
                    Err_Return = CHCNetSDK.NET_DVR_GetLastError();
                    string str = "Camera phụ: Đăng nhập thất bại, error code = " + Err_Return; // Print Error Name through Message Box
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
                    string str = "Camera phụ: Đăng xuất thất bại, error code = " + Err_Return;
                    MessageBox.Show(str);
                    return ERR_NOT_OK;
                }
                else
                {
                    //Logout Success
                    LoginStatus = -1;
                    return ERR_OK;
                }
            }
        }

        private void ShowCamera2Form_Load(object sender, EventArgs e)
        {
            // Start Login Camera
            if (LoginStatus < 0)
            {
                if (ERR_OK == Login_Camera(Login_Info))
                {
                    // Start live view Camera
                    if (Live_Status < 0)
                    {
                        if (ERR_OK == Start_PlayCam())
                        {

                        }
                        else
                        {
                            this.Dispose();
                        }
                    }
                }
                else
                {
                    this.Dispose();
                }
            }            
        }
    }
}
