using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPCameraManager
{
    public partial class Page2 : UserControl
    {
        public Page2()
        {
            InitializeComponent();
            Init_Button();
            this.ActiveControl = null;
        }
        private void Init_Button()
        {
            foreach (var button in this.Controls.OfType<Guna.UI2.WinForms.Guna2Button>())
            {
                button.GotFocus += (s, a) =>
                {
                    var currentButton = s as Guna.UI2.WinForms.Guna2Button;
                    currentButton.BorderColor = Color.RoyalBlue;
                    currentButton.BorderThickness = 2;
                };
                button.LostFocus += (s, a) =>
                {
                    var currentButton = s as Guna.UI2.WinForms.Guna2Button;
                    currentButton.BorderThickness = 1;
                    currentButton.BorderColor = SystemColors.ControlDark;
                };
            }
        }
        public void Load_Patient_Info( PatientInfo_Type info)
        {
            tbMaBN_IN.Text = info.MaBN;
            tbHoTenBN_IN.Text = info.HoTenBN;
            tbGioiTinh_IN.Text = info.GioiTinh;
            tbTuoi_IN.Text = info.Tuoi;
            tbNgayKham_IN.Text = info.NgayKham;
            tbDiaChi_IN.Text = info.DiaChi;
        }
    }
    public struct PatientInfo_Type
    {
        private string _MaBN;
        private string _HoTenBN;
        private string _GioiTinh;
        private string _Tuoi;
        private string _NgayKham;
        private string _DiaChi;

        public string MaBN { get { return _MaBN; } set => _MaBN = value; }
        public string HoTenBN { get { return _HoTenBN; } set => _HoTenBN = value; }
        public string GioiTinh { get { return _GioiTinh; } set => _GioiTinh = value; }
        public string Tuoi { get { return _Tuoi; } set => _Tuoi = value; }
        public string NgayKham { get { return _NgayKham; } set => _NgayKham = value; }
        public string DiaChi { get { return _DiaChi; } set => _DiaChi = value; }

    }
}
