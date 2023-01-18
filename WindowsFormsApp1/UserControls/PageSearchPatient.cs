using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace IPCameraManager
{
    public partial class PageSearchPatient : UserControl
    {
        public PageSearchPatient()
        {
            InitializeComponent();
        }

        List<DataUser_Patients_Info> Patients_Info;
        private string Anh1_Path = "";
        private string Anh2_Path = "";

        Thread LoadPatient_Info_trd;

        protected override void Dispose(bool disposing)
        {
            // Abort Thread
            if (LoadPatient_Info_trd != null)
            {
                try
                {
                    LoadPatient_Info_trd.Abort();
                    LoadPatient_Info_trd = null;
                }
                catch
                { }
            }
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        public void Load_Patients_Info()
        {
            LoadPatient_Info_trd = new Thread(new ThreadStart(ThreadTask_LoadPatient_Info));
            LoadPatient_Info_trd.IsBackground = true;
            LoadPatient_Info_trd.Start();
        }
        private void ThreadTask_LoadPatient_Info()
        {
            //Get Patients info
            Patients_Info = SqliteDataAccess.Load_Patients_Info();
            LoadPatient_Info_trd.Abort();
        }
        private void PageSearchPatient_Load(object sender, EventArgs e)
        {
            //Load_Patients_Info();
            StartFocus();
        }
        public void StartFocus()
        {
            if (tbMaBN.CanFocus) tbMaBN.Focus();
        }

        private void tbMaBN_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.F)
            {
                tbMaBN_IconRightClick(sender, e);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                tbMaBN_IconRightClick(sender, e);
                //e.Handled = true;
                //e.SuppressKeyPress = true;
            }
        }

        private void tbMaBN_IconRightClick(object sender, EventArgs e)
        {
            // Find Patient ID in List Patients Info
            if (Patients_Info != null && Patients_Info.Count >= 1)
            {
                int index = Patients_Info.FindIndex(a => a.MaBN == tbMaBN.Text);
                if (index != -1)
                {
                    tbHoTenBN.Text = Patients_Info[index].HoTenBN;
                    tbGioiTinh.Text = Patients_Info[index].GioiTinh;
                    tbTuoi.Text = Patients_Info[index].Tuoi;
                    tbNgayKham.Text = Patients_Info[index].NgayKham;
                    tbDiaChi.Text = Patients_Info[index].DiaChi;
                    Anh1_Path = Patients_Info[index].Anh1_Path;
                    Anh2_Path = Patients_Info[index].Anh2_Path;
                    if (Patients_Info[index].Anh1_Path != "")
                    {
                        try
                        {
                            picBox1.Load(Patients_Info[index].Anh1_Path);
                        }
                        catch
                        {
                            MessageBox.Show("Không load được ảnh 1!", "Warning",
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else picBox1.Image= null;
                    if (Patients_Info[index].Anh2_Path != "")
                    {
                        try
                        {
                            picBox2.Load(Patients_Info[index].Anh2_Path);
                        }
                        catch
                        {
                            MessageBox.Show("Không load được ảnh 2!", "Warning",
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else picBox2.Image = null;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin bệnh nhân!", "Warning",
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Không có thông tin bệnh nhân!", "Warning",
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void picBox1_DoubleClick(object sender, EventArgs e)
        {
            if (picBox1.Image != null)
            {
                try
                {
                    Process.Start(Anh1_Path);
                }
                catch { }
                //FormDoubleClick_to_ZoomPicture form = new FormDoubleClick_to_ZoomPicture(picBox1.Image);
                //form.ShowDialog();
            }
        }

        private void picBox2_DoubleClick(object sender, EventArgs e)
        {
            if (picBox2.Image != null)
            {
                try
                {
                    Process.Start(Anh2_Path);
                }
                catch { }
                //FormDoubleClick_to_ZoomPicture form = new FormDoubleClick_to_ZoomPicture(picBox2.Image);
                //form.ShowDialog();
            }
        }

        private void btOpenFolder1_Click(object sender, EventArgs e)
        {
            if (Anh1_Path != "")
            {
                try
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "File ảnh (*.jpg)|*.jpg|Other Image Files (*.*)|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
                    openFileDialog.Title = "Chọn file ảnh";
                    openFileDialog.Multiselect = false;
                    openFileDialog.FileName = "";

                    openFileDialog.InitialDirectory = Path.GetDirectoryName(Anh1_Path);

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Anh1_Path = openFileDialog.FileName;
                        picBox1.Load(Anh1_Path);
                    }
                }
                catch
                {
                    MessageBox.Show("Không load được ảnh!", "Warning",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btOpenFolder2_Click(object sender, EventArgs e)
        {
            if (Anh2_Path != "")
            {
                try
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "File ảnh (*.jpg)|*.jpg|Other Image Files (*.*)|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
                    openFileDialog.Title = "Chọn file ảnh";
                    openFileDialog.Multiselect = false;
                    openFileDialog.FileName = "";

                    openFileDialog.InitialDirectory = Path.GetDirectoryName(Anh2_Path);

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Anh2_Path = openFileDialog.FileName;
                        picBox2.Load(Anh2_Path);
                    }
                }
                catch
                {
                    MessageBox.Show("Không load được ảnh!", "Warning",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void Page4_FitToContainer(int Height, int Width)
        {
            int h = this.Height;
            Utility.FitUserControlToContainer(this, Height, Width);
            tbMaBN.Font = new Font(tbMaBN.Font.FontFamily, (tbMaBN.Font.Size * ((float)Height / (float)h)), tbMaBN.Font.Style);
            tbHoTenBN.Font = new Font(tbHoTenBN.Font.FontFamily, (tbHoTenBN.Font.Size * ((float)Height / (float)h)), tbHoTenBN.Font.Style);
            tbTuoi.Font = new Font(tbTuoi.Font.FontFamily, (tbTuoi.Font.Size * ((float)Height / (float)h)), tbTuoi.Font.Style);
            tbNgayKham.Font = new Font(tbNgayKham.Font.FontFamily, (tbNgayKham.Font.Size * (Height / (float)h)), tbNgayKham.Font.Style);
            tbGioiTinh.Font = new Font(tbGioiTinh.Font.FontFamily, (tbGioiTinh.Font.Size * (Height / (float)h)), tbGioiTinh.Font.Style);

            lbHoTen.Left = lbMaBN.Right - lbHoTen.Size.Width;
            lbGioiTinh.Left = lbMaBN.Right - lbGioiTinh.Width;
            lbDiaChi.Left = lbMaBN.Right - lbDiaChi.Width;
            lbNgayKham.Left = lbMaBN.Right - lbNgayKham.Width;
            lbTuoi.Left = lbMaBN.Right - lbTuoi.Width;

            tbMaBN.IconRightSize = new Size((int)Math.Round(tbMaBN.IconRightSize.Width * ((float)Height / (float)h)),
                                            (int)Math.Round(tbMaBN.IconRightSize.Height * ((float)Height / (float)h)));
        }

        private void btExit_F12_Click(object sender, EventArgs e)
        {
            if (btExit_F12.CanFocus)
            {
                btExit_F12.Focus();
            }
            if (MessageBox.Show("Bạn chắc chắn muốn thoát?", "Warning", MessageBoxButtons.OKCancel,
                                                            MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btXemAnh1_Click(object sender, EventArgs e)
        {
            if (Anh1_Path != "")
            {
                try
                {
                    Process.Start(Anh1_Path);
                }
                catch
                {
                    MessageBox.Show("Không load được ảnh!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btXemAnh2_Click(object sender, EventArgs e)
        {
            if (Anh2_Path != "")
            {
                try
                {
                    Process.Start(Anh2_Path);
                }
                catch
                {
                    MessageBox.Show("Không load được ảnh!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
