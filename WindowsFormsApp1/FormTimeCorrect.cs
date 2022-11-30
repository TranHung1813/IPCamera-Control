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
    public partial class FormTimeCorrect : Form
    {
        public FormTimeCorrect()
        {
            InitializeComponent();
        }

        private CHCNetSDK.NET_DVR_TIME m_struTimeCfg_MainCam;
        private CHCNetSDK.NET_DVR_TIME m_struTimeCfg_Cam2;

        private CameraManager_Type MainCam_Manager = new CameraManager_Type();
        private CameraManager_Type SecondaryCam_Manager = new CameraManager_Type();

        private int CurrentTabID = 0;
        private const int TAB_MAINCAM = 1;
        private const int TAB_SECONDARYCAM = 2;

        private void btTabMainCam_Click(object sender, EventArgs e)
        {
            if(CurrentTabID != TAB_MAINCAM)
            {
                CurrentTabID = TAB_MAINCAM;
                btGetTime_Camera_Click(sender, e);
                btGetRealTime_Click(sender, e);
            }
        }

        private void btTabCam2_Click(object sender, EventArgs e)
        {
            if (CurrentTabID != TAB_SECONDARYCAM)
            {
                CurrentTabID = TAB_SECONDARYCAM;
                btGetTime_Camera_Click(sender, e);
                btGetRealTime_Click(sender, e);
            }
        }

        public void SetLoginCamera_Info(LoginCameraInfo_Type Main_info, LoginCameraInfo_Type Second_info)
        {
            MainCam_Manager.LoginInfo = Main_info;
            SecondaryCam_Manager.LoginInfo = Second_info;
        }

        private void btGetTime_Camera_Click(object sender, EventArgs e)
        {
            if (CurrentTabID == TAB_MAINCAM)
            {
                UInt32 dwReturn = 0;
                Int32 nSize = Marshal.SizeOf(m_struTimeCfg_MainCam);
                IntPtr ptrTimeCfg = Marshal.AllocHGlobal(nSize);
                Marshal.StructureToPtr(m_struTimeCfg_MainCam, ptrTimeCfg, false);
                if (!CHCNetSDK.NET_DVR_GetDVRConfig(MainCam_Manager.LoginInfo.LoginStatus, CHCNetSDK.NET_DVR_GET_TIMECFG, -1, ptrTimeCfg, (UInt32)nSize, ref dwReturn))
                {
                    uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    string strErr = "Lấy thông tin từ Camera thất bại, error code = " + iLastErr;
                    //Failed to get time of the device and output the error code
                    MessageBox.Show(strErr, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    m_struTimeCfg_MainCam = (CHCNetSDK.NET_DVR_TIME)Marshal.PtrToStructure(ptrTimeCfg, typeof(CHCNetSDK.NET_DVR_TIME));
                    textBoxYear.Text = Convert.ToString(m_struTimeCfg_MainCam.dwYear);
                    textBoxMonth.Text = Convert.ToString(m_struTimeCfg_MainCam.dwMonth);
                    textBoxDay.Text = Convert.ToString(m_struTimeCfg_MainCam.dwDay);
                    textBoxHour.Text = Convert.ToString(m_struTimeCfg_MainCam.dwHour);
                    textBoxMinute.Text = Convert.ToString(m_struTimeCfg_MainCam.dwMinute);
                    textBoxSecond.Text = Convert.ToString(m_struTimeCfg_MainCam.dwSecond);
                }
                Marshal.FreeHGlobal(ptrTimeCfg);
            }
            else if (CurrentTabID == TAB_SECONDARYCAM)
            {
                UInt32 dwReturn = 0;
                Int32 nSize = Marshal.SizeOf(m_struTimeCfg_Cam2);
                IntPtr ptrTimeCfg = Marshal.AllocHGlobal(nSize);
                Marshal.StructureToPtr(m_struTimeCfg_Cam2, ptrTimeCfg, false);
                if (!CHCNetSDK.NET_DVR_GetDVRConfig(SecondaryCam_Manager.LoginInfo.LoginStatus, CHCNetSDK.NET_DVR_GET_TIMECFG, -1, ptrTimeCfg, (UInt32)nSize, ref dwReturn))
                {
                    uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    string strErr = "Lấy thông tin từ Camera thất bại, error code = " + iLastErr;
                    //Failed to get time of the device and output the error code
                    MessageBox.Show(strErr, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    m_struTimeCfg_Cam2 = (CHCNetSDK.NET_DVR_TIME)Marshal.PtrToStructure(ptrTimeCfg, typeof(CHCNetSDK.NET_DVR_TIME));
                    textBoxYear.Text = Convert.ToString(m_struTimeCfg_Cam2.dwYear);
                    textBoxMonth.Text = Convert.ToString(m_struTimeCfg_Cam2.dwMonth);
                    textBoxDay.Text = Convert.ToString(m_struTimeCfg_Cam2.dwDay);
                    textBoxHour.Text = Convert.ToString(m_struTimeCfg_Cam2.dwHour);
                    textBoxMinute.Text = Convert.ToString(m_struTimeCfg_Cam2.dwMinute);
                    textBoxSecond.Text = Convert.ToString(m_struTimeCfg_Cam2.dwSecond);
                }
                Marshal.FreeHGlobal(ptrTimeCfg);
            }
        }

        private void FormTimeCorrect_Load(object sender, EventArgs e)
        {
            btTabMainCam_Click(sender, e);
        }

        private void btGetRealTime_Click(object sender, EventArgs e)
        {
            textBoxYear_RT.Text = DateTime.Now.Year.ToString();
            textBoxMonth_RT.Text = DateTime.Now.Month.ToString();
            textBoxDay_RT.Text = DateTime.Now.Day.ToString();

            textBoxHour_RT.Text = DateTime.Now.Hour.ToString();
            textBoxMinute_RT.Text = DateTime.Now.Minute.ToString();
            textBoxSecond_RT.Text = DateTime.Now.Second.ToString();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btTimeCorrection_Click(object sender, EventArgs e)
        {
            if (CurrentTabID == TAB_MAINCAM)
            {
                m_struTimeCfg_MainCam.dwYear = UInt32.Parse(textBoxYear_RT.Text);
                m_struTimeCfg_MainCam.dwMonth = UInt32.Parse(textBoxMonth_RT.Text);
                m_struTimeCfg_MainCam.dwDay = UInt32.Parse(textBoxDay_RT.Text);
                m_struTimeCfg_MainCam.dwHour = UInt32.Parse(textBoxHour_RT.Text);
                m_struTimeCfg_MainCam.dwMinute = UInt32.Parse(textBoxMinute_RT.Text);
                m_struTimeCfg_MainCam.dwSecond = UInt32.Parse(textBoxSecond_RT.Text);

                Int32 nSize = Marshal.SizeOf(m_struTimeCfg_MainCam);
                IntPtr ptrTimeCfg = Marshal.AllocHGlobal(nSize);
                Marshal.StructureToPtr(m_struTimeCfg_MainCam, ptrTimeCfg, false);

                if (!CHCNetSDK.NET_DVR_SetDVRConfig(MainCam_Manager.LoginInfo.LoginStatus, CHCNetSDK.NET_DVR_SET_TIMECFG, -1, ptrTimeCfg, (UInt32)nSize))
                {
                    uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    string strErr = "Đồng bộ thời gian thất bại, error code = " + iLastErr;
                    //Failed to set the time of device and output the error code
                    MessageBox.Show(strErr, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Đồng bộ thời gian thành công！");
                }

                Marshal.FreeHGlobal(ptrTimeCfg);
            }
            else if(CurrentTabID == TAB_SECONDARYCAM)
            {
                m_struTimeCfg_Cam2.dwYear = UInt32.Parse(textBoxYear_RT.Text);
                m_struTimeCfg_Cam2.dwMonth = UInt32.Parse(textBoxMonth_RT.Text);
                m_struTimeCfg_Cam2.dwDay = UInt32.Parse(textBoxDay_RT.Text);
                m_struTimeCfg_Cam2.dwHour = UInt32.Parse(textBoxHour_RT.Text);
                m_struTimeCfg_Cam2.dwMinute = UInt32.Parse(textBoxMinute_RT.Text);
                m_struTimeCfg_Cam2.dwSecond = UInt32.Parse(textBoxSecond_RT.Text);

                Int32 nSize = Marshal.SizeOf(m_struTimeCfg_Cam2);
                IntPtr ptrTimeCfg = Marshal.AllocHGlobal(nSize);
                Marshal.StructureToPtr(m_struTimeCfg_Cam2, ptrTimeCfg, false);

                if (!CHCNetSDK.NET_DVR_SetDVRConfig(SecondaryCam_Manager.LoginInfo.LoginStatus, CHCNetSDK.NET_DVR_SET_TIMECFG, -1, ptrTimeCfg, (UInt32)nSize))
                {
                    uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    string strErr = "Đồng bộ thời gian thất bại, error code = " + iLastErr;
                    //Failed to set the time of device and output the error code
                    MessageBox.Show(strErr, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Đồng bộ thời gian thành công！");
                }

                Marshal.FreeHGlobal(ptrTimeCfg);
            }
        }
    }
}
