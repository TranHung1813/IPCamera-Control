using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPCameraManager
{
    public partial class PageSetupCamera_Info : UserControl
    {
        public PageSetupCamera_Info()
        {
            InitializeComponent();
            Init_IPCamera();
        }
        // Speed range: 1,2,3,4,5,6,7.
        private CameraManager_Type MainCam_Manager = new CameraManager_Type();
        private CameraManager_Type SecondaryCam_Manager = new CameraManager_Type();
        CHCNetSDK.REALDATACALLBACK RealData_Main = null;
        CHCNetSDK.REALDATACALLBACK RealData_Second = null;

        private uint Err_Return;
        private const int ERR_OK = 0;
        private const int ERR_NOT_OK = 1;
        private const int ERR_NONE = -1;

        public CHCNetSDK.NET_DVR_PTZPOS m_struPtzCfg_main;
        public CHCNetSDK.NET_DVR_PTZPOS m_struPtzCfg_second;
        private CHCNetSDK.NET_DVR_PTZSCOPE m_struPtzCfg1_main;
        private CHCNetSDK.NET_DVR_PTZSCOPE m_struPtzCfg1_second;
        //private const int MAXSPEED_PTZ = 7;
        private const int Default_Speed_PTZ_MainCam = 1;
        private const int Default_Speed_PTZ_Cam2 = 5;
        private int MainCam_MaxZoom = 0;
        private int MainCam_MinZoom = 0;
        private int MainCam_MaxPan = 0;
        private int MainCam_MinPan = 0;
        private int MainCam_MaxTilt = 0;
        private int MainCam_MinTilt = 0;
        private int Cam2_MaxZoom = 0;
        private int Cam2_MinZoom = 0;
        private int Cam2_MaxPan = 0;
        private int Cam2_MinPan = 0;
        private int Cam2_MaxTilt = 0;
        private int Cam2_MinTilt = 0;

        private int CurrentCamID = 0;
        private const int CAM1 = 1;
        private const int CAM2 = 2;

        uint Brightness_MainCam = 0;
        uint Contrast_MainCam = 0;
        uint Saturation_MainCam = 0;
        uint hue_MainCam = 0;
        uint Brightness_Cam2 = 0;
        uint Contrast_Cam2 = 0;
        uint Saturation_Cam2 = 0;
        uint hue_Cam2 = 0;

        Timer timerBrightness = new Timer();
        Timer timerContrast = new Timer();
        Timer timerSaturation = new Timer();
        Timer timerhue = new Timer();
        private void Init_IPCamera()
        {
            /* Init Cam chinh */
            MainCam_Manager.InitCam_Status = CHCNetSDK.NET_DVR_Init();
            if (MainCam_Manager.InitCam_Status == false)
            {
                MessageBox.Show("NET_DVR_Init error!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //Set Folder to save the SDK log
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
            }
            /* Init Cam phu */
            SecondaryCam_Manager.InitCam_Status = CHCNetSDK.NET_DVR_Init();
            if (SecondaryCam_Manager.InitCam_Status == false)
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
            // End Main Cam
            if (MainCam_Manager.Live_Status >= 0)
            {
                CHCNetSDK.NET_DVR_StopRealPlay(MainCam_Manager.Live_Status);
            }
            if (MainCam_Manager.InitCam_Status == true)
            {
                CHCNetSDK.NET_DVR_Cleanup();
            }
            if (MainCam_Manager.LoginInfo.LoginStatus >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(MainCam_Manager.LoginInfo.LoginStatus);
            }
            // End Secondary Cam
            if (SecondaryCam_Manager.Live_Status >= 0)
            {
                CHCNetSDK.NET_DVR_StopRealPlay(MainCam_Manager.Live_Status);
            }
            if (SecondaryCam_Manager.InitCam_Status == true)
            {
                CHCNetSDK.NET_DVR_Cleanup();
            }
            if (SecondaryCam_Manager.LoginInfo.LoginStatus >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(SecondaryCam_Manager.LoginInfo.LoginStatus);
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
        public void SetLoginCamera_Info(LoginCameraInfo_Type Main_info, LoginCameraInfo_Type Second_info)
        {
            MainCam_Manager.LoginInfo = Main_info;
            SecondaryCam_Manager.LoginInfo = Second_info;
        }
        private void RealDataCallBack_Main(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            //if (dwBufSize > 0)
            //{
            //    MAINCAM_Data_Available = true;
            //}
        }
        public int Start_PlayMainCam()
        {
            if (MainCam_Manager.LoginInfo.LoginStatus < 0)
            {
                MessageBox.Show("Camera chưa kết nối!\rHãy kết nối camera trước.", "Lỗi: Chưa kết nối camera", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetImage_Main();
                return ERR_NOT_OK;
            }

            if (MainCam_Manager.Live_Status < 0)
            {
                CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                lpPreviewInfo.hPlayWnd = RealPlayWnd.Handle;
                lpPreviewInfo.lChannel = 1;
                lpPreviewInfo.dwStreamType = 0;
                lpPreviewInfo.dwLinkMode = 0x0000;
                lpPreviewInfo.bBlocked = true;
                lpPreviewInfo.dwDisplayBufNum = 1;
                lpPreviewInfo.byProtoType = 0;
                lpPreviewInfo.byPreviewMode = 0;

                if (RealData_Main == null)
                {
                    RealData_Main = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack_Main);
                }

                IntPtr pUser = new IntPtr();

                //Start live view 
                MainCam_Manager.Live_Status = CHCNetSDK.NET_DVR_RealPlay_V40(MainCam_Manager.LoginInfo.LoginStatus,
                                                                        ref lpPreviewInfo, RealData_Main, pUser);
                if (MainCam_Manager.Live_Status < 0)
                {

                    Err_Return = CHCNetSDK.NET_DVR_GetLastError();
                    string str = "Camera chính: Load video thất bại, error code = " + Err_Return;
                    MessageBox.Show(str, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetImage_Main();
                    return ERR_NOT_OK;
                }
                else
                {
                    ResetImage_Main();
                    return ERR_OK;
                }
            }
            else
            {
                return ERR_NONE;
            }
        }
        //Xoa hinh anh Loading gif trong picture box
        public void ResetImage_Main()
        {
            RealPlayWnd.Image = null;
        }
        public int Stop_PlayMainCam()
        {
            //if (MainCam_Manager.LoginInfo.LoginStatus < 0)
            //{
            //    MessageBox.Show("Camera chưa kết nối!\rHãy kết nối camera trước.", "Lỗi: Chưa kết nối camera", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return ERR_NOT_OK;
            //}
            if (MainCam_Manager.Live_Status < 0)
            {
                return ERR_NONE;
            }
            // Stop live view 
            if (!CHCNetSDK.NET_DVR_StopRealPlay(MainCam_Manager.Live_Status))
            {
                Err_Return = CHCNetSDK.NET_DVR_GetLastError();
                string str = "Camera chính: Dừng video thất bại, error code = " + Err_Return;
                MessageBox.Show(str, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ERR_NOT_OK;
            }
            else
            {
                MainCam_Manager.Live_Status = -1;
                RealPlayWnd.Refresh();
                return ERR_OK;
            }
        }
        public int Start_PlayCam2()
        {
            if (SecondaryCam_Manager.LoginInfo.LoginStatus < 0)
            {
                MessageBox.Show("Camera chưa kết nối!\rHãy kết nối camera trước.", "Lỗi: Chưa kết nối camera", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ERR_NOT_OK;
            }

            if (SecondaryCam_Manager.Live_Status < 0)
            {
                CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                lpPreviewInfo.hPlayWnd = RealPlayWnd.Handle;
                lpPreviewInfo.lChannel = 1;
                lpPreviewInfo.dwStreamType = 0;
                lpPreviewInfo.dwLinkMode = 0x0000;
                lpPreviewInfo.bBlocked = true;
                lpPreviewInfo.dwDisplayBufNum = 1;
                lpPreviewInfo.byProtoType = 0;
                lpPreviewInfo.byPreviewMode = 0;

                if (RealData_Second == null)
                {
                    RealData_Second = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack_Cam2);
                }

                IntPtr pUser = new IntPtr();

                //Start live view 
                SecondaryCam_Manager.Live_Status = CHCNetSDK.NET_DVR_RealPlay_V40(SecondaryCam_Manager.LoginInfo.LoginStatus,
                                                                        ref lpPreviewInfo, RealData_Second, pUser);
                if (SecondaryCam_Manager.Live_Status < 0)
                {
                    Err_Return = CHCNetSDK.NET_DVR_GetLastError();
                    string str = "Camera phụ: Load video thất bại, error code = " + Err_Return;
                    MessageBox.Show(str, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetImage_Second();
                    return ERR_NOT_OK;
                }
                else
                {
                    ResetImage_Second();
                    return ERR_OK;
                }
            }
            else
            {
                return ERR_NONE;
            }
        }
        //Xoa hinh anh Loading gif trong picture box imgPreview
        public void ResetImage_Second()
        {
            RealPlayWnd.Image = null;
        }

        public int Stop_PlayCam2()
        {
            //if (SecondaryCam_Manager.LoginInfo.LoginStatus < 0)
            //{
            //    MessageBox.Show("Camera chưa kết nối!\rHãy kết nối camera trước.", "Lỗi: Chưa kết nối camera", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return ERR_NOT_OK;
            //}
            if (SecondaryCam_Manager.Live_Status < 0)
            {
                return ERR_NONE;
            }
            // Stop live view 
            if (!CHCNetSDK.NET_DVR_StopRealPlay(SecondaryCam_Manager.Live_Status))
            {
                Err_Return = CHCNetSDK.NET_DVR_GetLastError();
                string str = "Camera chính: Dừng video thất bại, error code = " + Err_Return;
                MessageBox.Show(str, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ERR_NOT_OK;
            }
            else
            {
                SecondaryCam_Manager.Live_Status = -1;
                RealPlayWnd.Refresh();
                return ERR_OK;
            }
        }
        public void RealDataCallBack_Cam2(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            //if (dwBufSize > 0)
            //{
            //    CAM2_Data_Available = true;
            //}
        }
        private void btnUp_MouseDown(object sender, MouseEventArgs e)
        {
            //Up_MouseDown
            if (CurrentCamID == CAM1)
            {
                if (MainCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.TILT_UP, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_UP, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
            }
            else
            {
                if (SecondaryCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.TILT_UP, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_UP, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
            }
        }

        private void btnUp_MouseUp(object sender, MouseEventArgs e)
        {
            //Up_MouseUp
            if (CurrentCamID == CAM1)
            {
                if (MainCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.TILT_UP, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_UP, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
            }
            else if (CurrentCamID == CAM2)
            {
                if (SecondaryCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.TILT_UP, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_UP, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
            }
        }
        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            //Right_MouseDown
            if (CurrentCamID == CAM1)
            {
                if (MainCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.PAN_RIGHT, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_RIGHT, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
            }
            else if (CurrentCamID == CAM2)
            {
                if (SecondaryCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.PAN_RIGHT, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_RIGHT, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
            }
        }

        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            //Right_MouseUp
            if (CurrentCamID == CAM1)
            {
                if (MainCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.PAN_RIGHT, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_RIGHT, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
            }
            else if (CurrentCamID == CAM2)
            {
                if (SecondaryCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.PAN_RIGHT, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_RIGHT, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
            }
        }

        private void btnDown_MouseDown(object sender, MouseEventArgs e)
        {
            //Down_MouseDown
            if (CurrentCamID == CAM1)
            {
                if (MainCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.TILT_DOWN, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_DOWN, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
            }
            else if (CurrentCamID == CAM2)
            {
                if (SecondaryCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.TILT_DOWN, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_DOWN, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
            }
        }

        private void btnDown_MouseUp(object sender, MouseEventArgs e)
        {
            //DownMouseUp
            if (CurrentCamID == CAM1)
            {
                if (MainCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.TILT_DOWN, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_DOWN, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
            }
            else if (CurrentCamID == CAM2)
            {
                if (SecondaryCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.TILT_DOWN, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_DOWN, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
            }
        }
        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            //Left_MouseDown
            if (CurrentCamID == CAM1)
            {
                if (MainCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.PAN_LEFT, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_LEFT, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
            }
            else if (CurrentCamID == CAM2)
            {
                if (SecondaryCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.PAN_LEFT, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_LEFT, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
            }
        }

        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            //Left_MouseUp
            if (CurrentCamID == CAM1)
            {
                if (MainCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.PAN_LEFT, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_LEFT, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
            }
            else if (CurrentCamID == CAM2)
            {
                if (SecondaryCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.PAN_LEFT, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_LEFT, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
            }
        }

        private void PageSetupCamera_Info_Load(object sender, EventArgs e)
        {
            btMainCam_Click(sender, e);
        }
        private void PtzRange_MainCam_Click(object sender, EventArgs e)
        {
            UInt32 dwReturn = 0;
            Int32 nSize = Marshal.SizeOf(m_struPtzCfg1_main);
            IntPtr ptrPtzCfg = Marshal.AllocHGlobal(nSize);
            Marshal.StructureToPtr(m_struPtzCfg1_main, ptrPtzCfg, false);

            // Get PTZ Range Fail
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(MainCam_Manager.LoginInfo.LoginStatus, CHCNetSDK.NET_DVR_GET_PTZSCOPE, -1, ptrPtzCfg, (UInt32)nSize, ref dwReturn))
            {
                uint Err_return = CHCNetSDK.NET_DVR_GetLastError();
                string str = "Lấy thông tin PTZ thất bại, error code= " + Err_return;
                MessageBox.Show(str);
                return;
            }
            else
            {
                m_struPtzCfg1_main = (CHCNetSDK.NET_DVR_PTZSCOPE)Marshal.PtrToStructure(ptrPtzCfg, typeof(CHCNetSDK.NET_DVR_PTZSCOPE));
                // Get PTZ Range success
                ushort wPanPosMax = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1_main.wPanPosMax, 16));
                float WPanPosMax = wPanPosMax * 0.1f;
                ushort wTiltPosMax = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1_main.wTiltPosMax, 16));
                float WTiltPosMax = wTiltPosMax * 0.1f;
                ushort wZoomPosMax = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1_main.wZoomPosMax, 16));
                float WZoomPosMax = wZoomPosMax * 0.1f;
                ushort wPanPosMin = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1_main.wPanPosMin, 16));
                float WPanPosMin = wPanPosMin * 0.1f;
                ushort wTiltPosMin = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1_main.wTiltPosMin, 16));
                float WTiltPosMin = wTiltPosMin * 0.1f;
                ushort wZoomPosMin = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1_main.wZoomPosMin, 16));
                float WZoomPosMin = wZoomPosMin * 0.1f;

                MainCam_MaxPan = (int)WPanPosMax;
                MainCam_MinPan = (int)WPanPosMin;
                MainCam_MaxZoom = (int)WZoomPosMax;
                MainCam_MinZoom = (int)WZoomPosMin;
                MainCam_MaxTilt = (int)WTiltPosMax;
                MainCam_MinTilt = (int)WTiltPosMin;

                tB_Zoom.Maximum = MainCam_MaxZoom;
                tB_Zoom.Minimum = MainCam_MinZoom;
            }
            return;
        }
        private void PtzRange_SecondaryCam_Click(object sender, EventArgs e)
        {
            UInt32 dwReturn = 0;
            Int32 nSize = Marshal.SizeOf(m_struPtzCfg1_second);
            IntPtr ptrPtzCfg = Marshal.AllocHGlobal(nSize);
            Marshal.StructureToPtr(m_struPtzCfg1_second, ptrPtzCfg, false);

            // Get PTZ Range Fail
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(SecondaryCam_Manager.LoginInfo.LoginStatus, CHCNetSDK.NET_DVR_GET_PTZSCOPE, -1, ptrPtzCfg, (UInt32)nSize, ref dwReturn))
            {
                uint Err_return = CHCNetSDK.NET_DVR_GetLastError();
                string str = "Lấy thông tin PTZ thất bại, error code= " + Err_return;
                MessageBox.Show(str);
                return;
            }
            else
            {
                m_struPtzCfg1_second = (CHCNetSDK.NET_DVR_PTZSCOPE)Marshal.PtrToStructure(ptrPtzCfg, typeof(CHCNetSDK.NET_DVR_PTZSCOPE));
                // Get PTZ Range success
                ushort wPanPosMax = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1_second.wPanPosMax, 16));
                float WPanPosMax = wPanPosMax * 0.1f;
                ushort wTiltPosMax = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1_second.wTiltPosMax, 16));
                float WTiltPosMax = wTiltPosMax * 0.1f;
                ushort wZoomPosMax = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1_second.wZoomPosMax, 16));
                float WZoomPosMax = wZoomPosMax * 0.1f;
                ushort wPanPosMin = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1_second.wPanPosMin, 16));
                float WPanPosMin = wPanPosMin * 0.1f;
                ushort wTiltPosMin = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1_second.wTiltPosMin, 16));
                float WTiltPosMin = wTiltPosMin * 0.1f;
                ushort wZoomPosMin = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1_second.wZoomPosMin, 16));
                float WZoomPosMin = wZoomPosMin * 0.1f;

                Cam2_MaxPan = (int)WPanPosMax;
                Cam2_MinPan = (int)WPanPosMin;
                Cam2_MaxZoom = (int)WZoomPosMax;
                Cam2_MinZoom = (int)WZoomPosMin;
                Cam2_MaxTilt = (int)WTiltPosMax;
                Cam2_MinTilt = (int)WTiltPosMin;

                tB_Zoom.Maximum = Cam2_MaxZoom;
                tB_Zoom.Minimum = Cam2_MinZoom;
            }
            return;
        }
        private void btMainCam_Click(object sender, EventArgs e)
        {
            CurrentCamID = CAM1;
            PtzRange_MainCam_Click(sender, e);
            Load_VideoEffect();
            if (SecondaryCam_Manager.Live_Status >= 0)
            {
                if (ERR_OK == Stop_PlayCam2())
                {
                    if (MainCam_Manager.Live_Status < 0)
                    {
                        if (ERR_OK == Start_PlayMainCam())
                        {

                        }
                        else
                        {
                            //this.Dispose();
                        }
                    }
                }
                else
                {
                    //this.Dispose();
                }
            }
            else
            {
                if (MainCam_Manager.Live_Status < 0)
                {
                    if (ERR_OK == Start_PlayMainCam())
                    {

                    }
                    else
                    {
                        //this.Dispose();
                    }
                }
            }    
        }

        private void btCam2_Click(object sender, EventArgs e)
        {
            CurrentCamID = CAM2;
            PtzRange_SecondaryCam_Click(sender, e);
            Load_VideoEffect();
            if (MainCam_Manager.Live_Status >= 0)
            {
                if (ERR_OK == Stop_PlayMainCam())
                {
                    if (SecondaryCam_Manager.Live_Status < 0)
                    {
                        if (ERR_OK == Start_PlayCam2())
                        {

                        }
                        else
                        {
                            //this.Dispose();
                        }
                    }
                }
                else
                {
                    //this.Dispose();
                }
            }
            else
            {
                if (SecondaryCam_Manager.Live_Status < 0)
                {
                    if (ERR_OK == Start_PlayCam2())
                    {

                    }
                    else
                    {
                        //this.Dispose();
                    }
                }
            }
        }

        private void btCrossRU_MouseDown(object sender, MouseEventArgs e)
        {
            if (CurrentCamID == CAM1)
            {
                if (MainCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.PAN_RIGHT, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.TILT_UP, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_RIGHT, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_UP, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
            }
            else if (CurrentCamID == CAM2)
            {
                if (SecondaryCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.PAN_RIGHT, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.TILT_UP, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_RIGHT, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_UP, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
            }
        }

        private void btCrossRU_MouseUp(object sender, MouseEventArgs e)
        {
            if (CurrentCamID == CAM1)
            {
                if (MainCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.PAN_RIGHT, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.TILT_UP, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_RIGHT, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_UP, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
            }
            else if (CurrentCamID == CAM2)
            {
                if (SecondaryCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.PAN_RIGHT, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.TILT_UP, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_RIGHT, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_UP, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
            }
        }

        private void btCross_RD_MouseDown(object sender, MouseEventArgs e)
        {
            //RightDown_MouseDown
            if (CurrentCamID == CAM1)
            {
                if (MainCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.TILT_DOWN, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.PAN_RIGHT, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_DOWN, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_RIGHT, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
            }
            else
            {
                if (SecondaryCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.TILT_DOWN, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.PAN_RIGHT, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_DOWN, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_RIGHT, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
            }
        }

        private void btCross_RD_MouseUp(object sender, MouseEventArgs e)
        {
            //RightDown_MouseUp
            if (CurrentCamID == CAM1)
            {
                if (MainCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.PAN_RIGHT, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.TILT_DOWN, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_RIGHT, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_DOWN, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
            }
            else if (CurrentCamID == CAM2)
            {
                if (SecondaryCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.PAN_RIGHT, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.TILT_DOWN, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_RIGHT, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_DOWN, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
            }
        }

        private void btCross_LD_MouseUp(object sender, MouseEventArgs e)
        {
            //LeftDown_MouseUp
            if (CurrentCamID == CAM1)
            {
                if (MainCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.TILT_DOWN, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.PAN_LEFT, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_DOWN, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_LEFT, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
            }
            else if (CurrentCamID == CAM2)
            {
                if (SecondaryCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.TILT_DOWN, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.PAN_LEFT, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_DOWN, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_LEFT, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
            }
        }

        private void btCross_LD_MouseDown(object sender, MouseEventArgs e)
        {
            //LeftDown_MouseDown
            if (CurrentCamID == CAM1)
            {
                if (MainCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.TILT_DOWN, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.PAN_LEFT, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_DOWN, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_LEFT, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
            }
            else if(CurrentCamID == CAM2)
            {
                if (SecondaryCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.TILT_DOWN, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.PAN_LEFT, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_DOWN, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_LEFT, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
            }
        }

        private void btCross_LU_MouseUp(object sender, MouseEventArgs e)
        {
            //LeftUp_MouseUp
            if (CurrentCamID == CAM1)
            {
                if (MainCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.PAN_LEFT, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.TILT_UP, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_LEFT, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_UP, 1, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
            }
            else if(CurrentCamID == CAM2)
            {
                if (SecondaryCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.PAN_LEFT, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.TILT_UP, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_LEFT, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_UP, 1, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
            }
        }

        private void btCross_LU_MouseDown(object sender, MouseEventArgs e)
        {
            //LeftUp_MouseDown
            if (CurrentCamID == CAM1)
            {
                if (MainCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.PAN_LEFT, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCam_Manager.Live_Status, CHCNetSDK.TILT_UP, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_LEFT, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_UP, 0, (uint)(Default_Speed_PTZ_MainCam) + 1);
                }
            }
            else if(CurrentCamID == CAM2)
            {
                if (SecondaryCam_Manager.Live_Status > -1)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.PAN_LEFT, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(SecondaryCam_Manager.Live_Status, CHCNetSDK.TILT_UP, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_LEFT, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(SecondaryCam_Manager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_UP, 0, (uint)(Default_Speed_PTZ_Cam2) + 1);
                }
            }
        }

        private void tB_Zoom_ValueChanged(object sender, EventArgs e)
        {
            if (CurrentCamID == CAM1)
            {
                string str3;
                int flag = 1;
                flag = 0;
                m_struPtzCfg_main.wAction = 4;
                m_struPtzCfg_main.wZoomPos = (ushort)tB_Zoom.Value;

                str3 = Convert.ToString((float)(tB_Zoom.Value * 10));
                m_struPtzCfg_main.wZoomPos = (ushort)(Convert.ToUInt16(str3, 16));

                while (flag == 0)
                {

                    Int32 nSize = Marshal.SizeOf(m_struPtzCfg_main);
                    IntPtr ptrPtzCfg = Marshal.AllocHGlobal(nSize);
                    Marshal.StructureToPtr(m_struPtzCfg_main, ptrPtzCfg, false);

                    if (!CHCNetSDK.NET_DVR_SetDVRConfig(MainCam_Manager.LoginInfo.LoginStatus, CHCNetSDK.NET_DVR_SET_PTZPOS, 1, ptrPtzCfg, (UInt32)nSize))
                    {
                        uint Err_Return = CHCNetSDK.NET_DVR_GetLastError();
                        string str = "NET_DVR_SetDVRConfig failed, error code= " + Err_Return;
                        // Khong the dat tham so PTZ
                        MessageBox.Show(str);
                        Marshal.FreeHGlobal(ptrPtzCfg);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Cài đặt thành công!");
                        Marshal.FreeHGlobal(ptrPtzCfg);
                        break;
                    }

                }
                return;
            }
            else if(CurrentCamID == CAM2)
            {
                string str3;
                int flag = 1;
                flag = 0;
                m_struPtzCfg_second.wAction = 4;
                m_struPtzCfg_second.wZoomPos = (ushort)tB_Zoom.Value;

                str3 = Convert.ToString((float)(tB_Zoom.Value * 10));
                m_struPtzCfg_second.wZoomPos = (ushort)(Convert.ToUInt16(str3, 16));

                while (flag == 0)
                {

                    Int32 nSize = Marshal.SizeOf(m_struPtzCfg_second);
                    IntPtr ptrPtzCfg = Marshal.AllocHGlobal(nSize);
                    Marshal.StructureToPtr(m_struPtzCfg_second, ptrPtzCfg, false);

                    if (!CHCNetSDK.NET_DVR_SetDVRConfig(SecondaryCam_Manager.LoginInfo.LoginStatus, CHCNetSDK.NET_DVR_SET_PTZPOS, 1, ptrPtzCfg, (UInt32)nSize))
                    {
                        uint Err_Return = CHCNetSDK.NET_DVR_GetLastError();
                        string str = "NET_DVR_SetDVRConfig failed, error code= " + Err_Return;
                        // Khong the dat tham so PTZ
                        MessageBox.Show(str);
                        Marshal.FreeHGlobal(ptrPtzCfg);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Cài đặt thành công!");
                        Marshal.FreeHGlobal(ptrPtzCfg);
                        break;
                    }

                }
                return;
            }
            
        }

        private void btZoomOut_Click(object sender, EventArgs e)
        {
            try
            {
                tB_Zoom.Value--;
            }
            catch
            {

            }
        }

        private void btZoomIn_Click(object sender, EventArgs e)
        {
            try
            {
                tB_Zoom.Value++;
            }
            catch
            {

            }
        }
        private void Load_VideoEffect()
        {
            if(CurrentCamID == CAM1)
            {
                // Get value from Main Camera
                CHCNetSDK.NET_DVR_GetVideoEffect(MainCam_Manager.LoginInfo.LoginStatus, 1,
                            ref Brightness_MainCam, ref Contrast_MainCam, ref Saturation_MainCam, ref hue_MainCam);
                //Set value for Slider
                Slide_Brightness.Percentage = (int)Brightness_MainCam * 10;
                Slide_Contrast.Percentage = (int)Contrast_MainCam * 10;
                Slide_Saturation.Percentage = (int)Saturation_MainCam * 10;
                Slide_hue.Percentage = (int)hue_MainCam * 10;
            }
            else if(CurrentCamID == CAM2)
            {
                // Get value from Secondary Camera
                CHCNetSDK.NET_DVR_GetVideoEffect(SecondaryCam_Manager.LoginInfo.LoginStatus, 1,
                            ref Brightness_Cam2, ref Contrast_Cam2, ref Saturation_Cam2, ref hue_Cam2);
                //Set value for Slider
                Slide_Brightness.Percentage = (int)Brightness_Cam2 * 10;
                Slide_Contrast.Percentage = (int)Contrast_Cam2 * 10;
                Slide_Saturation.Percentage = (int)Saturation_Cam2 * 10;
                Slide_hue.Percentage = (int)hue_Cam2 * 10;
            }

        }
        private void Change_Brightness()
        {
            if (CurrentCamID == CAM1)
            {
                uint Value = (uint)(Slide_Brightness.Percentage / 10);
                if (Brightness_MainCam != Value)
                {
                    // Set value for Main Camera
                    Brightness_MainCam = Value;
                    bool result = CHCNetSDK.NET_DVR_SetVideoEffect(MainCam_Manager.LoginInfo.LoginStatus, 1,
                                        Brightness_MainCam, Contrast_MainCam, Saturation_MainCam, hue_MainCam);
                    if (result == true)
                    {
                        //MessageBox.Show("Success");
                    }
                }
            }
            else if (CurrentCamID == CAM2)
            {
                uint Value = (uint)(Slide_Brightness.Percentage / 10);
                if (Brightness_Cam2 != Value)
                {
                    // Set value for Main Camera
                    Brightness_Cam2 = Value;
                    bool result = CHCNetSDK.NET_DVR_SetVideoEffect(SecondaryCam_Manager.LoginInfo.LoginStatus, 1,
                                        Brightness_Cam2, Contrast_Cam2, Saturation_Cam2, hue_Cam2);
                    if (result == true)
                    {
                        //MessageBox.Show("Success");
                    }
                }
            }
        }
        private void Slide_Brightness_Scroll(object sender, EventArgs e)
        {
            timerBrightness.Enabled = true;
            timerBrightness.Interval = 400;
            timerBrightness.Tick += Timer_BrightNess_Tick;
            timerBrightness.Start();
        }

        private void Timer_BrightNess_Tick(object sender, EventArgs e)
        {
            Change_Brightness();
            timerBrightness.Stop();
        }
        private void ChangeContrast()
        {
            if (CurrentCamID == CAM1)
            {
                uint Value = (uint)(Slide_Contrast.Percentage / 10);
                if (Contrast_MainCam != Value)
                {
                    // Set value for Main Camera
                    Contrast_MainCam = Value;
                    bool result = CHCNetSDK.NET_DVR_SetVideoEffect(MainCam_Manager.LoginInfo.LoginStatus, 1,
                                        Brightness_MainCam, Contrast_MainCam, Saturation_MainCam, hue_MainCam);
                    if (result == true)
                    {
                        //MessageBox.Show("Success");
                    }
                }
            }
            else if (CurrentCamID == CAM2)
            {
                uint Value = (uint)(Slide_Contrast.Percentage / 10);
                if (Contrast_Cam2 != Value)
                {
                    // Set value for Main Camera
                    Contrast_Cam2 = Value;
                    bool result = CHCNetSDK.NET_DVR_SetVideoEffect(SecondaryCam_Manager.LoginInfo.LoginStatus, 1,
                                        Brightness_Cam2, Contrast_Cam2, Saturation_Cam2, hue_Cam2);
                    if (result == true)
                    {
                        //MessageBox.Show("Success");
                    }
                }
            }
        }
        private void Slide_Contrast_Scroll(object sender, EventArgs e)
        {
            timerContrast.Enabled = true;
            timerContrast.Interval = 400;
            timerContrast.Tick += Timer_Contrast_Tick;
            timerContrast.Start();
        }
        private void Timer_Contrast_Tick(object sender, EventArgs e)
        {
            ChangeContrast();
            timerContrast.Stop();
        }
        private void ChangeSaturation()
        {
            if (CurrentCamID == CAM1)
            {
                uint Value = (uint)(Slide_Saturation.Percentage / 10);
                if (Saturation_MainCam != Value)
                {
                    // Set value for Main Camera
                    Saturation_MainCam = Value;
                    bool result = CHCNetSDK.NET_DVR_SetVideoEffect(MainCam_Manager.LoginInfo.LoginStatus, 1,
                                        Brightness_MainCam, Contrast_MainCam, Saturation_MainCam, hue_MainCam);
                    if (result == true)
                    {
                        //MessageBox.Show("Success");
                    }
                }
            }
            else if (CurrentCamID == CAM2)
            {
                uint Value = (uint)(Slide_Saturation.Percentage / 10);
                if (Saturation_Cam2 != Value)
                {
                    // Set value for Main Camera
                    Saturation_Cam2 = Value;
                    bool result = CHCNetSDK.NET_DVR_SetVideoEffect(SecondaryCam_Manager.LoginInfo.LoginStatus, 1,
                                        Brightness_Cam2, Contrast_Cam2, Saturation_Cam2, hue_Cam2);
                    if (result == true)
                    {
                        //MessageBox.Show("Success");
                    }
                }
            }
        }
        private void Slide_Saturation_Scroll(object sender, EventArgs e)
        {
            timerSaturation.Enabled = true;
            timerSaturation.Interval = 400;
            timerSaturation.Tick += Timer_Saturation_Tick;
            timerSaturation.Start();
        }
        private void Timer_Saturation_Tick(object sender, EventArgs e)
        {
            ChangeSaturation();
            timerSaturation.Stop();
        }

        private void Change_hue()
        {
            if (CurrentCamID == CAM1)
            {
                uint Value = (uint)(Slide_hue.Percentage / 10);
                if (hue_MainCam != Value)
                {
                    // Set value for Main Camera
                    hue_MainCam = Value;
                    bool result = CHCNetSDK.NET_DVR_SetVideoEffect(MainCam_Manager.LoginInfo.LoginStatus, 1,
                                        Brightness_MainCam, Contrast_MainCam, Saturation_MainCam, hue_MainCam);
                    if (result == true)
                    {
                        //MessageBox.Show("Success");
                    }
                }
            }
            else if (CurrentCamID == CAM2)
            {
                uint Value = (uint)(Slide_hue.Percentage / 10);
                if (hue_Cam2 != Value)
                {
                    // Set value for Main Camera
                    hue_Cam2 = Value;
                    bool result = CHCNetSDK.NET_DVR_SetVideoEffect(SecondaryCam_Manager.LoginInfo.LoginStatus, 1,
                                        Brightness_Cam2, Contrast_Cam2, Saturation_Cam2, hue_Cam2);
                    if (result == true)
                    {
                        //MessageBox.Show("Success");
                    }
                }
            }
        }
        private void Slide_hue_Scroll(object sender, EventArgs e)
        {
            timerhue.Enabled = true;
            timerhue.Interval = 400;
            timerhue.Tick += Timer_hue_Tick;
            timerhue.Start();
        }
        private void Timer_hue_Tick(object sender, EventArgs e)
        {
            Change_hue();
            timerhue.Stop();
        }
    }
}
