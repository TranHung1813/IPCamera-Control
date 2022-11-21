using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPCameraManager
{
    static class Program
    {
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private const int WS_SHOWNORMAL = 1;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            System.Diagnostics.Process[] name = System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            if (name.Length > 1)
            {
                MessageBox.Show("Ứng dụng đang chạy!", "Khởi động thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShowWindowAsync(name[0].MainWindowHandle, WS_SHOWNORMAL);
                SetForegroundWindow(name[0].MainWindowHandle);
            }
            else
            {

                Application.Run(new MainForm());

            }
        }
    }
}
