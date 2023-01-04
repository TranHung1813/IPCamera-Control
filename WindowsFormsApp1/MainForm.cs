using System;
using System.Collections.Generic;
using System.Drawing;
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
            //CheckForUpdates();
        }
        //1. Luu thong tin dang nhap (Done)
        //2. Tao form loading cho Camera (Done)
        //3. Xua ly tinh nang chup anh, in phieu, chon anh, lay duong dan, ... (done)
        //4. Hien thi trang thai cam qua control Status (Done, need test)
        //5. Luu vao git (Done)
        //6. Kiem tra do an toan cua Thread (Check xem cac nut co duoc nhan hay khong) (Done)
        //7. In barcode (bo)
        //8. Them tinh nang nhan nut (F1,F2,...) (done)
        //9. Them debug mode
        //10. Check lai thong tin size anh (Done, Auto is OK)
        //11. Them tinh nang phong to [] (done)
        //12. Them tinh nang Cam phu (done, testing)
        //13. Xem xet tinh nang Refresh (logout-> login-> start live view) (done)
        //14. Chon Folder luu anh chup (done)
        //15. Luu folder save file vao database (done)
        //16. Check box Luu thong tin trong Form Login
        //17. Code them phan Secondary Camera (done, testing)
        //18. Bug chuyen tab tu dong load du lieu trong (Form Login) (done)
        //19. Them Camera Phu Info vao database (done)
        //20. Bo het gia dein UI ra khoi Thread (Hard) (No need)
        //21. Fix 2 bug: 1. F7 ton nhieu thoi gian, 2. Login status = 1 cua Camera Phu (done)
        //22. Patient Info add to database (done)
        //23. Check xem k can login lai sau khi ket noi lai camera thi co chay k (Done, Co chay)
        //24. Them try catch vao button In Phieu Kham (done)
        //25. Van de load lai thong tin benh nhan cu: Can load thong tin gi? (done)
        //26. Them tinh nang PZT, chinh sua Do sang, contrast, ... vao menu Setting (done)
        //27. Kiem tra ket noi Camera tu dong (done)
        //28. Popup canh bao Message khi mat ket noi (Done)
        //29. Day Form Setup PTZ xuong MainForm (done)
        //30. Save thong tin File Mau Phieu Kham (done)
        //31. In barcode vao trong file Phieu Kham (no need)
        //32. Sua lai tinh nang khong cho mo 2 form cung luc (done)
        //33. Thêm tab Cài đặt Camera (done)
        //34. Thêm tab Xem lai phieu kham cu, bam vao anh thì phóng to (done)
        //35. Thêm nút cài đặt trong Mainform: cài đặt folder chứa ảnh, mẫu khám, kết nối Camera (done)
        //36. Hỏi lại bệnh viện về thông tin nhập vào Phiếu khám (mã BN, mã phiếu khám) (done, nothing change)
        //37. Xem lại Đường dẫn file ảnh (có thể tìm kiếm tông qua đương dẫn)
        //39. Thêm giờ khám vào thông tin bênh nhân
        //40. Thêm thông tin bênh nhân vào trong ảnh chụp từ Camera chính  (done)
        //41. Config brightness, constrat, ... bằng hàm CHCNetSDK.CLIENT_SDK_SetVideoEffect() (done)
        //42. Chuyen Tab khac -> dừng Camera -> Giảm CPU (khong can vi chuyen Tab khac thi khong ton CPU chay Camera)
        //43. Them hướng Pan/Title chéo (= ngang + dọc) (done) 
        //44. Them Timer de dieu chinh thanh Slide Bar cho muot (done)
        //45. Chinh lai vi tri luu File word Phieu Kham sau khi Print
        //46. Xac dinh xem neu trung PID thi ghi đè hay cảnh báo cho người dùng (done, both)

        //38. Thêm thứ ngày tháng vào thanh StatusBar (done)
        //47. Bo thong bao chup anh thanh cong (done, popup kieu thong bao moi)
        //48. Double Click -> phong to anh (done)
        //49. Them duong dan vao anh trong form Find Patient
        //50. Thời gian thong bao "chua chon anh" qua lau khi bam button In Phieu (done)

        //51. Load Patient Info trong form F8 take time
        //52. Click event vào notification form (done)
        //53. Vi tri luu file word Phieu Kham cua BN
        //54. Debug voi man hinh to FUll HD
        //55. Encode IP Address, Port (done, need test)
        private const int ERR_OK = 0;
        private const int ERR_NOT_OK = 1;

        Page1 ucPage1 = new Page1();
        Page2 ucPage2 = new Page2();
        PageSearchPatient ucPageSearchPatient = new PageSearchPatient();
        PageSetupCamera_Info ucPageSetupCamera_Info;
        FormLoginCamera formLoginCam;
        Thread Loading_MainCam_Trd;
        Thread Loading_Cam2_Trd;

        private const int PAGE1 = 1;
        private const int PAGE2 = 2;
        private const int PAGE3 = 3;
        private const int PAGE4 = 4;
        private int TabPageID = PAGE1;

        SetFoldertoSaveFile_Form SetFolder_Form = new SetFoldertoSaveFile_Form();
        FormSetTemplateDirectory formSetTemplateDirectory = new FormSetTemplateDirectory();
        FormTimeCorrect formTimeCorrect = new FormTimeCorrect();

        FormLoginSettingMenu formLogin = new FormLoginSettingMenu();
        private bool Admin_Allow = false;

        //WhatTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt");
        StatusBar mainStatusBar = new StatusBar();
        StatusBarPanel TrangThaiCamChinh = new StatusBarPanel();
        StatusBarPanel TrangThaiCamPhu = new StatusBarPanel();
        StatusBarPanel datetimePanel = new StatusBarPanel();

        //private async void CheckForUpdates()
        //{
        //    //UpdateManager manager = await UpdateManager.GitHubUpdateManager(@"https://github.com/TranHung1813/IPCamera-Control");
        //    //var updateInfo = await manager.CheckForUpdate();
        //    //if (updateInfo.ReleasesToApply.Count > 0)
        //    //{
        //    //    if(MessageBox.Show($"New version available ({updateInfo.ReleasesToApply[0].Version}). Update?", "Update?", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //    //    {
        //    //        await manager.UpdateApp();
        //    //        MessageBox.Show("Update complete, please restart application.");
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    MessageBox.Show("No update.");
        //    //}
        //}
        private void InitForm_Default()
        {
            //Init key press event
            this.KeyPreview = true;
            this.KeyUp += new KeyEventHandler(RoomView_KeyUp);
            this.KeyDown += new KeyEventHandler(RoomView_KeyDown);
            //Add user control to form
            Add_UserControl(ucPage1);
            TabPageID = PAGE1;
            // Setup menu Setting
            ToolStripLabel tSL1 = new ToolStripLabel();
            tSL1.Text = "Camera";
            tSL1.TextAlign = ContentAlignment.MiddleCenter;
            tSL1.Font = new Font("Tahoma", 10, FontStyle.Bold);
            cMStrip_Setting.Items.Insert(0, new ToolStripSeparator());
            cMStrip_Setting.Items.Insert(1, tSL1);

            ToolStripLabel tSL2 = new ToolStripLabel();
            tSL2.Text = "Folder";
            tSL2.TextAlign = ContentAlignment.MiddleCenter;
            tSL2.Font = new Font("Tahoma", 10, FontStyle.Bold);
            cMStrip_Setting.Items.Insert(6, new ToolStripSeparator());
            cMStrip_Setting.Items.Insert(7, tSL2);

            ToolStripLabel tSL3 = new ToolStripLabel();
            tSL3.Text = "Hệ thống";
            tSL3.TextAlign = ContentAlignment.MiddleCenter;
            tSL3.Font = new Font("Tahoma", 10, FontStyle.Bold);
            cMStrip_Setting.Items.Insert(10, new ToolStripSeparator());
            cMStrip_Setting.Items.Insert(11, tSL3);
            // Setup default status for controls
            ucPageSetupCamera_Info = new PageSetupCamera_Info();
            formLoginCam = new FormLoginCamera(ucPage1.MainCam_Manager, ucPage1.SecondaryCam_Manager);
            TrangThaiCamChinh.Text = "Camera chính: Đang kết nối, xin vui lòng chờ!";
            TrangThaiCamPhu.Text = "Camera phụ: Đang kết nối, xin vui lòng chờ!";
            //Setup Folder name for Page1, Page2
            // Get Folder Save File info
            DataUser_Other_Info Info = SqliteDataAccess.Load_Other_Info();

            if (Info != null)
            {
                // Set Folder Name to Save File to ucPage1, ucPage2
                ucPage1.SetFolderName_to_SaveFile(Info.FolderSaveFile);
                SetFolder_Form.SetFolderName(Info.FolderSaveFile);
                ucPage2.SetFolderName(Info.FolderSaveFile);
            }
            else
            {
                // Handle when database = null
            }
            // Get File Mau Phieu Kham info
            DataUser_MauPhieuKham_Info Template_Info = SqliteDataAccess.Load_MauPhieuKham_Info();

            if (Template_Info != null)
            {
                // Set File Mau Phieu Kham
                ucPage2.SetMauPhieuKham(Template_Info.MauPhieuKham1, Template_Info.MauPhieuKham2);
                formSetTemplateDirectory.SetMauPhieuKhamPath(Template_Info.MauPhieuKham1,
                                                             Template_Info.MauPhieuKham2);
            }
            else
            {
                // Handle when database = null
            }
            // Get Number Patients Info
            // Get File Mau Phieu Kham info
            DataUser_NumberPatients_Info NumberPatients_Info = SqliteDataAccess.Load_NumberPatients_Info();

            if (NumberPatients_Info != null)
            {
                ucPage2.Set_NumberPatients_Info(NumberPatients_Info.Number_Patients);
            }
            else
            {
                // Handle when database = null
            }

            // Get RealTime in Status Bar

            // Set first panel properties and add to StatusBar  
            TrangThaiCamChinh.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            TrangThaiCamChinh.Text = "";
            TrangThaiCamChinh.ToolTipText = "Trạng thái Camera chính";
            TrangThaiCamChinh.Alignment = HorizontalAlignment.Center;
            TrangThaiCamChinh.AutoSize = StatusBarPanelAutoSize.Contents;
            mainStatusBar.Panels.Add(TrangThaiCamChinh);

            // Set first panel properties and add to StatusBar  
            TrangThaiCamPhu.BorderStyle = StatusBarPanelBorderStyle.Raised;
            TrangThaiCamPhu.Text = "";
            TrangThaiCamPhu.ToolTipText = "Trạng thái Camera phụ";
            TrangThaiCamPhu.AutoSize = StatusBarPanelAutoSize.Spring;
            mainStatusBar.Panels.Add(TrangThaiCamPhu);

            mainStatusBar.Font = new Font("Tahoma", 12F);
            mainStatusBar.ShowPanels = true;
            Controls.Add(mainStatusBar);

            // Set second panel properties and add to StatusBar  
            datetimePanel.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            datetimePanel.AutoSize = StatusBarPanelAutoSize.Contents;
            datetimePanel.Alignment = HorizontalAlignment.Center;
            string DayNumber = "";
            int day1 = (int)DateTime.Now.DayOfWeek;
            if (day1 == 0) DayNumber = "Chủ nhật";
            else DayNumber = "Thứ " + (day1 + 1).ToString();
            datetimePanel.ToolTipText = DateTime.Now.ToLongDateString();
            datetimePanel.Text = DayNumber + ", " + DateTime.UtcNow.Date.ToString("d/M/yyyy") + "  " + DateTime.Now.ToLongTimeString();
            mainStatusBar.Panels.Add(datetimePanel);
            timer_GetRTC.Start();

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
                case Keys.F7:
                    if (TabPageID != PAGE3)
                    {
                        // Chuyen sang tab Setup Camera
                        tabPageCaidatCamera_Click(sender, e);
                        if (tabPageCaidatCamera.CanFocus)
                        {
                            tabPageCaidatCamera.Focus();
                            tabPageCaidatCamera.Checked = true;
                        }
                    }
                    break;
                case Keys.F8:
                    if (TabPageID != PAGE4)
                    {
                        // Chuyen sang tab Tim kiem Phieu kham
                        tabPageTimPhieu_Click(sender, e);
                        if (tabPageTimPhieu.CanFocus)
                        {
                            tabPageTimPhieu.Focus();
                            tabPageTimPhieu.Checked = true;
                        }
                    }
                    break;
                case Keys.F9:
                    if (TabPageID == PAGE2)
                    {
                        // Nhan nut In Phieu Kham
                        ucPage2.btInPhieu_F9_MouseUp_Click();
                    }
                    break;
                case Keys.F12:
                    ucPage1.btExit_F12_Click(sender, e);
                    break;
                // Dieu chinh PTZ Camera
                case Keys.W:
                    if (TabPageID == PAGE3)
                    {
                        ucPageSetupCamera_Info.btnUp_MouseUp(sender, null);
                    }
                    break;
                case Keys.S:
                    if (TabPageID == PAGE3)
                    {
                        ucPageSetupCamera_Info.btnDown_MouseUp(sender, null);
                    }
                    break;
                case Keys.D:
                    if (TabPageID == PAGE3)
                    {
                        ucPageSetupCamera_Info.btnRight_MouseUp(sender, null);
                    }
                    break;
                case Keys.A:
                    if (TabPageID == PAGE3)
                    {
                        ucPageSetupCamera_Info.btnLeft_MouseUp(sender, null);
                    }
                    break;
            }
        }
        void RoomView_KeyDown(object sender, KeyEventArgs e)
        {
            if (TabPageID == PAGE3)
            {
                // Dieu chinh PTZ Camera
                switch (e.KeyCode)
                {
                    case Keys.W:
                        ucPageSetupCamera_Info.btnUp_MouseDown(sender, null);
                        break;
                    case Keys.S:
                        ucPageSetupCamera_Info.btnDown_MouseDown(sender, null);
                        break;
                    case Keys.D:
                        ucPageSetupCamera_Info.btnRight_MouseDown(sender, null);
                        break;
                    case Keys.A:
                        ucPageSetupCamera_Info.btnLeft_MouseDown(sender, null);
                        break;
                }
            }
        }
        private void Add_UserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            panelUnknown.Controls.Clear();
            panelUnknown.Controls.Add(uc);
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
            this.WindowState = FormWindowState.Maximized;
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
        private void tabPageCaidatCamera_Click(object sender, EventArgs e)
        {
            if (TabPageID != PAGE3)
            {
                Add_UserControl(ucPageSetupCamera_Info);
                TabPageID = PAGE3;
            }
        }

        private void tabPageTimPhieu_Click(object sender, EventArgs e)
        {
            if (TabPageID != PAGE4)
            {
                Add_UserControl(ucPageSearchPatient);
                TabPageID = PAGE4;
                ucPageSearchPatient.Load_Patients_Info();
            }
        }

        private void btLogin_IPCamera_Click(object sender, EventArgs e)
        {
            if (formLoginCam.ShowDialog() == DialogResult.OK)
            {
                /* ---------- CAMERA CHINH ---------- */
                // Lay thong tin dang nhap Camera chinh thanh cong hay that bai
                formLoginCam.Get_LoginStatus_MainCam(ref ucPage1.MainCam_Manager.LoginInfo);
                // Set login info to TABPAGE3
                ucPageSetupCamera_Info.SetLoginInfo_MainCAM(ucPage1.MainCam_Manager.LoginInfo);
                // Login thanh cong
                if (ucPage1.MainCam_Manager.LoginInfo.LoginStatus >= 0)
                {
                    // Login thanh cong
                    TrangThaiCamChinh.Text = "Camera chính: Kết nối Camera thành công. Đang tải hình ảnh ...";
                    // Lay tgian thuc cho Camera
                    formTimeCorrect.Get_RealTime();
                    formTimeCorrect.TimeCorrection(ucPage1.MainCam_Manager.LoginInfo);
                    // Init Fill Text Overlay
                    ucPage1.FillTextOverlay_Init();
                    // Start Live view
                    if (ucPage1.MainCam_Manager.Live_Status < 0)
                    {
                        if (ERR_OK == ucPage1.Start_PlayMainCam())
                        {
                            TrangThaiCamChinh.Text = "Camera chính: Đã kết nối!";
                            btMainCamRefresh_Click(sender, e);
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
                                btMainCamRefresh_Click(sender, e);
                            }
                            else
                            {
                                TrangThaiCamChinh.Text = "Camera chính: Lỗi không xem được video!";
                            }
                        }
                        else
                        {
                            TrangThaiCamChinh.Text = "Camera chính: Kết nối thất bại. Hãy kiểm tra cáp kết nối!";
                        }
                    }

                    // Luu thong tin Ket noi Camera vao database
                    Save_Login_MainCam_Info(ucPage1.MainCam_Manager.LoginInfo);
                }
                else
                {
                    // Da dang xuat
                    TrangThaiCamChinh.Text = "Camera chính: Đã ngắt kết nối!";
                    if (ucPage1.MainCam_Manager.Live_Status >= 0)
                    {
                        if (ERR_OK == ucPage1.Stop_PlayMainCam())
                        {

                        }
                    }
                }
                /* ---------- CAMERA PHU ---------- */
                // Lay thong tin dang nhap Camera phu thanh cong hay that bai
                formLoginCam.Get_LoginStatus_Cam2(ref ucPage1.SecondaryCam_Manager.LoginInfo);
                // Set login info to TABPAGE3
                ucPageSetupCamera_Info.SetLogin_Info_SecondCAM(ucPage1.SecondaryCam_Manager.LoginInfo);
                // Login thanh cong
                if (ucPage1.SecondaryCam_Manager.LoginInfo.LoginStatus >= 0)
                {
                    // Login thanh cong
                    TrangThaiCamPhu.Text = "Camera phụ: Kết nối Camera thành công. Đang tải hình ảnh ...";
                    // Lay tgian thuc cho Camera
                    formTimeCorrect.Get_RealTime();
                    formTimeCorrect.TimeCorrection(ucPage1.SecondaryCam_Manager.LoginInfo);
                    // Start Live view
                    if (ucPage1.SecondaryCam_Manager.Live_Status < 0)
                    {
                        if (ERR_OK == ucPage1.Start_PlayCam2())
                        {
                            TrangThaiCamPhu.Text = "Camera phụ: Đã kết nối!";
                            btSecondCamRefresh_Click(sender, e);
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
                                btSecondCamRefresh_Click(sender, e);
                            }
                            else
                            {
                                TrangThaiCamPhu.Text = "Camera phụ: Lỗi không xem được video!";
                            }
                        }
                        else
                        {
                            TrangThaiCamPhu.Text = "Camera phụ: Kết nối thất bại. Hãy kiểm tra cáp kết nối!";
                        }
                    }

                    // Luu thong tin Ket noi Camera vao database
                    Save_Login_Cam2_Info(ucPage1.SecondaryCam_Manager.LoginInfo);
                }
                else if (ucPage1.SecondaryCam_Manager.LoginInfo.LoginStatus < 0)
                {
                    // Da dang xuat
                    TrangThaiCamPhu.Text = "Camera phụ: Đã ngắt kết nối!";
                    if (ucPage1.SecondaryCam_Manager.Live_Status >= 0)
                    {
                        if (ERR_OK == ucPage1.Stop_PlayCam2())
                        {

                        }
                    }
                }
            }
        }
        private void Save_Login_MainCam_Info(LoginCameraInfo_Type LoginInfo)
        {
            DataUser_LoginCamera_Info loginInfo_Save = new DataUser_LoginCamera_Info();
            loginInfo_Save.Id = 1;
            loginInfo_Save.IP_Address = Encode(LoginInfo.IP_Address, LoginInfo.IP_Address.Length);
            loginInfo_Save.Port = Encode(LoginInfo.IP_Address + LoginInfo.Port, (LoginInfo.IP_Address + LoginInfo.Port).Length);
            loginInfo_Save.Username = LoginInfo.Username;
            loginInfo_Save.Password = LoginInfo.Password;

            SqliteDataAccess.SaveInfo_LoginCamera(loginInfo_Save);
        }
        private void Save_Login_Cam2_Info(LoginCameraInfo_Type LoginInfo)
        {
            DataUser_LoginCamera_Info loginInfo_Save = new DataUser_LoginCamera_Info();
            loginInfo_Save.Id = 2;
            loginInfo_Save.IP_Address = Encode(LoginInfo.IP_Address, LoginInfo.IP_Address.Length);
            loginInfo_Save.Port = Encode(LoginInfo.IP_Address + LoginInfo.Port, (LoginInfo.IP_Address + LoginInfo.Port).Length);
            loginInfo_Save.Username = LoginInfo.Username;
            loginInfo_Save.Password = LoginInfo.Password;

            SqliteDataAccess.SaveInfo_LoginCamera(loginInfo_Save);
        }

        private string Encode (string SeedKey, int Key_Length)
        {
            if(Key_Length > 32 || SeedKey == "")
            {
                return null;
            }
            string PrivateKey1 = "nhdbBtZ1Bop6ouWMyXrsOpxhtvF90WJg";
            string New_PrivateKey1 = PrivateKey1.Substring(0, Key_Length);

            var New_PrivateKey1_Bytes = Encoding.ASCII.GetBytes(New_PrivateKey1);
            var SeedKey_Bytes = Encoding.ASCII.GetBytes(SeedKey);

            for (int CountByte = 0; CountByte < New_PrivateKey1_Bytes.Length; CountByte++)
            {
                New_PrivateKey1_Bytes[CountByte] ^= SeedKey_Bytes[CountByte];
            }
            // XOR 4 byte cuoi
            for (int CountByte = 0; CountByte < New_PrivateKey1_Bytes.Length; CountByte++)
            {
                if(CountByte != New_PrivateKey1_Bytes.Length - 1)
                {
                    New_PrivateKey1_Bytes[CountByte] ^= New_PrivateKey1_Bytes[New_PrivateKey1_Bytes.Length - 1];
                }
            }
            for (int CountByte = 0; CountByte < New_PrivateKey1_Bytes.Length; CountByte++)
            {
                if (CountByte != New_PrivateKey1_Bytes.Length - 2)
                {
                    New_PrivateKey1_Bytes[CountByte] ^= New_PrivateKey1_Bytes[New_PrivateKey1_Bytes.Length - 2];
                }
            }
            for (int CountByte = 0; CountByte < New_PrivateKey1_Bytes.Length; CountByte++)
            {
                if (CountByte != New_PrivateKey1_Bytes.Length - 3)
                {
                    New_PrivateKey1_Bytes[CountByte] ^= New_PrivateKey1_Bytes[New_PrivateKey1_Bytes.Length - 3];
                }
            }
            for (int CountByte = 0; CountByte < New_PrivateKey1_Bytes.Length; CountByte++)
            {
                if (CountByte != New_PrivateKey1_Bytes.Length - 4)
                {
                    New_PrivateKey1_Bytes[CountByte] ^= New_PrivateKey1_Bytes[New_PrivateKey1_Bytes.Length - 4];
                }
            }
            for (int CountByte = 0; CountByte < New_PrivateKey1_Bytes.Length; CountByte++)
            {
                if (CountByte != New_PrivateKey1_Bytes.Length - 5)
                {
                    New_PrivateKey1_Bytes[CountByte] ^= New_PrivateKey1_Bytes[New_PrivateKey1_Bytes.Length - 5];
                }
            }

            return String.Join(" ", New_PrivateKey1_Bytes);
        }
        private string Decode(string Key2Decode)
        {
            string PrivateKey1 = "nhdbBtZ1Bop6ouWMyXrsOpxhtvF90WJg";

            string[] Str_Array = Key2Decode.Split(' ');

            byte[] Byte_Array = new byte[Str_Array.Length];
            for (int CountString = 0; CountString < Str_Array.Length; CountString++)
            {
                Byte_Array[CountString] = byte.Parse(Str_Array[CountString]);
            }
            // XOR 4 byte cuoi
            for (int CountByte = 0; CountByte < Byte_Array.Length; CountByte++)
            {
                if (CountByte != Byte_Array.Length - 5)
                {
                    Byte_Array[CountByte] ^= Byte_Array[Byte_Array.Length - 5];
                }
            }
            for (int CountByte = 0; CountByte < Byte_Array.Length; CountByte++)
            {
                if (CountByte != Byte_Array.Length - 4)
                {
                    Byte_Array[CountByte] ^= Byte_Array[Byte_Array.Length - 4];
                }
            }
            for (int CountByte = 0; CountByte < Byte_Array.Length; CountByte++)
            {
                if (CountByte != Byte_Array.Length - 3)
                {
                    Byte_Array[CountByte] ^= Byte_Array[Byte_Array.Length - 3];
                }
            }
            for (int CountByte = 0; CountByte < Byte_Array.Length; CountByte++)
            {
                if (CountByte != Byte_Array.Length - 2)
                {
                    Byte_Array[CountByte] ^= Byte_Array[Byte_Array.Length - 2];
                }
            }
            for (int CountByte = 0; CountByte < Byte_Array.Length; CountByte++)
            {
                if (CountByte != Byte_Array.Length - 1)
                {
                    Byte_Array[CountByte] ^= Byte_Array[Byte_Array.Length - 1];
                }
            }
            // XOR Private Key
            string New_PrivateKey1 = PrivateKey1.Substring(0, Byte_Array.Length);
            var New_PrivateKey1_Bytes = Encoding.ASCII.GetBytes(New_PrivateKey1);
            for (int CountByte = 0; CountByte < Byte_Array.Length; CountByte++)
            {
                Byte_Array[CountByte] ^= New_PrivateKey1_Bytes[CountByte];
            }

            char[] Code_CharArray = new char[Byte_Array.Length];
            for (int CountByte = 0; CountByte < Byte_Array.Length; CountByte++)
            {
                Code_CharArray[CountByte] = (char)Byte_Array[CountByte];
            }

            return String.Join("", Code_CharArray);
        }

        private void Connect2MainCam_using_Database_Info()
        {
            //Get Login info
            List<DataUser_LoginCamera_Info> loginInfo = SqliteDataAccess.Load_LoginCamera_Info();

            if (loginInfo != null && (loginInfo.Count >= 1))
            {
                // Get info Login Camera and Login_Status
                string IPAddress = "";
                string PortValue = "";
                try
                {
                    IPAddress = Decode(loginInfo[0].IP_Address);
                    PortValue = Decode(loginInfo[0].Port);
                    PortValue = PortValue.Substring(PortValue.Length - 4);
                }
                catch
                { }
                ucPage1.MainCam_Manager.LoginInfo.IP_Address = IPAddress;
                ucPage1.MainCam_Manager.LoginInfo.Port = PortValue;
                ucPage1.MainCam_Manager.LoginInfo.Username = loginInfo[0].Username;
                ucPage1.MainCam_Manager.LoginInfo.Password = loginInfo[0].Password;

                formLoginCam.Load_MainCAM_Database_Info(ucPage1.MainCam_Manager.LoginInfo);

                // Login Camera roi Bat Live
                if (ERR_OK == formLoginCam.Login_Main_Camera_with_no_MessageBox(ucPage1.MainCam_Manager.LoginInfo))
                {
                    TrangThaiCamChinh.Text = "Camera chính: Kết nối Camera thành công. Đang tải hình ảnh ...";

                    // Lay thong tin dang nhap thanh cong hay that bai
                    formLoginCam.Get_LoginStatus_MainCam(ref ucPage1.MainCam_Manager.LoginInfo);

                    // Set login info to TABPAGE3
                    ucPageSetupCamera_Info.SetLoginInfo_MainCAM(ucPage1.MainCam_Manager.LoginInfo);

                    // Set thoi gian thuc cho Camera
                    formTimeCorrect.Get_RealTime();
                    formTimeCorrect.TimeCorrection(ucPage1.MainCam_Manager.LoginInfo);

                    // Init Fill Text Overlay
                    ucPage1.FillTextOverlay_Init();

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
                        TrangThaiCamChinh.Text = "Camera chính: Lỗi không xem được video!";
                        // Tu dong Dang xuat
                        formLoginCam.Logout_Main_Camera(ucPage1.MainCam_Manager.LoginInfo);
                        // Lay thong tin dang xuat thanh cong hay that bai
                        formLoginCam.Get_LoginStatus_MainCam(ref ucPage1.MainCam_Manager.LoginInfo);
                    }
                }
                else
                {
                    ucPage1.ResetImage_Main();
                    TrangThaiCamChinh.Text = "Camera chính: Kết nối thất bại. Hãy kiểm tra cáp kết nối!";
                    // Set login info to TABPAGE3
                    ucPageSetupCamera_Info.SetLoginInfo_MainCAM(ucPage1.MainCam_Manager.LoginInfo);
                }
            }
            else
            {
                // Xu ly khi chua co thong tin luu trong database
                ucPage1.ResetImage_Main();
                TrangThaiCamChinh.Text = "Hãy nhập thông tin để có thể kết nối Camera!";
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Utility.fitFormToScreen(this, 766, 1366);
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
                    TrangThaiCamChinh.Text = "Camera chính: Kết nối thất bại. Hãy kiểm tra cáp kết nối!";
                }
            }
        }

        private void btSecondCamRefresh_Click(object sender, EventArgs e)
        {
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
                    TrangThaiCamPhu.Text = "Camera phụ: Kết nối thất bại. Hãy kiểm tra cáp kết nối!";
                }
            }
        }
        //*****************************************************************************************************************
        //****************************************** Access to Secondary Camera *******************************************
        private void Connect2Cam2_using_Database_Info()
        {
            //Get Login info
            List<DataUser_LoginCamera_Info> loginInfo = SqliteDataAccess.Load_LoginCamera_Info();

            if (loginInfo != null && (loginInfo.Count >= 2))
            {
                // Get info Login Camera and Login_Status
                string IPAddress = "";
                string PortValue = "";
                try
                {
                    IPAddress = Decode(loginInfo[1].IP_Address);
                    PortValue = Decode(loginInfo[1].Port);
                    PortValue = PortValue.Substring(PortValue.Length - 4);
                }
                catch
                { }
                ucPage1.SecondaryCam_Manager.LoginInfo.IP_Address = IPAddress;
                ucPage1.SecondaryCam_Manager.LoginInfo.Port = PortValue;
                ucPage1.SecondaryCam_Manager.LoginInfo.Username = loginInfo[1].Username;
                ucPage1.SecondaryCam_Manager.LoginInfo.Password = loginInfo[1].Password;

                formLoginCam.Load_SecondCAM_Database_Info(ucPage1.SecondaryCam_Manager.LoginInfo);

                // Login Camera roi Bat Live
                if (ERR_OK == formLoginCam.Login_Second_Camera_with_no_MessageBox(ucPage1.SecondaryCam_Manager.LoginInfo))
                {
                    TrangThaiCamPhu.Text = "Camera phụ: Kết nối Camera thành công. Đang tải hình ảnh ...";
                    // Lay thong tin dang nhap thanh cong hay that bai
                    formLoginCam.Get_LoginStatus_Cam2(ref ucPage1.SecondaryCam_Manager.LoginInfo);
                    // Set login info to TABPAGE3
                    ucPageSetupCamera_Info.SetLogin_Info_SecondCAM(ucPage1.SecondaryCam_Manager.LoginInfo);
                    // Lay tgian thuc cho Camera
                    formTimeCorrect.Get_RealTime();
                    formTimeCorrect.TimeCorrection(ucPage1.SecondaryCam_Manager.LoginInfo);
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
                        TrangThaiCamPhu.Text = "Camera phụ: Lỗi không xem được video!";
                        // Tu dong Dang xuat
                        formLoginCam.Login_Second_Camera(ucPage1.SecondaryCam_Manager.LoginInfo);
                        // Lay thong tin dang xuat thanh cong hay that bai
                        formLoginCam.Get_LoginStatus_Cam2(ref ucPage1.SecondaryCam_Manager.LoginInfo);
                    }
                }
                else
                {
                    ucPage1.ResetImage_Second();
                    TrangThaiCamPhu.Text = "Camera phụ: Kết nối thất bại. Hãy kiểm tra cáp kết nối!";
                    // Set login info to TABPAGE3
                    ucPageSetupCamera_Info.SetLogin_Info_SecondCAM(ucPage1.SecondaryCam_Manager.LoginInfo);
                }
            }
            else
            {
                // Xu ly khi chua co thong tin luu trong database
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
        private bool isWarning_MainCam = false;
        private int Count_TimeRetry_MainCam = 0;
        private int Count_TimeRetry_Cam2 = 0;
        private const int MAXTIME_RETRY = 3;
        private bool isWarning_Cam2 = false;
        private void timer_GetCamStatus_Tick(object sender, EventArgs e)
        {
            if (ucPage1.MainCam_Manager.Live_Status >= 0)
            {
                if (ucPage1.MAINCAM_Data_Available == true)
                {
                    ucPage1.MAINCAM_Data_Available = false;
                    isWarning_MainCam = false;
                    Count_TimeRetry_MainCam = 0;
                    TrangThaiCamChinh.Text = "Camera chính: Đã kết nối!";
                }
                else
                {
                    TrangThaiCamChinh.Text = "Camera chính: Mất kết nối. Hãy kiểm tra cáp kết nối!";
                    if (++Count_TimeRetry_MainCam >= MAXTIME_RETRY)
                    {
                        Count_TimeRetry_MainCam = 0;
                        if (isWarning_MainCam == false)
                        {
                            isWarning_MainCam = true;
                            //MessageBox.Show("Camera chính: Mất kết nối. Hãy kiểm tra cáp kết nối!",
                            //                        "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            if (ucPage1.SecondaryCam_Manager.Live_Status >= 0)
            {
                if (ucPage1.CAM2_Data_Available == true)
                {
                    ucPage1.CAM2_Data_Available = false;
                    isWarning_Cam2 = false;
                    Count_TimeRetry_Cam2 = 0;
                    TrangThaiCamPhu.Text = "Camera phụ: Đã kết nối!";
                }
                else
                {
                    TrangThaiCamPhu.Text = "Camera phụ: Mất kết nối. Hãy kiểm tra cáp kết nối!";
                    if (++Count_TimeRetry_Cam2 >= MAXTIME_RETRY)
                    {
                        Count_TimeRetry_Cam2 = 0;
                        if (isWarning_Cam2 == false)
                        {
                            isWarning_Cam2 = true;
                            //MessageBox.Show("Camera phụ: Mất kết nối. Hãy kiểm tra cáp kết nối!",
                            //                        "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }
        // Cài đặt Context Menu Strip
        private void btSystemSetting_Click(object sender, EventArgs e)
        {
            if(Admin_Allow == false)
            {
                if (formLogin.ShowDialog() == DialogResult.OK)
                {
                    Admin_Allow = true;
                    Point point = this.PointToScreen(btSystemSetting.Location);
                    point.Y += btSystemSetting.Height;
                    cMStrip_Setting.Show(point);
                }
            }
            else
            {
                Point point = this.PointToScreen(btSystemSetting.Location);
                point.Y += btSystemSetting.Height;
                cMStrip_Setting.Show(point);
            }
        }

        private void btSetFolderchuaAnh_Click(object sender, EventArgs e)
        {
            string FolderName = "";
            if (SetFolder_Form.ShowDialog() == DialogResult.OK)
            {
                SetFolder_Form.GetFolderName(ref FolderName);
                ucPage1.SetFolderName_to_SaveFile(FolderName);
                ucPage2.SetFolderName(FolderName);
                Save_FolderSaveFile_Info(FolderName);
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

        private void btSetFile_MauPhieuKham_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == formSetTemplateDirectory.ShowDialog())
            {
                string FileName1 = "";
                string FileName2 = "";
                formSetTemplateDirectory.GetMauPhieuKhamPath(ref FileName1, ref FileName2);
                ucPage2.SetMauPhieuKham(FileName1, FileName2);

                DataUser_MauPhieuKham_Info InfoSave = new DataUser_MauPhieuKham_Info();
                InfoSave.Id = 1;
                InfoSave.MauPhieuKham1 = FileName1;
                InfoSave.MauPhieuKham2 = FileName2;

                SqliteDataAccess.SaveInfo_MauPhieuKham(InfoSave);
            }
        }

        private void btTimeCorrection_Click(object sender, EventArgs e)
        {
            formTimeCorrect.SetLoginCamera_Info(ucPage1.MainCam_Manager.LoginInfo,
                                                ucPage1.SecondaryCam_Manager.LoginInfo);
            if (DialogResult.OK == formTimeCorrect.ShowDialog())
            {

            }
        }

        private void timer_GetRTC_Tick(object sender, EventArgs e)
        {
            string DayNumber = "";
            int day1 = (int)DateTime.Now.DayOfWeek;
            if (day1 == 0) DayNumber = "Chủ nhật";
            else DayNumber = "Thứ " + (day1 + 1).ToString();
            datetimePanel.ToolTipText = DateTime.Now.ToLongDateString();
            datetimePanel.Text = DayNumber + ", " + DateTime.UtcNow.Date.ToString("d/M/yyyy") + "  " + DateTime.Now.ToLongTimeString();
        }
        private void btReboot_MainCam_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = CHCNetSDK.NET_DVR_RebootDVR(ucPage1.MainCam_Manager.LoginInfo.LoginStatus);
                if (result == true)
                {
                    MessageBox.Show("Camera chính đang được khởi động lại", "SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Khởi động lại Camera chính thất bại", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {

            }
        }

        private void btReboot_Cam2_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = CHCNetSDK.NET_DVR_RebootDVR(ucPage1.SecondaryCam_Manager.LoginInfo.LoginStatus);
                if (result == true)
                {
                    MessageBox.Show("Camera phụ đang được khởi động lại", "SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Khởi động lại Camera phụ thất bại", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {

            }
        }

        private void btResetConfig_MainCam_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = CHCNetSDK.NET_DVR_RestoreConfig(ucPage1.MainCam_Manager.LoginInfo.LoginStatus);
                if (result == true)
                {
                    MessageBox.Show("Khôi phục cài đặt gốc Camera chính thành công", "SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Khôi phục cài đặt gốc Camera chính thất bại", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {

            }
        }

        private void btResetConfig_Cam2_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = CHCNetSDK.NET_DVR_RestoreConfig(ucPage1.SecondaryCam_Manager.LoginInfo.LoginStatus);
                if (result == true)
                {
                    MessageBox.Show("Khôi phục cài đặt gốc Camera phụ thành công", "SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Khôi phục cài đặt gốc Camera phụ thất bại", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {

            }
        }
        // Cai dat mat khau cho Menu Setting
        FormSetting_KeyboardShortcut formSetting = new FormSetting_KeyboardShortcut();
        private void btSetting_KeyboardShortcut_Click(object sender, EventArgs e)
        {
            formSetting.ShowDialog();
        }
    }

    public class CameraManager_Type
    {
        public bool InitCam_Status { get; set; } = false;
        public Int32 Live_Status { get; set; } = -1;
        public LoginCameraInfo_Type LoginInfo;
    }

}
