using System.Drawing;
using System.Windows.Forms;

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
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = _Image;
        }

        private void pictureBox1_DoubleClick(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
