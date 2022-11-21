
namespace IPCameraManager
{
    partial class Page1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Page1));
            this.btOpen_Cam2 = new System.Windows.Forms.Button();
            this.btnOpen_MainCam = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbGioiTinh = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MaBN = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbTuoi = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbDiaChi = new System.Windows.Forms.TextBox();
            this.guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbHoTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbMaBenhNhan = new Guna.UI2.WinForms.Guna2TextBox();
            this.imgPreview = new System.Windows.Forms.PictureBox();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.btExit_F12 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.btTakePicture = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.RealPlayWnd = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RealPlayWnd)).BeginInit();
            this.SuspendLayout();
            // 
            // btOpen_Cam2
            // 
            this.btOpen_Cam2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOpen_Cam2.Location = new System.Drawing.Point(101, 282);
            this.btOpen_Cam2.Name = "btOpen_Cam2";
            this.btOpen_Cam2.Size = new System.Drawing.Size(170, 61);
            this.btOpen_Cam2.TabIndex = 32;
            this.btOpen_Cam2.Text = "Camera Phụ";
            this.btOpen_Cam2.Visible = false;
            // 
            // btnOpen_MainCam
            // 
            this.btnOpen_MainCam.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen_MainCam.Location = new System.Drawing.Point(101, 189);
            this.btnOpen_MainCam.Name = "btnOpen_MainCam";
            this.btnOpen_MainCam.Size = new System.Drawing.Size(170, 61);
            this.btnOpen_MainCam.TabIndex = 31;
            this.btnOpen_MainCam.Text = "Bật Camera";
            this.btnOpen_MainCam.Visible = false;
            this.btnOpen_MainCam.Click += new System.EventHandler(this.btOpen_MainCam_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(46, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 19);
            this.label12.TabIndex = 22;
            this.label12.Text = "Địa chỉ:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "Ngày Khám:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(226, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "Tuổi:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbGioiTinh
            // 
            this.tbGioiTinh.FormattingEnabled = true;
            this.tbGioiTinh.Items.AddRange(new object[] {
            " KHÁC",
            " NAM",
            " NỮ"});
            this.tbGioiTinh.Location = new System.Drawing.Point(114, 93);
            this.tbGioiTinh.Name = "tbGioiTinh";
            this.tbGioiTinh.Size = new System.Drawing.Size(106, 27);
            this.tbGioiTinh.TabIndex = 40;
            this.tbGioiTinh.Text = " NAM";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Giới Tính:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Họ Và Tên:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MaBN
            // 
            this.MaBN.AutoSize = true;
            this.MaBN.Location = new System.Drawing.Point(51, 33);
            this.MaBN.Name = "MaBN";
            this.MaBN.Size = new System.Drawing.Size(58, 19);
            this.MaBN.TabIndex = 0;
            this.MaBN.Text = "Mã Số:";
            this.MaBN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbTuoi);
            this.groupBox1.Controls.Add(this.tbDiaChi);
            this.groupBox1.Controls.Add(this.guna2TextBox2);
            this.groupBox1.Controls.Add(this.tbHoTen);
            this.groupBox1.Controls.Add(this.tbMaBenhNhan);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.imgPreview);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbGioiTinh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.MaBN);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(670, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 446);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập Thông Tin Bệnh Nhân";
            // 
            // tbTuoi
            // 
            this.tbTuoi.BackColor = System.Drawing.Color.Transparent;
            this.tbTuoi.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbTuoi.BorderRadius = 4;
            this.tbTuoi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTuoi.DefaultText = "";
            this.tbTuoi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbTuoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbTuoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTuoi.DisabledState.Parent = this.tbTuoi;
            this.tbTuoi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTuoi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTuoi.FocusedState.Parent = this.tbTuoi;
            this.tbTuoi.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTuoi.ForeColor = System.Drawing.Color.Black;
            this.tbTuoi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTuoi.HoverState.Parent = this.tbTuoi;
            this.tbTuoi.Location = new System.Drawing.Point(278, 93);
            this.tbTuoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbTuoi.Name = "tbTuoi";
            this.tbTuoi.PasswordChar = '\0';
            this.tbTuoi.PlaceholderText = "";
            this.tbTuoi.SelectedText = "";
            this.tbTuoi.ShadowDecoration.Parent = this.tbTuoi;
            this.tbTuoi.Size = new System.Drawing.Size(62, 27);
            this.tbTuoi.TabIndex = 41;
            // 
            // tbDiaChi
            // 
            this.tbDiaChi.Location = new System.Drawing.Point(114, 156);
            this.tbDiaChi.Multiline = true;
            this.tbDiaChi.Name = "tbDiaChi";
            this.tbDiaChi.Size = new System.Drawing.Size(226, 82);
            this.tbDiaChi.TabIndex = 43;
            // 
            // guna2TextBox2
            // 
            this.guna2TextBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2TextBox2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.guna2TextBox2.BorderRadius = 4;
            this.guna2TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox2.DefaultText = "";
            this.guna2TextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.DisabledState.Parent = this.guna2TextBox2;
            this.guna2TextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.FocusedState.Parent = this.guna2TextBox2;
            this.guna2TextBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox2.ForeColor = System.Drawing.Color.Black;
            this.guna2TextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.HoverState.Parent = this.guna2TextBox2;
            this.guna2TextBox2.Location = new System.Drawing.Point(114, 124);
            this.guna2TextBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2TextBox2.Name = "guna2TextBox2";
            this.guna2TextBox2.PasswordChar = '\0';
            this.guna2TextBox2.PlaceholderText = "";
            this.guna2TextBox2.SelectedText = "";
            this.guna2TextBox2.ShadowDecoration.Parent = this.guna2TextBox2;
            this.guna2TextBox2.Size = new System.Drawing.Size(226, 27);
            this.guna2TextBox2.TabIndex = 42;
            // 
            // tbHoTen
            // 
            this.tbHoTen.BackColor = System.Drawing.Color.Transparent;
            this.tbHoTen.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbHoTen.BorderRadius = 4;
            this.tbHoTen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbHoTen.DefaultText = "";
            this.tbHoTen.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbHoTen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbHoTen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbHoTen.DisabledState.Parent = this.tbHoTen;
            this.tbHoTen.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbHoTen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbHoTen.FocusedState.Parent = this.tbHoTen;
            this.tbHoTen.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHoTen.ForeColor = System.Drawing.Color.Black;
            this.tbHoTen.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbHoTen.HoverState.Parent = this.tbHoTen;
            this.tbHoTen.Location = new System.Drawing.Point(114, 62);
            this.tbHoTen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbHoTen.Name = "tbHoTen";
            this.tbHoTen.PasswordChar = '\0';
            this.tbHoTen.PlaceholderText = "";
            this.tbHoTen.SelectedText = "";
            this.tbHoTen.ShadowDecoration.Parent = this.tbHoTen;
            this.tbHoTen.Size = new System.Drawing.Size(226, 27);
            this.tbHoTen.TabIndex = 39;
            // 
            // tbMaBenhNhan
            // 
            this.tbMaBenhNhan.BackColor = System.Drawing.Color.Transparent;
            this.tbMaBenhNhan.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbMaBenhNhan.BorderRadius = 4;
            this.tbMaBenhNhan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbMaBenhNhan.DefaultText = "";
            this.tbMaBenhNhan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbMaBenhNhan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbMaBenhNhan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbMaBenhNhan.DisabledState.Parent = this.tbMaBenhNhan;
            this.tbMaBenhNhan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbMaBenhNhan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbMaBenhNhan.FocusedState.Parent = this.tbMaBenhNhan;
            this.tbMaBenhNhan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMaBenhNhan.ForeColor = System.Drawing.Color.Black;
            this.tbMaBenhNhan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbMaBenhNhan.HoverState.Parent = this.tbMaBenhNhan;
            this.tbMaBenhNhan.Location = new System.Drawing.Point(114, 31);
            this.tbMaBenhNhan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbMaBenhNhan.Name = "tbMaBenhNhan";
            this.tbMaBenhNhan.PasswordChar = '\0';
            this.tbMaBenhNhan.PlaceholderText = "";
            this.tbMaBenhNhan.SelectedText = "";
            this.tbMaBenhNhan.ShadowDecoration.Parent = this.tbMaBenhNhan;
            this.tbMaBenhNhan.Size = new System.Drawing.Size(226, 27);
            this.tbMaBenhNhan.TabIndex = 38;
            // 
            // imgPreview
            // 
            this.imgPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgPreview.Location = new System.Drawing.Point(55, 246);
            this.imgPreview.Name = "imgPreview";
            this.imgPreview.Size = new System.Drawing.Size(254, 194);
            this.imgPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPreview.TabIndex = 21;
            this.imgPreview.TabStop = false;
            // 
            // btExit_F12
            // 
            this.btExit_F12.BackColor = System.Drawing.Color.Transparent;
            this.btExit_F12.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btExit_F12.BorderRadius = 5;
            this.btExit_F12.BorderThickness = 1;
            this.btExit_F12.CheckedState.BorderColor = System.Drawing.Color.Blue;
            this.btExit_F12.CheckedState.Parent = this.btExit_F12;
            this.btExit_F12.CustomImages.Parent = this.btExit_F12;
            this.btExit_F12.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btExit_F12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit_F12.ForeColor = System.Drawing.Color.Black;
            this.btExit_F12.HoverState.FillColor = System.Drawing.Color.LightSteelBlue;
            this.btExit_F12.HoverState.Parent = this.btExit_F12;
            this.btExit_F12.Image = ((System.Drawing.Image)(resources.GetObject("btExit_F12.Image")));
            this.btExit_F12.ImageSize = new System.Drawing.Size(35, 35);
            this.btExit_F12.Location = new System.Drawing.Point(472, 526);
            this.btExit_F12.Name = "btExit_F12";
            this.btExit_F12.ShadowDecoration.Parent = this.btExit_F12;
            this.btExit_F12.Size = new System.Drawing.Size(152, 61);
            this.btExit_F12.TabIndex = 37;
            this.btExit_F12.Text = "  Thoát (F12)";
            this.btExit_F12.UseTransparentBackground = true;
            this.btExit_F12.Click += new System.EventHandler(this.btExit_F12_Click);
            // 
            // guna2Button4
            // 
            this.guna2Button4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button4.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.guna2Button4.BorderRadius = 5;
            this.guna2Button4.BorderThickness = 1;
            this.guna2Button4.CheckedState.BorderColor = System.Drawing.Color.Blue;
            this.guna2Button4.CheckedState.Parent = this.guna2Button4;
            this.guna2Button4.CustomImages.Parent = this.guna2Button4;
            this.guna2Button4.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Button4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button4.ForeColor = System.Drawing.Color.Black;
            this.guna2Button4.HoverState.FillColor = System.Drawing.Color.LightSteelBlue;
            this.guna2Button4.HoverState.Parent = this.guna2Button4;
            this.guna2Button4.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button4.Image")));
            this.guna2Button4.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2Button4.Location = new System.Drawing.Point(270, 526);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.ShadowDecoration.Parent = this.guna2Button4;
            this.guna2Button4.Size = new System.Drawing.Size(152, 61);
            this.guna2Button4.TabIndex = 36;
            this.guna2Button4.Text = "Cả Phòng (F6)";
            this.guna2Button4.UseTransparentBackground = true;
            // 
            // btTakePicture
            // 
            this.btTakePicture.BackColor = System.Drawing.Color.Transparent;
            this.btTakePicture.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btTakePicture.BorderRadius = 5;
            this.btTakePicture.BorderThickness = 1;
            this.btTakePicture.CheckedState.Parent = this.btTakePicture;
            this.btTakePicture.CustomImages.Parent = this.btTakePicture;
            this.btTakePicture.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btTakePicture.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTakePicture.ForeColor = System.Drawing.Color.Black;
            this.btTakePicture.HoverState.FillColor = System.Drawing.Color.LightSteelBlue;
            this.btTakePicture.HoverState.Parent = this.btTakePicture;
            this.btTakePicture.Image = ((System.Drawing.Image)(resources.GetObject("btTakePicture.Image")));
            this.btTakePicture.ImageSize = new System.Drawing.Size(35, 35);
            this.btTakePicture.Location = new System.Drawing.Point(68, 526);
            this.btTakePicture.Name = "btTakePicture";
            this.btTakePicture.ShadowDecoration.Parent = this.btTakePicture;
            this.btTakePicture.Size = new System.Drawing.Size(152, 61);
            this.btTakePicture.TabIndex = 35;
            this.btTakePicture.Text = "Chụp Ảnh (F5)";
            this.btTakePicture.UseTransparentBackground = true;
            this.btTakePicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btTakePicture_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(720, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(265, 147);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // RealPlayWnd
            // 
            this.RealPlayWnd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.RealPlayWnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RealPlayWnd.Image = global::IPCameraManager.Properties.Resources.Loading;
            this.RealPlayWnd.Location = new System.Drawing.Point(13, 13);
            this.RealPlayWnd.Name = "RealPlayWnd";
            this.RealPlayWnd.Size = new System.Drawing.Size(651, 498);
            this.RealPlayWnd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.RealPlayWnd.TabIndex = 29;
            this.RealPlayWnd.TabStop = false;
            // 
            // Page1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btExit_F12);
            this.Controls.Add(this.guna2Button4);
            this.Controls.Add(this.btTakePicture);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btOpen_Cam2);
            this.Controls.Add(this.btnOpen_MainCam);
            this.Controls.Add(this.RealPlayWnd);
            this.Name = "Page1";
            this.Size = new System.Drawing.Size(1044, 614);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RealPlayWnd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btOpen_Cam2;
        private System.Windows.Forms.Button btnOpen_MainCam;
        private System.Windows.Forms.PictureBox RealPlayWnd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox imgPreview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox tbGioiTinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label MaBN;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2Button btExit_F12;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button btTakePicture;
        private Guna.UI2.WinForms.Guna2TextBox tbMaBenhNhan;
        private Guna.UI2.WinForms.Guna2TextBox tbHoTen;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;
        private System.Windows.Forms.TextBox tbDiaChi;
        private Guna.UI2.WinForms.Guna2TextBox tbTuoi;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
    }
}
