using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        //6. Kiem tra do an toan cua Thread (Check xem cac nut co duoc nhan hay khong)
        //7. In barcode
        //8. Them tinh nang nhan nut (F1,F2,...) (half)
        //9. Them debug mode
        //10. Check lai thong tin size anh (Done, Auto is OK)
        //11. Them tinh nang phong to []
        //12. Them tinh nang Cam phu
        //13. Xem xet tinh nang Refresh (logout-> login-> start live view) (done)
        //14. Chon Folder luu anh chup (done)
        //15. Luu folder save file vao database (done)
        //16. Check box Luu thong tin trong Form Login
        //17. Code them phan Secondary Camera
        //18. Bug chuyen tab tu dong load du lieu trong (Form Login)
        private const int ERR_OK = 0;
        private const int ERR_NOT_OK = 1;

        Page1 ucPage1 = new Page1();
        Page2 ucPage2 = new Page2();
        FormLoginCamera formLoginCam;
        Thread Loading_Trd;

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
            formLoginCam = new FormLoginCamera( ucPage1.MainCam_Manager, ucPage1.SecondaryCam_Manager);
            TrangThaiCam.Text = "Đang kết nối camera, xin vui lòng chờ!";
            Control.CheckForIllegalCrossThreadCalls = false;
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
                    if(TabPageID == PAGE1)
                    {
                        // Nhan nut Refresh Cam
                        btCamRefresh_Click(sender, e);
                        if (btCamRefresh_R.CanFocus)
                        {
                            btCamRefresh_R.Focus();
                        }
                    }
                    break;
                case Keys.F5:
                    if(TabPageID == PAGE1)
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
        private void Add_UserControl( UserControl uc)
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
                Application.Exit();
            }
        }

        private void btMaximize_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        private void btMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tabPage_KhamBenh_Click(object sender, EventArgs e)
        {
            Add_UserControl(ucPage1);
            TabPageID = PAGE1;
        }

        private void tabPageInPhieu_Click(object sender, EventArgs e)
        {
            Add_UserControl(ucPage2);
            TabPageID = PAGE2;
        }

        private void btLogin_IPCamera_Click(object sender, EventArgs e)
        {
            if(formLoginCam.ShowDialog() == DialogResult.OK)
            {
                /* ---------- CAMERA CHINH ---------- */
                // Lay thong tin dang nhap Camera chinh thanh cong hay that bai
                formLoginCam.Get_LoginStatus_MainCam(ref ucPage1.MainCam_Manager.LoginInfo);
                if(ucPage1.MainCam_Manager.LoginInfo.LoginStatus < 0)
                {
                    // Login fail hoac khong login
                }
                else
                {
                    // Login thanh cong
                    btLogin_IPCamera.Visible = false;
                    TrangThaiCam.Text = "Camera chính: Kết nối Camera thành công. Đang tải hình ảnh ...";
                    // Start Live view
                    if (ERR_OK == ucPage1.Start_PlayMainCam())
                    {
                        TrangThaiCam.Text = "Camera chính: Đã kết nối!";
                    }
                    else
                    {
                        TrangThaiCam.Text = "Camera chính: Lỗi không xem được video!";
                    }

                    // Luu thong tin Ket noi Camera vao database
                    Save_LoginCamera_Info(ucPage1.MainCam_Manager.LoginInfo);
                }
                /* ---------- CAMERA PHU ---------- */
                // Lay thong tin dang nhap Camera phu thanh cong hay that bai
                formLoginCam.Get_LoginStatus_Cam2(ref ucPage1.SecondaryCam_Manager.LoginInfo);
                if (ucPage1.SecondaryCam_Manager.LoginInfo.LoginStatus < 0)
                {
                    // Login fail hoac khong login
                }
                else
                {
                    // Login thanh cong
                    btLogin_IPCamera.Visible = false;
                    TrangThaiCam.Text = "Camera phụ: Kết nối Camera thành công. Đang tải hình ảnh ...";
                    // Start Live view
                    if (ERR_OK == ucPage1.Start_PlayCam2())
                    {
                        TrangThaiCam.Text = "Camera phụ: Đã kết nối!";
                    }
                    else
                    {
                        TrangThaiCam.Text = "Camera phụ: Lỗi không xem được video!";
                    }

                    // Luu thong tin Ket noi Camera vao database
                    Save_LoginCamera_Info(ucPage1.SecondaryCam_Manager.LoginInfo);
                }
            }
        }
        private void Save_LoginCamera_Info(LoginCameraInfo_Type LoginInfo)
        {
            DataUser_LoginCamera_Info loginInfo_Save = new DataUser_LoginCamera_Info();
            loginInfo_Save.Id = 1;
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
            DataUser_LoginCamera_Info loginInfo = SqliteDataAccess.Load_LoginCamera_Info();

            if (loginInfo != null)
            {
                // Get info Login Camera and Login_Status
                ucPage1.MainCam_Manager.LoginInfo.IP_Address = loginInfo.IP_Address;
                ucPage1.MainCam_Manager.LoginInfo.Port = loginInfo.Port;
                ucPage1.MainCam_Manager.LoginInfo.Username = loginInfo.Username;
                ucPage1.MainCam_Manager.LoginInfo.Password = loginInfo.Password;

                formLoginCam.Load_Database_Info(ucPage1.MainCam_Manager.LoginInfo);

                // Login Camera roi Bat Live
                if (ERR_OK == formLoginCam.Login_Main_Camera(ucPage1.MainCam_Manager.LoginInfo))
                {
                    btLogin_IPCamera.Visible = false;
                    TrangThaiCam.Text = "Camera chính: Kết nối Camera thành công. Đang tải hình ảnh ...";

                    // Lay thong tin dang nhap thanh cong hay that bai
                    formLoginCam.Get_LoginStatus_MainCam(ref ucPage1.MainCam_Manager.LoginInfo);

                    //Start live view
                    if (ERR_OK == ucPage1.Start_PlayMainCam())
                    {
                        TrangThaiCam.Text = "Camera chính: Đã kết nối!";
                    }
                    else
                    {
                        btLogin_IPCamera.Visible = true;
                        TrangThaiCam.Text = "Camera chính: Lỗi không xem được video!";
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
                    TrangThaiCam.Text = "Camera chính: Kết nối thất bại. Hãy kiểm tra cáp kết nối!";
                }
            }
            else
            {
                // Xu ly khi chua co thong tin luu trong database
                btLogin_IPCamera.Visible = true;
                ucPage1.ResetImage_Main();
                TrangThaiCam.Text = "Hãy nhập thông tin để có thể kết nối Camera!";
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            Loading_Trd = new Thread(new ThreadStart(this.ThreadTask));
            Loading_Trd.IsBackground = true;
            Loading_Trd.Start();
        }
        private void ThreadTask()
        {
            Connect2MainCam_using_Database_Info();
            Loading_Trd.Abort();
        }
        private void btCamRefresh_Click(object sender, EventArgs e)
        {
            btLogin_IPCamera.Visible = false;
            TrangThaiCam.Text = "Đang kết nối lại Camera!";
            if (ERR_OK == ucPage1.Stop_PlayMainCam())
            {
                if (ERR_OK == ucPage1.Start_PlayMainCam())
                {
                    TrangThaiCam.Text = "Camera chính: Đã kết nối!";
                }
                else
                {
                    btLogin_IPCamera.Visible = true;
                    TrangThaiCam.Text = "Camera chính: Lỗi không xem được video!";
                    // Tu dong Dang xuat
                    formLoginCam.Logout_Main_Camera(ucPage1.MainCam_Manager.LoginInfo);
                    // Lay thong tin dang xuat thanh cong hay that bai
                    formLoginCam.Get_LoginStatus_MainCam(ref ucPage1.MainCam_Manager.LoginInfo);
                }
            }
            else
            {
                btLogin_IPCamera.Visible = true;
                TrangThaiCam.Text = "Camera chính: Kết nối thất bại. Hãy kiểm tra cáp kết nối!";
            }
            if (ERR_OK == ucPage1.Stop_PlayCam2())
            {
                if (ERR_OK == ucPage1.Start_PlayCam2())
                {
                    TrangThaiCam.Text = "Camera phụ: Đã kết nối!";
                }
                else
                {
                    btLogin_IPCamera.Visible = true;
                    TrangThaiCam.Text = "Camera phụ: Lỗi không xem được video!";
                    // Tu dong Dang xuat
                    formLoginCam.Login_Second_Camera(ucPage1.SecondaryCam_Manager.LoginInfo);
                    // Lay thong tin dang xuat thanh cong hay that bai
                    formLoginCam.Get_LoginStatus_Cam2(ref ucPage1.SecondaryCam_Manager.LoginInfo);
                }
            }
            else
            {
                btLogin_IPCamera.Visible = true;
                TrangThaiCam.Text = "Camera phụ: Kết nối thất bại. Hãy kiểm tra cáp kết nối!";
            }
        }
        //*****************************************************************************************************************
        //****************************************** Access to Secondary Camera *******************************************
        private void Connect2Cam2_using_Database_Info()
        {
            btLogin_IPCamera.Visible = false;
            //Get Login info
            DataUser_LoginCamera_Info loginInfo = SqliteDataAccess.Load_LoginCamera_Info();

            if (loginInfo != null)
            {
                // Get info Login Camera and Login_Status
                ucPage1.SecondaryCam_Manager.LoginInfo.IP_Address = loginInfo.IP_Address;
                ucPage1.SecondaryCam_Manager.LoginInfo.Port = loginInfo.Port;
                ucPage1.SecondaryCam_Manager.LoginInfo.Username = loginInfo.Username;
                ucPage1.SecondaryCam_Manager.LoginInfo.Password = loginInfo.Password;

                formLoginCam.Load_Database_Info(ucPage1.SecondaryCam_Manager.LoginInfo);

                // Login Camera roi Bat Live
                if (ERR_OK == formLoginCam.Login_Second_Camera(ucPage1.SecondaryCam_Manager.LoginInfo))
                {
                    btLogin_IPCamera.Visible = false;
                    TrangThaiCam.Text = "Camera phụ: Kết nối Camera thành công. Đang tải hình ảnh ...";

                    // Lay thong tin dang nhap thanh cong hay that bai
                    formLoginCam.Get_LoginStatus_Cam2(ref ucPage1.SecondaryCam_Manager.LoginInfo);

                    //Start live view
                    if (ERR_OK == ucPage1.Start_PlayCam2())
                    {
                        TrangThaiCam.Text = "Camera phụ: Đã kết nối!";
                    }
                    else
                    {
                        btLogin_IPCamera.Visible = true;
                        TrangThaiCam.Text = "Camera phụ: Lỗi không xem được video!";
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
                    TrangThaiCam.Text = "Camera phụ: Kết nối thất bại. Hãy kiểm tra cáp kết nối!";
                }
            }
            else
            {
                // Xu ly khi chua co thong tin luu trong database
                btLogin_IPCamera.Visible = true;
                ucPage1.ResetImage_Second();
                TrangThaiCam.Text = "Hãy nhập thông tin để có thể kết nối Camera!";
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
