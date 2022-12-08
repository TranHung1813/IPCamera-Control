
namespace IPCameraManager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btSystemSetting = new Guna.UI2.WinForms.Guna2Button();
            this.btMinimize = new Guna.UI2.WinForms.Guna2Button();
            this.btExit = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabPageTimPhieu = new Guna.UI2.WinForms.Guna2Button();
            this.tabPageCaidatCamera = new Guna.UI2.WinForms.Guna2Button();
            this.tabPage_InPhieu = new Guna.UI2.WinForms.Guna2Button();
            this.tabPage_KhamBenh = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panelBorder_Left = new System.Windows.Forms.Panel();
            this.panelBorder_Right = new System.Windows.Forms.Panel();
            this.timer_Update_PatientInfo_to_Page2 = new System.Windows.Forms.Timer(this.components);
            this.timer_GetCamStatus = new System.Windows.Forms.Timer(this.components);
            this.cMStrip_Setting = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btLogin_IPCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.btTimeCorrection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btReboot_MainCam = new System.Windows.Forms.ToolStripMenuItem();
            this.btReboot_Cam2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btResetConfig_MainCam = new System.Windows.Forms.ToolStripMenuItem();
            this.btResetConfig_Cam2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btSetFolderchuaAnh = new System.Windows.Forms.ToolStripMenuItem();
            this.btSetFile_MauPhieuKham = new System.Windows.Forms.ToolStripMenuItem();
            this.btSetting_KeyboardShortcut = new System.Windows.Forms.ToolStripMenuItem();
            this.kiểmTraCậpNhậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_GetRTC = new System.Windows.Forms.Timer(this.components);
            this.panelUnknown = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.cMStrip_Setting.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.guna2ControlBox1);
            this.panel1.Controls.Add(this.btSystemSetting);
            this.panel1.Controls.Add(this.btMinimize);
            this.panel1.Controls.Add(this.btExit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 37);
            this.panel1.TabIndex = 6;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.guna2ControlBox1.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox1.CustomIconSize = 13F;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Gray;
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(933, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(55, 37);
            this.guna2ControlBox1.TabIndex = 37;
            // 
            // btSystemSetting
            // 
            this.btSystemSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSystemSetting.CheckedState.Parent = this.btSystemSetting;
            this.btSystemSetting.CustomImages.Parent = this.btSystemSetting;
            this.btSystemSetting.FillColor = System.Drawing.Color.Transparent;
            this.btSystemSetting.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSystemSetting.ForeColor = System.Drawing.Color.White;
            this.btSystemSetting.HoverState.FillColor = System.Drawing.Color.Gray;
            this.btSystemSetting.HoverState.Parent = this.btSystemSetting;
            this.btSystemSetting.Image = global::IPCameraManager.Properties.Resources.setting_Icon1;
            this.btSystemSetting.ImageOffset = new System.Drawing.Point(0, 1);
            this.btSystemSetting.ImageSize = new System.Drawing.Size(26, 24);
            this.btSystemSetting.Location = new System.Drawing.Point(819, 0);
            this.btSystemSetting.Name = "btSystemSetting";
            this.btSystemSetting.ShadowDecoration.Parent = this.btSystemSetting;
            this.btSystemSetting.Size = new System.Drawing.Size(55, 37);
            this.btSystemSetting.TabIndex = 36;
            this.btSystemSetting.Click += new System.EventHandler(this.btSystemSetting_Click);
            // 
            // btMinimize
            // 
            this.btMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMinimize.CheckedState.Parent = this.btMinimize;
            this.btMinimize.CustomImages.Parent = this.btMinimize;
            this.btMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btMinimize.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMinimize.ForeColor = System.Drawing.Color.White;
            this.btMinimize.HoverState.FillColor = System.Drawing.Color.Gray;
            this.btMinimize.HoverState.Parent = this.btMinimize;
            this.btMinimize.Location = new System.Drawing.Point(877, 0);
            this.btMinimize.Name = "btMinimize";
            this.btMinimize.ShadowDecoration.Parent = this.btMinimize;
            this.btMinimize.Size = new System.Drawing.Size(55, 37);
            this.btMinimize.TabIndex = 34;
            this.btMinimize.Text = "-";
            this.btMinimize.Click += new System.EventHandler(this.btMinimize_Click);
            // 
            // btExit
            // 
            this.btExit.CheckedState.Parent = this.btExit;
            this.btExit.CustomImages.Parent = this.btExit;
            this.btExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btExit.FillColor = System.Drawing.Color.Transparent;
            this.btExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit.ForeColor = System.Drawing.Color.White;
            this.btExit.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btExit.HoverState.Parent = this.btExit;
            this.btExit.Location = new System.Drawing.Point(989, 0);
            this.btExit.Name = "btExit";
            this.btExit.ShadowDecoration.Parent = this.btExit;
            this.btExit.Size = new System.Drawing.Size(55, 37);
            this.btExit.TabIndex = 2;
            this.btExit.Text = "X";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(48, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phần mềm quản lý Camera";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 22;
            this.guna2Elipse1.TargetControl = this;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.tabPageTimPhieu);
            this.panel2.Controls.Add(this.tabPageCaidatCamera);
            this.panel2.Controls.Add(this.tabPage_InPhieu);
            this.panel2.Controls.Add(this.tabPage_KhamBenh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1044, 43);
            this.panel2.TabIndex = 7;
            // 
            // tabPageTimPhieu
            // 
            this.tabPageTimPhieu.BackColor = System.Drawing.Color.Transparent;
            this.tabPageTimPhieu.BorderRadius = 5;
            this.tabPageTimPhieu.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.tabPageTimPhieu.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabPageTimPhieu.CheckedState.FillColor = System.Drawing.Color.White;
            this.tabPageTimPhieu.CheckedState.Parent = this.tabPageTimPhieu;
            this.tabPageTimPhieu.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tabPageTimPhieu.CustomImages.Parent = this.tabPageTimPhieu;
            this.tabPageTimPhieu.FillColor = System.Drawing.Color.White;
            this.tabPageTimPhieu.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.tabPageTimPhieu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPageTimPhieu.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.tabPageTimPhieu.HoverState.Parent = this.tabPageTimPhieu;
            this.tabPageTimPhieu.Image = global::IPCameraManager.Properties.Resources.LookingIcon1;
            this.tabPageTimPhieu.ImageSize = new System.Drawing.Size(36, 36);
            this.tabPageTimPhieu.Location = new System.Drawing.Point(555, 0);
            this.tabPageTimPhieu.Name = "tabPageTimPhieu";
            this.tabPageTimPhieu.ShadowDecoration.Parent = this.tabPageTimPhieu;
            this.tabPageTimPhieu.Size = new System.Drawing.Size(186, 43);
            this.tabPageTimPhieu.TabIndex = 6;
            this.tabPageTimPhieu.Text = "Tìm phiếu khám (F8)";
            this.tabPageTimPhieu.UseTransparentBackground = true;
            this.tabPageTimPhieu.Click += new System.EventHandler(this.tabPageTimPhieu_Click);
            // 
            // tabPageCaidatCamera
            // 
            this.tabPageCaidatCamera.BackColor = System.Drawing.Color.Transparent;
            this.tabPageCaidatCamera.BorderRadius = 5;
            this.tabPageCaidatCamera.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.tabPageCaidatCamera.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabPageCaidatCamera.CheckedState.FillColor = System.Drawing.Color.White;
            this.tabPageCaidatCamera.CheckedState.Parent = this.tabPageCaidatCamera;
            this.tabPageCaidatCamera.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tabPageCaidatCamera.CustomImages.Parent = this.tabPageCaidatCamera;
            this.tabPageCaidatCamera.FillColor = System.Drawing.Color.White;
            this.tabPageCaidatCamera.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.tabPageCaidatCamera.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPageCaidatCamera.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.tabPageCaidatCamera.HoverState.Parent = this.tabPageCaidatCamera;
            this.tabPageCaidatCamera.Image = global::IPCameraManager.Properties.Resources.Camera1;
            this.tabPageCaidatCamera.ImageSize = new System.Drawing.Size(32, 32);
            this.tabPageCaidatCamera.Location = new System.Drawing.Point(364, 0);
            this.tabPageCaidatCamera.Name = "tabPageCaidatCamera";
            this.tabPageCaidatCamera.ShadowDecoration.Parent = this.tabPageCaidatCamera;
            this.tabPageCaidatCamera.Size = new System.Drawing.Size(192, 43);
            this.tabPageCaidatCamera.TabIndex = 5;
            this.tabPageCaidatCamera.Text = "Cài đặt Camera (F7)";
            this.tabPageCaidatCamera.UseTransparentBackground = true;
            this.tabPageCaidatCamera.Click += new System.EventHandler(this.tabPageCaidatCamera_Click);
            // 
            // tabPage_InPhieu
            // 
            this.tabPage_InPhieu.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_InPhieu.BorderRadius = 5;
            this.tabPage_InPhieu.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.tabPage_InPhieu.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabPage_InPhieu.CheckedState.FillColor = System.Drawing.Color.White;
            this.tabPage_InPhieu.CheckedState.Parent = this.tabPage_InPhieu;
            this.tabPage_InPhieu.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tabPage_InPhieu.CustomImages.Parent = this.tabPage_InPhieu;
            this.tabPage_InPhieu.FillColor = System.Drawing.Color.White;
            this.tabPage_InPhieu.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.tabPage_InPhieu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPage_InPhieu.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.tabPage_InPhieu.HoverState.Parent = this.tabPage_InPhieu;
            this.tabPage_InPhieu.Image = ((System.Drawing.Image)(resources.GetObject("tabPage_InPhieu.Image")));
            this.tabPage_InPhieu.ImageSize = new System.Drawing.Size(32, 32);
            this.tabPage_InPhieu.Location = new System.Drawing.Point(178, 0);
            this.tabPage_InPhieu.Name = "tabPage_InPhieu";
            this.tabPage_InPhieu.ShadowDecoration.Parent = this.tabPage_InPhieu;
            this.tabPage_InPhieu.Size = new System.Drawing.Size(187, 43);
            this.tabPage_InPhieu.TabIndex = 1;
            this.tabPage_InPhieu.Text = "In Phiếu Khám (F4)";
            this.tabPage_InPhieu.UseTransparentBackground = true;
            this.tabPage_InPhieu.Click += new System.EventHandler(this.tabPageInPhieu_Click);
            // 
            // tabPage_KhamBenh
            // 
            this.tabPage_KhamBenh.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_KhamBenh.BorderRadius = 5;
            this.tabPage_KhamBenh.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.tabPage_KhamBenh.Checked = true;
            this.tabPage_KhamBenh.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabPage_KhamBenh.CheckedState.FillColor = System.Drawing.Color.White;
            this.tabPage_KhamBenh.CheckedState.Parent = this.tabPage_KhamBenh;
            this.tabPage_KhamBenh.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tabPage_KhamBenh.CustomImages.Parent = this.tabPage_KhamBenh;
            this.tabPage_KhamBenh.FillColor = System.Drawing.Color.White;
            this.tabPage_KhamBenh.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.tabPage_KhamBenh.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPage_KhamBenh.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.tabPage_KhamBenh.HoverState.Parent = this.tabPage_KhamBenh;
            this.tabPage_KhamBenh.Image = ((System.Drawing.Image)(resources.GetObject("tabPage_KhamBenh.Image")));
            this.tabPage_KhamBenh.ImageSize = new System.Drawing.Size(32, 32);
            this.tabPage_KhamBenh.Location = new System.Drawing.Point(2, 0);
            this.tabPage_KhamBenh.Name = "tabPage_KhamBenh";
            this.tabPage_KhamBenh.ShadowDecoration.Parent = this.tabPage_KhamBenh;
            this.tabPage_KhamBenh.Size = new System.Drawing.Size(177, 43);
            this.tabPage_KhamBenh.TabIndex = 0;
            this.tabPage_KhamBenh.Text = "KHÁM BỆNH (F3)";
            this.tabPage_KhamBenh.UseTransparentBackground = true;
            this.tabPage_KhamBenh.Click += new System.EventHandler(this.tabPage_KhamBenh_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.panel1;
            // 
            // panelBorder_Left
            // 
            this.panelBorder_Left.BackColor = System.Drawing.Color.SlateBlue;
            this.panelBorder_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBorder_Left.Location = new System.Drawing.Point(0, 80);
            this.panelBorder_Left.Name = "panelBorder_Left";
            this.panelBorder_Left.Size = new System.Drawing.Size(1, 640);
            this.panelBorder_Left.TabIndex = 9;
            // 
            // panelBorder_Right
            // 
            this.panelBorder_Right.BackColor = System.Drawing.Color.SlateBlue;
            this.panelBorder_Right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBorder_Right.Location = new System.Drawing.Point(1042, 80);
            this.panelBorder_Right.Name = "panelBorder_Right";
            this.panelBorder_Right.Size = new System.Drawing.Size(2, 640);
            this.panelBorder_Right.TabIndex = 0;
            // 
            // timer_Update_PatientInfo_to_Page2
            // 
            this.timer_Update_PatientInfo_to_Page2.Enabled = true;
            this.timer_Update_PatientInfo_to_Page2.Tick += new System.EventHandler(this.timer_Update_PatientInfo_to_Page2_Tick);
            // 
            // timer_GetCamStatus
            // 
            this.timer_GetCamStatus.Interval = 3000;
            this.timer_GetCamStatus.Tick += new System.EventHandler(this.timer_GetCamStatus_Tick);
            // 
            // cMStrip_Setting
            // 
            this.cMStrip_Setting.BackColor = System.Drawing.Color.White;
            this.cMStrip_Setting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btLogin_IPCamera,
            this.btTimeCorrection,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.btSetFolderchuaAnh,
            this.btSetFile_MauPhieuKham,
            this.btSetting_KeyboardShortcut,
            this.kiểmTraCậpNhậtToolStripMenuItem});
            this.cMStrip_Setting.Name = "cMStrip_Setting";
            this.cMStrip_Setting.Size = new System.Drawing.Size(287, 196);
            // 
            // btLogin_IPCamera
            // 
            this.btLogin_IPCamera.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogin_IPCamera.Name = "btLogin_IPCamera";
            this.btLogin_IPCamera.ShowShortcutKeys = false;
            this.btLogin_IPCamera.Size = new System.Drawing.Size(286, 24);
            this.btLogin_IPCamera.Text = "Kết nối Camera";
            this.btLogin_IPCamera.Click += new System.EventHandler(this.btLogin_IPCamera_Click);
            // 
            // btTimeCorrection
            // 
            this.btTimeCorrection.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTimeCorrection.Name = "btTimeCorrection";
            this.btTimeCorrection.Size = new System.Drawing.Size(286, 24);
            this.btTimeCorrection.Text = "Hiệu chỉnh thời gian Camera";
            this.btTimeCorrection.Click += new System.EventHandler(this.btTimeCorrection_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btReboot_MainCam,
            this.btReboot_Cam2});
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(286, 24);
            this.toolStripMenuItem2.Text = "Khởi động lại Camera";
            // 
            // btReboot_MainCam
            // 
            this.btReboot_MainCam.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReboot_MainCam.Name = "btReboot_MainCam";
            this.btReboot_MainCam.Size = new System.Drawing.Size(166, 22);
            this.btReboot_MainCam.Text = "Camera chính";
            this.btReboot_MainCam.Click += new System.EventHandler(this.btReboot_MainCam_Click);
            // 
            // btReboot_Cam2
            // 
            this.btReboot_Cam2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReboot_Cam2.Name = "btReboot_Cam2";
            this.btReboot_Cam2.Size = new System.Drawing.Size(166, 22);
            this.btReboot_Cam2.Text = "Camera phụ";
            this.btReboot_Cam2.Click += new System.EventHandler(this.btReboot_Cam2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btResetConfig_MainCam,
            this.btResetConfig_Cam2});
            this.toolStripMenuItem3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(286, 24);
            this.toolStripMenuItem3.Text = "Khôi phục cài đặt gốc Camera";
            // 
            // btResetConfig_MainCam
            // 
            this.btResetConfig_MainCam.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btResetConfig_MainCam.Name = "btResetConfig_MainCam";
            this.btResetConfig_MainCam.Size = new System.Drawing.Size(180, 22);
            this.btResetConfig_MainCam.Text = "Camera chính";
            this.btResetConfig_MainCam.Click += new System.EventHandler(this.btResetConfig_MainCam_Click);
            // 
            // btResetConfig_Cam2
            // 
            this.btResetConfig_Cam2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btResetConfig_Cam2.Name = "btResetConfig_Cam2";
            this.btResetConfig_Cam2.Size = new System.Drawing.Size(180, 22);
            this.btResetConfig_Cam2.Text = "Camera phụ";
            this.btResetConfig_Cam2.Click += new System.EventHandler(this.btResetConfig_Cam2_Click);
            // 
            // btSetFolderchuaAnh
            // 
            this.btSetFolderchuaAnh.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSetFolderchuaAnh.Name = "btSetFolderchuaAnh";
            this.btSetFolderchuaAnh.Size = new System.Drawing.Size(286, 24);
            this.btSetFolderchuaAnh.Text = "Cài đặt folder chứa ảnh";
            this.btSetFolderchuaAnh.Click += new System.EventHandler(this.btSetFolderchuaAnh_Click);
            // 
            // btSetFile_MauPhieuKham
            // 
            this.btSetFile_MauPhieuKham.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSetFile_MauPhieuKham.Name = "btSetFile_MauPhieuKham";
            this.btSetFile_MauPhieuKham.Size = new System.Drawing.Size(286, 24);
            this.btSetFile_MauPhieuKham.Text = "Cài đặt file Mẫu phiếu khám";
            this.btSetFile_MauPhieuKham.Click += new System.EventHandler(this.btSetFile_MauPhieuKham_Click);
            // 
            // btSetting_KeyboardShortcut
            // 
            this.btSetting_KeyboardShortcut.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSetting_KeyboardShortcut.Name = "btSetting_KeyboardShortcut";
            this.btSetting_KeyboardShortcut.Size = new System.Drawing.Size(286, 24);
            this.btSetting_KeyboardShortcut.Text = "Cài đặt lại phím tắt";
            this.btSetting_KeyboardShortcut.Click += new System.EventHandler(this.btSetting_KeyboardShortcut_Click);
            // 
            // kiểmTraCậpNhậtToolStripMenuItem
            // 
            this.kiểmTraCậpNhậtToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kiểmTraCậpNhậtToolStripMenuItem.Name = "kiểmTraCậpNhậtToolStripMenuItem";
            this.kiểmTraCậpNhậtToolStripMenuItem.Size = new System.Drawing.Size(286, 24);
            this.kiểmTraCậpNhậtToolStripMenuItem.Text = "Kiểm tra cập nhật";
            // 
            // timer_GetRTC
            // 
            this.timer_GetRTC.Interval = 1000;
            this.timer_GetRTC.Tick += new System.EventHandler(this.timer_GetRTC_Tick);
            // 
            // panelUnknown
            // 
            this.panelUnknown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUnknown.Location = new System.Drawing.Point(0, 80);
            this.panelUnknown.Name = "panelUnknown";
            this.panelUnknown.Size = new System.Drawing.Size(1044, 640);
            this.panelUnknown.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1044, 720);
            this.Controls.Add(this.panelBorder_Right);
            this.Controls.Add(this.panelBorder_Left);
            this.Controls.Add(this.panelUnknown);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.cMStrip_Setting.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button tabPage_KhamBenh;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button tabPage_InPhieu;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Button btMinimize;
        private System.Windows.Forms.Panel panelBorder_Right;
        private System.Windows.Forms.Panel panelBorder_Left;
        private Guna.UI2.WinForms.Guna2Button btExit;
        private System.Windows.Forms.Timer timer_Update_PatientInfo_to_Page2;
        private System.Windows.Forms.Timer timer_GetCamStatus;
        private Guna.UI2.WinForms.Guna2Button tabPageTimPhieu;
        private Guna.UI2.WinForms.Guna2Button tabPageCaidatCamera;
        private Guna.UI2.WinForms.Guna2Button btSystemSetting;
        private System.Windows.Forms.ContextMenuStrip cMStrip_Setting;
        private System.Windows.Forms.ToolStripMenuItem btLogin_IPCamera;
        private System.Windows.Forms.ToolStripMenuItem btSetFolderchuaAnh;
        private System.Windows.Forms.ToolStripMenuItem btTimeCorrection;
        private System.Windows.Forms.ToolStripMenuItem kiểmTraCậpNhậtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btSetFile_MauPhieuKham;
        private System.Windows.Forms.ToolStripMenuItem btSetting_KeyboardShortcut;
        private System.Windows.Forms.Timer timer_GetRTC;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Panel panelUnknown;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem btReboot_MainCam;
        private System.Windows.Forms.ToolStripMenuItem btReboot_Cam2;
        private System.Windows.Forms.ToolStripMenuItem btResetConfig_MainCam;
        private System.Windows.Forms.ToolStripMenuItem btResetConfig_Cam2;
    }
}

