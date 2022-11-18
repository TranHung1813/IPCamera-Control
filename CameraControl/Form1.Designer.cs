
namespace CameraControl
{
    partial class Form1
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtTabPage_UserManual = new DevExpress.XtraTab.XtraTabPage();
            this.btDangnhapCamera = new System.Windows.Forms.Button();
            this.xtTabPage_KhamBenh = new DevExpress.XtraTab.XtraTabPage();
            this.xtTabPage_InPhieu = new DevExpress.XtraTab.XtraTabPage();
            this.Status1 = new System.Windows.Forms.StatusStrip();
            this.TrangThaiCam = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.Status1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.PaintStyleName = "PropertyView";
            this.xtraTabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.xtraTabControl1.SelectedTabPage = this.xtTabPage_UserManual;
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtTabPage_UserManual,
            this.xtTabPage_KhamBenh,
            this.xtTabPage_InPhieu});
            // 
            // xtTabPage_UserManual
            // 
            this.xtTabPage_UserManual.Enabled = true;
            this.xtTabPage_UserManual.Name = "xtTabPage_UserManual";
            this.xtTabPage_UserManual.Size = new System.Drawing.Size(298, 260);
            this.xtTabPage_UserManual.Text = "  Menu phím tắt   ";
            // 
            // btDangnhapCamera
            // 
            this.btDangnhapCamera.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btDangnhapCamera.Location = new System.Drawing.Point(899, 10);
            this.btDangnhapCamera.Name = "btDangnhapCamera";
            this.btDangnhapCamera.Size = new System.Drawing.Size(108, 23);
            this.btDangnhapCamera.TabIndex = 0;
            this.btDangnhapCamera.Text = "Đăng nhập Camera";
            this.btDangnhapCamera.UseVisualStyleBackColor = false;
            this.btDangnhapCamera.Click += new System.EventHandler(this.btDangnhapCamera_Click);
            // 
            // xtTabPage_KhamBenh
            // 
            this.xtTabPage_KhamBenh.Enabled = true;
            this.xtTabPage_KhamBenh.ImageOptions.Image = global::CameraControl.Properties.Resources.Health;
            this.xtTabPage_KhamBenh.Name = "xtTabPage_KhamBenh";
            this.xtTabPage_KhamBenh.Size = new System.Drawing.Size(298, 260);
            this.xtTabPage_KhamBenh.Text = "  KHÁM BỆNH (F3)   ";
            // 
            // xtTabPage_InPhieu
            // 
            this.xtTabPage_InPhieu.Enabled = true;
            this.xtTabPage_InPhieu.ImageOptions.Image = global::CameraControl.Properties.Resources.Printer;
            this.xtTabPage_InPhieu.Name = "xtTabPage_InPhieu";
            this.xtTabPage_InPhieu.Size = new System.Drawing.Size(298, 260);
            this.xtTabPage_InPhieu.Text = "  In Phiếu Khám (F4)   ";
            // 
            // Status1
            // 
            this.Status1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrangThaiCam,
            this.toolStripStatusLabel1});
            this.Status1.Location = new System.Drawing.Point(0, 639);
            this.Status1.Name = "Status1";
            this.Status1.Size = new System.Drawing.Size(1028, 22);
            this.Status1.TabIndex = 14;
            this.Status1.Text = "Status1";
            // 
            // TrangThaiCam
            // 
            this.TrangThaiCam.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrangThaiCam.Name = "TrangThaiCam";
            this.TrangThaiCam.Size = new System.Drawing.Size(156, 17);
            this.TrangThaiCam.Text = "Camera: Không có kết nối";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 661);
            this.Controls.Add(this.Status1);
            this.Controls.Add(this.btDangnhapCamera);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.Status1.ResumeLayout(false);
            this.Status1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtTabPage_UserManual;
        private DevExpress.XtraTab.XtraTabPage xtTabPage_KhamBenh;
        private DevExpress.XtraTab.XtraTabPage xtTabPage_InPhieu;
        private System.Windows.Forms.Button btDangnhapCamera;
        private System.Windows.Forms.StatusStrip Status1;
        private System.Windows.Forms.ToolStripStatusLabel TrangThaiCam;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

