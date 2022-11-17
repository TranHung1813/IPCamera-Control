
namespace CameraControl
{
    partial class UserControl_TabKhamBenh
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
            this.btOpenCamMain = new System.Windows.Forms.Button();
            this.btOpenCam2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TextBoxInfo = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btOpenCamMain
            // 
            this.btOpenCamMain.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btOpenCamMain.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btOpenCamMain.Location = new System.Drawing.Point(107, 167);
            this.btOpenCamMain.Name = "btOpenCamMain";
            this.btOpenCamMain.Size = new System.Drawing.Size(149, 69);
            this.btOpenCamMain.TabIndex = 1;
            this.btOpenCamMain.Text = "Bật Camera";
            this.btOpenCamMain.UseVisualStyleBackColor = false;
            this.btOpenCamMain.Click += new System.EventHandler(this.btOpenCamMain_Click);
            // 
            // btOpenCam2
            // 
            this.btOpenCam2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btOpenCam2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btOpenCam2.Location = new System.Drawing.Point(107, 267);
            this.btOpenCam2.Name = "btOpenCam2";
            this.btOpenCam2.Size = new System.Drawing.Size(149, 69);
            this.btOpenCam2.TabIndex = 3;
            this.btOpenCam2.Text = "Camera Phụ";
            this.btOpenCam2.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(666, 496);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TextBoxInfo
            // 
            this.TextBoxInfo.Location = new System.Drawing.Point(347, 26);
            this.TextBoxInfo.Name = "TextBoxInfo";
            this.TextBoxInfo.Size = new System.Drawing.Size(291, 451);
            this.TextBoxInfo.TabIndex = 9;
            this.TextBoxInfo.Text = "";
            this.TextBoxInfo.Visible = false;
            // 
            // UserControl_TabKhamBenh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxInfo);
            this.Controls.Add(this.btOpenCam2);
            this.Controls.Add(this.btOpenCamMain);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UserControl_TabKhamBenh";
            this.Size = new System.Drawing.Size(985, 518);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btOpenCamMain;
        private System.Windows.Forms.Button btOpenCam2;
        private System.Windows.Forms.RichTextBox TextBoxInfo;
    }
}
