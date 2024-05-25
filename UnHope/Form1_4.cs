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
using MoradzadeHelperUtilityLibrary;

namespace UnHope
{
    public partial class Form1_4 : Form
    {
        public Form1_4(bool FormRightToLeft = false)
        {
            InitializeComponent();
            this.FormRightToLeft = FormRightToLeft;
        }

        public bool FormRightToLeft;
        string s;

        #region Search
        private void Search(object sender, EventArgs e)
        {
            comboBox2.Text = FormRightToLeft ? "Boy's Name" : "First Name";
            bool caseInsensitive = false;
            int a = 0, n = 0;
            CultureInfo ci = new CultureInfo("");
            List<string> l = new List<string>();

            switch (comboBox2.Text)
            {
                case "Boy's Name":
                    n = Data.boyPerName.Length;
                    l = Data.boyPerName.ToList();
                    ci = new CultureInfo(s);
                    break;

                case "Girl's Name":
                    n = Data.girlPerName.Length;
                    l = Data.girlPerName.ToList();
                    ci = new CultureInfo(s);

                    break;

                case "First Name":
                    n = Data.engFirstName.Length;
                    l = Data.engFirstName.ToList();
                    ci = new CultureInfo(s);
                    break;

                case "Last Name":
                    n = Data.engLastName.Length;
                    l = Data.engLastName.ToList();
                    ci = new CultureInfo(s);
                    break;
            }

            if (checkBox1.Visible && !checkBox1.Checked) caseInsensitive = true;
           

            for (int i = 0; i <= checkedListBox1.Items.Count - 1; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    switch (i)
                    {
                        case 0:
                            l = l.FindAll(ele => ele.StartsWith(textBox1.Text, caseInsensitive, ci));
                            break;
                        //case 1:
                        //    l = l.FindAll(ele => ele.With(textBox1.Text, caseSensitive, ci));
                        //    break;
                        case 2:
                            l = l.FindAll(ele => ele.EndsWith(textBox1.Text, caseInsensitive, ci));
                            break;
                    }
                    break;
                }
            }

            textBox2.Clear();
            textBox2.Text = string.Join("\r\n", l);
            label1.Text = textBox2.Lines.Length.ToString();
            label1.Location = FormRightToLeft ? new Point(138, 136) : new Point(203 - label1.Size.Width, 136);
        }
        #endregion

        #region Keyboard
        private void Form1_4_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (FormRightToLeft)
            {
                comboBox2.Items.Add("Boy's Name");
                comboBox2.Items.Add("Girl's Name");
                textBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                checkBox1.Hide();
                s = "fa-IR";
                button1.Location = new Point(30, 109);
            }
            else
            {
                comboBox2.Items.Add("First Name");
                comboBox2.Items.Add("Last Name");
                textBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
                textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
                checkBox1.Show();
                s = "en-US";
                button1.Location = new Point(30, 126);
            }
            checkedListBox1.SetItemCheckState(0, CheckState.Checked);
        }
        #endregion

        private void checkedListBox1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                for (int i = 0; i <= checkedListBox1.Items.Count - 1; i++)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }
    }
}