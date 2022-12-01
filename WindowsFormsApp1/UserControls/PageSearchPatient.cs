using System;
using System.Collections.Generic;
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

        public void Load_Patients_Info()
        {
            //Get Patients info
            Patients_Info = SqliteDataAccess.Load_Patients_Info();
        }
        private void PageSearchPatient_Load(object sender, EventArgs e)
        {
            Load_Patients_Info();
        }

        private void tbMaBN_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.F)
            {
                tbMaBN_IconRightClick(sender, e);
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
                FormDoubleClick_to_ZoomPicture form = new FormDoubleClick_to_ZoomPicture(picBox1.Image);
                form.ShowDialog();
            }
        }

        private void picBox2_DoubleClick(object sender, EventArgs e)
        {
            if (picBox2.Image != null)
            {
                FormDoubleClick_to_ZoomPicture form = new FormDoubleClick_to_ZoomPicture(picBox2.Image);
                form.ShowDialog();
            }
        }
    }
}
