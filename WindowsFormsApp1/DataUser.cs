using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCameraManager
{
    public class DataUser_LoginCamera_Info
    {
        public int Id { get; set; }

        public string IP_Address { get; set; }

        public string Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
    public class DataUser_Other_Info
    {
        public int Id { get; set; }

        public string FolderSaveFile { get; set; }
    }
    public class DataUser_MauPhieuKham_Info
    {
        public int Id { get; set; }

        public string MauPhieuKham1 { get; set; }

        public string MauPhieuKham2 { get; set; }
    }
    public class DataUser_Patients_Info
    {
        public int Id { get; set; }

        public string MaBN { get; set; }

        public string HoTenBN { get; set; }

        public string GioiTinh { get; set; }

        public string Tuoi { get; set; }

        public string NgayKham { get; set; }

        public string DiaChi { get; set; }

        public string Anh1_Path { get; set; }

        public string Anh2_Path { get; set; }
    }
    public class DataUser_NumberPatients_Info
    {
        public int Id { get; set; }

        public int Number_Patients { get; set; }
    }
    public class DataUser_Password_Info
    {
        public int Id { get; set; }

        public string PrivateValue { get; set; }

        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public int UpdateStatus { get; set; }
    }
}
