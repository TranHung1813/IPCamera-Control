
namespace IPCameraManager
{
    partial class FormSetupPTZ
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
            this.checkBoxPreview = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxSpeed = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.PtzGet = new System.Windows.Forms.Button();
            this.PtzSet = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.textBoxZoomPos = new System.Windows.Forms.TextBox();
            this.textBoxTiltPos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPanPos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.PtzRange = new System.Windows.Forms.Button();
            this.label_PZTRange = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxPreview
            // 
            this.checkBoxPreview.AutoSize = true;
            this.checkBoxPreview.Enabled = false;
            this.checkBoxPreview.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPreview.Location = new System.Drawing.Point(110, 174);
            this.checkBoxPreview.Name = "checkBoxPreview";
            this.checkBoxPreview.Size = new System.Drawing.Size(114, 20);
            this.checkBoxPreview.TabIndex = 20;
            this.checkBoxPreview.Text = "enable preview";
            this.checkBoxPreview.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxPreview);
            this.groupBox2.Controls.Add(this.comboBoxSpeed);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnDown);
            this.groupBox2.Controls.Add(this.PtzGet);
            this.groupBox2.Controls.Add(this.PtzSet);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnRight);
            this.groupBox2.Controls.Add(this.btnAuto);
            this.groupBox2.Controls.Add(this.btnLeft);
            this.groupBox2.Controls.Add(this.btnUp);
            this.groupBox2.Controls.Add(this.textBoxZoomPos);
            this.groupBox2.Controls.Add(this.textBoxTiltPos);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxPanPos);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(30, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 357);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PTZ control";
            // 
            // comboBoxSpeed
            // 
            this.comboBoxSpeed.FormattingEnabled = true;
            this.comboBoxSpeed.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.comboBoxSpeed.Location = new System.Drawing.Point(151, 141);
            this.comboBoxSpeed.Name = "comboBoxSpeed";
            this.comboBoxSpeed.Size = new System.Drawing.Size(92, 26);
            this.comboBoxSpeed.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(83, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "Tốc độ：";
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(140, 96);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(60, 29);
            this.btnDown.TabIndex = 17;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseDown);
            this.btnDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseUp);
            // 
            // PtzGet
            // 
            this.PtzGet.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PtzGet.Location = new System.Drawing.Point(183, 308);
            this.PtzGet.Name = "PtzGet";
            this.PtzGet.Size = new System.Drawing.Size(76, 28);
            this.PtzGet.TabIndex = 23;
            this.PtzGet.Text = "PTZ Get";
            this.PtzGet.UseVisualStyleBackColor = true;
            // 
            // PtzSet
            // 
            this.PtzSet.Location = new System.Drawing.Point(75, 308);
            this.PtzSet.Name = "PtzSet";
            this.PtzSet.Size = new System.Drawing.Size(76, 28);
            this.PtzSet.TabIndex = 24;
            this.PtzSet.Text = "PTZ Set";
            this.PtzSet.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteCustomSource.AddRange(new string[] {
            "1-定位PTZ参数",
            "2-定位P参数",
            "3-定位T参数",
            "4-定位Z参数",
            "5-定位PT参数"});
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1 - Điều chỉnh PTZ",
            "2 - Điều chỉnh P",
            "3 - Điều chỉnh T",
            "4 - Điều chỉnh Z",
            "5 - Điều chỉnh PT"});
            this.comboBox2.Location = new System.Drawing.Point(146, 265);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(144, 26);
            this.comboBox2.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 18);
            this.label9.TabIndex = 26;
            this.label9.Text = "operation type：";
            // 
            // btnRight
            // 
            this.btnRight.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRight.Location = new System.Drawing.Point(217, 57);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(60, 29);
            this.btnRight.TabIndex = 16;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseDown);
            this.btnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseUp);
            // 
            // btnAuto
            // 
            this.btnAuto.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuto.Location = new System.Drawing.Point(140, 57);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(60, 29);
            this.btnAuto.TabIndex = 15;
            this.btnAuto.Text = "Auto";
            this.btnAuto.UseVisualStyleBackColor = true;
            // 
            // btnLeft
            // 
            this.btnLeft.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeft.Location = new System.Drawing.Point(63, 57);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(60, 29);
            this.btnLeft.TabIndex = 14;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseDown);
            this.btnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseUp);
            // 
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.Location = new System.Drawing.Point(140, 18);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(60, 29);
            this.btnUp.TabIndex = 13;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseDown);
            this.btnUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseUp);
            // 
            // textBoxZoomPos
            // 
            this.textBoxZoomPos.Location = new System.Drawing.Point(242, 223);
            this.textBoxZoomPos.Name = "textBoxZoomPos";
            this.textBoxZoomPos.Size = new System.Drawing.Size(32, 26);
            this.textBoxZoomPos.TabIndex = 28;
            // 
            // textBoxTiltPos
            // 
            this.textBoxTiltPos.Location = new System.Drawing.Point(156, 223);
            this.textBoxTiltPos.Name = "textBoxTiltPos";
            this.textBoxTiltPos.Size = new System.Drawing.Size(32, 26);
            this.textBoxTiltPos.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Z:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "T:";
            // 
            // textBoxPanPos
            // 
            this.textBoxPanPos.Location = new System.Drawing.Point(70, 223);
            this.textBoxPanPos.Name = "textBoxPanPos";
            this.textBoxPanPos.Size = new System.Drawing.Size(32, 26);
            this.textBoxPanPos.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "P:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label6.Location = new System.Drawing.Point(12, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(308, 17);
            this.label6.TabIndex = 40;
            this.label6.Text = "Lấy thông tin khoảng giá trị PZT trước khi cài đặt";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label12.Location = new System.Drawing.Point(12, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 17);
            this.label12.TabIndex = 42;
            this.label12.Text = "PTZ range：";
            // 
            // PtzRange
            // 
            this.PtzRange.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PtzRange.Location = new System.Drawing.Point(326, 9);
            this.PtzRange.Name = "PtzRange";
            this.PtzRange.Size = new System.Drawing.Size(67, 26);
            this.PtzRange.TabIndex = 39;
            this.PtzRange.Text = "Get";
            this.PtzRange.UseVisualStyleBackColor = true;
            this.PtzRange.Click += new System.EventHandler(this.PtzRange_Click);
            // 
            // label_PZTRange
            // 
            this.label_PZTRange.AutoSize = true;
            this.label_PZTRange.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label_PZTRange.Location = new System.Drawing.Point(85, 38);
            this.label_PZTRange.Name = "label_PZTRange";
            this.label_PZTRange.Size = new System.Drawing.Size(0, 17);
            this.label_PZTRange.TabIndex = 43;
            // 
            // FormSetupPZT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 434);
            this.Controls.Add(this.label_PZTRange);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.PtzRange);
            this.Name = "FormSetupPZT";
            this.Text = "FormSetupPTZ";
            this.Load += new System.EventHandler(this.FormSetupPZT_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxPreview;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button PtzGet;
        private System.Windows.Forms.Button PtzSet;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.TextBox textBoxZoomPos;
        private System.Windows.Forms.TextBox textBoxTiltPos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPanPos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button PtzRange;
        private System.Windows.Forms.Label label_PZTRange;
    }
}