using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using System.Text;
using System.Text.RegularExpressions;
using MoradzadeHelperUtilityLibrary;
using System.Web;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;

namespace UnHope
{
    public partial class Form1 : Form
    {
        Form1_1 f1_1;
        Form1_2 f1_2;
        Form2 f2;
        Form3 f3;
        Form4 f4;
        Form5 f5;
        Form6 f6;
        Form7 f7;

        public Form1(Form1_1 frm1_1, Form1_2 Frm1_2, Form2 Frm2, Form3 Frm3, Form4 Frm4, Form5 Frm5, Form6 Frm6, Form7 Frm7)
        {
            InitializeComponent();
            f1_1 = frm1_1;
            f1_2 = Frm1_2;
            f2 = Frm2;
            f3 = Frm3;
            f4 = Frm4;
            f5 = Frm5;
            f6 = Frm6;
            f7 = Frm7;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= f1_1.checkedListBox1.Items.Count - 1; i++)
            {
                if (i == 3 || i == 5) continue;
                f1_1.checkedListBox1.SetItemChecked(i, true);
            }

            
            openFileDialog1.Filter = "Text Files|*.txt;*.bat;*.cs;*.cpp;*.sql;*.jav;*.py;*.html;*.css;*.js";

            saveFileDialog1.Filter = "Text File|*.txt" +
                                     "|Batch File|*.bat" +
                                     "|C# File|*.cs" +
                                     "|C++ File|*.cpp" +
                                     "|SQL File|*.sql" +
                                     "|Java File|*.jav" +
                                     "|Python File|*.py" +
                                     "|HTML File|*.html" +
                                     "|CSS File|*.css" +
                                     "|JS File|*.js";

