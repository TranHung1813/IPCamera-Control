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
        //5. Luu vao git
        private const int ERR_OK = 0;
        private const int ERR_NOT_OK = 1;

        Page1 ucPage1 = new Page1();
        Page2 ucPage2 = new Page2();
        FormLoginCamera formLoginCam;
        private LoginCameraInfo_Type Login_Info;
        Thread Loading_Trd;

        private void InitForm_Default()
        {
            //Add user control to form
            Add_UserControl(ucPage1);
            // Setup default status for controls
            formLoginCam = new FormLoginCamera(ucPage1.LoginStatus, ucPage1.Live_Status);
            TrangThaiCam.Text = "Đang kết nối camera, xin vui lòng chờ!";
            Login_Info.LoginStatus = -1;
            Control.CheckForIllegalCrossThreadCalls = false;
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
        }

        private void tabPageInPhieu_Click(object sender, EventArgs e)
        {
            Add_UserControl(ucPage2);
        }

        private void btLogin_IPCamera_Click(object sender, EventArgs e)
        {
            if(formLoginCam.ShowDialog() == DialogResult.OK)
            {
                btLogin_IPCamera.Visible = false;
                TrangThaiCam.Text = "Camera: Kết nối Camera thành công. Đang tải hình ảnh ...";

                // Lay thong tin dang nhap thanh cong hay that bai
                formLoginCam.Get_Login_Status(ref Login_Info);

                // Start Live view
                ucPage1.LoginStatus = Login_Info.LoginStatus;
                if (ERR_OK == ucPage1.Start_PlayCam())
                {
                    TrangThaiCam.Text = "Camera: Đã kết nối!";
                }
                else
                {
                    TrangThaiCam.Text = "Camera: Lỗi không xem được video!";
                }

                // Luu thong tin Ket noi Camera vao database
                Save_LoginCamera_Info(Login_Info);
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

        private void Connect2Camera_using_Database_Info()
        {
            btLogin_IPCamera.Visible = false;
            //Get info number Items
            DataUser_LoginCamera_Info loginInfo = SqliteDataAccess.Load_LoginCamera_Info();

            if (loginInfo != null)
            {
                // Get info Login Camera and Login_Status
                Login_Info.IP_Address = loginInfo.IP_Address;
                Login_Info.Port = loginInfo.Port;
                Login_Info.Username = loginInfo.Username;
                Login_Info.Password = loginInfo.Password;

                // Login Camera roi Bat Live
                if (ERR_OK == formLoginCam.Login_Camera(Login_Info))
                {
                    btLogin_IPCamera.Visible = false;
                    TrangThaiCam.Text = "Camera: Kết nối Camera thành công. Đang tải hình ảnh ...";

                    // Lay thong tin dang nhap thanh cong hay that bai
                    formLoginCam.Get_Login_Status(ref Login_Info);

                    //Start live view
                    ucPage1.LoginStatus = Login_Info.LoginStatus;
                    if (ERR_OK == ucPage1.Start_PlayCam())
                    {
                        TrangThaiCam.Text = "Camera: Đã kết nối!";
                    }
                    else
                    {
                        btLogin_IPCamera.Visible = true;
                        TrangThaiCam.Text = "Camera: Lỗi không xem được video!";
                    }
                }
                else
                {
                    btLogin_IPCamera.Visible = true;
                    formLoginCam.Load_Database_Info(Login_Info);
                    ucPage1.ResetImage();
                    TrangThaiCam.Text = "Camera: Kết nối thất bại. Hãy kiểm tra cáp kết nối!";
                }
            }
            else
            {
                btLogin_IPCamera.Visible = true;
                // Xu ly khi chua co thong tin luu trong database
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
            Connect2Camera_using_Database_Info();
            Loading_Trd.Abort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ucPage1.RefreshImage();
        }
    }

}
