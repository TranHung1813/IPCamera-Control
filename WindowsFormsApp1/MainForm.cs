using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
namespace IPCameraManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitForm_Default();
        }
        //1. Luu thong tin dang nhap (Done)
        //2. Tao form loading cho Camera (Done)
        //3. Xua ly tinh nang chup anh, in phieu, chon anh, lay duong dan, ...
        //4. Hien thi trang thai cam qua control Status (Done, need test)
        //5. Luu vao git (Done)
        //6. Kiem tra do an toan cua Thread (Check xem cac nut co duoc nhan hay khong) (Done)
        //7. In barcode
        //8. Them tinh nang nhan nut (F1,F2,...) (half)
        //9. Them debug mode
        //10. Check lai thong tin size anh (Done, Auto is OK)
        //11. Them tinh nang phong to []
        //12. Them tinh nang Cam phu (done, testing)
        //13. Xem xet tinh nang Refresh (logout-> login-> start live view) (done)
        //14. Chon Folder luu anh chup (done)
        //15. Luu folder save file vao database (done)
        //16. Check box Luu thong tin trong Form Login
        //17. Code them phan Secondary Camera (done, testing)
        //18. Bug chuyen tab tu dong load du lieu trong (Form Login) (done)
        //19. Them Camera Phu Info vao database (done)
        //20. Bo het gia dein UI ra khoi Thread (Hard)
        //21. Fix 2 bug: 1. F7 ton nhieu thoi gian, 2. Login status = 1 cua Camera Phu (done)
        //22. Patient Info add to database
        //23. Check xem k can login lai sau khi ket noi lai camera thi co chay k (Done, Co chay)
        //24. Them try catch vao button In Phieu Kham
        //25. Van de load lai thong tin benh nhan cu: Can load thong tin gi?
        //26. Them tinh nang PZT, chinh sua Do sang, contrast, ... vao menu Setting
        //27. Kiem tra ket noi Camera tu dong
        private const int ERR_OK = 0;
        private const int ERR_NOT_OK = 1;

        Page1 ucPage1 = new Page1();
        Page2 ucPage2 = new Page2();
        FormLoginCamera formLoginCam;
        Thread Loading_MainCam_Trd;
        Thread Loading_Cam2_Trd;

        private const int PAGE1 = 1;
        private const int PAGE2 = 2;
        private int TabPageID = PAGE1;

        private void InitForm_Default()
        {
            //Init key press event
            this.KeyPreview = true;
            this.KeyUp += new KeyEventHandler(RoomView_KeyUp);
            //Add user control to form
            Add_UserControl(ucPage1);
            TabPageID = PAGE1;
            // Setup default status for controls
            formLoginCam = new FormLoginCamera(ucPage1.MainCam_Manager, ucPage1.SecondaryCam_Manager);
            TrangThaiCamChinh.Text = "Camera chính: Đang kết nối, xin vui lòng chờ!";
            TrangThaiCamPhu.Text = "Camera phụ: Đang kết nối, xin vui lòng chờ!";
            //Setup Folder name for Page2
            string FolderName = "";
            ucPage1.GetFolderName_to_SaveFile(ref FolderName);
            ucPage2.SetFolderName(FolderName);
            Control.CheckForIllegalCrossThreadCalls = false;
            // Register event button Ket no Camera click
            ucPage1.NotifyConnect_MainCam += UcPage1_NotifyConnect_MainCam;
            ucPage1.NotifyConnect_SecondaryCam += UcPage1_NotifyConnect_SecondaryCam;
        }

        private void UcPage1_NotifyConnect_MainCam(object sender, NotifyConnectMainCam e)
        {
            btLogin_IPCamera_Click(sender, e);
        }
        private void UcPage1_NotifyConnect_SecondaryCam(object sender, NotifyConnectSecondaryCam e)
        {
            btLogin_IPCamera_Click(sender, e);
        }

        void RoomView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    if (TabPageID != PAGE1)
                    {
                        // Chuyen sang tab Kham benh
                        tabPage_KhamBenh_Click(sender, e);
                        if (tabPage_KhamBenh.CanFocus)
                        {
                            tabPage_KhamBenh.Focus();
                            tabPage_KhamBenh.Checked = true;
                        }
                    }
                    break;
                case Keys.F4:
                    if (TabPageID != PAGE2)
                    {
                        // Chuyen sang tab In phieu
                        tabPageInPhieu_Click(sender, e);
                        if (tabPage_InPhieu.CanFocus)
                        {
                            tabPage_InPhieu.Focus();
                            tabPage_InPhieu.Checked = true;
                        }
                    }
                    break;
                case Keys.F7:
                    if (TabPageID == PAGE1)
                    {
                        // Nhan nut Refresh Cam
                        //btCamRefresh_Click(sender, e);
                        //if (btCamRefresh_R.CanFocus)
                        //{
                        //    btCamRefresh_R.Focus();
                        //}
                    }
                    break;
                case Keys.F5:
                    if (TabPageID == PAGE1)
                    {
                        // Nhan nut Chup anh
                        ucPage1.btTakePicture_LeftClick();
                    }
                    break;
                case Keys.F6:
                    if (TabPageID == PAGE1)
                    {
                        // Nhan nut Ca Phong
                        ucPage1.btShowCamera2_Click(sender, e);
                    }
                    break;
                case Keys.F12:
                    ucPage1.btExit_F12_Click(sender, e);
                    break;
            }
        }
        private void Add_UserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Warning", MessageBoxButtons.OKCancel,
                                                           MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    Application.Exit();
                }
                catch { }

            }
        }

        private void btMaximize_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        private void btMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void tabPage_KhamBenh_Click(object sender, EventArgs e)
        {
            if (TabPageID != PAGE1)
            {
                Add_UserControl(ucPage1);
                TabPageID = PAGE1;
            }
        }

        private void tabPageInPhieu_Click(object sender, EventArgs e)
        {
            if (TabPageID != PAGE2)
            {
                Add_UserControl(ucPage2);
                TabPageID = PAGE2;
            }
        }

        private void btLogin_IPCamera_Click(object sender, EventArgs e)
        {
            // Check trang thai login truoc khi mo form
            bool MainCam_Already_Login = false;
            bool Cam2_Already_Login = false;
            if (ucPage1.MainCam_Manager.LoginInfo.LoginStatus >= 0)
            {
                MainCam_Already_Login = true;
            }
            if (ucPage1.SecondaryCam_Manager.LoginInfo.LoginStatus >= 0)
            {
                Cam2_Already_Login = true;
            }
            if (formLoginCam.ShowDialog() == DialogResult.OK)
            {
                /* ---------- CAMERA CHINH ---------- */
                // Lay thong tin dang nhap Camera chinh thanh cong hay that bai
                formLoginCam.Get_LoginStatus_MainCam(ref ucPage1.MainCam_Manager.LoginInfo);
                // Login thanh cong va already login = false
                if (ucPage1.MainCam_Manager.LoginInfo.LoginStatus >= 0 && (MainCam_Already_Login == false))
                {
                    // Login thanh cong
                    btLogin_IPCamera.Visible = false;
                    TrangThaiCamChinh.Text = "Camera chính: Kết nối Camera thành công. Đang tải hình ảnh ...";
                    // Start Live view
                    if (ERR_OK == ucPage1.Start_PlayMainCam())
                    {
                        TrangThaiCamChinh.Text = "Camera chính: Đã kết nối!";
                        btMainCamRefresh_Click(sender, e);
                        //timer_GetCamStatus.Start();
                    }
                    else
                    {
                        TrangThaiCamChinh.Text = "Camera chính: Lỗi không xem được video!";
                    }

                    // Luu thong tin Ket noi Camera vao database
                    Save_Login_MainCam_Info(ucPage1.MainCam_Manager.LoginInfo);
                }
                /* ---------- CAMERA PHU ---------- */
                // Lay thong tin dang nhap Camera phu thanh cong hay that bai
                formLoginCam.Get_LoginStatus_Cam2(ref ucPage1.SecondaryCam_Manager.LoginInfo);
                // Login thanh cong va already login = false
                if (ucPage1.SecondaryCam_Manager.LoginInfo.LoginStatus >= 0 && (Cam2_Already_Login == false))
                {
                    // Login thanh cong
                    btLogin_IPCamera.Visible = false;
                    TrangThaiCamPhu.Text = "Camera phụ: Kết nối Camera thành công. Đang tải hình ảnh ...";
                    // Start Live view
                    if (ERR_OK == ucPage1.Start_PlayCam2())
                    {
                        TrangThaiCamPhu.Text = "Camera phụ: Đã kết nối!";
                        btSecondCamRefresh_Click(sender, e);
                    }
                    else
                    {
                        TrangThaiCamPhu.Text = "Camera phụ: Lỗi không xem được video!";
                    }

                    // Luu thong tin Ket noi Camera vao database
                    Save_Login_Cam2_Info(ucPage1.SecondaryCam_Manager.LoginInfo);
                }
            }
        }
        private void Save_Login_MainCam_Info(LoginCameraInfo_Type LoginInfo)
        {
            DataUser_LoginCamera_Info loginInfo_Save = new DataUser_LoginCamera_Info();
            loginInfo_Save.Id = 1;
            loginInfo_Save.IP_Address = LoginInfo.IP_Address;
            loginInfo_Save.Port = LoginInfo.Port;
            loginInfo_Save.Username = LoginInfo.Username;
            loginInfo_Save.Password = LoginInfo.Password;

            SqliteDataAccess.SaveInfo_LoginCamera(loginInfo_Save);
        }
        private void Save_Login_Cam2_Info(LoginCameraInfo_Type LoginInfo)
        {
            DataUser_LoginCamera_Info loginInfo_Save = new DataUser_LoginCamera_Info();
            loginInfo_Save.Id = 2;
            loginInfo_Save.IP_Address = LoginInfo.IP_Address;
            loginInfo_Save.Port = LoginInfo.Port;
            loginInfo_Save.Username = LoginInfo.Username;
            loginInfo_Save.Password = LoginInfo.Password;

            SqliteDataAccess.SaveInfo_LoginCamera(loginInfo_Save);
        }

        private void Connect2MainCam_using_Database_Info()
        {
            btLogin_IPCamera.Visible = false;
            //Get Login info
            List<DataUser_LoginCamera_Info> loginInfo = SqliteDataAccess.Load_LoginCamera_Info();

            if (loginInfo != null && (loginInfo.Count >= 1))
            {
                // Get info Login Camera and Login_Status
                ucPage1.MainCam_Manager.LoginInfo.IP_Address = loginInfo[0].IP_Address;
                ucPage1.MainCam_Manager.LoginInfo.Port = loginInfo[0].Port;
                ucPage1.MainCam_Manager.LoginInfo.Username = loginInfo[0].Username;
                ucPage1.MainCam_Manager.LoginInfo.Password = loginInfo[0].Password;

                formLoginCam.Load_MainCAM_Database_Info(ucPage1.MainCam_Manager.LoginInfo);

                // Login Camera roi Bat Live
                if (ERR_OK == formLoginCam.Login_Main_Camera(ucPage1.MainCam_Manager.LoginInfo))
                {
                    btLogin_IPCamera.Visible = false;
                    TrangThaiCamChinh.Text = "Camera chính: Kết nối Camera thành công. Đang tải hình ảnh ...";

                    // Lay thong tin dang nhap thanh cong hay that bai
                    formLoginCam.Get_LoginStatus_MainCam(ref ucPage1.MainCam_Manager.LoginInfo);

                    //Start live view
                    if (ERR_OK == ucPage1.Start_PlayMainCam())
                    {
                        // Refresh
                        if (ERR_OK == ucPage1.Stop_PlayMainCam())
                        {
                            if (ERR_OK == ucPage1.Start_PlayMainCam())
                            {
                                TrangThaiCamChinh.Text = "Camera chính: Đã kết nối!";
                            }
                            else
                            {
                                TrangThaiCamChinh.Text = "Camera chính: Lỗi không xem được video!";
                            }
                        }
                    }
                    else
                    {
                        btLogin_IPCamera.Visible = true;
                        TrangThaiCamChinh.Text = "Camera chính: Lỗi không xem được video!";
                        // Tu dong Dang xuat
                        formLoginCam.Logout_Main_Camera(ucPage1.MainCam_Manager.LoginInfo);
                        // Lay thong tin dang xuat thanh cong hay that bai
                        formLoginCam.Get_LoginStatus_MainCam(ref ucPage1.MainCam_Manager.LoginInfo);
                    }
                }
                else
                {
                    btLogin_IPCamera.Visible = true;
                    ucPage1.ResetImage_Main();
                    TrangThaiCamChinh.Text = "Camera chính: Kết nối thất bại. Hãy kiểm tra cáp kết nối!";
                }
            }
            else
            {
                // Xu ly khi chua co thong tin luu trong database
                btLogin_IPCamera.Visible = true;
                ucPage1.ResetImage_Main();
                TrangThaiCamChinh.Text = "Hãy nhập thông tin để có thể kết nối Camera!";
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            // Thread load Main Camera
            Loading_MainCam_Trd = new Thread(new ThreadStart(this.ThreadTask_LoadMainCam));
            Loading_MainCam_Trd.IsBackground = true;
            Loading_MainCam_Trd.Start();
            // Thread load Secondary Camera
            Loading_Cam2_Trd = new Thread(new ThreadStart(this.ThreadTask_LoadCam2));
            Loading_Cam2_Trd.IsBackground = true;
            Loading_Cam2_Trd.Start();

            timer_GetCamStatus.Start();
        }
        private void ThreadTask_LoadMainCam()
        {
            Connect2MainCam_using_Database_Info();
            Loading_MainCam_Trd.Abort();
        }
        private void ThreadTask_LoadCam2()
        {
            Connect2Cam2_using_Database_Info();
            Loading_Cam2_Trd.Abort();
        }
        private void btMainCamRefresh_Click(object sender, EventArgs e)
        {
            btLogin_IPCamera.Visible = false;
            TrangThaiCamChinh.Text = "Camera chính: Đang kết nối lại Camera!";
            if (ucPage1.MainCam_Manager.Live_Status < 0)
            {
                if (ERR_OK == ucPage1.Start_PlayMainCam())
                {
                    TrangThaiCamChinh.Text = "Camera chính: Đã kết nối!";
                }
                else
                {
                    TrangThaiCamChinh.Text = "Camera chính: Lỗi không xem được video!";
                }
            }
            else
            {
                if (ERR_OK == ucPage1.Stop_PlayMainCam())
                {
                    if (ERR_OK == ucPage1.Start_PlayMainCam())
                    {
                        TrangThaiCamChinh.Text = "Camera chính: Đã kết nối!";
                    }
                    else
                    {
                        TrangThaiCamChinh.Text = "Camera chính: Lỗi không xem được video!";
                    }
                }
                else
                {
                    btLogin_IPCamera.Visible = true;
                    TrangThaiCamChinh.Text = "Camera chính: Kết nối thất bại. Hãy kiểm tra cáp kết nối!";
                }
            }
        }

        private void btSecondCamRefresh_Click(object sender, EventArgs e)
        {
            btLogin_IPCamera.Visible = false;
            TrangThaiCamPhu.Text = "Camera phụ: Đang kết nối lại Camera!";
            if (ucPage1.SecondaryCam_Manager.Live_Status < 0)
            {
                if (ERR_OK == ucPage1.Start_PlayCam2())
                {
                    TrangThaiCamPhu.Text = "Camera phụ: Đã kết nối!";
                }
                else
                {
                    TrangThaiCamPhu.Text = "Camera phụ: Lỗi không xem được video!";
                }
            }
            else
            {
                if (ERR_OK == ucPage1.Stop_PlayCam2())
                {
                    if (ERR_OK == ucPage1.Start_PlayCam2())
                    {
                        TrangThaiCamPhu.Text = "Camera phụ: Đã kết nối!";
                    }
                    else
                    {
                        TrangThaiCamPhu.Text = "Camera phụ: Lỗi không xem được video!";
                    }
                }
                else
                {
                    btLogin_IPCamera.Visible = true;
                    TrangThaiCamPhu.Text = "Camera phụ: Kết nối thất bại. Hãy kiểm tra cáp kết nối!";
                }
            }
        }
        //*****************************************************************************************************************
        //****************************************** Access to Secondary Camera *******************************************
        private void Connect2Cam2_using_Database_Info()
        {
            btLogin_IPCamera.Visible = false;
            //Get Login info
            List<DataUser_LoginCamera_Info> loginInfo = SqliteDataAccess.Load_LoginCamera_Info();

            if (loginInfo != null && (loginInfo.Count >= 2))
            {
                // Get info Login Camera and Login_Status
                ucPage1.SecondaryCam_Manager.LoginInfo.IP_Address = loginInfo[1].IP_Address;
                ucPage1.SecondaryCam_Manager.LoginInfo.Port = loginInfo[1].Port;
                ucPage1.SecondaryCam_Manager.LoginInfo.Username = loginInfo[1].Username;
                ucPage1.SecondaryCam_Manager.LoginInfo.Password = loginInfo[1].Password;

                formLoginCam.Load_SecondCAM_Database_Info(ucPage1.SecondaryCam_Manager.LoginInfo);

                // Login Camera roi Bat Live
                if (ERR_OK == formLoginCam.Login_Second_Camera(ucPage1.SecondaryCam_Manager.LoginInfo))
                {
                    btLogin_IPCamera.Visible = false;
                    TrangThaiCamPhu.Text = "Camera phụ: Kết nối Camera thành công. Đang tải hình ảnh ...";

                    // Lay thong tin dang nhap thanh cong hay that bai
                    formLoginCam.Get_LoginStatus_Cam2(ref ucPage1.SecondaryCam_Manager.LoginInfo);

                    //Start live view
                    if (ERR_OK == ucPage1.Start_PlayCam2())
                    {
                        TrangThaiCamPhu.Text = "Camera phụ: Đã kết nối!";
                        if (ERR_OK == ucPage1.Stop_PlayCam2())
                        {
                            if (ERR_OK == ucPage1.Start_PlayCam2())
                            {
                                TrangThaiCamPhu.Text = "Camera phụ: Đã kết nối!";
                            }
                            else
                            {
                                TrangThaiCamPhu.Text = "Camera phụ: Lỗi không xem được video!";
                            }
                        }
                    }
                    else
                    {
                        btLogin_IPCamera.Visible = true;
                        TrangThaiCamPhu.Text = "Camera phụ: Lỗi không xem được video!";
                        // Tu dong Dang xuat
                        formLoginCam.Login_Second_Camera(ucPage1.SecondaryCam_Manager.LoginInfo);
                        // Lay thong tin dang xuat thanh cong hay that bai
                        formLoginCam.Get_LoginStatus_Cam2(ref ucPage1.SecondaryCam_Manager.LoginInfo);
                    }
                }
                else
                {
                    btLogin_IPCamera.Visible = true;
                    ucPage1.ResetImage_Second();
                    TrangThaiCamPhu.Text = "Camera phụ: Kết nối thất bại. Hãy kiểm tra cáp kết nối!";
                }
            }
            else
            {
                // Xu ly khi chua co thong tin luu trong database
                btLogin_IPCamera.Visible = true;
                ucPage1.ResetImage_Second();
                TrangThaiCamPhu.Text = "Hãy nhập thông tin để có thể kết nối Camera!";
            }
        }

        private void timer_Update_PatientInfo_to_Page2_Tick(object sender, EventArgs e)
        {
            PatientInfo_Type info = new PatientInfo_Type();
            ucPage1.Get_Patient_Info(ref info);
            ucPage2.Load_Patient_Info(info);
        }
        private void timer_GetCamStatus_Tick(object sender, EventArgs e)
        {
            if(ucPage1.MainCam_Manager.Live_Status >= 0)
            {
                if (ucPage1.MAINCAM_Data_Available == true)
                {
                    ucPage1.MAINCAM_Data_Available = false;
                    TrangThaiCamChinh.Text = "Camera chính: Đã kết nối!";
                }
                else
                {
                    TrangThaiCamChinh.Text = "Camera chính: Mất kết nối. Hãy kiểm tra cáp kết nối!";
                }
            }
            if(ucPage1.SecondaryCam_Manager.Live_Status >= 0)
            {
                if (ucPage1.CAM2_Data_Available == true)
                {
                    ucPage1.CAM2_Data_Available = false;
                    TrangThaiCamPhu.Text = "Camera phụ: Đã kết nối!";
                }
                else
                {
                    TrangThaiCamPhu.Text = "Camera phụ: Mất kết nối. Hãy kiểm tra cáp kết nối!";
                }
            }
        }
    }

    public class CameraManager_Type
    {
        public bool InitCam_Status { get; set; } = false;
        public Int32 Live_Status { get; set; } = -1;
        public LoginCameraInfo_Type LoginInfo;
    }

}
