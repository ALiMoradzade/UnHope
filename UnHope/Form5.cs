using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnHope
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        #region Formula
        private void richTextBoxChanged(object sender, EventArgs e)
        {
            int x = richTextBox1.SelectionStart, y = richTextBox2.SelectionStart;

            string txt1 = "", txt2 = "";
            if (richTextBox1.TextLength >= richTextBox2.TextLength) { txt1 = richTextBox1.Text; txt2 = richTextBox2.Text; }
            else if (richTextBox1.TextLength < richTextBox2.TextLength) { txt1 = richTextBox2.Text; txt2 = richTextBox1.Text; }
            
            if (!checkBox1.Checked) { txt1 = txt1.ToUpper(); txt2 = txt2.ToUpper(); }
            
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.TextLength;
            richTextBox1.SelectionColor = Color.Red;
            richTextBox2.SelectionStart = 0;
            richTextBox2.SelectionLength = richTextBox2.TextLength;
            richTextBox2.SelectionColor = Color.Red;

            for (int i = txt1.Length - 1; i >= 0; i--)
            {
                int before = (i == 0) ? -2 : txt2.LastIndexOf(txt1[i - 1]);
                int now = txt2.LastIndexOf(txt1[i]);

                if (now >= 0 && (before <= now))
                {
                    if (richTextBox1.TextLength >= richTextBox2.TextLength)
                    {
                        richTextBox1.SelectionStart = i;
                        richTextBox1.SelectionLength = 1;
                        richTextBox1.SelectionColor = Color.Green;
                        richTextBox2.SelectionStart = now;
                        richTextBox2.SelectionLength = 1;
                        richTextBox2.SelectionColor = Color.Green;
                    }
                    else if (richTextBox1.TextLength < richTextBox2.TextLength)
                    {
                        richTextBox2.SelectionStart = i;
                        richTextBox2.SelectionLength = 1;
                        richTextBox2.SelectionColor = Color.Green;
                        richTextBox1.SelectionStart = now;
                        richTextBox1.SelectionLength = 1;
                        richTextBox1.SelectionColor = Color.Green;
                    }
                    txt2 = txt2.Remove(now);
                }
            }

            richTextBox1.SelectionStart = x;
            richTextBox1.SelectionLength = 0;
            richTextBox2.SelectionStart = y;
            richTextBox2.SelectionLength = 0;
        }
        #endregion

        #region Button
        private void Paste_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
        }
        #endregion

        #region Right Click
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Focused)
            {
                if (richTextBox1.SelectedText.Length > 0)
                {
                    Clipboard.SetText(richTextBox1.SelectedText);
                }
            }
            else if (richTextBox2.Focused)
            {
                if (richTextBox2.SelectedText.Length > 0)
                {
                    Clipboard.SetText(richTextBox2.SelectedText);
                }
            }
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Focused)
            {
                richTextBox1.Paste();
            }
            else if (richTextBox2.Focused)
            {
                richTextBox2.Paste();
            }
        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Focused)
            {
                if (richTextBox1.SelectedText.Length > 0)
                {
                    int temp = richTextBox1.SelectionStart;
                    richTextBox1.Text = richTextBox1.Text.Remove(temp, richTextBox1.SelectionLength);
                    richTextBox1.SelectionStart = temp;
                }
            }
            else if (richTextBox2.Focused)
            {
                if (richTextBox2.SelectedText.Length > 0)
                {
                    int temp = richTextBox2.SelectionStart;
                    richTextBox2.Text = richTextBox2.Text.Remove(temp, richTextBox2.SelectionLength);
                    richTextBox2.SelectionStart = temp;
                }
            }
        }
        #endregion

        #region Double Click TextBox
        private void richTextBox_DoubleClick(object sender, EventArgs e)
        {
            if (richTextBox1.Focused)
            {
                richTextBox1.SelectAll();
            }
            else if (richTextBox2.Focused)
            {
                richTextBox2.SelectAll();
            }
        }
        #endregion
    }
}
