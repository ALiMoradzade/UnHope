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
using System.Messaging;

namespace UnHope
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void asterisk_Click(object sender, EventArgs e)
        {
            SystemSounds.Asterisk.Play();
        }

        private void beep_Click(object sender, EventArgs e)
        {
            SystemSounds.Beep.Play();
        }

        private void exclamation_Click(object sender, EventArgs e)
        {
            SystemSounds.Exclamation.Play();
        }

        private void hand_Click(object sender, EventArgs e)
        {
            SystemSounds.Hand.Play();
        }

        private void question_Click(object sender, EventArgs e)
        {
            SystemSounds.Question.Play();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            buttonComboBox.SelectedIndex = 0;
            iconComboBox.SelectedIndex = 0;
            defaultButtonComboBox.SelectedIndex = 0;
        }


        static MessageBoxOptions GetOptions(CheckedListBox options)
        {
            MessageBoxOptions ops = default;
            bool isFirst = true;
            foreach (var item in options.CheckedItems)
            {
                if (isFirst)
                {
                    ops = (MessageBoxOptions)Enum.Parse(typeof(MessageBoxOptions), item.ToString());
                    isFirst = false;
                }
                else ops |= (MessageBoxOptions)Enum.Parse(typeof(MessageBoxOptions), item.ToString());
            }
            return ops;
        }
        private void runButton_Click(object sender, EventArgs e)
        {
            var icon = (MessageBoxIcon)Enum.Parse(typeof(MessageBoxIcon), iconComboBox.Text);

            var defaultButton = (MessageBoxDefaultButton)Enum.Parse(typeof(MessageBoxDefaultButton), defaultButtonComboBox.Text);

            var button = (MessageBoxButtons)buttonComboBox.SelectedIndex;

            var options = GetOptions(optionCheckedListBox);

            DialogResult r = MessageBox.Show(captionTextBox.Text, titleTextBox.Text, button, icon, defaultButton, options);

            resultLabel.Text = $"Result: {r} button detected";
        }
    }
}
