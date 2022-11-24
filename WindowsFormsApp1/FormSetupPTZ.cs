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
    public partial class FormSetupPTZ : Form
    {
        public FormSetupPTZ(CameraManager_Type MainCam, CameraManager_Type Cam2)
        {
            InitializeComponent();
            MainCamManager = MainCam;
            SecondaryCamManager = Cam2;
        }
        CameraManager_Type MainCamManager = new CameraManager_Type();
        CameraManager_Type SecondaryCamManager = new CameraManager_Type();
        private bool bAuto = false;

        public CHCNetSDK.NET_DVR_PTZPOS m_struPtzCfg;
        public CHCNetSDK.NET_DVR_PTZSCOPE m_struPtzCfg1;
        private void PtzRange_Click(object sender, EventArgs e)
        {
            UInt32 dwReturn = 0;
            Int32 nSize = Marshal.SizeOf(m_struPtzCfg1);
            IntPtr ptrPtzCfg = Marshal.AllocHGlobal(nSize);
            Marshal.StructureToPtr(m_struPtzCfg1, ptrPtzCfg, false);

            // Get PTZ Range Fail
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(MainCamManager.LoginInfo.LoginStatus, CHCNetSDK.NET_DVR_GET_PTZSCOPE, -1, ptrPtzCfg, (UInt32)nSize, ref dwReturn))
            {
                uint Err_return = CHCNetSDK.NET_DVR_GetLastError();
                string str = "Lấy thông tin PTZ thất bại, error code= " + Err_return;
                MessageBox.Show(str);
                return;
            }
            else
            {
                m_struPtzCfg1 = (CHCNetSDK.NET_DVR_PTZSCOPE)Marshal.PtrToStructure(ptrPtzCfg, typeof(CHCNetSDK.NET_DVR_PTZSCOPE));
                // Get PTZ Range success
                ushort wPanPosMax = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1.wPanPosMax, 16));
                float WPanPosMax = wPanPosMax * 0.1f;
                ushort wTiltPosMax = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1.wTiltPosMax, 16));
                float WTiltPosMax = wTiltPosMax * 0.1f;
                ushort wZoomPosMax = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1.wZoomPosMax, 16));
                float WZoomPosMax = wZoomPosMax * 0.1f;
                ushort wPanPosMin = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1.wPanPosMin, 16));
                float WPanPosMin = wPanPosMin * 0.1f;
                ushort wTiltPosMin = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1.wTiltPosMin, 16));
                float WTiltPosMin = wTiltPosMin * 0.1f;
                ushort wZoomPosMin = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1.wZoomPosMin, 16));
                float WZoomPosMin = wZoomPosMin * 0.1f;

                string str = "PMax=" + WPanPosMax + "  TMax=" + WTiltPosMax + "  ZMax=" + WZoomPosMax + "  PMin=" + WPanPosMin + "  TMin=" + WTiltPosMin + "  ZMin=" + WZoomPosMin;
                label_PZTRange.Text = str;
            }
            return;
        }
        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                if (!bAuto)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCamManager.Live_Status, CHCNetSDK.PAN_AUTO, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
                    btnAuto.Text = "Stop";
                    bAuto = true;
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCamManager.Live_Status, CHCNetSDK.PAN_AUTO, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
                    btnAuto.Text = "Auto";
                    bAuto = false;
                }
            }
            else
            {
                if (!bAuto)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCamManager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_AUTO, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
                    btnAuto.Text = "Stop";
                    bAuto = true;
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCamManager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_AUTO, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
                    btnAuto.Text = "Auto";
                    bAuto = false;
                }
            }
        }

        private void btnUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCamManager.Live_Status, CHCNetSDK.TILT_UP, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
            else
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCamManager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_UP, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
        }

        private void btnUp_MouseUp(object sender, MouseEventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCamManager.Live_Status, CHCNetSDK.TILT_UP, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
            else
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCamManager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_UP, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
        }
        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCamManager.Live_Status, CHCNetSDK.PAN_RIGHT, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
            else
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCamManager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_RIGHT, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
        }

        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCamManager.Live_Status, CHCNetSDK.PAN_RIGHT, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
            else
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCamManager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_RIGHT, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
        }

        private void btnDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCamManager.Live_Status, CHCNetSDK.TILT_DOWN, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
            else
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCamManager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_DOWN, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
        }

        private void btnDown_MouseUp(object sender, MouseEventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCamManager.Live_Status, CHCNetSDK.TILT_DOWN, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
            else
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCamManager.LoginInfo.LoginStatus, 0, CHCNetSDK.TILT_DOWN, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
        }
        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCamManager.Live_Status, CHCNetSDK.PAN_LEFT, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
            else
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCamManager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_LEFT, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
        }

        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed(MainCamManager.Live_Status, CHCNetSDK.PAN_LEFT, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
            else
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(MainCamManager.LoginInfo.LoginStatus, 0, CHCNetSDK.PAN_LEFT, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
        }
        private void PtzGet_Click(object sender, EventArgs e)
        {
            UInt32 dwReturn = 0;
            Int32 nSize = Marshal.SizeOf(m_struPtzCfg);
            IntPtr ptrPtzCfg = Marshal.AllocHGlobal(nSize);
            Marshal.StructureToPtr(m_struPtzCfg, ptrPtzCfg, false);
            // Get information fail
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(MainCamManager.LoginInfo.LoginStatus, CHCNetSDK.NET_DVR_GET_PTZPOS, -1, ptrPtzCfg, (UInt32)nSize, ref dwReturn))
            {
                uint Err_return = CHCNetSDK.NET_DVR_GetLastError();
                string str = "NET_DVR_GetDVRConfig failed, error code= " + Err_return;
                MessageBox.Show(str);
                return;
            }
            else
            {
                m_struPtzCfg = (CHCNetSDK.NET_DVR_PTZPOS)Marshal.PtrToStructure(ptrPtzCfg, typeof(CHCNetSDK.NET_DVR_PTZPOS));
                //Get PTZ parameters success
                ushort wPanPos = Convert.ToUInt16(Convert.ToString(m_struPtzCfg.wPanPos, 16));
                float WPanPos = wPanPos * 0.1f;
                textBoxPanPos.Text = Convert.ToString(WPanPos);
                ushort wTiltPos = Convert.ToUInt16(Convert.ToString(m_struPtzCfg.wTiltPos, 16));
                float WTiltPos = wTiltPos * 0.1f;
                textBoxTiltPos.Text = Convert.ToString(WTiltPos);
                ushort wZoomPos = Convert.ToUInt16(Convert.ToString(m_struPtzCfg.wZoomPos, 16));
                float WZoomPos = wZoomPos * 0.1f;
                textBoxZoomPos.Text = Convert.ToString(WZoomPos);
                /*textBoxPanPos.Text= Convert.ToString(Convert.ToUInt32(Convert.ToString(m_struPtzCfg.wPanPos,16))*0.1f,10);
                textBoxTiltPos.Text = Convert.ToString(Convert.ToUInt32(Convert.ToUInt32(Convert.ToString(m_struPtzCfg.wTiltPos, 16)) * 0.1f), 10);
                textBoxZoomPos.Text = Convert.ToString(Convert.ToUInt32(Convert.ToString(m_struPtzCfg.wZoomPos, 16)) * 0.1), 10);*/
                //textBoxPanPos.Text=Convert.ToString(m_struPtzCfg.wPanPos,16);
            }
            return;
        }

        private void FormSetupPZT_Load(object sender, EventArgs e)
        {
            comboBoxSpeed.SelectedIndex = 3;
            if (MainCamManager.Live_Status >= 0)
            {
                checkBoxPreview.Checked = true;
            }
            else
            {
                checkBoxPreview.Checked = false;
            }
        }

        private void PtzSet_Click(object sender, EventArgs e)
        {
            int flag = 1;
            //float wPanPos, wTiltPos, wZoomPos;
            String str1, str2, str3;
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Please input the operation type  ");
            }
            /* wPanPos = ushort.Parse(textBoxPanPos.Text);
             wTiltPos = ushort.Parse(textBoxTiltPos.Text);
             wZoomPos = ushort.Parse(textBoxZoomPos.Text);*/
            switch (comboBox2.Items.IndexOf(comboBox2.Text))
            {
                case 0:

                    if (textBoxPanPos.Text == "" || textBoxTiltPos.Text == "" ||
                        textBoxZoomPos.Text == "")
                    {

                        MessageBox.Show("Please input prarameters of P,T,Z: ");
                        return;
                    }
                    else
                    {
                        flag = 0;
                        m_struPtzCfg.wAction = 1;
                        //m_struPtzCfg.wPanPos = ushort.Parse(textBoxPanPos.Text);
                        /* m_struPtzCfg.wPanPos = Convert.ToUInt16(wPanPos);
                          m_struPtzCfg.wTiltPos = wTiltPos;
                          m_struPtzCfg.wZoomPos = wZoomPos;*/
                        /* m_struPtzCfg.wPanPos = Convert.ToUInt16(Convert.ToString(Convert.ToUInt32(Convert.ToString(wPanPos * 10, 16)), 10));
                        m_struPtzCfg.wTiltPos = Convert.ToUInt16(Convert.ToString(Convert.ToUInt32(Convert.ToString(wTiltPos*10, 16)), 10));
                         m_struPtzCfg.wZoomPos = Convert.ToUInt16(Convert.ToString(Convert.ToUInt32(Convert.ToString(wZoomPos*10, 16)), 10));*/
                        str1 = Convert.ToString(float.Parse(textBoxPanPos.Text) * 10);
                        m_struPtzCfg.wPanPos = (ushort)(Convert.ToUInt16(str1, 16));
                        str2 = Convert.ToString(float.Parse(textBoxTiltPos.Text) * 10);
                        m_struPtzCfg.wTiltPos = (ushort)(Convert.ToUInt16(str2, 16));
                        str3 = Convert.ToString(float.Parse(textBoxZoomPos.Text) * 10);
                        m_struPtzCfg.wZoomPos = (ushort)(Convert.ToUInt16(str3, 16));
                        /* m_struPtzCfg.wTiltPos = ushort.Parse(textBoxTiltPos.Text);
                         m_struPtzCfg.wZoomPos = ushort.Parse(textBoxZoomPos.Text);*/
                    }
                    break;
                case 1:
                    if (textBoxPanPos.Text == "")
                    {
                        MessageBox.Show("Please input prarameters of P: ");
                        return;
                    }
                    else
                    {
                        flag = 0;
                        m_struPtzCfg.wAction = 2;

                        //wPanPos = float.Parse(textBoxPanPos.Text);
                        str1 = Convert.ToString(float.Parse(textBoxPanPos.Text) * 10);
                        m_struPtzCfg.wPanPos = (ushort)(Convert.ToUInt16(str1, 16));

                        //m_struPtzCfg.wPanPos = ushort.Parse(textBoxPanPos.Text);

                    }
                    break;
                case 2:
                    if (textBoxTiltPos.Text == "")
                    {
                        MessageBox.Show("Please input prarameters of T: ");
                        return;
                    }
                    else
                    {
                        flag = 0;
                        m_struPtzCfg.wAction = 3;
                        m_struPtzCfg.wTiltPos = ushort.Parse(textBoxTiltPos.Text);

                        str2 = Convert.ToString(float.Parse(textBoxTiltPos.Text) * 10);
                        m_struPtzCfg.wTiltPos = (ushort)(Convert.ToUInt16(str2, 16));

                    }
                    break;
                case 3:
                    if (textBoxZoomPos.Text == "")
                    {
                        MessageBox.Show("Please input prarameters of Z: ");
                        return;
                    }
                    else
                    {
                        flag = 0;
                        m_struPtzCfg.wAction = 4;
                        m_struPtzCfg.wZoomPos = ushort.Parse(textBoxZoomPos.Text);

                        str3 = Convert.ToString(float.Parse(textBoxZoomPos.Text) * 10);
                        m_struPtzCfg.wZoomPos = (ushort)(Convert.ToUInt16(str3, 16));
                    }
                    break;
                case 4:
                    if (textBoxTiltPos.Text == "" || textBoxPanPos.Text == "")
                    {
                        MessageBox.Show("Please input prarameters of P,T: ");
                        return;
                    }
                    else
                    {
                        flag = 0;
                        m_struPtzCfg.wAction = 5;
                        m_struPtzCfg.wPanPos = ushort.Parse(textBoxPanPos.Text);
                        m_struPtzCfg.wTiltPos = ushort.Parse(textBoxTiltPos.Text);

                        str1 = Convert.ToString(float.Parse(textBoxPanPos.Text) * 10);
                        m_struPtzCfg.wPanPos = (ushort)(Convert.ToUInt16(str1, 16));
                        str2 = Convert.ToString(float.Parse(textBoxTiltPos.Text) * 10);
                        m_struPtzCfg.wTiltPos = (ushort)(Convert.ToUInt16(str2, 16));
                    }
                    break;
            }


            while (flag == 0)
            {

                Int32 nSize = Marshal.SizeOf(m_struPtzCfg);
                IntPtr ptrPtzCfg = Marshal.AllocHGlobal(nSize);
                Marshal.StructureToPtr(m_struPtzCfg, ptrPtzCfg, false);

                if (!CHCNetSDK.NET_DVR_SetDVRConfig(MainCamManager.LoginInfo.LoginStatus, CHCNetSDK.NET_DVR_SET_PTZPOS, 1, ptrPtzCfg, (UInt32)nSize))
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
}
