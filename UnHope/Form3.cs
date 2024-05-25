using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using MoradzadeHelperUtilityLibrary;

namespace UnHope
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        #region Data
        public char[] Eng = new char[60];// { 'C','H','a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ',', ';', '\'', ']', '[', '\\', '?' };
        char[] Per = new char[60];// { 'ژ','آ','ش', 'ذ', 'ز', 'ی', 'ث', 'ب', 'ل', 'ا', 'ه', 'ت', 'ن', 'م', 'ئ', 'د', 'خ', 'ح', 'ض', 'ق', 'س', 'ف', 'ع', 'ر', 'ص', 'ط', 'غ', 'ظ', 'و', 'ک', 'گ', 'چ', 'ج', 'پ', '?' };
        string FirstInput = "sghlو hdk[h ldj,hkdn fvu;s fk,dsdn , kjd[i a v, ffdkdn آهو غخع زشد فغحث قثرثقسث & سثث فاث قثسعمف", FirstOutput = "سلام, اینجا میتوانید برعکس بنویسید و نتیجه ش رو ببینید Hi, you can type reverse & see the result";
        #endregion

        #region Function
        private void Text_Convertor()
        {
            Output.Text = "";

            #region Typographical Text
            if (comboBox1.Text == "Typographical Text")
            {
                string txt = Input.Text;
                int index_num;

                for (int i = 0; i <= txt.Length - 1; i++)
                {
                    if (Eng.Contains(txt[i]))
                    {
                        index_num = Array.IndexOf(Eng, txt[i]);
                        Output.Text += Per[index_num];
                    }
                    else if (Per.Contains(txt[i]))
                    {
                        index_num = Array.IndexOf(Per, txt[i]);
                        Output.Text += Eng[index_num];
                    }
                    else
                    {
                        Output.Text += txt[i];
                    }
                }
                if (Output.Text.Contains("`"))
                {
                    Output.Text = Output.Text.Replace("`", "پ");
                }
            }
            #endregion

            #region Binary Code
            else if (comboBox1.Text == "Binary Code") Output.Text = string.Join(" - ", Input.Text.Select(x => FastCode.Split(new MultiBaseNumber(Convert.ToInt32(x), 2), 4, " ", '0')));
            #endregion

            #region Octal Code
            else if (comboBox1.Text == "Octal Code") Output.Text = string.Join(" - ", Input.Text.Select(x => FastCode.Split(new MultiBaseNumber(Convert.ToInt32(x), 8), 3, " ")));
            #endregion

            #region Decimal Code
            else if (comboBox1.Text == "Decimal Code") Output.Text = string.Join(" - ", Input.Text.Select(x => FastCode.Split(Convert.ToInt32(x), 3, ",")));
            #endregion

            #region Hexadecimal Code
            else if (comboBox1.Text == "Hexadecimal Code") Output.Text = "0x" + string.Join(" 0x", Input.Text.Select(x => FastCode.Split(new MultiBaseNumber(Convert.ToInt32(x), 16), 8, " 0x")));
            #endregion

            #region UTF-8 (Hex)
            else if (comboBox1.Text == "UTF-8 (Hex)") Output.Text = "0x" + BitConverter.ToString(Encoding.UTF8.GetBytes(Input.Text)).ToUpper().Replace("-", " 0x");
            #endregion

            #region UTF-16 (Hex)
            else if (comboBox1.Text == "UTF-16 (Hex)") Output.Text = "0x" + FastCode.Split(BitConverter.ToString(Encoding.BigEndianUnicode.GetBytes(Input.Text)).Replace("-", "").ToUpper(), 4, " 0x");
            #endregion

            #region UTF-32 (Hex)
            else if (comboBox1.Text == "UTF-32 (Hex)") Output.Text = "0x" + FastCode.Split(FastCode.ReverseSplit(BitConverter.ToString(Encoding.UTF32.GetBytes(Input.Text)).Replace("-", "").ToUpper(), 8, 2), 8, " 0x");
            #endregion

            #region Morse Code
            else if (comboBox1.Text == "Morse Code") Output.Text = FastCode.MorseCode(Input.Text);
            #endregion

            #region Normal Text
            else if (comboBox1.Text == "Normal Text") Output.Text = string.Concat(FastCode.ConvertStringToArray(Input.Text, new string[] { " ", "\r", "\n", "\r\n", "\n\r" }).Select(x => char.ToUpper(x[0]) + x.Substring(1).ToLower())).Replace('ی', 'ي');
            #endregion

            #region Pascal Case
            else if (comboBox1.Text == "Pascal Case") Output.Text = string.Concat(FastCode.ConvertStringToArray(Input.Text, new string[] { " ", ".", "-", "_", "\r", "\n", "\r\n", "\n\r" }).Select(x => x == "." || x == "-" || x == "_" ? " " : x).Select(x => char.ToUpper(x[0]) + x.Substring(1).ToLower()));
            #endregion

            #region Uppercase
            else if (comboBox1.Text == "Uppercase") Output.Text = Input.Text.ToUpper();
            #endregion

            #region Lowercase
            else if (comboBox1.Text == "Lowercase") Output.Text = Input.Text.ToLower();
            #endregion

            #region Oppositecase Upper-Lowercase
            else if (comboBox1.Text == "Oppositecase Upper-Lowercase") Output.Text = string.Concat(Input.Text.Select(x => char.IsUpper(x) ? x.ToString().ToLower() : x.ToString().ToUpper()));
            #endregion

            #region One By One Upper-Lowercase
            else if (comboBox1.Text == "One By One Upper-Lowercase")
            {
                bool b = true;
                foreach (char c in Input.Text)
                {
                    if (char.IsLetter(c))
                    {
                        if (b) Output.Text += char.ToUpper(c);
                        else Output.Text += char.ToLower(c);
                        b = !b;
                        continue;
                    }
                    Output.Text += c;
                }
            }
            #endregion

            #region Reverse All
            else if (comboBox1.Text == "Reverse All") Output.Text = string.Concat(Input.Text.Replace("\r\n", "\n\r").Reverse());
            #endregion

            #region Reverse Words
            else if (comboBox1.Text == "Reverse Words") Output.Text = string.Concat(FastCode.ConvertStringToArray(Input.Text, new string[] { " ", "-", "\r", "\n", "\r\n", "\n\r" }).Reverse());
            #endregion

            #region Remove Gaps
            else if (comboBox1.Text == "Remove Gaps") Output.Text = String.Concat(Input.Text.Where(x => !char.IsWhiteSpace(x)));
            #endregion
        }
        #endregion

        #region Text Changer
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Text_Convertor();
        }
        #endregion

        #region Button
        private void button_Paste(object sender, EventArgs e)
        {
            if (Input.Text == FirstInput) Input.Clear();
            Input.Paste();
        }
        private void button_Copy(object sender, EventArgs e)
        {
            if (Output.Text != FirstOutput)
            {
                Clipboard.SetText(Output.Text.Replace("\n", "\r\n"));
            }
        }
        private void button_Clear(object sender, EventArgs e)
        {
            Input.Clear();
        }
        #endregion

        #region Right Click of Input
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Input.SelectedText.Length > 0)
            {
                Clipboard.SetText(Input.SelectedText.Replace("\n", "\r\n"));
            }
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Input.Text == FirstInput) Input.Clear();
            Input.Paste();
        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Input.SelectionLength > 0)
            {
                int temp = Input.SelectionStart;
                Input.Text = Input.Text.Remove(temp, Input.SelectionLength);
                Input.SelectionStart = temp;
            }
        }
        #endregion

        #region Right Click of Output
        private void copytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Output.SelectedText.Length > 0)
            {
                Clipboard.SetText(Output.SelectedText.Replace("\n", "\r\n"));
            }
            else if (Output.Text != FirstOutput)
            {
                Clipboard.SetText(Output.Text.Replace("\n", "\r\n"));
            }
        }
        #endregion

        #region Double Click TextBox
        private void InputOutput_DoubleClick(object sender, EventArgs e)
        {
            if (Input.Focused)
            {
                Input.SelectAll();
            }
            else if (Output.Focused)
            {
                Output.SelectAll();
            }
        }
        #endregion

        private void Form3_Load(object sender, EventArgs e)
        {
            Eng[0] = 'a';
            Eng[1] = 'b';
            Eng[2] = 'c';
            Eng[3] = 'd';
            Eng[4] = 'e';
            Eng[5] = 'f';
            Eng[6] = 'g';
            Eng[7] = 'h';
            Eng[8] = 'i';
            Eng[9] = 'j';
            Eng[10] = 'k';
            Eng[11] = 'l';
            Eng[12] = 'm';
            Eng[13] = 'n';
            Eng[14] = 'o';
            Eng[15] = 'p';
            Eng[16] = 'q';
            Eng[17] = 'r';
            Eng[18] = 's';
            Eng[19] = 't';
            Eng[20] = 'u';
            Eng[21] = 'v';
            Eng[22] = 'w';
            Eng[23] = 'x';
            Eng[24] = 'y';
            Eng[25] = 'z';
            //////////////
            Eng[26] = 'A';
            Eng[27] = 'B';
            Eng[28] = 'C';
            Eng[29] = 'D';
            Eng[30] = 'E';
            Eng[31] = 'F';
            Eng[32] = 'G';
            Eng[33] = 'H';
            Eng[34] = 'I';
            Eng[35] = 'J';
            Eng[36] = 'K';
            Eng[37] = 'L';
            Eng[38] = 'M';
            Eng[39] = 'N';
            Eng[40] = 'O';
            Eng[41] = 'P';
            Eng[42] = 'Q';
            Eng[43] = 'R';
            Eng[44] = 'S';
            Eng[45] = 'T';
            Eng[46] = 'U';
            Eng[47] = 'V';
            Eng[48] = 'W';
            Eng[49] = 'X';
            Eng[50] = 'Y';
            Eng[51] = 'Z';
            //////////////
            Eng[52] = ',';
            Eng[53] = (char)59;
            Eng[54] = '\'';
            Eng[55] = ']';
            Eng[56] = '[';
            Eng[57] = '\\';
            Eng[58] = '`';
            Eng[59] = '?';


            Per[0] = 'ش';
            Per[1] = 'ذ';
            Per[2] = 'ز';
            Per[3] = 'ی';
            Per[4] = 'ث';
            Per[5] = 'ب';
            Per[6] = 'ل';
            Per[7] = 'ا';
            Per[8] = 'ه';
            Per[9] = 'ت';
            Per[10] = 'ن';
            Per[11] = 'م';
            Per[12] = 'ئ';
            Per[13] = 'د';
            Per[14] = 'خ';
            Per[15] = 'ح';
            Per[16] = 'ض';
            Per[17] = 'ق';
            Per[18] = 'س';
            Per[19] = 'ف';
            Per[20] = 'ع';
            Per[21] = 'ر';
            Per[22] = 'ص';
            Per[23] = 'ط';
            Per[24] = 'غ';
            Per[25] = 'ظ';
            //////////////
            Per[26] = (char)1614;
            Per[27] = (char)1573;
            Per[28] = 'ژ';
            Per[29] = (char)1616;
            Per[30] = (char)1613;
            Per[31] = (char)1617;
            Per[32] = (char)1728;
            Per[33] = (char)1570;
            Per[34] = ']';
            Per[35] = (char)1600;
            Per[36] = '«';
            Per[37] = '»';
            Per[38] = (char)1569;
            Per[39] = (char)1571;
            Per[40] = '[';
            Per[41] = '\\';
            Per[42] = (char)1611;
            Per[43] = 'ر';
            Per[44] = (char)1615;
            Per[45] = (char)1548;
            Per[46] = ',';
            Per[47] = (char)1572;
            Per[48] = (char)1612;
            Per[49] = (char)1610;
            Per[50] = (char)1563;
            Per[51] = (char)1577;
            //////////////
            Per[52] = 'و';
            Per[53] = 'ک';
            Per[54] = 'گ';
            Per[55] = 'چ';
            Per[56] = 'ج';
            Per[57] = 'پ';
            Per[58] = 'پ';
            Per[59] = '؟';
        }
    }
}
