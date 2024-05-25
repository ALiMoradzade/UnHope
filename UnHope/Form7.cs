using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoradzadeHelperUtilityLibrary;

namespace UnHope
{
    public partial class Form7 : Form
    {
        Color a;
        public int F1_x, F1_y, F1_Width, F1_Height;
        public Form7()
        {
            InitializeComponent();
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            checkedListBox1_SelectedIndexChanged(sender, new EventArgs());
        }
        private void Form7_Resize(object sender, EventArgs e)
        {
            Left = F1_x + (F1_Width - Width) / 2;
            Top = F1_y + (F1_Height - Height) / 2;
        }
        private void KeyPress_JustNumber(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))) e.Handled = true;
        }
        private void null_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "" || ((TextBox)sender).Text == "0")
            {
                ((TextBox)sender).Text = "1";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).TextLength;
            }
        }
        private void hexaCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Regex.IsMatch(e.KeyChar.ToString(), @"^[a-fA-F0-9]+$") || char.IsControl(e.KeyChar))) e.Handled = true;
        }

        void RGB()
        {

        }

        #region Right Click
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(hexaCode.Text);
        }
        #endregion

        #region TrackBar & TextBox Events
        private void trackBarR_Scroll(object sender, EventArgs e)
        {
            textBoxR.Text = trackBarR.Value.ToString();
        }
        private void textBoxR_TextChanged(object sender, EventArgs e)
        {
            if (0 <= int.Parse(textBoxR.Text) && int.Parse(textBoxR.Text) <= 255) trackBarR.Value = int.Parse(textBoxR.Text);
            else textBoxR.Text = "0";
            if (ActiveControl == textBoxR || ActiveControl == trackBarR) FuncRGB();
            if (textBoxR.Enabled) progressBar1.Hide();
        }

        private void trackBarG_Scroll(object sender, EventArgs e)
        {
            textBoxG.Text = trackBarG.Value.ToString();
        }
        private void textBoxG_TextChanged(object sender, EventArgs e)
        {
            if (0 <= int.Parse(textBoxG.Text) && int.Parse(textBoxG.Text) <= 255) trackBarG.Value = int.Parse(textBoxG.Text);
            else textBoxG.Text = "0";
            if (ActiveControl == textBoxG || ActiveControl == trackBarG) FuncRGB();
            if (textBoxG.Enabled) progressBar1.Hide();
        }

        private void trackBarB_Scroll(object sender, EventArgs e)
        {
            textBoxB.Text = trackBarB.Value.ToString();
        }
        private void textBoxB_TextChanged(object sender, EventArgs e)
        {
            if (0 <= int.Parse(textBoxB.Text) && int.Parse(textBoxB.Text) <= 255) trackBarB.Value = int.Parse(textBoxB.Text);
            else textBoxB.Text = "0";
            if (ActiveControl == textBoxB|| ActiveControl == trackBarB) FuncRGB();
            if (textBoxB.Enabled) progressBar1.Hide();
        }
        #endregion

        #region HexCode
        private void hexaCode_Validated(object sender, EventArgs e)
        {
            hexaCode.Text = hexaCode.Text.Replace("#", "");
            if (hexaCode.TextLength > 6) hexaCode.Text = hexaCode.Text.Remove(6);
            hexaCode.Text = FastCode.Split(hexaCode.Text, 6, "", '0', false);
            textBoxR.Text = Convert.ToInt32(hexaCode.Text.Substring(0, 2), 16).ToString();
            textBoxG.Text = Convert.ToInt32(hexaCode.Text.Substring(2, 2), 16).ToString();
            textBoxB.Text = Convert.ToInt32(hexaCode.Text.Substring(4, 2), 16).ToString();
            hexaCode.Text += '#';
            FuncRGB();
        }
        #endregion

        #region check list
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= 3; i++)
            {
                if (i == checkedListBox1.SelectedIndex) continue;
                checkedListBox1.SetItemChecked(i, false);
            }

            a = Color.FromArgb(0, 0, 0);
            hexaCode.Text = ColorTranslator.ToHtml(a);
            hexaCode_Validated(sender, e);
            if (checkedListBox1.GetItemChecked(0))
            {
                progressBar1.SetState(1); //ProgressBarColor.SetState(progressBar1, 1);
                ClientSize = new Size(656, 259);

                trackBarR.Location = new Point(64, 41);
                trackBarG.Location = new Point(64, 92);
                trackBarB.Location = new Point(64, 143);

                textBoxR.Location = new Point(609, 51);
                textBoxG.Location = new Point(609, 102);
                textBoxB.Location = new Point(609, 153);
                hexaCode.Location = new Point(575, 194);
                colorName.Location = new Point(575, 225);

                checkedListBox1.Location = new Point(12, 194);
                intervalBox.Location = new Point(148, 194);
                stepBox.Location = new Point(262, 194);

                labelR.Location = new Point(12, 55);
                labelG.Location = new Point(12, 106);
                labelB.Location = new Point(12, 157);
                label1.Location = new Point(187, 198);
                label2.Location = new Point(218, 198);

                progressBar1.Show();
                trackBarR.Show();
                trackBarG.Show();
                trackBarB.Show();
                labelR.Show();
                labelG.Show();
                labelB.Show();
                spectrum.Hide();

                label1.Show();
                label2.Show();
                intervalBox.Show();
                stepBox.Show();

                trackBarR.Enabled = false;
                trackBarG.Enabled = false;
                trackBarB.Enabled = false;
                textBoxR.Enabled = false;
                textBoxG.Enabled = false;
                textBoxB.Enabled = false;
                hexaCode.Enabled = false;
                timer1.Start();
            }
            else if (checkedListBox1.GetItemChecked(1))
            {
                ClientSize = new Size(656, 230);

                trackBarR.Location = new Point(64, 12);
                trackBarG.Location = new Point(64, 63);
                trackBarB.Location = new Point(64, 114);

                textBoxR.Location = new Point(609, 22);
                textBoxG.Location = new Point(609, 73);
                textBoxB.Location = new Point(609, 124);
                hexaCode.Location = new Point(575, 165);
                colorName.Location = new Point(575, 196);

                checkedListBox1.Location = new Point(12, 165);
                intervalBox.Location = new Point(148, 165);

                labelR.Location = new Point(12, 26);
                labelG.Location = new Point(12, 77);
                labelB.Location = new Point(12, 128);
                label1.Location = new Point(187, 169);

                progressBar1.Hide();
                trackBarR.Show();
                trackBarG.Show();
                trackBarB.Show();

                spectrum.Hide();

                label1.Show();
                label2.Hide();
                intervalBox.Show();
                stepBox.Hide();

                trackBarR.Enabled = false;
                trackBarG.Enabled = false;
                trackBarB.Enabled = false;
                textBoxR.Enabled = false;
                textBoxG.Enabled = false;
                textBoxB.Enabled = false;
                hexaCode.Enabled = false;
                timer1.Start();
            }
            else if (checkedListBox1.GetItemChecked(2))
            {
                ClientSize = new Size(656, 230);

                trackBarR.Location = new Point(64, 12);
                trackBarG.Location = new Point(64, 63);
                trackBarB.Location = new Point(64, 114);

                textBoxR.Location = new Point(609, 22);
                textBoxG.Location = new Point(609, 73);
                textBoxB.Location = new Point(609, 124);
                hexaCode.Location = new Point(575, 165);
                colorName.Location = new Point(575, 196);

                checkedListBox1.Location = new Point(12, 165);

                labelR.Location = new Point(12, 26);
                labelG.Location = new Point(12, 77);
                labelB.Location = new Point(12, 128);

                progressBar1.Hide();
                trackBarR.Show();
                trackBarG.Show();
                trackBarB.Show();

                spectrum.Hide();

                label1.Hide();
                label2.Hide();
                intervalBox.Hide();
                stepBox.Hide();

                trackBarR.Enabled = false;
                trackBarG.Enabled = false;
                trackBarB.Enabled = false;
                textBoxR.Enabled = false;
                textBoxG.Enabled = false;
                textBoxB.Enabled = false;
                hexaCode.Enabled = false;
                timer1.Stop();
            }
            else if (checkedListBox1.GetItemChecked(3))
            {
                ClientSize = new Size(334, 241);

                textBoxR.Location = new Point(64, 12);
                textBoxG.Location = new Point(64, 63);
                textBoxB.Location = new Point(64, 114);
                hexaCode.Location = new Point(26, 145);
                colorName.Location = new Point(575, 176);

                checkedListBox1.Location = new Point(12, 176);

                labelR.Location = new Point(12, 16);
                labelG.Location = new Point(12, 67);
                labelB.Location = new Point(12, 118);

                progressBar1.Hide();
                trackBarR.Hide();
                trackBarG.Hide();
                trackBarB.Hide();

                spectrum.Show();

                label1.Hide();
                label2.Hide();
                intervalBox.Hide();
                stepBox.Hide();

                trackBarR.Enabled = false;
                trackBarG.Enabled = false;
                trackBarB.Enabled = false;
                textBoxR.Enabled = false;
                textBoxG.Enabled = false;
                textBoxB.Enabled = false;
                hexaCode.Enabled = false;
                timer1.Stop();
            }
            //else if()
            //{ 
            //}
            else
            {
                ClientSize = new Size(656, 230);

                trackBarR.Location = new Point(64, 12);
                trackBarG.Location = new Point(64, 63);
                trackBarB.Location = new Point(64, 114);

                textBoxR.Location = new Point(609, 22);
                textBoxG.Location = new Point(609, 73);
                textBoxB.Location = new Point(609, 124);
                hexaCode.Location = new Point(575, 165);
                colorName.Location = new Point(575, 196);

                checkedListBox1.Location = new Point(12, 165);

                labelR.Location = new Point(12, 26);
                labelG.Location = new Point(12, 77);
                labelB.Location = new Point(12, 128);

                progressBar1.Hide();
                trackBarR.Show();
                trackBarG.Show();
                trackBarB.Show();

                spectrum.Hide();

                label1.Hide();
                label2.Hide();
                intervalBox.Hide();
                stepBox.Hide();

                trackBarR.Enabled = true;
                trackBarG.Enabled = true;
                trackBarB.Enabled = true;
                textBoxR.Enabled = true;
                textBoxG.Enabled = true;
                textBoxB.Enabled = true;
                hexaCode.Enabled = true;
                timer1.Stop();
            }
        }
        #endregion

        #region RGB
        private void FuncRGB(int? r = null, int? g = null, int? b = null)
        {
            if (r == null) r = trackBarR.Value;
            if (g == null) g = trackBarG.Value;
            if (b == null) b = trackBarB.Value;
            Color a = Color.FromArgb((int)r, (int)g, (int)b);
            BackColor = a;
            checkedListBox1.BackColor = a;
            hexaCode.Text = ColorTranslator.ToHtml(a);
            colorName.Text = a.Name;

            if (BackColor.GetBrightness() <= 0.5 && labelR.ForeColor == Color.Black)
            {
                labelR.ForeColor = Color.White;
                labelG.ForeColor = Color.White;
                labelB.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                checkedListBox1.ForeColor = Color.White;
            }
            else if (BackColor.GetBrightness() > 0.5 && labelR.ForeColor == Color.White)
            {
                labelR.ForeColor = Color.Black;
                labelG.ForeColor = Color.Black;
                labelB.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                checkedListBox1.ForeColor = Color.Black;
            }
        }
        #endregion
       
        #region Random Picker
        private void RandomRGBPicker()
        {
            Random a = new Random();
            string s = "0123456789ABCDEF", t = "";
            for (int j = 1; j < 7; j++)
            {
                t = t.InsertRandom(s[a.Next(16)]);
            }
            //Random a = new Random(DateTime.Now.Millisecond);
            //int r = a.Next(256), g = a.Next(256), b = a.Next(256);
            //hexaCode.Text = ColorTranslator.ToHtml(Color.FromArgb(r, g, b));
            hexaCode.Text = '#' + t;
        }
        #endregion

        #region Timer
        private void timer1_Tick(object sender, EventArgs e)
        {   
            timer1.Interval = int.Parse(intervalBox.Text);
            if (checkedListBox1.GetItemChecked(0))
            {
                int a = Convert.ToInt32(hexaCode.Text.Replace("#", ""), 16);
                a += int.Parse(stepBox.Text);
                if (a >= 0xFFFFFF) a -= 0xFFFFFF;
                hexaCode.Text = "#" + FastCode.Split(new MultiBaseNumber(a, 16), 6, "", '0');
                progressBar1.Value = a;
            }
            else if (checkedListBox1.GetItemChecked(1)) RandomRGBPicker();
            hexaCode_Validated(sender, e);
        }
        #endregion

        #region Mouse Move Random
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (checkedListBox1.GetItemChecked(2))
            {
                RandomRGBPicker();
                hexaCode_Validated(sender, new EventArgs());
            }
        }
        #endregion

        #region Spectrum
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Bitmap b = (Bitmap)spectrum.Image;
            Color c = b.GetPixel(e.X, e.Y);
            textBoxR.Text = c.R.ToString();
            textBoxG.Text = c.G.ToString();
            textBoxB.Text = c.B.ToString();
            FuncRGB();
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            textBoxR.Text = a.R.ToString();
            textBoxG.Text = a.G.ToString();
            textBoxB.Text = a.B.ToString();
            FuncRGB();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Bitmap b = (Bitmap)spectrum.Image;
            a = b.GetPixel(e.X, e.Y);
        }
        #endregion
    }
}