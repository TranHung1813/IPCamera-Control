using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCameraManager
{
    public class SqliteDataAccess
    {
        //*****************************************************************************************************************
        //****************************************** Access to Login Camera Infomation *******************************************
        public static List<DataUser_LoginCamera_Info> Load_LoginCamera_Info()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<DataUser_LoginCamera_Info>("select * from LoginCamera_Info", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void AddInfo_LoginCamera(DataUser_LoginCamera_Info info)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    cnn.Execute("insert into LoginCamera_Info ( IP_Address, Port, Username, Password) values ( @IP_Address, @Port, @Username, @Password)", info);
                }
                catch
                { }
            }
        }
        public static void SaveInfo_LoginCamera(DataUser_LoginCamera_Info info)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                int id = cnn.Query<int>("select Id from LoginCamera_Info where Id like @Id", new { Id = info.Id }).FirstOrDefault();

                if (id == info.Id)
                {
                    cnn.Execute("update LoginCamera_Info set IP_Address= @IP_Address, Port = @Port, Username = @Username, Password = @Password where Id = @Id", info);
                }
                else
                {
                    cnn.Execute("insert into LoginCamera_Info ( IP_Address, Port, Username, Password) values ( @IP_Address, @Port, @Username, @Password)", info);
                }
            }
        }

        //*****************************************************************************************************************
        //****************************************** Access to Other Infomation *******************************************
        public static DataUser_Other_Info Load_Other_Info()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    DataUser_Other_Info output = cnn.Query<DataUser_Other_Info>("select * from Other_Info", new DynamicParameters()).FirstOrDefault();
                    return output;
                }
                catch
                {

                }

                return null;
            }
        }

        public static void SaveInfo_Other(DataUser_Other_Info info)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                int id = cnn.Query<int>("select Id from Other_Info where Id like @Id", new { Id = 1 }).FirstOrDefault();

                if (id != 0)
                {
                    cnn.Execute("update Other_Info set  FolderSaveFile= @FolderSaveFile where Id = 1", info);
                }
                else
                {
                    cnn.Execute("insert into Other_Info ( FolderSaveFile) values ( @FolderSaveFile)", info);
                }
            }
        }

        //*****************************************************************************************************************
        //****************************************** Access to Mau Phieu Kham Infomation *******************************************
        public static DataUser_MauPhieuKham_Info Load_MauPhieuKham_Info()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    DataUser_MauPhieuKham_Info output = cnn.Query<DataUser_MauPhieuKham_Info>("select * from MauPhieuKham_Info", new DynamicParameters()).FirstOrDefault();
                    return output;
                }
                catch
                {

                }

                return null;
            }
        }

        public static void SaveInfo_MauPhieuKham(DataUser_MauPhieuKham_Info info)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                int id = cnn.Query<int>("select Id from MauPhieuKham_Info where Id like @Id", new { Id = 1 }).FirstOrDefault();

                if (id != 0)
                {
                    cnn.Execute("update MauPhieuKham_Info set MauPhieuKham1= @MauPhieuKham1, MauPhieuKham2= @MauPhieuKham2 where Id = 1", info);
                }
                else
                {
                    cnn.Execute("insert into MauPhieuKham_Info ( MauPhieuKham1, MauPhieuKham2) values ( @MauPhieuKham1, @MauPhieuKham2)", info);
                }
            }
        }

        //*****************************************************************************************************************
        //****************************************** Access to Patients Infomation *******************************************
        public static List<DataUser_Patients_Info> Load_Patients_Info()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<DataUser_Patients_Info>("select * from Patients_Info", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void AddInfo_Patients(DataUser_Patients_Info info)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    cnn.Execute("insert into Patients_Info ( MaBN, HoTenBN, GioiTinh, Tuoi, NgayKham, DiaChi, Anh1_Path, Anh2_Path) values ( @MaBN, @HoTenBN, @GioiTinh, @Tuoi, @NgayKham, @DiaChi, @Anh1_Path, @Anh2_Path)", info);
                }
                catch
                { }
            }
        }
        public static void SaveInfo_Patients(DataUser_Patients_Info info)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                int id = cnn.Query<int>("select Id from Patients_Info where Id like @Id", new { Id = info.Id }).FirstOrDefault();

                if (id == info.Id)
                {
                    cnn.Execute("update Patients_Info set MaBN= @MaBN, HoTenBN = @HoTenBN, GioiTinh = @GioiTinh, Tuoi = @Tuoi, NgayKham = @NgayKham, DiaChi = @DiaChi, Anh1_Path = @Anh1_Path, Anh2_Path = @Anh2_Path where Id = @Id", info);
                }
                else
                {
                    cnn.Execute("insert into Patients_Info ( MaBN, HoTenBN, GioiTinh, Tuoi, NgayKham, DiaChi, Anh1_Path, Anh2_Path) values ( @MaBN, @HoTenBN, @GioiTinh, @Tuoi, @NgayKham, @DiaChi, @Anh1_Path, @Anh2_Path)", info);
                }
            }
        }

        //*****************************************************************************************************************
        //****************************************** Access to Number Patients Infomation *******************************************
        public static DataUser_NumberPatients_Info Load_NumberPatients_Info()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    DataUser_NumberPatients_Info output = cnn.Query<DataUser_NumberPatients_Info>("select * from NumberPatients_Info", new DynamicParameters()).FirstOrDefault();
                    return output;
                }
                catch
                {

                }

                return null;
            }
        }

        public static void SaveInfo_NumberPatients(DataUser_NumberPatients_Info info)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                int id = cnn.Query<int>("select Id from NumberPatients_Info where Id like @Id", new { Id = 1 }).FirstOrDefault();

                if (id != 0)
                {
                    cnn.Execute("update NumberPatients_Info set Number_Patients= @Number_Patients where Id = 1", info);
                }
                else
                {
                    cnn.Execute("insert into NumberPatients_Info ( Number_Patients) values ( @Number_Patients)", info);
                }
            }
        }

        //*****************************************************************************************************************
        //****************************************** Access to Password Infomation *******************************************
        public static DataUser_Password_Info Load_Password_Info()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    DataUser_Password_Info output = cnn.Query<DataUser_Password_Info>("select * from PrivateValue_Info", new DynamicParameters()).FirstOrDefault();
                    return output;
                }
                catch
                {

                }

                return null;
            }
        }

        public static void SaveInfo_Password(DataUser_Password_Info info)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                int id = cnn.Query<int>("select Id from PrivateValue_Info where Id like @Id", new { Id = 1 }).FirstOrDefault();

                if (id != 0)
                {
                    cnn.Execute("update PrivateValue_Info set  PrivateValue= @PrivateValue, Day= @Day, Month= @Month, Year = @Year, UpdateStatus = @UpdateStatus where Id = 1", info);
                }
                else
                {
                    cnn.Execute("insert into PrivateValue_Info ( PrivateValue, Day, Month, Year, UpdateStatus) values ( @PrivateValue, @Day, @Month, @Year, @UpdateStatus)", info);
                }
            }
        }

        //*****************************************************************************************************************
        //*****************************************************************************************************************
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
