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
}