            fontDialog1.Font = textBox1DefaultFont = textBox1.Font;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!textBox1.IsNullOrEmpty() || fileName.Visible)
            {
                var r = MessageBox.Show("Do you want to save?",
                                        "Magic is over!, Vanish✨ the form!",
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button3);
                
                if (r == DialogResult.Yes)
                {
                    saveFile_Click(sender, EventArgs.Empty);
                }
                else if (r == DialogResult.Cancel) e.Cancel = true;
            }
        }

        #region Data
        public readonly string[,] passwordCharList = { { "abcdefghijklmnopqrstuvwxyz", "ABCDEFGHIJKLMNOPQRSTUVWXYZ" },
                                                       { "0123456789", "۰۱۲۳۴۵۶۷۸۹٠١٢٣٤٥٦٧٨٩" },
                                                       { "!\"#$%&\'()*+,-./:;<=>?@[\\]^_`{|}~", "¡£¤¥°¿÷٪•₩€■□▪◇○●☆♡♤♧《》" }
                                                     };
        int encryptionBase = 10, m;
        #endregion

        #region Length Label
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "Length: " + textBox1.TextLength;
            label2.Location = new Point(label1.Location.X + label1.Size.Width + 4, 257);
            label2.Text = "Spaces: " + textBox1.Text.Count(x => x == ' ');
            label3.Location = new Point(label2.Location.X + label2.Size.Width + 4, 257);
            label3.Text = "Lines: " + textBox1.Lines.Length;
            label4.Location = new Point(label3.Location.X + label3.Size.Width + 4, 257);
            label4.Text = "Enters: " + Regex.Matches(textBox1.Text, @"\r\n").Count;
        }
        #endregion

        #region Char Group Label
        bool clientRequest = false;
        bool wasInBase = false;
        private void Length1(object b)
        {
            char c;
            if (typeof(ulong) == b.GetType())
            {
                ulong ulongb = (ulong)b;
                if (0xD800 <= ulongb && ulongb <= 0xDFFF)
                {
                    c = Convert.ToChar(ulongb);
                    List<string> a = FastCode.CharGroupBy(c);
                    label5.Text += c + "\n";
                    if (a.Count == 0) label5.Text += "unknown group!";
                    else if (a.Count >= 1) label5.Text += string.Join(" & ", a);
                }
                else if (0 <= ulongb && ulongb <= 0x10FFFF)
                {
                    if (char.ConvertFromUtf32(Convert.ToInt32(b)).Length == 1)
                    {
                        c = char.ConvertFromUtf32(Convert.ToInt32(b))[0];
                        List<string> a = FastCode.CharGroupBy(c);
                        label5.Text += c + "\n";
                        if (a.Count == 0) label5.Text += "unknown group!";
                        else if (a.Count >= 1) label5.Text += string.Join(" & ", a);
                    }
                    else
                    {
                        string a = char.ConvertFromUtf32(Convert.ToInt32(b));
                        label5.Text += a + " => Length: " + a.Length;
                        UTF(a, " - ");
                        return;
                    }
                }
                else label5.Text += "Code is out of range of 0x0 ~ 0x10FFFF!";
                MultiBaseNumber tmp = new MultiBaseNumber(b, 10);
                label6.Text += "Binary: " + FastCode.Split(new MultiBaseNumber(tmp, 2), 4, " ", '0') +
                "\nOctal: " + FastCode.Split(new MultiBaseNumber(tmp, 8), 3, " ") +
                "\nDecimal: " + FastCode.Split(tmp.DecodedNumber, 3, ",") +
                "\nHexadecimal: " + new MultiBaseNumber(tmp, 16);
            }
            else
            {
                c = (char)b;
                label5.Text += c + "\n";
                List<string> a = FastCode.CharGroupBy(c);
                if (a.Count == 0) label5.Text += "unknown group!";
                else if (a.Count >= 1) label5.Text +=  string.Join(" & ", a);
                label6.Text += "Binary: " + FastCode.Split(Convert.ToString(c, 2), 4, " ", '0') +
                    "\nOctal: " + FastCode.Split(Convert.ToString(c, 8), 3, " ") +
                    "\nDecimal: " + FastCode.Split(Convert.ToString(c, 10), 3, ",") +
                    "\nHexadecimal: " + Convert.ToString(c, 16).ToUpper();
            }
        }
        private void FindBase(string[] a)
        {
            wasInBase = !wasInBase;

            int selectedEncodingBase = 10;

            if (a.Length != 0)
            {
                if (a.All(x => Regex.IsMatch(x, @"^[ 01]+$")) && a.All(x => Regex.IsMatch(x, @"^[^xX]+$"))) selectedEncodingBase = 2;
                else if (a.All(x => Regex.IsMatch(x, @"^[ 0-7]+$")) && a.All(x => Regex.IsMatch(x, @"^[^xX]+$"))) selectedEncodingBase = 8;
                else if (a.All(x => Regex.IsMatch(x, @"^[0-9,]+$")) && a.All(x => Regex.IsMatch(x, @"^[^xX]+$"))) selectedEncodingBase = 10;
                else if (a.All(x => Regex.IsMatch(x, @"^[ \\+Uuxa-fA-F0-9]+$"))) selectedEncodingBase = 16;
            }

            selectedEncodingBase = (int)Math.Ceiling(selectedEncodingBase / 4.0) - 1;
            defaultEncoding.DropDownItems[selectedEncodingBase].PerformClick();
        }
        private void UTF(string a, string s)
        {
            if (textBox1.SelectionLength > 120 || (Regex.Matches(textBox1.SelectedText, @"\r\n").Count >1 && textBox1.SelectionLength > 14)) return;
            string[] utf8 = BitConverter.ToString(Encoding.UTF8.GetBytes(a)).ToUpper().Split("-".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] utf16 = FastCode.Split(BitConverter.ToString(Encoding.BigEndianUnicode.GetBytes(a)).Replace("-", "").ToUpper(), 4, " ").Split(" ".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] utf32 = FastCode.Split(FastCode.ReverseSplit(BitConverter.ToString(Encoding.UTF32.GetBytes(a)).Replace("-", "").ToUpper(), 8, 2), 8, " ").Split(" ".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            switch (encryptionBase)
            {
                case 2:
                    label6.Text += $"\nUTF-8: {string.Join(s, utf8.Select(x => FastCode.Split(new MultiBaseNumber(new MultiBaseNumber(x, 16), encryptionBase), 4, " ", '0')))}\n" +
                                   $"UTF-16: {string.Join(s, utf16.Select(x => FastCode.Split(new MultiBaseNumber(new MultiBaseNumber(x, 16), encryptionBase), 4, " ", '0')))}\n" +
                                   $"UTF-32: {string.Join(s, utf32.Select(x => FastCode.Split(new MultiBaseNumber(new MultiBaseNumber(x, 16), encryptionBase), 4, " ", '0')))}";
                    break;
                case 8:
                    label6.Text += $"\nUTF-8: {string.Join(s, utf8.Select(x => FastCode.Split(new MultiBaseNumber(new MultiBaseNumber(x, 16), encryptionBase), 3, " ")))}\n" +
                                   $"UTF-16: {string.Join(s, utf16.Select(x => FastCode.Split(new MultiBaseNumber(new MultiBaseNumber(x, 16), encryptionBase), 3, " ")))}\n" +
                                   $"UTF-32: {string.Join(s, utf32.Select(x => FastCode.Split(new MultiBaseNumber(new MultiBaseNumber(x, 16), encryptionBase), 3, " ")))}";
                    break;
                case 10:
                    label6.Text += $"\nUTF-8: {string.Join(s, utf8.Select(x => FastCode.Split(new MultiBaseNumber(new MultiBaseNumber(x, 16), encryptionBase), 3, ",")))}\n" +
                                   $"UTF-16: {string.Join(s, utf16.Select(x => FastCode.Split(new MultiBaseNumber(new MultiBaseNumber(x, 16), encryptionBase), 3, ",")))}\n" +
                                   $"UTF-32: {string.Join(s, utf32.Select(x => FastCode.Split(new MultiBaseNumber(new MultiBaseNumber(x, 16), encryptionBase), 3, ",")))}";
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
            if (a.All(x => char.IsWhiteSpace(x))) a = string.Concat(a.Where(x => !char.IsWhiteSpace(x)));
            if (a != "" && a.Length != 1 && !clientRequest) FindBase(a.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries).Select(x => string.Concat(x.Where(y => Regex.IsMatch(y.ToString(), @"^[, \\uU+xa-fA-F0-9]+$")))).Where(z => z != "").ToArray());
            string[] s = a.Replace(",", "").Split(new string[] { "\\U", "\\u", "\\x", "U+", "u+", "0x", "-", "+" }, StringSplitOptions.RemoveEmptyEntries);
            
            label5.ResetText();
            label6.ResetText();
            if (m == 1)
            {
                Length1(a[0]);
            }
            else if (m > 1)
            {
                label5.Text = "Selected text length is " + m + '\n';
                try
                {
                    if (Regex.IsMatch(a, @"^[a-fA-F0-9,]+$") && Regex.IsMatch(a, @"[^,]+"))
                    {
                        ulong b = Convert.ToUInt64(a.Replace(",", ""), encryptionBase);
                        Length1(b);
                    }
                    else if (s.Length == 1 && s.All(x => Regex.IsMatch(x, @"^[a-fA-F0-9]+$")))
                    {
                        ulong b = Convert.ToUInt64(s[0].Replace(",", ""), encryptionBase);
                        Length1(b);
                    }
                    else if (s.Length > 1 && s.All(x => Regex.IsMatch(x, @"^[a-fA-F0-9]+$")) && s.Select(x => Convert.ToInt32(x, encryptionBase)).All(x => 0 <= x && x <= 0xFFFF))
                    {
                        a = string.Concat(s.Select(x => Convert.ToChar(new MultiBaseNumber(x, encryptionBase).DecodedNumber)));
                        label5.Text += a + " => Length: " + a.Length;
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
            bool backword = false;
            Again:
            for (int i = backword ? textBox1.Text.IndexOf(textBox1.SelectedText) : textBox1.Text.IndexOf(textBox1.SelectedText) + textBox1.SelectionLength-1; 0<=i&& i <= textBox1.TextLength-1 && !new char[] { '\r', '\n' }.Contains(textBox1.Text[i]); i += backword ? -1 : 1)
            {
                encryptionBase = i;
            }
            if (!backword)
            {
                m = encryptionBase;
                backword = true;
                goto Again;
            }
            textBox1.SelectionStart = encryptionBase;
            textBox1.SelectionLength = m - encryptionBase + 1;
            encryptionBase = 10;
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

        private void undoToolStripMenuItem_Click(object sender, EventArgs e) => textBox1.Undo();
     
        private void cutToolStripMenuItem_Click(object sender, EventArgs e) => textBox1.Cut();

        private void copyToolStripMenuItem_Click(object sender, EventArgs e) => textBox1.Copy();

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox1.SelectionLength > 0)
            {
                if (!textBox1.SelectedText.All(x => !char.IsDigit(x))) fixNumberFormatToolStripMenu.Visible = true;
                if (textBox1.SelectionLength == 2 || textBox1.SelectedText.Contains(',')) getCharacterRangeToolStripMenuItem.Visible = true;
                replaceSelectedText.Visible = true;
            }
            else
            {
                fixNumberFormatToolStripMenu.Visible = false;
                getCharacterRangeToolStripMenuItem.Visible = false;
                replaceSelectedText.Visible = false;
            }
        }

        private void label5_MouseDown(object sender, MouseEventArgs e) => label5.Select();
      
        private void label6_MouseDown(object sender, MouseEventArgs e) => label6.Select();
      
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) => textBox1.Paste();

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0)
            {
                int temp = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Remove(temp, textBox1.SelectionLength);
                textBox1.SelectionStart = temp;
            }
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) => textBox1.SelectAll();
      
        private void rightToLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.RightToLeft == RightToLeft.Yes)
            {
                textBox1.RightToLeft = RightToLeft.No;
                contextMenuStrip1.RightToLeft = RightToLeft.No;
                rightToLeft.Checked = false;
            }
            else
            {
                textBox1.RightToLeft = RightToLeft.Yes;
                contextMenuStrip1.RightToLeft = RightToLeft.No;
                rightToLeft.Checked = true;
            }
        }
        private void fixNumberFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = FastCode.NumberFormatFixer(textBox1.SelectedText);
        }
        private void ReplaceToolStripMenu_Click(object sender, EventArgs e)
        {
            bool isReplaceSelected = replace.Pressed, isReplaceSelectedTextSelected = replaceSelectedText.Pressed;
            Form1_3 f1_3 = new Form1_3();
            f1_3.F1x = DesktopLocation.X;
            f1_3.f1y = DesktopLocation.Y;
            f1_3.F1_Width = Width;
            f1_3.F1_Height = Height;
            if (isReplaceSelected) f1_3.s = textBox1.SelectedText;
            f1_3.ShowDialog();

            List<string> b = new List<string>(f1_3.Controls.OfType<TextBox>().Select(x => x.Text));
            if (f1_3.checkBox1.Checked)
            {
                string[,] a = new string[,] { { "\\a", "\a" }, { "\\b", "\b" }, { "\\f", "\f" }, { "\\n", "\n" }, { "\\r", "\r" }, { "\\t", "\t" }, { "\\v", "\v" } };
                for (int i = 0; i < b.Count(); i++)
                {
                    for (int j = 0; j < a.Length / 2; j++)
                    {
                        b[i] = b[i].Replace(a[j, 0], a[j, 1]);
                    }
                }
            }
            if (isReplaceSelectedTextSelected) textBox1.SelectedText = FastCode.Replace(textBox1.SelectedText, b.Where((x, i) => i % 2 != 0).ToArray(), b.Where((x, i) => i % 2 == 0).ToArray());
            else textBox1.Text = FastCode.Replace(textBox1.Text, b.Where((x, i) => i % 2 != 0).ToArray(), b.Where((x, i) => i % 2 == 0).ToArray());
        }
        private void getCharacterRange(object sender, EventArgs e)
        {
            textBox1.SelectedText = Unicode.GetRange.UTF16(textBox1.SelectedText[0], textBox1.SelectedText[1]);
            textBox1.SelectionStart = textBox1.TextLength;
        }
        private void addEachLineAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1_6 f1_6 = new Form1_6();
            f1_6.ShowDialog();
            textBox1.Lines = textBox1.Lines.Select(x => x + f1_6.textBox1.Text).ToArray();
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }

        #region Sort
        private void ascendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0) textBox1.SelectedText = string.Concat(textBox1.SelectedText.OrderBy(x => x));
            else textBox1.Lines = textBox1.Lines.OrderBy(x => x).ToArray();
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }

        private void descendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0) textBox1.SelectedText = string.Concat(textBox1.SelectedText.OrderByDescending(x => x));
            else textBox1.Lines = textBox1.Lines.OrderByDescending(x => x).ToArray();
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }
        #endregion

        #region Reverse
        private void reverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0) textBox1.SelectedText = string.Concat(textBox1.SelectedText.Reverse());
            else textBox1.Lines = textBox1.Lines.Reverse().ToArray();
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }
        #endregion

        #region Distinct
        private void distinctToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0) textBox1.SelectedText = string.Concat(textBox1.SelectedText.Distinct());
            else textBox1.Lines = textBox1.Lines.Distinct().ToArray();
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }
        #endregion

        #region ClipboardWatchDog
        private void ClipboardWatchDog_Click(object sender, EventArgs e)
        {
            clipboardWatchDog.Checked = !clipboardWatchDog.Checked;
            timer1.Enabled = !timer1.Enabled;
            clipboardWatchDog.Text = clipboardWatchDog.Checked ? "Deactivate Clipboard WatchDog" : "Activate Clipboard WatchDog";
            Clipboard.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TextDataFormat format = TextDataFormat.UnicodeText;
            try
            {
                string clipboardText = Clipboard.GetText(format);
                if (!string.IsNullOrEmpty(clipboardText))
                {
                    textBox1.Text += clipboardText + "\r\n";
                    textBox1.SelectionStart = textBox1.TextLength;
                    textBox1.ScrollToCaret();
                    Clipboard.Clear();
                }
            }
            catch (Exception)
            {
            }

        }
        #endregion

        #endregion

        #region Clear
        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedItem = null;
            checkBox1.Checked = false;

            f1_2.textBox1.Clear();
            f1_2.textBox2.Clear();

            for (int i = 0; i < f1_1.checkedListBox1.Items.Count; i++)
            {
                f1_1.checkedListBox1.SetItemCheckState(i, CheckState.Checked);
            }
            f1_1.checkBox1.Checked = true;
            f1_1.distinctCheckBox.Checked = false;

            f2.x_Date_Type.SelectedItem = null;
            f2.Year.Text = "";
            f2.Month.Text = "";
            f2.Day.Text = "";
            f2.y_Date_Type.SelectedItem = null;
            f2.s = "";
            f2.S = "";
        }
        #endregion

        #region Automatic Edit
        private void button1_1_1_Click(object sender, EventArgs e)
        {
            f1_1.ShowDialog();
        }
        #endregion

        #region Automatic
        private void button1_1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) textBox1.Clear();
            if (comboBox1.Text == "") comboBox1.Text = "8";

            int passwordCount = int.Parse(comboBox1.Text);

            if (f1_1.distinctCheckBox.Checked && passwordCount > 140)
            {
                MessageBox.Show("Sorry, the chosen length is more than we expected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (f1_1.checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Sorry, you didn't checked any of checkboxes!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                f1_1.ShowDialog();
            }
            else
            {
                Random random = new Random();
                string password = "";
                int generatedNum, previousNum = -1;

                while (password.Length < passwordCount)
                {
                    generatedNum = random.Next(f1_1.checkedListBox1.Items.Count);
                    if (f1_1.checkedListBox1.GetItemChecked(generatedNum) && (previousNum != generatedNum / 2 || f1_1.checkedListBox1.CheckedIndices.Cast<int>().GroupBy(x => x / 2).Count() < 2)) 
                    {
                        int catagoryNumber = generatedNum / 2;

                        string samplePass = passwordCharList[catagoryNumber, generatedNum % 2];
                        char passsCharGen = samplePass[random.Next(samplePass.Length)];
                        
                        if (!(f1_1.distinctCheckBox.Checked && password.Contains(passsCharGen)))
                        {
                            password += passsCharGen;
                            previousNum = catagoryNumber;
                        }
                    }
                }
                encryptionBase = 0;

                if (!(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox1.Lines.Last())))
                {
                    textBox1.Text += "\r\n";
                }

                textBox1.Text += password;
            }
        }
        #endregion

        #region Customize
        private void button1_2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) textBox1.Clear();

            if (f1_2.textBox1.Text == "" && f1_2.textBox2.Text == "" ) f1_2.ShowDialog();
            if (comboBox1.Text == "") comboBox1.Text = Convert.ToString(Math.Ceiling((f1_2.textBox1.TextLength + f1_2.textBox2.TextLength) / 3.0));
            if (f1_2.textBox1.Text != "" || f1_2.textBox2.Text != "")
            {

                for (int i = 1; i <= Convert.ToInt32(comboBox1.Text); i++)
                {
                    
                }
                if (!checkBox1.Checked) textBox1.Text += "\r\n";
            }
            else MessageBox.Show("Sorry, you didn't enter your information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region English Name Select
        private void button1_3_1_Click(object sender, EventArgs e)
        {
            new Form1_4().ShowDialog();
        }
        #endregion

        #region English Name
        private void button1_3_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            if (checkBox1.Checked) textBox1.Clear();
            encryptionBase = random.Next(Data.engFirstName.Length);
            m = random.Next(Data.engLastName.Length);
            textBox1.Text += Convert.ToString(Data.engFirstName[encryptionBase]) + " " + Convert.ToString(Data.engLastName[m]);
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

            Random random = new Random();
            switch (comboBox2.Text)
            {
                case "Boy's Name":
                    encryptionBase = random.Next(Data.boyPerName.Length);
                    textBox1.Text += Convert.ToString(Data.boyPerName[encryptionBase]);
                    break;

                case "Girl's Name":
                    encryptionBase = random.Next(Data.girlPerName.Length);
                    textBox1.Text += Convert.ToString(Data.girlPerName[encryptionBase]);
                    break;
            }
            if (!checkBox1.Checked) textBox1.Text += "\r\n";
        }
        #endregion

        #region Date Convertor
        private void button2_Click(object sender, EventArgs e)
        {
            f2.ShowDialog();
            if (textBox1.Text != "" && f2.s != "" && f2.S != "") textBox1.Text += "\r\n";

            textBox1.Text += f2.s + f2.S;
            f2.s = "";
            f2.S = "";
        }
        #endregion

        #region Changer
        private void button3_Click(object sender, EventArgs e)
        {
            f3.ShowDialog();
        }
        #endregion

        #region Time Calculator
        private void button4_Click(object sender, EventArgs e)
        {
            f4.ShowDialog();
        }
        #endregion

        #region Checker
        private void button5_Click(object sender, EventArgs e)
        {
            f5.ShowDialog();
        }
        #endregion

        #region Cal-Call
        private void button6_Click(object sender, EventArgs e)
        {
            f6.ShowDialog();
        }
        #endregion

        #region Auto Code
        private void button9_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.ShowDialog();
        }
        #endregion

        #region RGB
        private void button7_Click(object sender, EventArgs e)
        {
            f7.F1_x = DesktopLocation.X;
            f7.F1_y = DesktopLocation.Y;
            f7.F1_Width = Width;
            f7.F1_Height = Height;
            f7.ShowDialog();
        }
        #endregion

        #region Win Sounds
        private void button8_Click(object sender, EventArgs e)
        {
            new Form8().ShowDialog();
        }
        #endregion

        #region Tab

        #region File

        #region Open
        private async void openFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader streamReader = new StreamReader(openFileDialog1.FileName))
                {
                    if (textBox1.IsNullOrEmpty()) textBox1.Text += await streamReader.ReadToEndAsync();
                    else
                    {
                        var r = MessageBox.Show("Overwrite text file over your text?",
                                      "Text Mix-Up! 😵‍💫",
                                      MessageBoxButtons.YesNoCancel,
                                      MessageBoxIcon.Exclamation,
                                      MessageBoxDefaultButton.Button2);

                        if (r == DialogResult.Cancel) return;
                        else if (r == DialogResult.Yes) textBox1.Text = await streamReader.ReadToEndAsync();
                        else if (r == DialogResult.No) textBox1.Text += await streamReader.ReadToEndAsync();
                    }
                }
                textBox1.SelectionStart = textBox1.TextLength;
                textBox1.ScrollToCaret();

                if (!openFileDialog1.ReadOnlyChecked) fileName.Text = "File Name: " + openFileDialog1.SafeFileName;
            }
        }
        #endregion

        #region Save
        private async void saveFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(openFileDialog1.FileName)) saveAsFile_Click(sender, e);

            else
            {
                using (StreamWriter streamWriter = new StreamWriter(openFileDialog1.FileName))
                {
                    await streamWriter.WriteLineAsync(textBox1.Text);
                }
            }
        }
        #endregion

        #region Save as
        private async void saveAsFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName))
                {
                    await streamWriter.WriteLineAsync(textBox1.Text);
                    fileName.Text = "File Name: " + Path.GetFileName(saveFileDialog1.FileName);
                }
            }
        }

        #endregion

        #region Close
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                Close();
            }
            else
            {
                openFileDialog1.FileName = "";

                fileName.Text = openFileDialog1.SafeFileName;
            }
        }
        #endregion

        #endregion

        #region Edit

        #region Default Font

        Font textBox1DefaultFont;
        private void defaultFont_Click(object sender, EventArgs e)
        {
            textBox1.Font = textBox1DefaultFont;
        }
        #endregion

        #region Change Font
        private void changeFont_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBox1.Font = fontDialog1.Font;
        }
        #endregion

        #endregion

        #region Default Encoding
        void SetDefaultEncodingFontRegularUnchecked(int encryptionBase)
        {
            encryptionBase = (int)Math.Ceiling(encryptionBase / 4.0) - 1;

            var defaultEncodingItem = defaultEncoding.DropDownItems[encryptionBase];
            defaultEncodingItem.Font = new Font(defaultEncodingItem.Font, FontStyle.Regular);
            ((ToolStripMenuItem)defaultEncodingItem).Checked = false;
        }


        private void binary_Click(object sender, EventArgs e)
        {
            clientRequest = true;

            SetDefaultEncodingFontRegularUnchecked(encryptionBase);

            binary.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            binary.Checked = true;

            encryptionBase = 2;
            if (!wasInBase && clientRequest) Func();
        }
        private void octal_Click(object sender, EventArgs e)
        {
            clientRequest = true;

            SetDefaultEncodingFontRegularUnchecked(encryptionBase);

            octal.Font = new Font(octal.Font, FontStyle.Bold);
            octal.Checked = true;

            encryptionBase = 8;
            if (!wasInBase && clientRequest) Func();
        }
        private void decimal_Click(object sender, EventArgs e)
        {
            clientRequest = true;

            SetDefaultEncodingFontRegularUnchecked(encryptionBase);

            Decimal.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Decimal.Checked = true;

            encryptionBase = 10;
            if (!wasInBase && clientRequest) Func();
        }
        private void hexadecimal_Click(object sender, EventArgs e)
        {
            clientRequest = true;

            SetDefaultEncodingFontRegularUnchecked(encryptionBase);

            hexadecimal.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hexadecimal.Checked = true;

            encryptionBase = 16;
            if (!wasInBase && clientRequest) Func();
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

        #region File Address
        private void fileName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fileName.Text)) fileName.Visible = false;
            else fileName.Visible = true;
        }
        #endregion

        #endregion

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = textBox1.Text.Replace("\r\n", "\a");
            switch (toolStripComboBox1.SelectedIndex)
            {
                case 0:
                    s = string.Concat(s.Where(x => x < 127));
                    break;
                case 2:
                    s = string.Concat(s.Where(x => char.IsLetter(x)));
                    break;
            }
            textBox1.Text = s.Replace("\a", "\r\n");
            toolStripComboBox1_TextChanged(sender, e);
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Choose Filter";
        }
    }
}