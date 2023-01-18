using System.Drawing;
using System.Windows.Forms;
using Syncfusion.WinForms.Input;

namespace IPCameraManager
{
    public partial class FormDoubleClick_to_ZoomPicture : Form
    {
        public FormDoubleClick_to_ZoomPicture(Image image)
        {
            InitializeComponent();
            _Image = image;
        }
        private Image _Image = null;

        private void FormDoubleClick_to_ZoomPicture_Load(object sender, System.EventArgs e)
        {
            Utility.fitFormToScreen(this, 766, 1366);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = _Image;
            this.StartPosition= FormStartPosition.CenterScreen;
        }

        private void pictureBox1_DoubleClick(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
