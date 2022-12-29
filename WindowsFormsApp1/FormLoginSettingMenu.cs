using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
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
    public partial class FormLoginSettingMenu : Form
    {
        Password_Type _Password = new Password_Type();
        private const string _PrivateKey1 = "jcJQMP9Fz5YaUgAYBqjHofdk2PFJhq9S";
        private const string _PrivateKey2 = "NC72JtuaObxcsuIBjiUjhzbWOq";
        public FormLoginSettingMenu()
        {
            InitializeComponent();
        }
        IFirebaseConfig firebaseConfig = new FirebaseConfig()
        {
            AuthSecret = "2zWdZPIbFZRvKAxheEA7R5attKrbzfalHnyTGjUJ",
            BasePath = "https://watchful-branch-364316-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        IFirebaseClient Client;

        private void FormLoginSettingMenu_Load(object sender, EventArgs e)
        {
            try
            {
                Client = new FirebaseClient(firebaseConfig);
                tbPassword.PlaceholderText = " Password";
                Load_Password_Info();
                GenerateCode();
            }
            catch
            {
                //MessageBox.Show("Problem!");
            }
        }
        private void Load_Password_Info()
        {
            // Get Password info
            DataUser_Password_Info Password_Info = SqliteDataAccess.Load_Password_Info();

            if (Password_Info != null)
            {
                _Password.PrivateCode = Password_Info.PrivateValue;
                _Password.Day = Password_Info.Day;
                _Password.Month = Password_Info.Month;
                _Password.Year = Password_Info.Year;
            }
            else
            {
                // Handle when database = null
                _Password.PrivateCode = "";
                _Password.Day = 0;
                _Password.Month = 0;
                _Password.Year = 0;
            }
        }
        private async void GenerateCode()
        {
            if ((_Password.Day != DateTime.Now.Day) || (_Password.Month != DateTime.Now.Month)
                                                    || (_Password.Year  != DateTime.Now.Year))
            {
                Random random = new Random();
                int SeedKey = random.Next(100000, 1000000);
                
                _Password.PrivateCode = Encode(SeedKey.ToString());
                _Password.Month = DateTime.Now.Month;
                _Password.Day = DateTime.Now.Day;
                _Password.Year = DateTime.Now.Year;

                DataUser_Password_Info InfoSave = new DataUser_Password_Info();
                InfoSave.Id = 1;
                InfoSave.Day = _Password.Day;
                InfoSave.Month = _Password.Month;
                InfoSave.Year = _Password.Year;
                InfoSave.PrivateValue = _Password.PrivateCode;

                SqliteDataAccess.SaveInfo_Password(InfoSave);

                await Client.SetAsync(@"IPCamera/Setting_Password", _Password.PrivateCode);
            }
        }
        private string Encode (string SeedKey)
        {
            // New Private Key 2
            int WeekDay = (int)DateTime.Today.DayOfWeek;
            int DayTime = DateTime.Now.Day;
            int MonthTime = DateTime.Now.Month;

            string New_PrivateKey2 = _PrivateKey2.Substring(0, WeekDay + MonthTime) + SeedKey.ToString() + _PrivateKey2.Substring(WeekDay + MonthTime);
            // Convert to ASCII Code
            var PrivateKey1_Bytes = Encoding.ASCII.GetBytes(_PrivateKey1);
            // Encode PrivateKey1
            for (int CountByte = 0; CountByte < PrivateKey1_Bytes.Length; CountByte++)
            {
                if(CountByte != WeekDay)
                {
                    PrivateKey1_Bytes[CountByte] ^= PrivateKey1_Bytes[WeekDay];
                }
            }
            for (int CountByte = 0; CountByte < PrivateKey1_Bytes.Length; CountByte++)
            {
                if (CountByte != DayTime)
                {
                    PrivateKey1_Bytes[CountByte] ^= PrivateKey1_Bytes[DayTime];
                }
            }
            for (int CountByte = 0; CountByte < PrivateKey1_Bytes.Length; CountByte++)
            {
                if (CountByte != MonthTime)
                {
                    PrivateKey1_Bytes[CountByte] ^= PrivateKey1_Bytes[MonthTime];
                }
            }
            var New_PrivateKey2_Bytes = Encoding.ASCII.GetBytes(New_PrivateKey2);
            if (New_PrivateKey2_Bytes.Length < 32) return "";
            // Encode array with last element & day time
            for (int CountByte = 0; CountByte < PrivateKey1_Bytes.Length; CountByte++)
            {
                // Encode array with day time
                var Date_byte = (byte) DayTime;
                var Month_byte = (byte) MonthTime;
                New_PrivateKey2_Bytes[CountByte] ^= Date_byte;
                New_PrivateKey2_Bytes[CountByte] ^= Month_byte;
                New_PrivateKey2_Bytes[CountByte] ^= PrivateKey1_Bytes[CountByte];
            }

            return String.Join(" ", New_PrivateKey2_Bytes);
        }
        private int NoInternet_Encode()
        {
            int WeekDay = (int)DateTime.Today.DayOfWeek + 1;
            int DayTime = DateTime.Now.Day;
            int MonthTime = DateTime.Now.Month;
            int YearTime = DateTime.Now.Year;

            int NoInternet_Code = Factorial(WeekDay) * MonthTime * DayTime + (DayTime + 2) * YearTime * (YearTime + 1) / 2 * (WeekDay + 1);
            return (int)(NoInternet_Code % 1000000);
        }
        private int Factorial(int num)
        {
            int fact_value = num;
            if (num > 0)
            {
                for (int i = fact_value - 1; i > 0; i--)
                {
                    fact_value *= i;
                }
            }
            return fact_value;
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            // Have Internet and Server is OK
            if(tbPassword.Text.Length >= 6)
            {
                if (Encode(tbPassword.Text) == _Password.PrivateCode)
                {
                    DialogResult = DialogResult.OK;
                }
                // No Internet or Server is not working
                else if (NoInternet_Encode().ToString() == tbPassword.Text)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu. Hãy thử lại sau.");
                }
            }
            else
            {
                MessageBox.Show("Sai mật khẩu. Hãy thử lại sau.");
            }
        }
        public struct Password_Type
        {
            private string _PrivateCode;
            private int? _Day;
            private int? _Month;
            private int? _Year;

            public string PrivateCode { get { return _PrivateCode ?? ""; } set => _PrivateCode = value; }
            public int Day { get { return _Day ?? 0; } set => _Day = value; }
            public int Month { get { return _Month ?? 0; } set => _Month = value; }
            public int Year { get { return _Year ?? 0; } set => _Year = value; }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btLogin_Click(sender, e);
            }
        }
    }
}
