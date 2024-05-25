using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using System.Text;
using System.Text.RegularExpressions;


namespace UnHope
{
    public partial class Form1 : Form
    {
        Form1_1 F1_1;
        Form1_2 F1_2;
        Form2 F2;
        Form3 F3;
        Form4 F4;
        Form5 F5;
        Form6 F6;
        public Form1(Form1_1 Frm1_1, Form1_2 Frm1_2, Form2 Frm2, Form3 Frm3, Form4 Frm4, Form5 Frm6, Form6 Frm7)
        {
            InitializeComponent();
            F1_1 = Frm1_1;
            F1_2 = Frm1_2;
            F2 = Frm2;
            F3 = Frm3;
            F4 = Frm4;
            F5 = Frm6;
            F6 = Frm7;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= F1_1.checkedListBox1.Items.Count - 1; i++)
            {
                F1_1.checkedListBox1.SetItemCheckState(i, CheckState.Checked);
            }
        }

        #region Data
        Random R = new Random();

        int n = 10, m;
        #endregion

        #region Length Label
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "Length: " + textBox1.Text.Length;
            label2.Location = new Point(label1.Location.X + label1.Size.Width + 4, 257);
            label2.Text = "Spaces: " + textBox1.Text.Count(x => x == ' ');
            label3.Location = new Point(label2.Location.X + label2.Size.Width + 4, 257);
            label3.Text = "Lines: " + ((textBox1.Text != "") ? textBox1.Lines.Length : 1);
            label4.Location = new Point(label3.Location.X + label3.Size.Width + 4, 257);
            label4.Text = "Enters: " + Regex.Matches(textBox1.Text, @"\r\n").Count;
        }
        #endregion

        #region Char Group Label
        bool clientRequest = false;
        bool wasInBase = false;
        private void Length1(object b)
        {
            if (typeof(int) == b.GetType())
            {
                if (0xD800 <= (int)b && (int)b <= 0xDFFF)
                {
                    List<string> a = FastCode.CharGroupBy(Convert.ToChar((int)b));
                    label5.Text += Convert.ToChar((int)b);
                    label5.Text += " char is in ";
                    if (a.Count == 0) label5.Text += "unknown groups!";
                    else if (a.Count == 1) label5.Text += "group of " + a[0];
                    else if (a.Count > 1) label5.Text += "groups of " + string.Join(" & ", a);
                }
                else if (!(0 <= (int)b && (int)b <= 0x10FFFF)) label5.Text += "Code is out of range of 0x0 ~ 0x10FFFF!";
                else label5.Text += char.ConvertFromUtf32((int)b);
            }
            else
            {
                label5.Text += "Selected char is in ";
                List<string> a = FastCode.CharGroupBy((char)b);
                if (a.Count == 0) label5.Text += "unknown groups!";
                else if (a.Count == 1) label5.Text += "group of\n" + a[0];
                else if (a.Count > 1) label5.Text += "groups of\n" + string.Join(" & ", a);
            }
        }
        private void FindBase(string[] a)
        {
            wasInBase = !wasInBase;
            int n = 10;

            if (a.Length != 0)
            {
                if (a.All(x => Regex.IsMatch(x, @"^[ 01]+$")) && a.All(x => Regex.IsMatch(x, @"^[^xX]+$"))) n = 2;
                else if (a.All(x => Regex.IsMatch(x, @"^[ 0-7]+$")) && a.All(x => Regex.IsMatch(x, @"^[^xX]+$"))) n = 8;
                else if (a.All(x => Regex.IsMatch(x, @"^[0-9,]+$")) && a.All(x => Regex.IsMatch(x, @"^[^xX]+$"))) n = 10;
                else if (a.All(x => Regex.IsMatch(x, @"^[ \\+Uuxa-fA-F0-9]+$"))) n = 16;
            }

            switch (n)
            {
                case 2:
                    binary_Click(octal.Text, new EventArgs());
                    break;
                case 8:
                    octal_Click(octal.Text, new EventArgs());
                    break;
                case 10:
                    decimal_Click(octal.Text, new EventArgs());
                    break;
                case 16:
                    hexadecimal_Click(octal.Text, new EventArgs());
                    break;
            }
        }
        private void UTF(string a, string s)
        {
            if (textBox1.SelectionLength > 14 || (Regex.Matches(textBox1.SelectedText, @"\r\n").Count > 3 && textBox1.SelectionLength > 120)) return;
            string[] utf8 = BitConverter.ToString(Encoding.UTF8.GetBytes(a)).ToUpper().Split("-".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] utf16 = FastCode.Split(BitConverter.ToString(Encoding.BigEndianUnicode.GetBytes(a)).Replace("-", "").ToUpper(), 4, " ").Split(" ".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] utf32 = FastCode.Split(FastCode.ReverseSplit(BitConverter.ToString(Encoding.UTF32.GetBytes(a)).Replace("-", "").ToUpper(), 8, 2), 8, " ").Split(" ".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            switch (n)
            {
                case 2:
                    label6.Text += $"\nUTF-8: {string.Join(s, utf8.Select(x => FastCode.Split(FastCode.EncodeToBase(FastCode.DecodeToBase10(x, 16), n), 4, " ", '0')))}\n" +
                                   $"UTF-16: {string.Join(s, utf16.Select(x => FastCode.Split(FastCode.EncodeToBase(FastCode.DecodeToBase10(x, 16), n), 4, " ", '0')))}\n" +
                                   $"UTF-32: {string.Join(s, utf32.Select(x => FastCode.Split(FastCode.EncodeToBase(FastCode.DecodeToBase10(x, 16), n), 4, " ", '0')))}";
                    break;
                case 8:
                    label6.Text += $"\nUTF-8: {string.Join(s, utf8.Select(x => FastCode.Split(FastCode.EncodeToBase(FastCode.DecodeToBase10(x, 16), n), 3, " ")))}\n" +
                                   $"UTF-16: {string.Join(s, utf16.Select(x => FastCode.Split(FastCode.EncodeToBase(FastCode.DecodeToBase10(x, 16), n), 3, " ")))}\n" +
                                   $"UTF-32: {string.Join(s, utf32.Select(x => FastCode.Split(FastCode.EncodeToBase(FastCode.DecodeToBase10(x, 16), n), 3, " ")))}";
                    break;
                case 10:
                    label6.Text += $"\nUTF-8: {string.Join(s, utf8.Select(x => FastCode.Split(FastCode.EncodeToBase(FastCode.DecodeToBase10(x, 16), n), 3, ",")))}\n" +
                                   $"UTF-16: {string.Join(s, utf16.Select(x => FastCode.Split(FastCode.EncodeToBase(FastCode.DecodeToBase10(x, 16), n), 3, ",")))}\n" +
                                   $"UTF-32: {string.Join(s, utf32.Select(x => FastCode.Split(FastCode.EncodeToBase(FastCode.DecodeToBase10(x, 16), n), 3, ",")))}";
                    break;
                case 16:
                    label6.Text += $"\nUTF-8: 0x{string.Join(" 0x", utf8)}\n" +
                                   $"UTF-16: 0x{string.Join(" 0x", utf16)}\n" +
                                   $"UTF-32: 0x{string.Join(" 0x", utf32)}";
                    break;
            }
        }
        private void Func()
        {
            string a = textBox1.SelectedText;
            m = textBox1.SelectionLength;
            if (!a.All(x => char.IsWhiteSpace(x))) a = string.Concat(a.Where(x => !char.IsWhiteSpace(x)));
            if (a != "" && a.Length != 1 && !clientRequest) FindBase(a.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries).Select(x => string.Concat(x.Where(y => Regex.IsMatch(y.ToString(), @"^[, \\uU+xa-fA-F0-9]+$")))).Where(z => z != "").ToArray());
            string[] s = a.Replace(",", "").Split(new string[] { "\\U", "\\u", "\\x", "U+", "u+", "0x", "-", "+" }, StringSplitOptions.RemoveEmptyEntries);
            
            label5.ResetText();
            label6.ResetText();
            if (m == 1)
            {
                Length1(a[0]);
                int b = int.Parse(Convert.ToString(a[0], 10));
                label6.Text += "Binary: " + FastCode.Split(Convert.ToString(a[0], 2), 4, " ", '0') +
                "\nOctal: " + FastCode.Split(Convert.ToString(a[0], 8), 3, " ") +
                "\nDecimal: " + FastCode.Split(b, 3, ",") +
                "\nHexadecimal: " + Convert.ToString(a[0], 16).ToUpper();
            }
            else if (m > 1)
            {
                label5.Text = "Selected text length is " + m + '\n';
                try
                {
                    if (Regex.IsMatch(a, @"^[a-fA-F0-9,]+$") && Regex.IsMatch(a, @"[^,]+"))
                    {
                        ulong b = Convert.ToUInt64(a.Replace(",", ""), n);
                        Length1((int)b);
                        label6.Text += "Binary: " + FastCode.Split(FastCode.EncodeToBase(b, 2), 4, " ", '0') +
                        "\nOctal: " + FastCode.Split(FastCode.EncodeToBase(b, 8), 3, " ") +
                        "\nDecimal: " + FastCode.Split(b, 3, ",") +
                        "\nHexadecimal: " + FastCode.EncodeToBase(b, 16);
                    }
                    else if (s.Length != 0 && s.All(x => Regex.IsMatch(x, @"^[a-fA-F0-9]+$")) && s.Select(x => Convert.ToInt32(x, n)).All(x => 0 <= x && x <= 0xFFFF))
                    {
                        a = string.Concat(s.Select(x => Convert.ToChar(int.Parse(FastCode.EncodeToBase(FastCode.DecodeToBase10(x, n), 10)))));
                        if (a.Length == 1) Length1(int.Parse(Convert.ToString(a[0], 10)));
                        else label5.Text += a + " => Length: " + a.Length;
                        UTF(a, " - ");
                    }
                    else UTF(a, " - ");
                }
                catch (OverflowException)
                {
                    UTF(a, " - ");
                }
                catch (Exception)
                {
                    wasInBase = true;
                    FindBase(a.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries).Select(x => string.Concat(x.Where(y => Regex.IsMatch(y.ToString(), @"^[, \\uU+xa-fA-F0-9]+$")))).Where(z => z != "").ToArray());
                }
            }
            clientRequest = false;
            wasInBase = false;
            label5.Location = new Point((Width - 17 - label5.Width) / 2, (label6.Location.Y + 364 - label5.Height) / 2);
            label6.Location = new Point((Width - 17 - label6.Width) / 2, label6.Location.Y);
        }
        private void textBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength != 0) Func();
            else if (textBox1.SelectionLength == 0)
            {
                label5.ResetText();
                label6.ResetText();
            }
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 65 || (37 <= e.KeyValue && e.KeyValue <= 40) || textBox1.SelectionLength != 0) Func();
            else if (textBox1.SelectionLength == 0)
            {
                label5.ResetText();
                label6.ResetText();
            }
        }
        #endregion

        #region Double Click
        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            int a = textBox1.GetFirstCharIndexOfCurrentLine();
            textBox1.SelectionStart = a;
            a = textBox1.GetFirstCharIndexFromLine(textBox1.GetLineFromCharIndex(a) + 1);
            textBox1.SelectionLength = (a == -1) ? textBox1.TextLength : Math.Abs(textBox1.SelectionStart - (a - 2));
            Func();
        }
        #endregion

        #region Right Click
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (label5.Focused)
            {
                if (label5.Text.Contains(" => ")) Clipboard.SetText(label5.Text.Substring(label5.Text.IndexOf('\n') + 1, int.Parse(label5.Text.Substring(label5.Text.IndexOf(": ") + 1))));
                else if (!label5.Text.Contains("\n") || label5.Text.Contains("group")) Clipboard.SetText(label5.Text);
                else Clipboard.SetText(label5.Text.Substring(label5.Text.IndexOf('\n') + 1));
            
            }
            else if (label6.Focused) Clipboard.SetText(label6.Text.Replace("\n", "\r\n"));
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectedText.Length > 0) Clipboard.SetText(textBox1.SelectedText);
        }
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (ActiveControl != textBox1) textBox1.Select();
        }
        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            label5.Select(); // ActiveControl = label5;
        }

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            label6.Select(); // ActiveControl = label6;
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0)
            {
                int temp = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Remove(temp, textBox1.SelectionLength);
                textBox1.SelectionStart = temp;
            }
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }
        private void rightToLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.RightToLeft = (textBox1.RightToLeft == RightToLeft.Yes) ? RightToLeft.No : RightToLeft.Yes;
        }
        #endregion

        #region Clear
        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            checkBox1.Checked = false;

            F1_2.textBox1.Clear();
            F1_2.textBox2.Clear();

            for (int i = 0; i < F1_1.checkedListBox1.Items.Count; i++)
            {
                F1_1.checkedListBox1.SetItemCheckState(i, CheckState.Checked);
            }
            F1_1.checkBox1.Checked = true;
            F1_1.checkBox2.Checked = false;

            F2.x_Date_Type.SelectedItem = null;
            F2.Year.Text = "";
            F2.Month.Text = "";
            F2.Day.Text = "";
            F2.y_Date_Type.SelectedItem = null;
            F2.s = "";
            F2.S = "";
        }
        #endregion

        #region Automatic Edit
        private void button1_1_1_Click(object sender, EventArgs e)
        {
            F1_1.ShowDialog();
        }
        #endregion

        #region Automatic
        private void button1_1_Click(object sender, EventArgs e)
        {
            int[,] a = new int[4, 2] { { 32, 41 }, { 42, 67 }, { 42, 67 }, { 0, 31 } };

            if (checkBox1.Checked) textBox1.Clear();
            if (comboBox1.Text == "") comboBox1.Text = "8";
           
            if (F1_1.checkBox2.Checked)
            {
                for (int i = 0; i <= F1_1.checkedListBox1.Items.Count - 1; i++)
                {
                    if (F1_1.checkedListBox1.GetItemChecked(i))
                    {
                        n += a[i, 1] - a[i, 0] + 1;
                    }
                }
            }

            if (int.Parse(comboBox1.Text) > n && n != 0)
            {
                n = 0;
                MessageBox.Show("Sorry, the chosen length is more than we expected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (F1_1.checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Sorry, you didn't checked any of checkboxes!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                F1_1.ShowDialog();
            }
            else
            {
                string s = "";
                while (s.Length < Convert.ToInt32(comboBox1.Text))
                {
                Again:
                    n = R.Next(0, F1_1.checkedListBox1.Items.Count);
                    if (F1_1.checkedListBox1.GetItemChecked(n))
                    {
                        m = R.Next(a[n, 0], a[n, 1] + 1);
                        if (n != 2) s += Data.autoPassword[m];
                        else if (n == 2) s += char.ToUpper(Data.autoPassword[m]);
                    }
                    else goto Again;

                    if (F1_1.checkBox2.Checked) s = new string(s.ToCharArray().Distinct().ToArray());
                }
                n = 0;
                textBox1.Text += s ;
                if (!checkBox1.Checked) textBox1.Text += "\r\n";
            }
        }
        #endregion

        #region Customize
        private void button1_2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) textBox1.Clear();

            int X = 0, Z = 0, V = 0;

            if (F1_2.textBox1.Text == "" && F1_2.textBox2.Text == "" ) F1_2.ShowDialog();
            if (comboBox1.Text == "") comboBox1.Text = Convert.ToString(Math.Ceiling((F1_2.textBox1.TextLength + F1_2.textBox2.TextLength) / 3.0));
            if (F1_2.textBox1.Text != "" || F1_2.textBox2.Text != "")
            {
                for (int i = 1; i <= Convert.ToInt32(comboBox1.Text); i++)
                {
                    n = R.Next(1, 5);
                    if (n == 1)
                    {
                        if (X <= F1_2.textBox1.TextLength - 1)
                        {
                            textBox1.Text += F1_2.textBox1.Text[X];
                            X += 1;
                        }
                    }
                    else if (n == 2)
                    {
                        if (Z <= F1_2.textBox2.TextLength - 1)
                        {
                            textBox1.Text += F1_2.textBox2.Text[Z];
                            Z += 1;
                        }
                    }
                    else if (n == 4)
                    {
                        n = R.Next(0, Data.autoPassword.Length);
                        textBox1.Text += Data.autoPassword[n];
                    }
                }
                if (!checkBox1.Checked) textBox1.Text += "\r\n";
            }
            else MessageBox.Show("Sorry, you didn't enter your information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region English Name Select
        private void button1_3_1_Click(object sender, EventArgs e)
        {
            new Form1_4(false).ShowDialog();
        }
        #endregion

        #region English Name
        private void button1_3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) textBox1.Clear();
            n = R.Next(0, Data.engFirstName.Length);
            m = R.Next(0, Data.engLastName.Length);
            textBox1.Text += Convert.ToString(Data.engFirstName[n]) + " " + Convert.ToString(Data.engLastName[m]);
            if (!checkBox1.Checked) textBox1.Text += "\r\n";
        }
        #endregion

        #region Persian Name Select
        private void button1_4_1_Click(object sender, EventArgs e)
        {
            new Form1_4(true).ShowDialog();
        }
        #endregion

        #region Persian Name
        private void button1_4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) textBox1.Clear();

            if (comboBox2.Text == "") comboBox2.Text = "Boy's Name";


            switch (comboBox2.Text)
            {
                case "Boy's Name":
                    n = R.Next(0, Data.boyPerName.Length);
                    textBox1.Text += Convert.ToString(Data.boyPerName[n]);
                    break;

                case "Girl's Name":
                    n = R.Next(0, Data.girlPerName.Length);
                    textBox1.Text += Convert.ToString(Data.girlPerName[n]);
                    break;
            }
            if (!checkBox1.Checked) textBox1.Text += "\r\n";
        }
        #endregion

        #region Date Convertor
        private void button2_Click(object sender, EventArgs e)
        {
            F2.ShowDialog();
            if (textBox1.Text != "" && F2.s != "" && F2.S != "") textBox1.Text += "\r\n";

            textBox1.Text += F2.s + F2.S;
            F2.s = "";
            F2.S = "";
        }
        #endregion

        #region Changer
        private void button3_Click(object sender, EventArgs e)
        {
            F3.ShowDialog();
        }
        #endregion

        #region Time Calculator
        private void button4_Click(object sender, EventArgs e)
        {
            F4.ShowDialog();
        }
        #endregion

        #region Checker
        private void button5_Click(object sender, EventArgs e)
        {
            F5.ShowDialog();
        }
        #endregion

        #region Cal-Call
        private void button6_Click(object sender, EventArgs e)
        {
            F6.ShowDialog();
        }
        #endregion

        #region Help
        private void aboutUnHope_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UnHope is check and analyze data project.\nMade of Hope in the middle of Hopelessness.\n(:There is Hope in UnHope:)", aboutUnHope.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void aboutDeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form1_5().ShowDialog();
        }
        #endregion

        #region Default Encoding
        private void binary_Click(object sender, EventArgs e)
        {
            clientRequest = true;
            switch (n)
            {
                case 8:
                    octal.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    octal.Checked = false;
                    break;
                case 10:
                    Decimal.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    Decimal.Checked = false;
                    break;
                case 16:
                    hexadecimal.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    hexadecimal.Checked = false;
                    break;
            }
            binary.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            binary.Checked = true;
            n = 2;
            if (!wasInBase && clientRequest) Func();
        }
        private void octal_Click(object sender, EventArgs e)
        {
            clientRequest = true;
            switch (n)
            {
                case 2:
                    binary.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    binary.Checked = false;
                    break;
                case 10:
                    Decimal.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    Decimal.Checked = false;
                    break;
                case 16:
                    hexadecimal.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    hexadecimal.Checked = false;
                    break;
            }
            octal.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            octal.Checked = true;
            n = 8;
            if (!wasInBase && clientRequest) Func();
        }
        private void decimal_Click(object sender, EventArgs e)
        {
            clientRequest = true;
            switch (n)
            {
                case 2:
                    binary.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    binary.Checked = false;
                    break;
                case 8:
                    octal.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    octal.Checked = false;
                    break;
                case 16:
                    hexadecimal.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    hexadecimal.Checked = false;
                    break;
            }
            Decimal.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Decimal.Checked = true;
            n = 10;
            if (!wasInBase && clientRequest) Func();
        }
        private void hexadecimal_Click(object sender, EventArgs e)
        {
            clientRequest = true;
            switch (n)
            {
                case 2:
                    binary.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    binary.Checked = false;
                    break;
                case 8:
                    octal.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    octal.Checked = false;
                    break;
                case 10:
                    Decimal.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    Decimal.Checked = false;
                    break;
            }
            hexadecimal.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hexadecimal.Checked = true;
            n = 16;
            if (!wasInBase && clientRequest) Func();
        }
        #endregion
    }
}