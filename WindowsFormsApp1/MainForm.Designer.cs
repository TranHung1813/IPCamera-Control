
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
            this.btSystemSetting = new Guna.UI2.WinForms.Guna2Button();
            this.btMaximize = new Guna.UI2.WinForms.Guna2Button();
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
            this.panelUnknown = new System.Windows.Forms.Panel();
            this.Status1 = new System.Windows.Forms.StatusStrip();
            this.TrangThaiCamChinh = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TrangThaiCamPhu = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelBorder_Left = new System.Windows.Forms.Panel();
            this.panelBorder_Right = new System.Windows.Forms.Panel();
            this.timer_Update_PatientInfo_to_Page2 = new System.Windows.Forms.Timer(this.components);
            this.timer_GetCamStatus = new System.Windows.Forms.Timer(this.components);
            this.cMStrip_Setting = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btLogin_IPCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.càiĐặtFileMẫuPhiếuKhámToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btSetFolderchuaAnh = new System.Windows.Forms.ToolStripMenuItem();
            this.btSetFile_MauPhieuKham = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kiểmTraCậpNhậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.Status1.SuspendLayout();
            this.cMStrip_Setting.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.btSystemSetting);
            this.panel1.Controls.Add(this.btMaximize);
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
            // btSystemSetting
            // 
            this.btSystemSetting.CheckedState.Parent = this.btSystemSetting;
            this.btSystemSetting.CustomImages.Parent = this.btSystemSetting;
            this.btSystemSetting.FillColor = System.Drawing.Color.Transparent;
            this.btSystemSetting.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSystemSetting.ForeColor = System.Drawing.Color.White;
            this.btSystemSetting.HoverState.FillColor = System.Drawing.Color.Gray;
            this.btSystemSetting.HoverState.Parent = this.btSystemSetting;
            this.btSystemSetting.Image = global::IPCameraManager.Properties.Resources.setting_Icon1;
            this.btSystemSetting.ImageSize = new System.Drawing.Size(26, 26);
            this.btSystemSetting.Location = new System.Drawing.Point(819, 0);
            this.btSystemSetting.Name = "btSystemSetting";
            this.btSystemSetting.ShadowDecoration.Parent = this.btSystemSetting;
            this.btSystemSetting.Size = new System.Drawing.Size(55, 37);
            this.btSystemSetting.TabIndex = 36;
            this.btSystemSetting.Click += new System.EventHandler(this.btSystemSetting_Click);
            // 
            // btMaximize
            // 
            this.btMaximize.CheckedState.Parent = this.btMaximize;
            this.btMaximize.CustomImages.Parent = this.btMaximize;
            this.btMaximize.FillColor = System.Drawing.Color.Transparent;
            this.btMaximize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMaximize.ForeColor = System.Drawing.Color.White;
            this.btMaximize.HoverState.FillColor = System.Drawing.Color.Gray;
            this.btMaximize.HoverState.Parent = this.btMaximize;
            this.btMaximize.Location = new System.Drawing.Point(933, 0);
            this.btMaximize.Name = "btMaximize";
            this.btMaximize.ShadowDecoration.Parent = this.btMaximize;
            this.btMaximize.Size = new System.Drawing.Size(55, 37);
            this.btMaximize.TabIndex = 35;
            this.btMaximize.Text = "[ ]";
            this.btMaximize.Click += new System.EventHandler(this.btMaximize_Click);
            // 
            // btMinimize
            // 
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
            // panelUnknown
            // 
            this.panelUnknown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUnknown.Location = new System.Drawing.Point(0, 80);
            this.panelUnknown.Name = "panelUnknown";
            this.panelUnknown.Size = new System.Drawing.Size(1044, 640);
            this.panelUnknown.TabIndex = 8;
            // 
            // Status1
            // 
            this.Status1.BackColor = System.Drawing.Color.Gainsboro;
            this.Status1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrangThaiCamChinh,
            this.toolStripStatusLabel1,
            this.TrangThaiCamPhu});
            this.Status1.Location = new System.Drawing.Point(0, 696);
            this.Status1.Name = "Status1";
            this.Status1.Size = new System.Drawing.Size(1044, 24);
            this.Status1.TabIndex = 0;
            this.Status1.Text = "Status1";
            // 
            // TrangThaiCamChinh
            // 
            this.TrangThaiCamChinh.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TrangThaiCamChinh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TrangThaiCamChinh.Font = new System.Drawing.Font("Tahoma", 12F);
            this.TrangThaiCamChinh.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.TrangThaiCamChinh.Name = "TrangThaiCamChinh";
            this.TrangThaiCamChinh.Size = new System.Drawing.Size(250, 19);
            this.TrangThaiCamChinh.Text = " Camera chính: Không có kết nối! ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 19);
            // 
            // TrangThaiCamPhu
            // 
            this.TrangThaiCamPhu.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TrangThaiCamPhu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TrangThaiCamPhu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrangThaiCamPhu.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.TrangThaiCamPhu.Name = "TrangThaiCamPhu";
            this.TrangThaiCamPhu.Size = new System.Drawing.Size(239, 19);
            this.TrangThaiCamPhu.Text = " Camera phụ: Không có kết nối! ";
            // 
            // panelBorder_Left
            // 
            this.panelBorder_Left.BackColor = System.Drawing.Color.SlateBlue;
            this.panelBorder_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBorder_Left.Location = new System.Drawing.Point(0, 80);
            this.panelBorder_Left.Name = "panelBorder_Left";
            this.panelBorder_Left.Size = new System.Drawing.Size(1, 616);
            this.panelBorder_Left.TabIndex = 9;
            // 
            // panelBorder_Right
            // 
            this.panelBorder_Right.BackColor = System.Drawing.Color.SlateBlue;
            this.panelBorder_Right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBorder_Right.Location = new System.Drawing.Point(1042, 80);
            this.panelBorder_Right.Name = "panelBorder_Right";
            this.panelBorder_Right.Size = new System.Drawing.Size(2, 616);
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
            this.cMStrip_Setting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btLogin_IPCamera,
            this.càiĐặtFileMẫuPhiếuKhámToolStripMenuItem,
            this.btSetFolderchuaAnh,
            this.btSetFile_MauPhieuKham,
            this.toolStripMenuItem1,
            this.kiểmTraCậpNhậtToolStripMenuItem});
            this.cMStrip_Setting.Name = "cMStrip_Setting";
            this.cMStrip_Setting.Size = new System.Drawing.Size(278, 170);
            // 
            // btLogin_IPCamera
            // 
            this.btLogin_IPCamera.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogin_IPCamera.Image = global::IPCameraManager.Properties.Resources.Printer;
            this.btLogin_IPCamera.Name = "btLogin_IPCamera";
            this.btLogin_IPCamera.ShowShortcutKeys = false;
            this.btLogin_IPCamera.Size = new System.Drawing.Size(277, 24);
            this.btLogin_IPCamera.Text = "Kết nối Camera";
            this.btLogin_IPCamera.Click += new System.EventHandler(this.btLogin_IPCamera_Click);
            // 
            // càiĐặtFileMẫuPhiếuKhámToolStripMenuItem
            // 
            this.càiĐặtFileMẫuPhiếuKhámToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.càiĐặtFileMẫuPhiếuKhámToolStripMenuItem.Name = "càiĐặtFileMẫuPhiếuKhámToolStripMenuItem";
            this.càiĐặtFileMẫuPhiếuKhámToolStripMenuItem.Size = new System.Drawing.Size(277, 24);
            this.càiĐặtFileMẫuPhiếuKhámToolStripMenuItem.Text = "Hiệu chỉnh thời gian Camera";
            this.càiĐặtFileMẫuPhiếuKhámToolStripMenuItem.Click += new System.EventHandler(this.càiĐặtFileMẫuPhiếuKhámToolStripMenuItem_Click);
            // 
            // btSetFolderchuaAnh
            // 
            this.btSetFolderchuaAnh.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSetFolderchuaAnh.Name = "btSetFolderchuaAnh";
            this.btSetFolderchuaAnh.Size = new System.Drawing.Size(277, 24);
            this.btSetFolderchuaAnh.Text = "Cài đặt folder chứa ảnh";
            this.btSetFolderchuaAnh.Click += new System.EventHandler(this.btSetFolderchuaAnh_Click);
            // 
            // btSetFile_MauPhieuKham
            // 
            this.btSetFile_MauPhieuKham.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSetFile_MauPhieuKham.Name = "btSetFile_MauPhieuKham";
            this.btSetFile_MauPhieuKham.Size = new System.Drawing.Size(277, 24);
            this.btSetFile_MauPhieuKham.Text = "Cài đặt file Mẫu phiếu khám";
            this.btSetFile_MauPhieuKham.Click += new System.EventHandler(this.btSetFile_MauPhieuKham_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(277, 24);
            this.toolStripMenuItem1.Text = "Cài đặt lại phím tắt";
            // 
            // kiểmTraCậpNhậtToolStripMenuItem
            // 
            this.kiểmTraCậpNhậtToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kiểmTraCậpNhậtToolStripMenuItem.Name = "kiểmTraCậpNhậtToolStripMenuItem";
            this.kiểmTraCậpNhậtToolStripMenuItem.Size = new System.Drawing.Size(277, 24);
            this.kiểmTraCậpNhậtToolStripMenuItem.Text = "Kiểm tra cập nhật";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1044, 720);
            this.Controls.Add(this.panelBorder_Right);
            this.Controls.Add(this.panelBorder_Left);
            this.Controls.Add(this.Status1);
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
            this.Status1.ResumeLayout(false);
            this.Status1.PerformLayout();
            this.cMStrip_Setting.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Guna.UI2.WinForms.Guna2Button btMaximize;
        private System.Windows.Forms.Panel panelUnknown;
        private System.Windows.Forms.StatusStrip Status1;
        private System.Windows.Forms.ToolStripStatusLabel TrangThaiCamChinh;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panelBorder_Right;
        private System.Windows.Forms.Panel panelBorder_Left;
        private Guna.UI2.WinForms.Guna2Button btExit;
        private System.Windows.Forms.Timer timer_Update_PatientInfo_to_Page2;
        private System.Windows.Forms.Timer timer_GetCamStatus;
        private System.Windows.Forms.ToolStripStatusLabel TrangThaiCamPhu;
        private Guna.UI2.WinForms.Guna2Button tabPageTimPhieu;
        private Guna.UI2.WinForms.Guna2Button tabPageCaidatCamera;
        private Guna.UI2.WinForms.Guna2Button btSystemSetting;
        private System.Windows.Forms.ContextMenuStrip cMStrip_Setting;
        private System.Windows.Forms.ToolStripMenuItem btLogin_IPCamera;
        private System.Windows.Forms.ToolStripMenuItem btSetFolderchuaAnh;
        private System.Windows.Forms.ToolStripMenuItem càiĐặtFileMẫuPhiếuKhámToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kiểmTraCậpNhậtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btSetFile_MauPhieuKham;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

