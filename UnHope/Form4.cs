using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoradzadeHelperUtilityLibrary;

namespace UnHope
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void KeyPress_JustNumberAbs(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }
        private void KeyPress_JustDecimalNumberAbs(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || (e.KeyChar == '.' && !textBox.Text.Contains('.')))) e.Handled = true;
            else if (e.KeyChar == '.' && textBox.Text == "")
            {
                textBox.Text = "0.";
                textBox.SelectionStart = textBox.TextLength;
                e.Handled = true;
            }
        }
        bool b = false;

        #region Type 1
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "")
            {
                try
                {
                    int a = textBox1.SelectionStart;
                    textBox1.Text = textBox1.Text.Replace("-", "").Replace(",", "");
                    textBox1.SelectionStart = a;

                    TimeCalculator tCal = new TimeCalculator(decimal.Parse(textBox1.Text) * TimeCalculator.timeInSec[comboBox1.SelectedIndex + 1]);

                    for (int i = 2; i <= 8; i++)
                    {
                        ((TextBox)Controls.Find("textBox" + i, true)[0]).Text = tCal.ValuesArray[i - 2].ToString();
                    }
                }
                catch (FormatException)
                {
                    int a = (textBox1.SelectionStart > 0) ? textBox1.SelectionStart - 1 : 0;
                    textBox1.Text = FastCode.NumberFormatFixer(textBox1.Text);
                    textBox1.SelectionStart = a;
                }
            }
            else
            {
                for (int i = 2; i <= 8; i++)
                {
                    ((TextBox)Controls.Find("textBox" + i, true)[0]).Clear();
                }
            }
        }
        #endregion

        #region Type 2
        private void label21_Click(object sender, EventArgs e)
        {
            label21.Text = (label21.Text == "+") ? "-" : "+";
            textBox8_TextChanged(sender, e);
        }
        private void PC_Click(object sender, EventArgs e)
        {
            b = true;
            textBox9.Text = checkBox1.Checked ? DateTime.Now.ToString("hh") : DateTime.Now.ToString("HH");
            textBox10.Text = DateTime.Now.ToString("mm");
            b = false;
            textBox11.Text = DateTime.Now.ToString("ss");
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) checkBox2.Checked = false;
            else checkBox2.Checked = true;
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) checkBox1.Checked = false;
            else checkBox1.Checked = true;
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (b) return;
            try
            {
                for (int i = 9; i <= 14; i++)
                {
                    TextBox textBox = Controls.Find("textBox" + i, true)[0] as TextBox;
                    b = true;
                    if ((textBox.Text != "" && int.Parse(textBox.Text) >= 60) || textBox.Text == "") textBox.Text = "0";
                    b = false;
                }

                TimeCalculator t1 = new TimeCalculator(0, 0, 0, 0, uint.Parse(textBox9.Text), uint.Parse(textBox10.Text), uint.Parse(textBox11.Text));
                TimeCalculator t2 = new TimeCalculator(0, 0, 0, 0, uint.Parse(textBox12.Text), uint.Parse(textBox13.Text), uint.Parse(textBox14.Text));

                t1 += (label21.Text == "+") ? t2 : -t2;

                result2.ResetText();
                if (t1.IsNegative) result2.Text += "-";
                result2.Text += "  ";

                if (t1.Hour.ToString().Length == 1) result2.Text += "  ";
                result2.Text += t1.Hour + "  :  ";
                if (t1.Minute.ToString().Length == 1) result2.Text += "  ";
                result2.Text += t1.Minute + "' : ";
                if (Math.Floor(t1.Second).ToString().Length == 1) result2.Text += "  ";
                result2.Text += Math.Floor(t1.Second) + "\"";

                timeLeft.Text = Convert.ToString(Math.Round(t1.GetMinutes(), 2)) + "min or " + t1.GetSeconds() + 's';
            }
            catch (Exception)
            {
                int a;
                for (int i = 9; i <= 14; i++)
                {
                    TextBox textBox = Controls.Find("textBox" + i, true)[0] as TextBox;
                    a = (textBox.SelectionStart > 0) ? textBox.SelectionStart - 1 : 0;
                    textBox.Text = FastCode.NumberFormatFixer(textBox.Text);
                    textBox.SelectionStart = a;
                }
            }
        }
        #endregion

        #region Type 3
        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if (textBoxType3M.Text != "" && !(1 <= short.Parse(textBoxType3M.Text) && short.Parse(textBoxType3M.Text) <= 12))
            {
                textBoxType3M.Clear();
                weekDay.ResetText();
                result3.ResetText();
                dayLeft.ResetText();
            }
            else if (comboBox3.Text != "" && textBoxType3Y.Text != "" && textBoxType3M.Text != "" && textBoxType3D.Text != "")
            {
                weekDay.Text = DateConvertor.WeekDayFinder((sbyte)comboBox3.SelectedIndex, ulong.Parse(textBoxType3Y.Text), byte.Parse(textBoxType3M.Text), long.Parse(textBoxType3D.Text));
            }

            if (textBox15.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && textBoxType3Y.Text != "" && textBoxType3M.Text != "" && textBoxType3D.Text != "")
            {
                try
                {
                    textBox15.Text = textBox15.Text.Replace("-", "").Replace(",", "");

                    TimeCalculator tC = new TimeCalculator(decimal.Parse(textBox15.Text) * TimeCalculator.timeInSec[comboBox2.SelectedIndex]);

                    sbyte D = 0;
                    ulong y = ulong.Parse(DateTime.Now.ToString("yyyy"));
                    if (y > 2021) D = 1;
                    else if (y > 1443) D = 2;
                    else if (y > 1400) D = 0;
                    result3.Text = "Result: ";

                    if (label28.Text == "Add to...")
                    {
                        result3.Text += DateConvertor.ConvertDate((sbyte)comboBox3.SelectedIndex, (sbyte)comboBox3.SelectedIndex, ulong.Parse(textBoxType3Y.Text), byte.Parse(textBoxType3M.Text), long.Parse(textBoxType3D.Text) + (long)tC.GetDays()) + "  " + DateConvertor.WeekDayFinder((sbyte)comboBox3.SelectedIndex, ulong.Parse(textBoxType3Y.Text), byte.Parse(textBoxType3M.Text), long.Parse(textBoxType3D.Text) + (long)tC.GetDays());
                        DateConvertor.ConvertDate(D, (sbyte)comboBox3.SelectedIndex, ulong.Parse(textBoxType3Y.Text), byte.Parse(textBoxType3M.Text), long.Parse(textBoxType3D.Text) + (long)tC.GetDays());
                    }
                    else if (label28.Text == "Subtract from...")
                    {
                        string s = DateConvertor.ConvertDate((sbyte)comboBox3.SelectedIndex, (sbyte)comboBox3.SelectedIndex, ulong.Parse(textBoxType3Y.Text), byte.Parse(textBoxType3M.Text), long.Parse(textBoxType3D.Text) - (long)tC.GetDays());
                        if (FastCode.IsNumber(s) && decimal.Parse(s) < 0)
                        {
                            result3.Text = $"Can't Subtract {textBox15.Text} {comboBox2.Text} from date you entered!";
                            dayLeft.Text = $"We need {new TimeCalculator(-decimal.Parse(s) * TimeCalculator.timeInSec[3])}more!";
                            return;
                        }
                        result3.Text += s + "  " + DateConvertor.WeekDayFinder((sbyte)comboBox3.SelectedIndex, ulong.Parse(textBoxType3Y.Text), byte.Parse(textBoxType3M.Text), long.Parse(textBoxType3D.Text) - (long)tC.GetDays());
                        DateConvertor.ConvertDate(D, (sbyte)comboBox3.SelectedIndex, ulong.Parse(textBoxType3Y.Text), byte.Parse(textBoxType3M.Text), long.Parse(textBoxType3D.Text) - (long)tC.GetDays());
                    }

                    decimal a = (decimal)DateConvertor.ConvertDatetoDay(D, DateConvertor.ShowYear(), DateConvertor.ShowMonth(), DateConvertor.ShowDay()) - (decimal)DateConvertor.ConvertDatetoDay(D, y, byte.Parse(DateTime.Now.ToString("MM")), long.Parse(DateTime.Now.ToString("dd")));
                    dayLeft.Text = new TimeCalculator(Math.Abs(a) * TimeCalculator.timeInSec[3]) + (a > 0 ? "Remaining" : "Left");
                }
                catch (FormatException)
                {
                    int a = (textBox15.SelectionStart > 0) ? textBox15.SelectionStart - 1 : 0;
                    textBox15.Text = FastCode.NumberFormatFixer(textBox15.Text);
                    textBox15.SelectionStart = a;
                }
            }
            else
            {
                result3.ResetText();
                dayLeft.ResetText();
            }
        }
        private void label28_Click(object sender, EventArgs e)
        {
            label28.Text = (label28.Text == "Add to...") ? "Subtract from..." : "Add to...";
            textBox19_TextChanged(sender, e);
        }
        private void PC_Date_Click(object sender, EventArgs e)
        {
            ushort a = ushort.Parse(DateTime.Now.ToString("yyyy"));

            if (a > 2021) comboBox3.SelectedIndex = 1;
            else if (a > 1442) comboBox3.SelectedIndex = 2;
            else if (a > 1399) comboBox3.SelectedIndex = 0;
         
            textBoxType3Y.Text = DateTime.Now.ToString("yyyy");
            textBoxType3M.Text = DateTime.Now.ToString("MM");
            textBoxType3D.Text = DateTime.Now.ToString("dd");
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(result3.Text.Substring(8));
        }
        #endregion

        TimeCalculator total = new TimeCalculator();
        private void AddingTime()
        {
            if (b) return;
            try
            {
                for (int i = 16; i <= 18; i++)
                {
                    TextBox textBox = Controls.Find("textBox" + i, true)[0] as TextBox;
                    b = true;
                    if ((textBox.Text != "" && int.Parse(textBox.Text) >= 60) || textBox.Text == "") textBox.Text = "0";
                    b = false;
                }

                total += new TimeCalculator(0,0,0,0, uint.Parse(textBox16.Text), uint.Parse(textBox17.Text), uint.Parse(textBox18.Text));

                textBox19.Text = total.Hour.ToString();
                textBox20.Text = total.Minute.ToString();
                textBox21.Text = total.Second.ToString();
            }
            catch (Exception)
            {
                int a;
                for (int i = 16; i <= 18; i++)
                {
                    TextBox textBox = Controls.Find("textBox" + i, true)[0] as TextBox;
                    a = (textBox.SelectionStart > 0) ? textBox.SelectionStart - 1 : 0;
                    textBox.Text = FastCode.NumberFormatFixer(textBox.Text);
                    textBox.SelectionStart = a;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddingTime();
        }

        private void textBox18_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) AddingTime();
        }
    }
}