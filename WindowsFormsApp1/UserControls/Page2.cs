using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace IPCameraManager
{
    public partial class Page2 : UserControl
    {
        public Page2()
        {
            InitializeComponent();
            Init_Button();
            this.ActiveControl = null;
        }
        private string MauPhieuKham_Path = @"D:\Hinh_Anh\MauPhieuKham\";
        private string SavePic_Folder_Path = @"D:\Hinh_Anh\";
        private string MauPhieuKham1_Path = "";
        private string MauPhieuKham2_Path = "";
        private string FolderPath = "";

        private int Number_Patients = 0;
        private void Init_Button()
        {
            foreach (var button in this.Controls.OfType<Guna.UI2.WinForms.Guna2Button>())
            {
                button.GotFocus += (s, a) =>
                {
                    var currentButton = s as Guna.UI2.WinForms.Guna2Button;
                    currentButton.BorderColor = Color.RoyalBlue;
                    currentButton.BorderThickness = 2;
                };
                button.LostFocus += (s, a) =>
                {
                    var currentButton = s as Guna.UI2.WinForms.Guna2Button;
                    currentButton.BorderThickness = 1;
                    currentButton.BorderColor = SystemColors.ControlDarkDark;
                };
            }
        }
        public void Load_Patient_Info(PatientInfo_Type info)
        {
            tbMaBN_IN.Text = info.MaBN;
            tbHoTenBN_IN.Text = info.HoTenBN;
            tbGioiTinh_IN.Text = info.GioiTinh;
            tbTuoi_IN.Text = info.Tuoi;
            tbNgayKham_IN.Text = info.NgayKham;
            tbDiaChi_IN.Text = info.DiaChi;
        }
        public void SetFolderName(string FolderName)
        {
            FolderPath = FolderName;
        }
        public void SetMauPhieuKham(string FileName1, string FileName2)
        {
            MauPhieuKham1_Path = FileName1;
            MauPhieuKham2_Path = FileName2;
        }
        private void btExit_F12_Click(object sender, EventArgs e)
        {
            if (btExit_F12.CanFocus)
            {
                btExit_F12.Focus();
            }
            if (MessageBox.Show("Bạn chắc chắn muốn thoát?", "Warning", MessageBoxButtons.OKCancel,
                                                            MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btChonAnh1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "File ảnh (*.jpg)|*.jpg|Other Image Files (*.*)|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            openFileDialog.Title = "Chọn file ảnh";
            openFileDialog.Multiselect = false;
            openFileDialog.FileName = "";

            if (FolderPath != "")
            {
                openFileDialog.InitialDirectory = FolderPath;
            }
            else
            {
                openFileDialog.InitialDirectory = SavePic_Folder_Path;
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath1.Text = openFileDialog.FileName;
                picBox1.Load(txtPath1.Text);
            }
        }

        private void btChonAnh2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "File ảnh (*.jpg)|*.jpg|Other Image Files (*.*)|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            openFileDialog.Title = "Chọn file ảnh";
            openFileDialog.Multiselect = false;
            openFileDialog.FileName = "";

            if (FolderPath != "")
            {
                openFileDialog.InitialDirectory = FolderPath;
            }
            else
            {
                openFileDialog.InitialDirectory = SavePic_Folder_Path;
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath2.Text = openFileDialog.FileName;
                picBox2.Load(txtPath2.Text);
            }
        }

        private void btXoaChonAnh1_Click(object sender, EventArgs e)
        {
            txtPath1.Text = "";
            picBox1.Image = null;
        }

        private void btXoaChonAnh2_Click(object sender, EventArgs e)
        {
            txtPath2.Text = "";
            picBox2.Image = null;
        }
        private void TaoPhieuKhamVaIn()
        {
            Word.Application wordApp = new Word.Application();
            if (txtPath2.Text == "")
            {
                if (MauPhieuKham1_Path == "")
                {
                    MauPhieuKham1_Path = MauPhieuKham_Path + "MauPhieuDC.doc";
                }
                string file_word_mau_1 = MauPhieuKham1_Path;
                Word.Document oDoc = wordApp.Documents.Add(file_word_mau_1);
                wordApp.Visible = false;
                oDoc.Activate();
                //oDoc.
                this.FindAndReplace(wordApp, "<MABENHNHAN>", tbMaBN_IN.Text);
                this.FindAndReplace(wordApp, "<NGAYKHAM>", tbNgayKham_IN.Text);
                this.FindAndReplace(wordApp, "<DIACHI>", tbDiaChi_IN.Text);
                this.FindAndReplace(wordApp, "<GIOKHAM>", DateTime.Now.ToString("HH:mm:ss"));
                this.FindAndReplace(wordApp, "<HOVATEN>", tbHoTenBN_IN.Text);
                this.FindAndReplace(wordApp, "<TUOIBENHNHAN>", tbTuoi_IN.Text);
                this.FindAndReplace(wordApp, "<GIOITINH>", tbGioiTinh_IN.Text);

                //    object oRange = oDoc.Bookmarks[0].Range;
                //object owRange = _wordAp

                object saveWithDocument = true;
                object missing = Type.Missing;

                Word.Table table1 = oDoc.Tables[2];
                object myImageRange;
                string pictureName;

                if (txtPath1.TextLength < 10)
                {
                    MessageBox.Show("Bạn chưa chọn ảnh");
                    return;
                }
                pictureName = txtPath1.Text;
                myImageRange = table1.Cell(1, 1).Range;
                var Picture1 = oDoc.InlineShapes.AddPicture(pictureName, ref missing, ref saveWithDocument, ref myImageRange);
                Picture1.Height = 240;
                Picture1.Width = 320;


                string doc_filename;
                string doc_filepath;
                doc_filename = "\\" + tbMaBN_IN.Text + "_" + DateTime.Now.ToString("HHmmss") + ".doc";
                if (FolderPath == null)
                {
                    string directoryPath = Path.GetDirectoryName(txtPath1.Text);
                    //MessageBox.Show(directoryPath);
                    doc_filepath = directoryPath + doc_filename + ".doc";
                }
                else doc_filepath = FolderPath + doc_filename + ".doc";
                //doc_filename = @"D:\Dulieu\" + tbHoTen.Text + ".doc";
                if (File.Exists(doc_filepath))
                {
                    File.Delete(doc_filepath);
                }
                oDoc.SaveAs2(doc_filepath, Word.WdSaveFormat.wdFormatDocument97);
                wordApp.PrintOut();
                object nullObject = Type.Missing;
                oDoc.Close(ref nullObject, ref nullObject, ref nullObject);
                wordApp.Quit(ref nullObject, ref nullObject, ref nullObject);

            }
            else
            {
                if (MauPhieuKham2_Path == "")
                {
                    MauPhieuKham2_Path = MauPhieuKham_Path + "MauPhieuDC2.doc";
                }
                string file_word_mau_2 = MauPhieuKham2_Path;
                Word.Document oDoc = wordApp.Documents.Add(file_word_mau_2);
                wordApp.Visible = false;
                oDoc.Activate();
                //oDoc.
                this.FindAndReplace(wordApp, "<MABENHNHAN>", tbMaBN_IN.Text);
                this.FindAndReplace(wordApp, "<NGAYKHAM>", tbNgayKham_IN.Text);
                this.FindAndReplace(wordApp, "<DIACHI>", tbDiaChi_IN.Text);
                this.FindAndReplace(wordApp, "<GIOKHAM>", DateTime.Now.ToString("HH:mm"));
                this.FindAndReplace(wordApp, "<HOVATEN>", tbHoTenBN_IN.Text);
                this.FindAndReplace(wordApp, "<TUOIBENHNHAN>", tbTuoi_IN.Text);
                this.FindAndReplace(wordApp, "<GIOITINH>", tbGioiTinh_IN.Text);

                //    object oRange = oDoc.Bookmarks[0].Range;
                //object owRange = _wordAp

                object saveWithDocument = true;
                object missing = Type.Missing;

                Word.Table table1 = oDoc.Tables[2];
                object myImageRange;
                string pictureName;

                if (txtPath1.TextLength < 10)
                {
                    MessageBox.Show("Bạn chưa chọn ảnh");
                    return;
                }
                pictureName = txtPath1.Text;
                myImageRange = table1.Cell(1, 1).Range;
                var Picture01 = oDoc.InlineShapes.AddPicture(pictureName, ref missing, ref saveWithDocument, ref myImageRange);
                Picture01.Height = 165;
                Picture01.Width = 220;


                if (txtPath2.TextLength < 10)
                {
                    MessageBox.Show("Bạn chưa chọn ảnh");
                    return;
                }
                pictureName = txtPath2.Text;
                myImageRange = table1.Cell(1, 2).Range;
                var Picture02 = oDoc.InlineShapes.AddPicture(pictureName, ref missing, ref saveWithDocument, ref myImageRange);
                Picture02.Height = 165;
                Picture02.Width = 220;
                //Word.Bookmark bookmark1 = this.Controls.Add(
                // oDoc.InlineShapes.AddPicture(@"C:\TEST.jpg", misValue, misValue, misValue);

                //oDoc.Bookmarks.get_Items(ref myEndOfDoc).
                //oDoc.Bookmarks.Exists(ref myEndOfDoc)

                //string imagePath = @"C:\TEST.JPG";
                //oDoc.MailMerge.MainDocumentType = Word.WdMailMergeMainDocType.wdFormLetters;
                //oDoc.MailMerge.OpenDataSource(@"D:\DuLieu\Temp\temp.xls", false, true, true);
                //oDoc.MailMerge.Destination = Word.WdMailMergeDestination.wdSendToNewDocument;
                //oDoc.MailMerge.Execute(true);
                //oDoc.Fields.Update();
                //oDoc.Fields.UpdateSource();
                string doc_filename;
                string doc_filepath;
                doc_filename = "\\" + tbMaBN_IN.Text + "_" + DateTime.Now.ToString("HHmmss") + ".doc";
                if (FolderPath == null)
                {
                    string directoryPath = Path.GetDirectoryName(txtPath1.Text);
                    //MessageBox.Show(directoryPath);
                    doc_filepath = directoryPath + doc_filename + ".doc";
                }
                else doc_filepath = FolderPath + doc_filename + ".doc";
                //doc_filename = @"D:\Dulieu\" + tbHoTen.Text + ".doc";
                if (File.Exists(doc_filepath))
                {
                    File.Delete(doc_filepath);
                }
                oDoc.SaveAs2(doc_filepath, Word.WdSaveFormat.wdFormatDocument97);
                wordApp.PrintOut();
                object nullObject = Type.Missing;
                oDoc.Close(ref nullObject, ref nullObject, ref nullObject);
                wordApp.Quit(ref nullObject, ref nullObject, ref nullObject);
            }
        }
        private void FindAndReplace(Word.Application wordApp, object findText, object replaceText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            wordApp.Selection.Find.Execute(ref findText, ref matchCase,
                ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
                ref matchAllWordForms, ref forward, ref wrap, ref format,
                ref replaceText, ref replace, ref matchKashida,
                        ref matchDiacritics,
                ref matchAlefHamza, ref matchControl);
        }

        private void btInPhieu_F9_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                btInPhieu_F9_MouseUp_Click();
            }
            else if (e.Button == MouseButtons.Right)
            {

            }
        }
        public void btInPhieu_F9_MouseUp_Click()
        {
            if (tbMaBN_IN.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập mã bệnh nhân! \rĐề nghị nhập lại.", "Lỗi: Chưa nhập mã bệnh nhân", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbHoTenBN_IN.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập tên bệnh nhân! \rĐề nghị nhập lại.", "Lỗi: Chưa nhập tên bệnh nhân", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbTuoi_IN.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập tuổi bệnh nhân! \rĐề nghị nhập lại.", "Lỗi: Chưa nhập tuổi bệnh nhân", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check xem thong tin bênh nhân đã tồn tại hay chưa
            List<DataUser_Patients_Info> Patients_Info = SqliteDataAccess.Load_Patients_Info();
            if (Patients_Info != null && Patients_Info.Count >= 1)
            {
                int index = Patients_Info.FindIndex(a => a.MaBN == tbMaBN_IN.Text);
                if (index != -1)
                {
                    if (DialogResult.OK == MessageBox.Show("Mã bệnh nhân đã tồn tại. Vẫn tiếp tục?",
                                                        "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                    {
                        // Ghi đè
                        try
                        {
                            TaoPhieuKhamVaIn();
                            // Save Patient Info at Id = index + 1
                            Save_Patients_Info(index + 1);
                            // Save Number Patient Info
                            Save_NumberPatients_Info(Number_Patients);
                        }
                        catch
                        {
                            MessageBox.Show("In phiếu khám không thành công. Hãy xem lại mẫu phiếu khám.", "Warning",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            try
            {
                TaoPhieuKhamVaIn();
                Number_Patients++;
                // Save Patient Info at Id = Number_Patients
                Save_Patients_Info(Number_Patients);
                // Save Number Patient Info
                Save_NumberPatients_Info(Number_Patients);
            }
            catch
            {
                MessageBox.Show("In phiếu khám không thành công. Hãy xem lại mẫu phiếu khám.", "Warning",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Save_Patients_Info(int Patient_ID)
        {
            // Save Patient Info
            DataUser_Patients_Info patientsInfo_Save = new DataUser_Patients_Info();
            patientsInfo_Save.Id = Patient_ID;
            patientsInfo_Save.MaBN = tbMaBN_IN.Text;
            patientsInfo_Save.HoTenBN = tbHoTenBN_IN.Text;
            patientsInfo_Save.GioiTinh = tbGioiTinh_IN.Text;
            patientsInfo_Save.Tuoi = tbTuoi_IN.Text;
            patientsInfo_Save.NgayKham = tbNgayKham_IN.Text;
            patientsInfo_Save.DiaChi = tbDiaChi_IN.Text;
            patientsInfo_Save.Anh1_Path = txtPath1.Text;
            patientsInfo_Save.Anh2_Path = txtPath2.Text;

            SqliteDataAccess.SaveInfo_Patients(patientsInfo_Save);
        }
        private void Save_NumberPatients_Info(int numberPatient)
        {
            DataUser_NumberPatients_Info InfoSave = new DataUser_NumberPatients_Info();
            InfoSave.Id = 1;
            InfoSave.Number_Patients = numberPatient;

            SqliteDataAccess.SaveInfo_NumberPatients(InfoSave);
        }
        public void Set_NumberPatients_Info(int number)
        {
            Number_Patients = number;
            textBox1.Text = Number_Patients.ToString();
        }
    }
    public struct PatientInfo_Type
    {
        private string _MaBN;
        private string _HoTenBN;
        private string _GioiTinh;
        private string _Tuoi;
        private string _NgayKham;
        private string _DiaChi;

        public string MaBN { get { return _MaBN; } set => _MaBN = value; }
        public string HoTenBN { get { return _HoTenBN; } set => _HoTenBN = value; }
        public string GioiTinh { get { return _GioiTinh; } set => _GioiTinh = value; }
        public string Tuoi { get { return _Tuoi; } set => _Tuoi = value; }
        public string NgayKham { get { return _NgayKham; } set => _NgayKham = value; }
        public string DiaChi { get { return _DiaChi; } set => _DiaChi = value; }

    }
}
