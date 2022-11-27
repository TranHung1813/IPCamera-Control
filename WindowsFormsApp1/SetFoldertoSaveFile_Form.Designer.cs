
namespace IPCameraManager
{
    partial class SetFoldertoSaveFile_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.btBrowse = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbFolderName = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btOK = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.groupBox1.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.panel_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Folder:";
            // 
            // btBrowse
            // 
            this.btBrowse.BackColor = System.Drawing.Color.Transparent;
            this.btBrowse.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btBrowse.BorderRadius = 4;
            this.btBrowse.BorderThickness = 1;
            this.btBrowse.CheckedState.Parent = this.btBrowse;
            this.btBrowse.CustomImages.Parent = this.btBrowse;
            this.btBrowse.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btBrowse.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBrowse.ForeColor = System.Drawing.Color.Black;
            this.btBrowse.HoverState.Parent = this.btBrowse;
            this.btBrowse.Location = new System.Drawing.Point(555, 21);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.ShadowDecoration.Parent = this.btBrowse;
            this.btBrowse.Size = new System.Drawing.Size(75, 24);
            this.btBrowse.TabIndex = 2;
            this.btBrowse.Text = "Browse";
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.tbFolderName);
            this.groupBox1.Controls.Add(this.btBrowse);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(636, 53);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // tbFolderName
            // 
            this.tbFolderName.BorderRadius = 3;
            this.tbFolderName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFolderName.DefaultText = "D:\\Hinh_Anh";
            this.tbFolderName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbFolderName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbFolderName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFolderName.DisabledState.Parent = this.tbFolderName;
            this.tbFolderName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFolderName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFolderName.FocusedState.Parent = this.tbFolderName;
            this.tbFolderName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFolderName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbFolderName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFolderName.HoverState.Parent = this.tbFolderName;
            this.tbFolderName.Location = new System.Drawing.Point(97, 19);
            this.tbFolderName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbFolderName.Name = "tbFolderName";
            this.tbFolderName.PasswordChar = '\0';
            this.tbFolderName.PlaceholderText = "";
            this.tbFolderName.SelectedText = "";
            this.tbFolderName.ShadowDecoration.Parent = this.tbFolderName;
            this.tbFolderName.Size = new System.Drawing.Size(448, 26);
            this.tbFolderName.TabIndex = 3;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.guna2GroupBox1.BorderRadius = 10;
            this.guna2GroupBox1.Controls.Add(this.panel_Top);
            this.guna2GroupBox1.Controls.Add(this.btCancel);
            this.guna2GroupBox1.Controls.Add(this.btOK);
            this.guna2GroupBox1.Controls.Add(this.groupBox1);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(663, 125);
            this.guna2GroupBox1.TabIndex = 6;
            this.guna2GroupBox1.Text = "Cài đặt tên Folder";
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.Transparent;
            this.panel_Top.Controls.Add(this.guna2ControlBox1);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(663, 32);
            this.panel_Top.TabIndex = 8;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(618, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 32);
            this.guna2ControlBox1.TabIndex = 31;
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.Transparent;
            this.btCancel.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btCancel.BorderRadius = 4;
            this.btCancel.BorderThickness = 1;
            this.btCancel.CheckedState.Parent = this.btCancel;
            this.btCancel.CustomImages.Parent = this.btCancel;
            this.btCancel.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.Black;
            this.btCancel.HoverState.Parent = this.btCancel;
            this.btCancel.Location = new System.Drawing.Point(550, 93);
            this.btCancel.Name = "btCancel";
            this.btCancel.ShadowDecoration.Parent = this.btCancel;
            this.btCancel.Size = new System.Drawing.Size(75, 25);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "Cancel";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click_1);
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.Transparent;
            this.btOK.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btOK.BorderRadius = 4;
            this.btOK.BorderThickness = 1;
            this.btOK.CheckedState.Parent = this.btOK;
            this.btOK.CustomImages.Parent = this.btOK;
            this.btOK.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btOK.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.ForeColor = System.Drawing.Color.Black;
            this.btOK.HoverState.Parent = this.btOK;
            this.btOK.Location = new System.Drawing.Point(458, 93);
            this.btOK.Name = "btOK";
            this.btOK.ShadowDecoration.Parent = this.btOK;
            this.btOK.Size = new System.Drawing.Size(75, 25);
            this.btOK.TabIndex = 6;
            this.btOK.Text = "OK";
            this.btOK.Click += new System.EventHandler(this.btOK_Click_1);
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
            // SetFoldertoSaveFile_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(664, 126);
            this.Controls.Add(this.guna2GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "SetFoldertoSaveFile_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cài đặt tên folder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.guna2GroupBox1.ResumeLayout(false);
            this.panel_Top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btBrowse;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2TextBox tbFolderName;
        private Guna.UI2.WinForms.Guna2Button btCancel;
        private Guna.UI2.WinForms.Guna2Button btOK;
        private System.Windows.Forms.Panel panel_Top;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}