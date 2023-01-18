using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace IPCameraManager
{
    //this is a utility static class
    public static class Utility
    {
        public static void fitFormToScreen(Form form, int h, int w)
        {

            //scale the form to the current screen resolution
            int form_h = form.Height;
            int form_w = form.Width;
            form.Height = (int)Math.Round((float)form.Height * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h));
            form.Width = (int)Math.Round((float)form.Width * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));

            //here font is scaled like width
            form.Font = new Font(form.Font.FontFamily, form.Font.Size * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));

            foreach (Control item in form.Controls)
            {
                fitControlsToContainer(item, form_h, form_w, form.Height, form.Width);
                if (item is Guna.UI2.WinForms.Guna2GroupBox)
                {
                    Guna.UI2.WinForms.Guna2GroupBox itemGroupBox = (Guna.UI2.WinForms.Guna2GroupBox)item;
                    int Old_Thickness = itemGroupBox.CustomBorderThickness.Top;
                    itemGroupBox.CustomBorderThickness = new Padding(0, (int)Math.Round((float)itemGroupBox.CustomBorderThickness.Top * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w)), 0, 0);
                    itemGroupBox.TextOffset = new Point(0, (itemGroupBox.TextOffset.Y + (int)(Math.Abs((int)(itemGroupBox.CustomBorderThickness.Top - Old_Thickness) / 2))));
                }
                if (item is Guna.UI2.WinForms.Guna2Button)
                {
                    Guna.UI2.WinForms.Guna2Button itemGroupBox = (Guna.UI2.WinForms.Guna2Button)item;
                    itemGroupBox.ImageSize = new Size(itemGroupBox.ImageSize.Width * (int)(Screen.PrimaryScreen.Bounds.Size.Width / w),
                                                      itemGroupBox.ImageSize.Height * (int)(Screen.PrimaryScreen.Bounds.Size.Width / w));
                }
            }
            form.StartPosition = FormStartPosition.CenterScreen;
            ReallyCenterToScreen(form);

        }
        public static void fitFormToContainer(Form form, int Form_Height, int Form_Width, int Container_Height, int Container_Width)
        {

            //scale the form to the current screen resolution
            //form.Height = Container_Height;
            //form.Width = Container_Width;

            //here font is scaled like width
            form.Font = new Font(form.Font.FontFamily, form.Font.Size * ((float)Container_Width / (float)Form_Width));

            foreach (Control item in form.Controls)
            {
                fitControlsToContainer(item, Form_Height, Form_Width, Container_Height, Container_Width);
                if (item is Guna.UI2.WinForms.Guna2GroupBox)
                {
                    Guna.UI2.WinForms.Guna2GroupBox itemGroupBox = (Guna.UI2.WinForms.Guna2GroupBox)item;
                    itemGroupBox.CustomBorderThickness = new Padding(0, (int)Math.Round((float)itemGroupBox.CustomBorderThickness.Top * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)Form_Width)), 0, 0);
                    itemGroupBox.TextOffset = new Point(0, (int)Math.Round((float)itemGroupBox.TextOffset.Y * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)Form_Width) / 2));
                }
                if (item is Guna.UI2.WinForms.Guna2Button)
                {
                    Guna.UI2.WinForms.Guna2Button itemGroupBox = (Guna.UI2.WinForms.Guna2Button)item;
                    itemGroupBox.ImageSize = new Size(itemGroupBox.ImageSize.Width * (int)(Container_Width / Form_Width),
                                                      itemGroupBox.ImageSize.Height * (int)(Container_Width / Form_Width));
                }
                if(item is Guna.UI2.WinForms.Guna2ControlBox)
                {
                    Guna.UI2.WinForms.Guna2ControlBox itemControlBox = (Guna.UI2.WinForms.Guna2ControlBox)item;
                    itemControlBox.CustomIconSize = itemControlBox.CustomIconSize * ((float)Container_Width / (float)Form_Width);
                }
            }
            form.StartPosition = FormStartPosition.CenterScreen;
            ReallyCenterToScreen(form);

        }
        private static void ReallyCenterToScreen(Form form)
        {
            Screen screen = Screen.FromControl(form);

            Rectangle workingArea = screen.WorkingArea;
            form.Location = new Point()
            {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - form.Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - form.Height) / 2)
            };
        }
        public static void FitUserControlToContainer(UserControl form, int Container_Height, int Container_Width)
        {
            //scale the form to the current screen resolution
            int h = form.Height;
            int w = form.Width;
            form.Height = Container_Height;
            form.Width = Container_Width;

            //here font is scaled like width
            form.Font = new Font(form.Font.FontFamily, form.Font.Size * ((float)Container_Height / (float)h), form.Font.Style);

            foreach (Control item in form.Controls)
            {
                fitControlsToContainer(item, h, w, Container_Height, Container_Width);
                if (item is Guna.UI2.WinForms.Guna2Button)
                {
                    Guna.UI2.WinForms.Guna2Button itemGroupBox = (Guna.UI2.WinForms.Guna2Button)item;
                    itemGroupBox.ImageSize = new Size((int)Math.Round(itemGroupBox.ImageSize.Width * ((float)Container_Height / (float)h)),
                                                      (int)Math.Round(itemGroupBox.ImageSize.Height * ((float)Container_Height / (float)h)));
                }
            }
        }

        public static void fitControlsToScreen(Control cntrl, int h, int w)
        {
            if (Screen.PrimaryScreen.Bounds.Size.Height != h)
            {

                cntrl.Height = (int)Math.Round((float)cntrl.Height * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h));
                cntrl.Top = (int)Math.Round((float)cntrl.Top * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h));

            }
            if (Screen.PrimaryScreen.Bounds.Size.Width != w)
            {

                cntrl.Width = (int)Math.Round((float)cntrl.Width * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));
                cntrl.Left = (int)Math.Round((float)cntrl.Left * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));

                cntrl.Font = new Font(cntrl.Font.FontFamily, (float)(cntrl.Font.Size * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w)), cntrl.Font.Style);

            }

            foreach (Control item in cntrl.Controls)
            {
                if (item is Guna.UI2.WinForms.Guna2TextBox)
                {
                    fitGunaTextBoxsToScreen(item, h, w);
                }
                else
                {
                    fitControlsToScreen(item, h, w);
                    if (item is Guna.UI2.WinForms.Guna2Button)
                    {
                        Guna.UI2.WinForms.Guna2Button itemGroupBox = (Guna.UI2.WinForms.Guna2Button)item;
                        itemGroupBox.ImageSize = new Size((int)Math.Round(itemGroupBox.ImageSize.Width * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w)),
                                                          (int)Math.Round(itemGroupBox.ImageSize.Height * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w)));
                    }
                }
            }
        }
        static void fitControlsToContainer(Control cntrl, int h, int w, int Container_Height, int Container_Width)
        {
            if (Container_Height != h)
            {

                cntrl.Height = (int)Math.Round((float)cntrl.Height * ((float)Container_Height / (float)h));
                cntrl.Top = (int)Math.Round((float)cntrl.Top * ((float)Container_Height / (float)h));

            }
            if (Container_Width != w)
            {

                cntrl.Width = (int)Math.Round((float)cntrl.Width * ((float)Container_Width / (float)w));
                cntrl.Left = (int)Math.Round((float)cntrl.Left * ((float)Container_Width / (float)w));

                cntrl.Font = new Font(cntrl.Font.FontFamily, (float)(cntrl.Font.Size * ((float)Container_Height / (float)h)), cntrl.Font.Style);

            }

            foreach (Control item in cntrl.Controls)
            {
                if (item is Guna.UI2.WinForms.Guna2TextBox)
                {
                    fitGunaTextBoxsToContainer(item, h, w, Container_Height, Container_Width);
                }
                else
                {
                    fitControlsToContainer(item, h, w, Container_Height, Container_Width);
                    if (item is Guna.UI2.WinForms.Guna2Button)
                    {
                        Guna.UI2.WinForms.Guna2Button itemGroupBox = (Guna.UI2.WinForms.Guna2Button)item;
                        itemGroupBox.ImageSize = new Size((int)Math.Round(itemGroupBox.ImageSize.Width * ((float)Container_Height / (float)h)),
                                                          (int)Math.Round(itemGroupBox.ImageSize.Height * ((float)Container_Height / (float)h)));
                    }
                    if (item is Guna.UI2.WinForms.Guna2ControlBox)
                    {
                        Guna.UI2.WinForms.Guna2ControlBox itemControlBox = (Guna.UI2.WinForms.Guna2ControlBox)item;
                        itemControlBox.CustomIconSize = itemControlBox.CustomIconSize * ((float)Container_Height / (float)h);
                    }
                }
            }
        }

        static void fitGunaTextBoxsToScreen(Control cntrl, int h, int w)
        {
            if (Screen.PrimaryScreen.Bounds.Size.Height != h)
            {

                cntrl.Height = (int)Math.Round((float)cntrl.Height * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h));
                cntrl.Top = (int)Math.Round((float)cntrl.Top * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h));

            }
            if (Screen.PrimaryScreen.Bounds.Size.Width != w)
            {

                cntrl.Width = (int)Math.Round((float)cntrl.Width * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));
                cntrl.Left = (int)Math.Round((float)cntrl.Left * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));

                cntrl.Font = new Font(cntrl.Font.FontFamily, cntrl.Font.Size * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w), cntrl.Font.Style);

            }
        }
        static void fitGunaTextBoxsToContainer(Control cntrl, int h, int w, int Container_Height, int Container_Width)
        {
            if (Container_Height != h)
            {

                cntrl.Height = (int)Math.Round((float)cntrl.Height * ((float)Container_Height / (float)h));
                cntrl.Top = (int)Math.Round((float)cntrl.Top * ((float)Container_Height / (float)h));

            }
            if (Container_Width != w)
            {

                cntrl.Width = (int)Math.Round((float)cntrl.Width * ((float)Container_Width / (float)w));
                cntrl.Left = (int)Math.Round((float)cntrl.Left * ((float)Container_Width / (float)w));

                cntrl.Font = new Font(cntrl.Font.FontFamily, cntrl.Font.Size * ((float)Container_Width / (float)w), cntrl.Font.Style);

            }
        }
        public static void fitPopupToScreen(PopupNotifier popup, int h, int w)
        {

            //scale the popup to the current screen resolution
            popup.HeaderHeight = (int)Math.Round((float)popup.HeaderHeight * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h));
            popup.ImagePadding = new Padding((int)Math.Round((float)popup.ImagePadding.Left * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w)),
                                              (int)Math.Round((float)popup.ImagePadding.Top * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w)), 0, 0);
            popup.Size = new Size((int)Math.Round(popup.Size.Width * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h)),
                                  (int)Math.Round(popup.Size.Height * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h)));
            popup.ImageSize = new Size((int)Math.Round(popup.ImageSize.Width * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h)),
                                       (int)Math.Round(popup.ImageSize.Height * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h)));
            //here font is scaled like width
            popup.TitleFont = new Font(popup.TitleFont.FontFamily, popup.TitleFont.Size * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));
            popup.ContentFont = new Font(popup.ContentFont.FontFamily, popup.ContentFont.Size * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));
        }
    }
}
