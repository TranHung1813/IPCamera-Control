using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraControl
{
    public partial class UserControl_TabKhamBenh : UserControl
    {
        public UserControl_TabKhamBenh()
        {
            InitializeComponent();

            InitCam_Status = CHCNetSDK.NET_DVR_Init();
            if (InitCam_Status == false)
            {
                MessageBox.Show("NET_DVR_Init error!");
                return;
            }
            else
            {
                //Set Folder to save the SDK log
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
            }
        }
        private bool InitCam_Status = false;
        public Int32 Live_Status = -1;
        public Int32 LoginStatus = -1;

        protected override void Dispose(bool disposing)
		{
			if (Live_Status >= 0)
			{
				CHCNetSDK.NET_DVR_StopRealPlay(Live_Status);
			}
			if (InitCam_Status == true)
			{
				CHCNetSDK.NET_DVR_Cleanup();
			}
            if (LoginStatus >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(LoginStatus);
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

		private void btOpenCamMain_Click(object sender, EventArgs e)
        {
            


        }
    }
}
