using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
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
        private bool _isResize = false;

        private const int ERR_OK = 0;
        private const int ERR_NOT_OK = 1;
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
            if (_isResize == false)
            {
                _isResize = true;
                Utility.fitFormToScreen(this, 766, 1366);
                tbPassword.Font = new Font(tbPassword.Font.FontFamily, (int)(tbPassword.Font.Size * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)1366)), tbPassword.Font.Style);
            }
            try
            {
                Client = new FirebaseClient(firebaseConfig);
                tbPassword.PlaceholderText = " Password";
                Check_PasswordInfo_FromServer();
            }
            catch
            {
                //MessageBox.Show("Problem!");
            }
        }
        private async void Check_PasswordInfo_FromServer()
        {
            int result_Day = ERR_OK;
            int result_Month = ERR_OK;
            int result_Year = ERR_OK;
            int result_Pass = ERR_OK;
            try
            {
                FirebaseResponse resp = await Client.GetAsync(@"IPCamera/Setting_Properties");
                Dictionary<string, string > data = JsonConvert.DeserializeObject<Dictionary<string, string>>(resp.Body.ToString());
                if(data.ContainsKey("Setting_Day"))
                {
                    if (data["Setting_Day"] != DateTime.Now.Day.ToString())
                    {
                        result_Day = ERR_NOT_OK;
                    }
                    else
                    {
                        try
                        {
                            _Password.Day = Int32.Parse(data["Setting_Day"]);
                        }
                        catch { }
                    }
                }
                if (data.ContainsKey("Setting_Month"))
                {
                    if (data["Setting_Month"] != DateTime.Now.Month.ToString())
                    {
                        result_Month = ERR_NOT_OK;
                    }
                    else
                    {
                        try
                        {
                            _Password.Month = Int32.Parse(data["Setting_Month"]);
                        }
                        catch { }
                    }
                }
                if (data.ContainsKey("Setting_Year"))
                {
                    if (data["Setting_Year"] != DateTime.Now.Year.ToString())
                    {
                        result_Year = ERR_NOT_OK;
                    }
                    else
                    {
                        try
                        {
                            _Password.Year = Int32.Parse(data["Setting_Year"]);
                        }
                        catch { }
                    }
                }
                if (data.ContainsKey("Setting_Password"))
                {
                    if (data["Setting_Password"] == "")
                    {
                        result_Pass = ERR_NOT_OK;
                    }
                    else
                    {
                        _Password.PrivateCode = data["Setting_Password"];
                    }
                }
            }
            catch
            {
                result_Pass = ERR_NOT_OK;
            }
            if(result_Day == ERR_NOT_OK || result_Month == ERR_NOT_OK || result_Year == ERR_NOT_OK || result_Pass == ERR_NOT_OK) 
            {
                try
                {
                    GenerateCode();
                }
                catch { }
            }
        }
        private async void GenerateCode()
        {
            Random random = new Random();
            int SeedKey = random.Next(100000, 1000000);

            _Password.PrivateCode = Encode(SeedKey.ToString());
            _Password.Month = DateTime.Now.Month;
            _Password.Day = DateTime.Now.Day;
            _Password.Year = DateTime.Now.Year;

            try
            {
                await Client.SetAsync(@"IPCamera/Setting_Properties/Setting_Password", _Password.PrivateCode);
                await Client.SetAsync(@"IPCamera/Setting_Properties/Setting_Month", _Password.Month.ToString());
                await Client.SetAsync(@"IPCamera/Setting_Properties/Setting_Day", _Password.Day.ToString());
                await Client.SetAsync(@"IPCamera/Setting_Properties/Setting_Year", _Password.Year.ToString());
            }
            catch
            { }
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
        private string NoInternet_Encode()
        {
            int WeekDay = (int)DateTime.Today.DayOfWeek + 1;
            int DayTime = DateTime.Now.Day;
            int MonthTime = DateTime.Now.Month;
            int YearTime = DateTime.Now.Year;

            int NoInternet_Code = Factorial(WeekDay) * MonthTime * DayTime + (DayTime + 2) * YearTime * (YearTime + 1) / 2 * (WeekDay + 1);
            // Lay 6 chu so cuoi 
            var digit = Convert.ToString(NoInternet_Code);
            var SixlastDigit = digit.Substring(digit.Length - 6);
            return SixlastDigit;
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
                else if (NoInternet_Encode() == tbPassword.Text)
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
            private int? _UpdateStatus;

            public string PrivateCode { get { return _PrivateCode ?? ""; } set => _PrivateCode = value; }
            public int Day { get { return _Day ?? 0; } set => _Day = value; }
            public int Month { get { return _Month ?? 0; } set => _Month = value; }
            public int Year { get { return _Year ?? 0; } set => _Year = value; }
            public int UpdateStatus { get { return _UpdateStatus ?? 0; } set => _UpdateStatus = value; }
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
