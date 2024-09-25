using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UnHope
{
    public partial class Form1_1 : Form
    {
        public Form1_1()
        {
            InitializeComponent();
            
            CheckASCIIs(true);
            checkedListBox1_SelectedIndexChanged(null, EventArgs.Empty);
        }

        int[] asciiIndices = { 0, 1, 5, 7 };
        int[] nonAsciiIndices = { 2, 3, 6, 8 };
        
        public void CheckAll(bool checkState)
        {
            for (int i = 0; i <= checkedListBox1.Items.Count - 1; i++)
            {
                checkedListBox1.SetItemChecked(i, checkState);
            }
        }
        public void CheckASCIIs(bool checkState)
        {
            foreach (var i in asciiIndices)
            {
                checkedListBox1.SetItemChecked(i, checkState);
            }
        }
        public void CheckNonASCIIs(bool checkState)
        {
            foreach (var i in nonAsciiIndices)
            {
                checkedListBox1.SetItemChecked(i, checkState);
            }
        }

        private void checkAll_Click(object sender, EventArgs e)
        {
            CheckAll(checkAll.Checked);
        }
        private void checkAscii_Click(object sender, EventArgs e)
        {
            CheckASCIIs(checkAscii.Checked);
        }
        private void checkNonAscii_Click(object sender, EventArgs e)
        {
            CheckNonASCIIs(checkNonAscii.Checked);
        }

        #region AutoCheck
        void AutoCheckAll()
        {
            if (checkedListBox1.CheckedItems.Count >= checkedListBox1.Items.Count / 2) checkAll.Checked = true;
            else checkAll.Checked = false;
        }
        void AutoCheckASCIIs()
        {
            int counter = 0;
            foreach (var i in asciiIndices)
            {
                if (checkedListBox1.GetItemChecked(i)) counter++;
            }

            if(counter >= asciiIndices.Length / 2) checkAscii.Checked = true;
            else checkAscii.Checked = false;
        }
        void AutoCheckNonASCIIs()
        {
            int counter = 0;
            foreach (var i in nonAsciiIndices)
            {
                if (checkedListBox1.GetItemChecked(i)) counter++;
            }
            if (counter >= nonAsciiIndices.Length / 2) checkNonAscii.Checked = true;
            else checkNonAscii.Checked = false;
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoCheckAll();
            AutoCheckASCIIs();
            AutoCheckNonASCIIs();
        }
        #endregion

        #region Apply
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
