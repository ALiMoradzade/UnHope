using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoradzadeHelperUtilityLibrary;

namespace UnHope
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string yes = " year is leap year";
        string no = " year isn't leap year";
        public string s, S;

        private void KeyPress_JustNumberAbs(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))) e.Handled = true;
        }

        #region نام ماه ها
        private void x_Date_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (x_Date_Type.Text == "")
            {
                xLeapYear.Text = "";
                x_Date_Type.Text = "";
                y_Date_Type.Text = "";
                y_Date_Type.SelectedItem = "";
                Day.Items.Clear();
                Day.Text = "";
                Month.Items.Clear();
                Month.Text = "";
                Year.Clear();
            }
            else
            {
                Month.Items.Clear();

                for (int i = 0; i <= 11; i++)
                {
                    Month.Items.Add(DateConvertor.MonthsName[x_Date_Type.SelectedIndex, i]);
                }
            }
            Year_Input_Changed(sender, e);
        }
        #endregion

        #region استعلام کبیسه بودن
        private void Year_Input_Changed(object sender, EventArgs e)
        {
            sbyte n = (sbyte)x_Date_Type.SelectedIndex;
            if (Year.Text != "" && int.Parse(Year.Text) != 0 && n != -1)
            {
                if (DateConvertor.LeapYearQuery(n, Convert.ToUInt64(Year.Text)))
                {
                    DateConvertor.MonthsDay[n, DateConvertor.LeapMonthIndexDay[n, 0]] = DateConvertor.LeapMonthIndexDay[n, 1];
                    xLeapYear.Text = x_Date_Type.Text.Remove(x_Date_Type.Text.Length - 9) + yes;
                }
                else
                {
                    DateConvertor.MonthsDay[n, DateConvertor.LeapMonthIndexDay[n, 0]] = (byte)(DateConvertor.LeapMonthIndexDay[n, 1] - 1);
                    xLeapYear.Text = x_Date_Type.Text.Remove(x_Date_Type.Text.Length - 9) + no;
                }
            }
            else
            {
                xLeapYear.ResetText();
                Year.Clear();
            }
            Month_Validated(sender, e);
        }
        #endregion

        #region هویت ماه ها
        private void Month_Validated(object sender, EventArgs e)
        {
            if (Month.Text != "")
            {
                string[] a = Enumerable.Range(0, DateConvertor.MonthsName.GetLength(1)).Select(y => DateConvertor.MonthsName[x_Date_Type.SelectedIndex, y]).ToArray();
                if (a.Contains(Month.Text) || (FastCode.IsNumber(Month.Text) && (1 <= int.Parse(Month.Text) && int.Parse(Month.Text) <= 12)))
                {
                    #region شماره ماه ها
                    for (int i = 0; i <= 11; i++)
                    {
                        if (Month.Text == DateConvertor.MonthsName[x_Date_Type.SelectedIndex, i])
                        {
                            Month.Text = $"{i + 1}";
                            break;
                        }
                    }
                    #endregion

                    #region روز های هر ماه
                    for (int i = 0; i <= 11; i++)
                    {
                        if (int.Parse(Month.Text) == i + 1)
                        {
                            Day.Items.Clear();
                            for (int j = 1; j <= DateConvertor.MonthsDay[x_Date_Type.SelectedIndex, i]; j++)
                            {
                                Day.Items.Add(j);
                            }
                            break;
                        }
                    }
                    #endregion
                }
                else
                {
                    Month.Text = "";
                }
            }
            else
            {
                Day.Text = "";
                Day.Items.Clear();
            }
            Day_Validated(sender, e);
        }

        private void Day_Validated(object sender, EventArgs e)
        {
            if (Day.Text != "" && !Day.Items.Contains(int.Parse(Day.Text)))
            {
                Day.Text = "";
            }
        }
        #endregion

        #region PC's Date
        private void PC_Date_Button(object sender, EventArgs e)
        {
            ushort a = ushort.Parse(DateTime.Now.ToString("yyyy"));

            if (a > 2021) x_Date_Type.SelectedIndex = 1;
            else if (a > 1442) x_Date_Type.SelectedIndex = 2;
            else if (a > 1399) x_Date_Type.SelectedIndex = 0;

            Year.Text = DateTime.Now.ToString("yyyy");
            Month.Text = DateTime.Now.ToString("MM"); Month_Validated(sender, e);
            Day.Text = DateTime.Now.ToString("dd");
        }
        #endregion

        #region Convert Button
        private void Convert_Button(object sender, EventArgs e)
        {
            #region Errors
            if (Year.Text == "" || Month.Text == "" || Day.Text == "" || x_Date_Type.Text == "" || y_Date_Type.Text == "" || x_Date_Type.Text == y_Date_Type.Text)
            {
                MessageBox.Show("Sorry, you didn't enter date values!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            #endregion

            #region Calculation
            else
            {
                if (!FastCode.IsNumber(this.Month.Text)) Month_Validated(sender, e);

                sbyte x = (sbyte)x_Date_Type.SelectedIndex, y = (sbyte)y_Date_Type.SelectedIndex;

                byte Month = byte.Parse(this.Month.Text);

                ulong Year = ulong.Parse(this.Year.Text);
                long Day = long.Parse(this.Day.Text);

                s = $"{Year:00}/{Month:00}/{Day:00}  {xLeapYear.Text}.It's {DateConvertor.WeekDayFinder(x, Year, Month, Day)}.\r\n";
                S = DateConvertor.ConvertDate(y, x, Year, Month, Day);
                if (S != "Length Error!") S += $"  {y_Date_Type.Text.Remove(y_Date_Type.Text.Length - 9)}{(DateConvertor.LeapYearQuery(x, DateConvertor.ShowYear()) ? yes : no)}.It's {DateConvertor.WeekDayFinder(y, DateConvertor.ShowYear(), DateConvertor.ShowMonth(), DateConvertor.ShowDay())}.";
                S += "\r\n";

                Close();
            }
            #endregion
        }
        #endregion
    }
}