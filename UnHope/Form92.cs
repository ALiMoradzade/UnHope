using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Web.UI.WebControls;

namespace UnHope
{
    public partial class Form92 : Form
    {
        Form9 f9;
        public Form92(Form9 f9)
        {
            InitializeComponent();
            this.f9 = f9;
        }

        private async void generateButton_Click(object sender, EventArgs e)
        {
            string s = "";
            foreach (var item in collectionBox.Text.Split(new string[] { "\r\n"}, StringSplitOptions.RemoveEmptyEntries))
            {
                int a = int.Parse(selectedIndexLabel.Text.Substring(selectedIndexLabel.Text.LastIndexOf(" ") + 1));
                s += syntaxBox.Text.Insert(a, item) + "\r\n";
            }

            using (SaveFileDialog A = new SaveFileDialog() { Filter = "Text File|.txt", ValidateNames = true })
            {
                if (A.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter B = new StreamWriter(A.FileName)) await B.WriteLineAsync(s.TrimEnd());
                }
                f9.Close();
                Close();
            }

        }

        void SelectedIndex()
        {
            selectedIndexLabel.Text = "Selected Index : " + syntaxBox.SelectionStart;
        }

        private void syntaxBox_MouseDown(object sender, MouseEventArgs e) => SelectedIndex();

        private void syntaxBox_KeyUp(object sender, KeyEventArgs e) => SelectedIndex();
    }
}
