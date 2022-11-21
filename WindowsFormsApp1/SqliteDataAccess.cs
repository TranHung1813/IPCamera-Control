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
        public static DataUser_LoginCamera_Info Load_LoginCamera_Info()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    DataUser_LoginCamera_Info output = cnn.Query<DataUser_LoginCamera_Info>("select * from LoginCamera_Info", new DynamicParameters()).FirstOrDefault();
                    return output;
                }
                catch
                {

                }

                return null;
            }
        }

        public static void SaveInfo_LoginCamera(DataUser_LoginCamera_Info info)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                int id = cnn.Query<int>("select Id from LoginCamera_Info where Id like @Id", new { Id = 1 }).FirstOrDefault();

                if (id != 0)
                {
                    cnn.Execute("update LoginCamera_Info set  IP_Address= @IP_Address, Port = @Port, Username = @Username, Password = @Password where Id = 1", info);
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
        //*****************************************************************************************************************
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
