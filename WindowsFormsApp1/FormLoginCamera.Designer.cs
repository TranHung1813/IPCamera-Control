
namespace IPCameraManager
{
    partial class FormLoginCamera
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panel_Top = new System.Windows.Forms.Panel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.textBoxUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btLogin = new Guna.UI2.WinForms.Guna2Button();
            this.textBoxPort = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxIP = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2CheckBox1 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.panelTabControl = new Guna.UI2.WinForms.Guna2Panel();
            this.btTabCam2 = new Guna.UI2.WinForms.Guna2Button();
            this.btTabMainCam = new Guna.UI2.WinForms.Guna2Button();
            this.textBoxPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel_Top.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.panelTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 19;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.panel_Top;
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.Transparent;
            this.panel_Top.Controls.Add(this.guna2ControlBox1);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(300, 40);
            this.panel_Top.TabIndex = 29;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(255, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 40);
            this.guna2ControlBox1.TabIndex = 30;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBoxUserName.BorderRadius = 4;
            this.textBoxUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxUserName.DefaultText = "admin";
            this.textBoxUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxUserName.DisabledState.Parent = this.textBoxUserName;
            this.textBoxUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxUserName.FocusedState.Parent = this.textBoxUserName;
            this.textBoxUserName.Font = new System.Drawing.Font("Tahoma", 11.5F);
            this.textBoxUserName.ForeColor = System.Drawing.Color.Black;
            this.textBoxUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxUserName.HoverState.Parent = this.textBoxUserName;
            this.textBoxUserName.Location = new System.Drawing.Point(119, 194);
            this.textBoxUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.PasswordChar = '\0';
            this.textBoxUserName.PlaceholderText = "";
            this.textBoxUserName.SelectedText = "";
            this.textBoxUserName.SelectionStart = 5;
            this.textBoxUserName.ShadowDecoration.Parent = this.textBoxUserName;
            this.textBoxUserName.Size = new System.Drawing.Size(160, 30);
            this.textBoxUserName.TabIndex = 24;
            this.textBoxUserName.TextChanged += new System.EventHandler(this.textBoxUserName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(15, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 23);
            this.label5.TabIndex = 18;
            this.label5.Text = "Password: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(9, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 23);
            this.label6.TabIndex = 17;
            this.label6.Text = "Username: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(60, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "Port: ";
            // 
            // btLogin
            // 
            this.btLogin.BackColor = System.Drawing.Color.Transparent;
            this.btLogin.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btLogin.BorderRadius = 5;
            this.btLogin.BorderThickness = 1;
            this.btLogin.CheckedState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btLogin.CheckedState.FillColor = System.Drawing.SystemColors.ActiveCaption;
            this.btLogin.CheckedState.Parent = this.btLogin;
            this.btLogin.CustomImages.Parent = this.btLogin;
            this.btLogin.FillColor = System.Drawing.Color.White;
            this.btLogin.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogin.ForeColor = System.Drawing.Color.Black;
            this.btLogin.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btLogin.HoverState.FillColor = System.Drawing.SystemColors.ActiveCaption;
            this.btLogin.HoverState.Parent = this.btLogin;
            this.btLogin.Location = new System.Drawing.Point(52, 336);
            this.btLogin.Name = "btLogin";
            this.btLogin.ShadowDecoration.Parent = this.btLogin;
            this.btLogin.Size = new System.Drawing.Size(192, 43);
            this.btLogin.TabIndex = 23;
            this.btLogin.Text = "Đăng nhập";
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // textBoxPort
            // 
            this.textBoxPort.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBoxPort.BorderRadius = 4;
            this.textBoxPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPort.DefaultText = "";
            this.textBoxPort.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxPort.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxPort.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxPort.DisabledState.Parent = this.textBoxPort;
            this.textBoxPort.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxPort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxPort.FocusedState.Parent = this.textBoxPort;
            this.textBoxPort.Font = new System.Drawing.Font("Tahoma", 11.5F);
            this.textBoxPort.ForeColor = System.Drawing.Color.Black;
            this.textBoxPort.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxPort.HoverState.Parent = this.textBoxPort;
            this.textBoxPort.Location = new System.Drawing.Point(119, 144);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.PasswordChar = '\0';
            this.textBoxPort.PlaceholderText = "";
            this.textBoxPort.SelectedText = "";
            this.textBoxPort.ShadowDecoration.Parent = this.textBoxPort;
            this.textBoxPort.Size = new System.Drawing.Size(160, 30);
            this.textBoxPort.TabIndex = 22;
            this.textBoxPort.TextChanged += new System.EventHandler(this.textBoxPort_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(13, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "Địa chỉ IP: ";
            // 
            // textBoxIP
            // 
            this.textBoxIP.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBoxIP.BorderRadius = 4;
            this.textBoxIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxIP.DefaultText = "";
            this.textBoxIP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxIP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxIP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxIP.DisabledState.Parent = this.textBoxIP;
            this.textBoxIP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxIP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxIP.FocusedState.Parent = this.textBoxIP;
            this.textBoxIP.Font = new System.Drawing.Font("Tahoma", 11.5F);
            this.textBoxIP.ForeColor = System.Drawing.Color.Black;
            this.textBoxIP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxIP.HoverState.Parent = this.textBoxIP;
            this.textBoxIP.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxIP.IconRightSize = new System.Drawing.Size(25, 25);
            this.textBoxIP.Location = new System.Drawing.Point(119, 94);
            this.textBoxIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.PasswordChar = '\0';
            this.textBoxIP.PlaceholderText = "";
            this.textBoxIP.SelectedText = "";
            this.textBoxIP.ShadowDecoration.Parent = this.textBoxIP;
            this.textBoxIP.Size = new System.Drawing.Size(160, 30);
            this.textBoxIP.TabIndex = 21;
            this.textBoxIP.TextChanged += new System.EventHandler(this.textBoxIP_TextChanged);
            // 
            // guna2CheckBox1
            // 
            this.guna2CheckBox1.AutoSize = true;
            this.guna2CheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CheckBox1.Checked = true;
            this.guna2CheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox1.CheckedState.BorderRadius = 2;
            this.guna2CheckBox1.CheckedState.BorderThickness = 0;
            this.guna2CheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.guna2CheckBox1.Font = new System.Drawing.Font("Tahoma", 13F);
            this.guna2CheckBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2CheckBox1.Location = new System.Drawing.Point(74, 295);
            this.guna2CheckBox1.Name = "guna2CheckBox1";
            this.guna2CheckBox1.Size = new System.Drawing.Size(143, 26);
            this.guna2CheckBox1.TabIndex = 26;
            this.guna2CheckBox1.Text = " Lưu thông tin";
            this.guna2CheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CheckBox1.UncheckedState.BorderRadius = 2;
            this.guna2CheckBox1.UncheckedState.BorderThickness = 0;
            this.guna2CheckBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CheckBox1.UseVisualStyleBackColor = false;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.guna2GroupBox1.BorderRadius = 10;
            this.guna2GroupBox1.Controls.Add(this.panelTabControl);
            this.guna2GroupBox1.Controls.Add(this.panel_Top);
            this.guna2GroupBox1.Controls.Add(this.guna2CheckBox1);
            this.guna2GroupBox1.Controls.Add(this.textBoxIP);
            this.guna2GroupBox1.Controls.Add(this.label8);
            this.guna2GroupBox1.Controls.Add(this.textBoxPassword);
            this.guna2GroupBox1.Controls.Add(this.textBoxPort);
            this.guna2GroupBox1.Controls.Add(this.btLogin);
            this.guna2GroupBox1.Controls.Add(this.label7);
            this.guna2GroupBox1.Controls.Add(this.label6);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.textBoxUserName);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Tahoma", 11.5F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(300, 402);
            this.guna2GroupBox1.TabIndex = 27;
            this.guna2GroupBox1.Text = "Thông tin kết nối Camera";
            // 
            // panelTabControl
            // 
            this.panelTabControl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelTabControl.Controls.Add(this.btTabCam2);
            this.panelTabControl.Controls.Add(this.btTabMainCam);
            this.panelTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTabControl.Location = new System.Drawing.Point(0, 40);
            this.panelTabControl.Name = "panelTabControl";
            this.panelTabControl.ShadowDecoration.Parent = this.panelTabControl;
            this.panelTabControl.Size = new System.Drawing.Size(300, 40);
            this.panelTabControl.TabIndex = 30;
            // 
            // btTabCam2
            // 
            this.btTabCam2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btTabCam2.BorderRadius = 2;
            this.btTabCam2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btTabCam2.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btTabCam2.CheckedState.FillColor = System.Drawing.Color.White;
            this.btTabCam2.CheckedState.Parent = this.btTabCam2;
            this.btTabCam2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btTabCam2.CustomImages.Parent = this.btTabCam2;
            this.btTabCam2.Dock = System.Windows.Forms.DockStyle.Right;
            this.btTabCam2.FillColor = System.Drawing.Color.White;
            this.btTabCam2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTabCam2.ForeColor = System.Drawing.Color.Black;
            this.btTabCam2.HoverState.Parent = this.btTabCam2;
            this.btTabCam2.Location = new System.Drawing.Point(150, 0);
            this.btTabCam2.Name = "btTabCam2";
            this.btTabCam2.ShadowDecoration.Parent = this.btTabCam2;
            this.btTabCam2.Size = new System.Drawing.Size(150, 40);
            this.btTabCam2.TabIndex = 1;
            this.btTabCam2.Text = "Cam Phụ";
            this.btTabCam2.Click += new System.EventHandler(this.btTabCam2_Click);
            // 
            // btTabMainCam
            // 
            this.btTabMainCam.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btTabMainCam.BorderRadius = 2;
            this.btTabMainCam.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btTabMainCam.Checked = true;
            this.btTabMainCam.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btTabMainCam.CheckedState.FillColor = System.Drawing.Color.White;
            this.btTabMainCam.CheckedState.Parent = this.btTabMainCam;
            this.btTabMainCam.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btTabMainCam.CustomImages.Parent = this.btTabMainCam;
            this.btTabMainCam.Dock = System.Windows.Forms.DockStyle.Left;
            this.btTabMainCam.FillColor = System.Drawing.Color.White;
            this.btTabMainCam.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTabMainCam.ForeColor = System.Drawing.Color.Black;
            this.btTabMainCam.HoverState.Parent = this.btTabMainCam;
            this.btTabMainCam.Location = new System.Drawing.Point(0, 0);
            this.btTabMainCam.Name = "btTabMainCam";
            this.btTabMainCam.ShadowDecoration.Parent = this.btTabMainCam;
            this.btTabMainCam.Size = new System.Drawing.Size(151, 40);
            this.btTabMainCam.TabIndex = 0;
            this.btTabMainCam.Text = "Cam Chính";
            this.btTabMainCam.Click += new System.EventHandler(this.btTabMainCam_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBoxPassword.BorderRadius = 4;
            this.textBoxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPassword.DefaultText = "abcd1234";
            this.textBoxPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxPassword.DisabledState.Parent = this.textBoxPassword;
            this.textBoxPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxPassword.FocusedState.Parent = this.textBoxPassword;
            this.textBoxPassword.Font = new System.Drawing.Font("Tahoma", 11.5F);
            this.textBoxPassword.ForeColor = System.Drawing.Color.Black;
            this.textBoxPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxPassword.HoverState.Parent = this.textBoxPassword;
            this.textBoxPassword.IconRight = global::IPCameraManager.Properties.Resources.eye_hidden;
            this.textBoxPassword.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxPassword.Location = new System.Drawing.Point(119, 244);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.PlaceholderText = "";
            this.textBoxPassword.SelectedText = "";
            this.textBoxPassword.SelectionStart = 8;
            this.textBoxPassword.ShadowDecoration.Parent = this.textBoxPassword;
            this.textBoxPassword.Size = new System.Drawing.Size(160, 30);
            this.textBoxPassword.TabIndex = 25;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            this.textBoxPassword.IconRightClick += new System.EventHandler(this.textBoxPassword_IconRightClick);
            // 
            // FormLoginCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(301, 403);
            this.Controls.Add(this.guna2GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FormLoginCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.FormLoginCamera_Load);
            this.panel_Top.ResumeLayout(false);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.panelTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Panel panel_Top;
        private Guna.UI2.WinForms.Guna2CheckBox guna2CheckBox1;
        private Guna.UI2.WinForms.Guna2TextBox textBoxIP;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox textBoxPassword;
        private Guna.UI2.WinForms.Guna2TextBox textBoxPort;
        private Guna.UI2.WinForms.Guna2Button btLogin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox textBoxUserName;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Panel panelTabControl;
        private Guna.UI2.WinForms.Guna2Button btTabMainCam;
        private Guna.UI2.WinForms.Guna2Button btTabCam2;
    }
}