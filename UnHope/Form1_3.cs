using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace UnHope
{
    public partial class Form1_3 : Form
    {
        public int F1x, f1y, F1_Width, F1_Height;
        public string s = "";
        int n = 1;

        
        public Form1_3()
        {
            InitializeComponent();
        }
        private void addingTextBoxes_Click(object sender, EventArgs e)
        {
            TextBox a = Controls.Find("newString" + n, true).FirstOrDefault() as TextBox;
            TextBox b = Controls.Find("oldString" + n, true).FirstOrDefault() as TextBox;
            n++;

            TextBox textBox1 = new TextBox();
            textBox1.Location = new Point(a.Location.X, a.Location.Y + 26);
            textBox1.Name = "newString" + n;
            textBox1.Size = new Size(100, 20);
            textBox1.TabIndex = a.TabIndex + 1;
            Controls.Add(textBox1);

            textBox1 = new TextBox();
            textBox1.Location = new Point(b.Location.X, b.Location.Y + 26);
            textBox1.Name = "oldString" + n;
            textBox1.Size = new Size(100, 20);
            textBox1.TabIndex = b.TabIndex + 1;
            Controls.Add(textBox1);

            apply.Location = new Point(apply.Location.X, apply.Location.Y + 26);
            Size = new Size(Width, Height + 26);
        }
        private void removingTextBoxes_Click(object sender, EventArgs e)
        {
            if (n == 1) return;
            Controls.Remove(Controls.Find("newString" + n, true).FirstOrDefault() as TextBox);
            Controls.Remove(Controls.Find("oldString" + n, true).FirstOrDefault() as TextBox);
            n--;

            apply.Location = new Point(apply.Location.X, apply.Location.Y - 26);
            Size = new Size(Width, Height - 26);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            for (; n > 1; n--)
            {
                Controls.Remove(Controls.Find("newString" + n, true).FirstOrDefault() as TextBox);
                Controls.Remove(Controls.Find("oldString" + n, true).FirstOrDefault() as TextBox);
                apply.Location = new Point(apply.Location.X, apply.Location.Y - 26);
                Size = new Size(Width, Height - 26);
            }
            newString1.Clear();
            oldString1.Clear();
        }

        private void Form1_3_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void Form1_3_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_3_Load(object sender, EventArgs e)
        {
            oldString1.Text = s;
        }

       
        private void apply_Click(object sender, EventArgs e)
        {
            if (!Controls.OfType<TextBox>().Where((x, i) => i % 2 != 0).All(x => x.Text != "")) MessageBox.Show("Sorry, you can't give Old String empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            else Close();
        }
        private void Form1_3_Resize(object sender, EventArgs e)
        {
            Left = F1x + (F1_Width - Width) / 2;
            Top = f1y + (F1_Height - Height) / 2;
        }
    }
}
