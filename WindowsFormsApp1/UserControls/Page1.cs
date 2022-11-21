using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
        private bool InitCam_Status = false;
        public Int32 Live_Status = -1;
        public Int32 LoginStatus = -1;
        CHCNetSDK.REALDATACALLBACK RealData = null;
        CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara;

        private uint Err_Return;
        private const int ERR_OK = 0;
        private const int ERR_NOT_OK = 1;

        SetFoldertoSaveFile_Form SetFolder_Form = new SetFoldertoSaveFile_Form();
        private string FolderName_to_saveFile = "";

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
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
            }
        }
        private void InitForm_Default()
        {
            // Get Folder Save File info
            DataUser_Other_Info Info = SqliteDataAccess.Load_Other_Info();

            if(Info != null)
            {
                FolderName_to_saveFile = Info.FolderSaveFile;
                SetFolder_Form.SetFolderName(FolderName_to_saveFile);
            }
            else
            {
                // Handle when database = null
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

        public void btExit_F12_Click(object sender, EventArgs e)
        {
            if(btExit_F12.CanFocus)
            {
                btExit_F12.Focus();
            }
            if (MessageBox.Show("Bạn chắc chắn muốn thoát?", "Warning", MessageBoxButtons.OKCancel,
                                                            MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
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
                lpPreviewInfo.hPlayWnd = RealPlayWnd.Handle;
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
                    string str = "NET_DVR_RealPlay_V40 failed, error code= " + Err_Return;
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

        //Xoa hinh anh Loading gif trong picture box RealPlayWnd
        public void ResetImage()
        {
            RealPlayWnd.Image = null;
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
                string str = "NET_DVR_StopRealPlay failed, error code= " + Err_Return;
                MessageBox.Show(str);
                return ERR_NOT_OK;
            }
            else
            {
                Live_Status = -1;
                return ERR_OK;
            }
        }
        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            if (dwBufSize > 0)
            {
                byte[] sData = new byte[dwBufSize];
                Marshal.Copy(pBuffer, sData, 0, (Int32)dwBufSize);

                string str = "Hello.ps";
                FileStream fs = new FileStream(str, FileMode.Create);
                int iLen = (int)dwBufSize;
                fs.Write(sData, 0, iLen);
                fs.Close();
            }
        }
        // Live_Status < 0: Không live
        // else: Đang live
        public void btOpen_MainCam_Click(object sender, EventArgs e)
        {
            if (Live_Status < 0)
            {
                if (ERR_OK == Start_PlayCam())
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
                if (ERR_OK == Stop_PlayCam())
                {
                    btnOpen_MainCam.Text = "Bật Camera";
                }
            }
        }
        private int TakePicture()
        {
            string sJpegPicFileName;
            //Set the path and file name to save
            sJpegPicFileName = "JPEG_test.jpg";

            int lChannel = 1;

            lpJpegPara = new CHCNetSDK.NET_DVR_JPEGPARA();
            lpJpegPara.wPicQuality = 0; //Set Image quality
            lpJpegPara.wPicSize = 0xff; //Set Picture size (0xff: Auto)

            //Capture a JPEG picture
            if (!CHCNetSDK.NET_DVR_CaptureJPEGPicture(LoginStatus, lChannel, ref lpJpegPara, sJpegPicFileName))
            {
                uint LastErr = CHCNetSDK.NET_DVR_GetLastError();
                string str = "NET_DVR_CaptureJPEGPicture failed, error code= " + LastErr;
                MessageBox.Show(str);
                return ERR_NOT_OK;
            }
            else
            {
                string str = "Successful to capture the JPEG file and the saved file is " + sJpegPicFileName;
                MessageBox.Show(str);
                return ERR_OK;
            }
        }
        // Luu Folder Save File vao database
        private void Save_FolderSaveFile_Info(string FolderName)
        {
            DataUser_Other_Info InfoSave = new DataUser_Other_Info();
            InfoSave.Id = 1;
            InfoSave.FolderSaveFile = FolderName;

            SqliteDataAccess.SaveInfo_Other(InfoSave);
        }

        private void btTakePicture_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                btTakePicture_LeftClick();
            }
            if (e.Button == MouseButtons.Right)
            {
                if (SetFolder_Form.ShowDialog() == DialogResult.OK)
                {
                    SetFolder_Form.GetFolderName(ref FolderName_to_saveFile);
                    Save_FolderSaveFile_Info(FolderName_to_saveFile);
                }
            }
        }
        public void btTakePicture_LeftClick()
        {
            if(btTakePicture.CanFocus)
            {
                btTakePicture.Focus();
            }
            if (Live_Status == -1)
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
    }
}
