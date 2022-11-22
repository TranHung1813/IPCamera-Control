
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
            this.btMaximize = new Guna.UI2.WinForms.Guna2Button();
            this.btMinimize = new Guna.UI2.WinForms.Guna2Button();
            this.btExit = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btCamRefresh_R = new System.Windows.Forms.Button();
            this.btLogin_IPCamera = new Guna.UI2.WinForms.Guna2Button();
            this.tabPage_InPhieu = new Guna.UI2.WinForms.Guna2Button();
            this.tabPage_KhamBenh = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panelContainer = new System.Windows.Forms.Panel();
            this.Status1 = new System.Windows.Forms.StatusStrip();
            this.TrangThaiCam = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelBorder_Left = new System.Windows.Forms.Panel();
            this.panelBorder_Right = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.Status1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
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
            this.panel2.Controls.Add(this.btCamRefresh_R);
            this.panel2.Controls.Add(this.btLogin_IPCamera);
            this.panel2.Controls.Add(this.tabPage_InPhieu);
            this.panel2.Controls.Add(this.tabPage_KhamBenh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1044, 43);
            this.panel2.TabIndex = 7;
            // 
            // btCamRefresh_R
            // 
            this.btCamRefresh_R.Location = new System.Drawing.Point(471, 6);
            this.btCamRefresh_R.Name = "btCamRefresh_R";
            this.btCamRefresh_R.Size = new System.Drawing.Size(127, 31);
            this.btCamRefresh_R.TabIndex = 3;
            this.btCamRefresh_R.Text = "Refresh Camera (F7)";
            this.btCamRefresh_R.UseVisualStyleBackColor = true;
            this.btCamRefresh_R.Click += new System.EventHandler(this.btCamRefresh_Click);
            // 
            // btLogin_IPCamera
            // 
            this.btLogin_IPCamera.BackColor = System.Drawing.Color.Transparent;
            this.btLogin_IPCamera.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btLogin_IPCamera.BorderRadius = 5;
            this.btLogin_IPCamera.BorderThickness = 1;
            this.btLogin_IPCamera.CheckedState.CustomBorderColor = System.Drawing.Color.SlateBlue;
            this.btLogin_IPCamera.CheckedState.FillColor = System.Drawing.Color.White;
            this.btLogin_IPCamera.CheckedState.Parent = this.btLogin_IPCamera;
            this.btLogin_IPCamera.CustomImages.Parent = this.btLogin_IPCamera;
            this.btLogin_IPCamera.FillColor = System.Drawing.Color.White;
            this.btLogin_IPCamera.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.btLogin_IPCamera.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btLogin_IPCamera.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btLogin_IPCamera.HoverState.CustomBorderColor = System.Drawing.Color.SlateBlue;
            this.btLogin_IPCamera.HoverState.Parent = this.btLogin_IPCamera;
            this.btLogin_IPCamera.ImageSize = new System.Drawing.Size(33, 33);
            this.btLogin_IPCamera.Location = new System.Drawing.Point(877, 9);
            this.btLogin_IPCamera.Name = "btLogin_IPCamera";
            this.btLogin_IPCamera.ShadowDecoration.Parent = this.btLogin_IPCamera;
            this.btLogin_IPCamera.Size = new System.Drawing.Size(155, 25);
            this.btLogin_IPCamera.TabIndex = 2;
            this.btLogin_IPCamera.Text = "Kết nối Camera";
            this.btLogin_IPCamera.UseTransparentBackground = true;
            this.btLogin_IPCamera.Click += new System.EventHandler(this.btLogin_IPCamera_Click);
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
            this.tabPage_InPhieu.ImageSize = new System.Drawing.Size(33, 33);
            this.tabPage_InPhieu.Location = new System.Drawing.Point(178, 0);
            this.tabPage_InPhieu.Name = "tabPage_InPhieu";
            this.tabPage_InPhieu.ShadowDecoration.Parent = this.tabPage_InPhieu;
            this.tabPage_InPhieu.Size = new System.Drawing.Size(207, 43);
            this.tabPage_InPhieu.TabIndex = 1;
            this.tabPage_InPhieu.Text = "  In Phiếu Khám (F4)";
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
            this.tabPage_KhamBenh.Text = " KHÁM BỆNH (F3)";
            this.tabPage_KhamBenh.UseTransparentBackground = true;
            this.tabPage_KhamBenh.Click += new System.EventHandler(this.tabPage_KhamBenh_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.panel1;
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 80);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1044, 640);
            this.panelContainer.TabIndex = 8;
            // 
            // Status1
            // 
            this.Status1.BackColor = System.Drawing.Color.Gainsboro;
            this.Status1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrangThaiCam,
            this.toolStripStatusLabel1});
            this.Status1.Location = new System.Drawing.Point(0, 697);
            this.Status1.Name = "Status1";
            this.Status1.Size = new System.Drawing.Size(1044, 23);
            this.Status1.TabIndex = 0;
            this.Status1.Text = "Status1";
            // 
            // TrangThaiCam
            // 
            this.TrangThaiCam.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TrangThaiCam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TrangThaiCam.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrangThaiCam.Name = "TrangThaiCam";
            this.TrangThaiCam.Size = new System.Drawing.Size(192, 18);
            this.TrangThaiCam.Text = " Camera: Không có kết nối! ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 18);
            // 
            // panelBorder_Left
            // 
            this.panelBorder_Left.BackColor = System.Drawing.Color.SlateBlue;
            this.panelBorder_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBorder_Left.Location = new System.Drawing.Point(0, 80);
            this.panelBorder_Left.Name = "panelBorder_Left";
            this.panelBorder_Left.Size = new System.Drawing.Size(1, 617);
            this.panelBorder_Left.TabIndex = 9;
            // 
            // panelBorder_Right
            // 
            this.panelBorder_Right.BackColor = System.Drawing.Color.SlateBlue;
            this.panelBorder_Right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBorder_Right.Location = new System.Drawing.Point(1042, 80);
            this.panelBorder_Right.Name = "panelBorder_Right";
            this.panelBorder_Right.Size = new System.Drawing.Size(2, 617);
            this.panelBorder_Right.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1044, 720);
            this.Controls.Add(this.panelBorder_Right);
            this.Controls.Add(this.panelBorder_Left);
            this.Controls.Add(this.Status1);
            this.Controls.Add(this.panelContainer);
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
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.StatusStrip Status1;
        private System.Windows.Forms.ToolStripStatusLabel TrangThaiCam;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panelBorder_Right;
        private System.Windows.Forms.Panel panelBorder_Left;
        private Guna.UI2.WinForms.Guna2Button btLogin_IPCamera;
        private Guna.UI2.WinForms.Guna2Button btExit;
        private System.Windows.Forms.Button btCamRefresh_R;
    }
}

