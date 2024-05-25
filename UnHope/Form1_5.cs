using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Diagnostics;

namespace UnHope
{
    public partial class Form1_5 : Form
    {
        public Form1_5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_5_Load(object sender, EventArgs e)
        {
            SystemSounds.Asterisk.Play();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://s24.picofile.com/file/8453421234/Resum%C3%A8.pdf.html");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://s25.picofile.com/file/8453421418/Projects.rar.html");
        }
    }
}
