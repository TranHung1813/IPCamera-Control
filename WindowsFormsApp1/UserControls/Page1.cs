using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace IPCameraManager
{
    public partial class Page1 : UserControl
    {
        public Page1()
        {
            InitializeComponent();
            InitForm_Default();
            Init_Button();
            Init_IPCamera();
        }
        public CameraManager_Type MainCam_Manager = new CameraManager_Type();
        public CameraManager_Type SecondaryCam_Manager = new CameraManager_Type();
        CHCNetSDK.REALDATACALLBACK RealData_Main = null;
        CHCNetSDK.REALDATACALLBACK RealData_Second = null;
        CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara;

        private uint Err_Return;
        private const int ERR_OK = 0;
        private const int ERR_NOT_OK = 1;
        private const int ERR_NONE = -1;

        private string FolderName_to_saveFile = "";

        public bool MAINCAM_Data_Available = false;
        public bool CAM2_Data_Available = false;

        Thread FillTextOverlay_trd;
        private CHCNetSDK.NET_DVR_SHOWSTRING_V30 m_struShowStrCfg;

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
        private void InitForm_Default()
        {
            // Set ngay kham bang real time
            tbNgayKham.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        public void FillTextOverlay_Init()
        {
            UInt32 dwReturn = 0;
            Int32 nSize = Marshal.SizeOf(m_struShowStrCfg);
            IntPtr ptrShowStrCfg = Marshal.AllocHGlobal(nSize);
            Marshal.StructureToPtr(m_struShowStrCfg, ptrShowStrCfg, false);
            if(CHCNetSDK.NET_DVR_GetDVRConfig(MainCam_Manager.LoginInfo.LoginStatus, CHCNetSDK.NET_DVR_GET_SHOWSTRING_V30, 1, ptrShowStrCfg, (UInt32)nSize, ref dwReturn))
            {
                m_struShowStrCfg = (CHCNetSDK.NET_DVR_SHOWSTRING_V30)Marshal.PtrToStructure(ptrShowStrCfg, typeof(CHCNetSDK.NET_DVR_SHOWSTRING_V30));
                FillTextOverlay_trd = new Thread(new ThreadStart(this.ThreadTask_FillTextOverlay));
                FillTextOverlay_trd.IsBackground = true;
                FillTextOverlay_trd.Start();
            }
        }
        private event EventHandler<NotifyConnectMainCam> _NotifyConnect_MainCam;
        public event EventHandler<NotifyConnectMainCam> NotifyConnect_MainCam
        {
            add
            {
                _NotifyConnect_MainCam += value;
            }
            remove
            {
                _NotifyConnect_MainCam -= value;
            }
        }
        private event EventHandler<NotifyConnectSecondaryCam> _NotifyConnect_SecondaryCam;
        public event EventHandler<NotifyConnectSecondaryCam> NotifyConnect_SecondaryCam
        {
            add
            {
                _NotifyConnect_SecondaryCam += value;
            }
            remove
            {
                _NotifyConnect_SecondaryCam -= value;
            }
        }
        protected virtual void OnNotifyConnect_MainCam()
        {
            if (_NotifyConnect_MainCam != null)
            {
                _NotifyConnect_MainCam(this, new NotifyConnectMainCam());
            }
        }
        protected virtual void OnNotifyConnect_SecondaryCam()
        {
            if (_NotifyConnect_SecondaryCam != null)
            {
                _NotifyConnect_SecondaryCam(this, new NotifyConnectSecondaryCam());
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
            // Abort Thread
            if(FillTextOverlay_trd != null)
            {
                try
                {
                    FillTextOverlay_trd.Abort();
                }
                catch
                { }
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

        private void Init_Button()
        {
            foreach (var button in this.Controls.OfType<Guna.UI2.WinForms.Guna2Button>())
            {
                button.GotFocus += (s, a) =>
                {
                    var currentButton = s as Guna.UI2.WinForms.Guna2Button;
                    currentButton.BorderColor = Color.RoyalBlue;
                    currentButton.BorderThickness = 2;
                };
                button.LostFocus += (s, a) =>
                {
                    var currentButton = s as Guna.UI2.WinForms.Guna2Button;
                    currentButton.BorderThickness = 1;
                    currentButton.BorderColor = SystemColors.ControlDarkDark;
                };
            }
        }
        public void SetFolderName_to_SaveFile(string FolderName)
        {
            FolderName_to_saveFile = FolderName;
        }

        public void btExit_F12_Click(object sender, EventArgs e)
        {
            if (btExit_F12.CanFocus)
            {
                btExit_F12.Focus();
            }
            if (MessageBox.Show("Bạn chắc chắn muốn thoát?", "Warning", MessageBoxButtons.OKCancel,
                                                            MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        public int Start_PlayMainCam()
        {
            if (MainCam_Manager.LoginInfo.LoginStatus < 0)
            {
                MessageBox.Show("Camera chưa kết nối!\rHãy kết nối camera trước.", "Lỗi: Chưa kết nối camera", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        //Xoa hinh anh Loading gif trong picture box RealPlayWnd
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
        public void RealDataCallBack_Main(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            if (dwBufSize > 0)
            {
                MAINCAM_Data_Available = true;
            }
        }
        // Live_Status < 0: Không live
        // else: Đang live
        public void btOpen_MainCam_Click(object sender, EventArgs e)
        {
            if (MainCam_Manager.Live_Status < 0)
            {
                if (ERR_OK == Start_PlayMainCam())
                {
                    btnOpen_MainCam.Text = "Tắt Camera";
                    btnOpen_MainCam.Visible = false;
                    btOpen_Cam2.Visible = false;
                }
                else
                {
                    // Tu dong logout (chua viet duoc, bo sung sau)
                }
            }
            else
            {
                if (ERR_OK == Stop_PlayMainCam())
                {
                    btnOpen_MainCam.Text = "Bật Camera";
                }
            }
        }
        private int TakePicture()
        {
            string sBmpPicFileName;
            //Í¼Æ¬±£´æÂ·¾¶ºÍÎÄ¼þÃû the path and file name to save
            sBmpPicFileName = "BMP_test.bmp";

            //BMP×¥Í¼ Capture a BMP picture
            if (!CHCNetSDK.NET_DVR_CapturePicture(MainCam_Manager.Live_Status, sBmpPicFileName))
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string str = "Chụp ảnh không thành công, error code= " + iLastErr;
                MessageBox.Show(str);
                return ERR_NOT_OK;
            }
            else
            {
                string str = "Chụp ảnh thành công!";
                MessageBox.Show(str);
            }
            SaveBmpAsJPG();
            return ERR_OK;
        }
        private void SaveBmpAsJPG()
        {
            Bitmap bmp1 = new Bitmap("BMP_test.bmp");
            bmp1.Save("JPEG_test.jpg", ImageFormat.Jpeg);
        }

        private void btTakePicture_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                btTakePicture_LeftClick();
            }
            if (e.Button == MouseButtons.Right)
            {
                //if (SetFolder_Form.ShowDialog() == DialogResult.OK)
                //{
                //    SetFolder_Form.GetFolderName(ref FolderName_to_saveFile);
                //    Save_FolderSaveFile_Info(FolderName_to_saveFile);
                //}
            }
        }
        public void btTakePicture_LeftClick()
        {
            if (btTakePicture.CanFocus)
            {
                btTakePicture.Focus();
            }
            if (MainCam_Manager.Live_Status == -1)
            {
                MessageBox.Show("Camera chưa kết nối!\rHãy kết nối camera trước.", "Lỗi: Chưa kết nối camera", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbMaBenhNhan.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập mã bệnh nhân! \rĐề nghị nhập lại.", "Lỗi: Chưa nhập mã bệnh nhân", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbHoTen.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập tên bệnh nhân! \rĐề nghị nhập lại.", "Lỗi: Chưa nhập tên bệnh nhân", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbTuoi.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập tuổi bệnh nhân! \rĐề nghị nhập lại.", "Lỗi: Chưa nhập tuổi bệnh nhân", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ERR_OK == TakePicture())
            {
                if (FolderName_to_saveFile.Length == 0)
                {
                    FolderName_to_saveFile = "D:\\Hinh_Anh";
                }
                string ImagePath = FolderName_to_saveFile + "\\Thang" + DateTime.Today.ToString("MM");
                ImagePath += "_" + DateTime.Today.ToString("yyyy");
                ImagePath += "\\Ngay" + DateTime.Today.ToString("dd") + "\\" + tbMaBenhNhan.Text;
                string FolderPath = ImagePath;
                string file_name = "\\" + DateTime.Now.ToString("HHmmss") + "_" + tbMaBenhNhan.Text;
                ImagePath += file_name + ".jpg";

                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }
                //Copy & override file "JPEG_test.jpg" to ImagePath
                FileInfo fi = new FileInfo("JPEG_test.jpg");
                fi.CopyTo(ImagePath, true);
            }
        }
        //*****************************************************************************************************************
        //****************************************** Access to Secondary Camera *******************************************
        // Show camera phụ
        public void btShowCamera2_Click(object sender, EventArgs e)
        {
            if (btShowCamera2.CanFocus)
            {
                btShowCamera2.Focus();
            }
            ShowCamera2Form form = new ShowCamera2Form(SecondaryCam_Manager.LoginInfo);
            form.ShowDialog();
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
                lpPreviewInfo.hPlayWnd = imgPreview.Handle;
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
            imgPreview.Image = null;
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
                imgPreview.Refresh();
                return ERR_OK;
            }
        }
        public void RealDataCallBack_Cam2(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            if (dwBufSize > 0)
            {
                CAM2_Data_Available = true;
            }
        }
        private void cbGioiTinh_Click(object sender, EventArgs e)
        {
            cbGioiTinh.DroppedDown = true;
            cbGioiTinh.Cursor = Cursors.Arrow;
        }
        //*****************************************************************************************************************
        //****************************************** Contact with Page 2 *******************************************
        public void Get_Patient_Info(ref PatientInfo_Type info)
        {
            info.MaBN = tbMaBenhNhan.Text;
            info.HoTenBN = tbHoTen.Text;
            info.GioiTinh = cbGioiTinh.Text.Replace(" ", "");
            info.Tuoi = tbTuoi.Text;
            info.NgayKham = tbNgayKham.Text;
            info.DiaChi = tbDiaChi.Text;
        }
        //*****************************************************************************************************************
        //****************************************** Context Menu Strip *******************************************
        private void RealPlayWnd_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    Point point = this.PointToScreen(RealPlayWnd.Location);
            //    point.X += RealPlayWnd.Width;
            //    cMStrip_MainCAM.Show(point);
            //}
        }
        private void imgPreview_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    Point point = groupBox1.PointToScreen(imgPreview.Location);
            //    point.X += imgPreview.Width;
            //    cMStrip_SecondCAM.Show(point);
            //}
        }

        private void btConnectMainCam_Click(object sender, EventArgs e)
        {
            OnNotifyConnect_MainCam();
        }

        private void btConnectCam2_Click(object sender, EventArgs e)
        {
            OnNotifyConnect_SecondaryCam();
        }
        // File Text Overlay
        private void ThreadTask_FillTextOverlay()
        {
            while(true)
            {
                //if (tbMaBenhNhan.Text != "") m_struShowStrCfg.struStringInfo[0].wShowString = 1;
                //else m_struShowStrCfg.struStringInfo[0].wShowString = 0;
                //m_struShowStrCfg.struStringInfo[0].sString = tbMaBenhNhan.Text;
                //m_struShowStrCfg.struStringInfo[0].wStringSize = (ushort)tbMaBenhNhan.Text.Length;
                //m_struShowStrCfg.struStringInfo[0].wShowStringTopLeftX = 12;
                //m_struShowStrCfg.struStringInfo[0].wShowStringTopLeftY = 192;

                //if (tbHoTen.Text != "") m_struShowStrCfg.struStringInfo[1].wShowString = 1;
                //else m_struShowStrCfg.struStringInfo[1].wShowString = 0;
                //m_struShowStrCfg.struStringInfo[1].sString = tbHoTen.Text;
                //m_struShowStrCfg.struStringInfo[1].wStringSize = (ushort)tbHoTen.Text.Length;
                //m_struShowStrCfg.struStringInfo[1].wShowStringTopLeftX = 12;
                //m_struShowStrCfg.struStringInfo[1].wShowStringTopLeftY = 212;

                //if (tbTuoi.Text != "") m_struShowStrCfg.struStringInfo[2].wShowString = 1;
                //else m_struShowStrCfg.struStringInfo[2].wShowString = 0;
                //m_struShowStrCfg.struStringInfo[2].sString = tbTuoi.Text + "tuoi, " + cbGioiTinh.Text;
                //m_struShowStrCfg.struStringInfo[2].wStringSize = (ushort)m_struShowStrCfg.struStringInfo[2].sString.Length;
                //m_struShowStrCfg.struStringInfo[2].wShowStringTopLeftX = 12;
                //m_struShowStrCfg.struStringInfo[2].wShowStringTopLeftY = 232;

                //if (tbNgayKham.Text != "") m_struShowStrCfg.struStringInfo[3].wShowString = 1;
                //else m_struShowStrCfg.struStringInfo[3].wShowString = 0;
                //m_struShowStrCfg.struStringInfo[3].sString = tbNgayKham.Text;
                //m_struShowStrCfg.struStringInfo[3].wStringSize = (ushort)tbNgayKham.Text.Length;
                //m_struShowStrCfg.struStringInfo[3].wShowStringTopLeftX = 12;
                //m_struShowStrCfg.struStringInfo[3].wShowStringTopLeftY = 252;

                if(tbMaBenhNhan.Text != "" || tbHoTen.Text != "")
                {
                    m_struShowStrCfg.struStringInfo[0].wShowString = 1;
                    string str = "PID: " + tbMaBenhNhan.Text + ", " + RemoveSign4VietnameseString(tbHoTen.Text);
                    m_struShowStrCfg.struStringInfo[0].sString = str;
                    m_struShowStrCfg.struStringInfo[0].wStringSize = (ushort)str.Length;
                    m_struShowStrCfg.struStringInfo[0].wShowStringTopLeftX = 12;
                    m_struShowStrCfg.struStringInfo[0].wShowStringTopLeftY = 192;
                }
                else
                {
                    m_struShowStrCfg.struStringInfo[0].wShowString = 0;
                }

                Int32 nSize = Marshal.SizeOf(m_struShowStrCfg);
                IntPtr ptrShowStrCfg = Marshal.AllocHGlobal(nSize);
                Marshal.StructureToPtr(m_struShowStrCfg, ptrShowStrCfg, false);

                if (!CHCNetSDK.NET_DVR_SetDVRConfig(MainCam_Manager.LoginInfo.LoginStatus, CHCNetSDK.NET_DVR_SET_SHOWSTRING_V30, 1, ptrShowStrCfg, (UInt32)nSize))
                {
                    uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    string strErr = "NET_DVR_SET_SHOWSTRING_V30 failed, error code= " + iLastErr;
                    //Failed to set overlay parameters and output the error code
                    //MessageBox.Show(strErr);
                }
                else
                {
                    //MessageBox.Show("Set OSD parameters successfully！");
                }

                Marshal.FreeHGlobal(ptrShowStrCfg);

                Thread.Sleep(3000);
            }
        }
        private static readonly string[] VietnameseSigns = new string[]
        {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"
        };
        public static string RemoveSign4VietnameseString(string str)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }

        private void Page1_Load(object sender, EventArgs e)
        {
            Utility.fitUserControlToScreen(this, 766, 1366);
        }
    }
    public class NotifyConnectMainCam : EventArgs
    {
        public NotifyConnectMainCam()
        {

        }
    }
    public class NotifyConnectSecondaryCam : EventArgs
    {
        public NotifyConnectSecondaryCam()
        {

        }
    }
}
