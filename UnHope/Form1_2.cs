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
    public partial class Form1_2 : Form
    {
        public Form1_2()
        {
            InitializeComponent();
        }

        Random random = new Random();

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text+=random.Next((int)numericUpDown1.Value, (int)numericUpDown2.Value + 1)+"\r\n";
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }
    }
}
