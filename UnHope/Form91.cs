using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using System.IO;
using static System.Net.WebRequestMethods;

namespace UnHope
{
    public partial class Form91 : Form
    {
        Form9 f9;
        Attribute[] ForeignKey;

        public Form91(Form9 f9)
        {
            InitializeComponent();
            this.f9 = f9;
        }

        List<Table> tables = new List<Table>();
        bool isAnyCellsChanged = false;

        private void Form9_Load(object sender, EventArgs e)
        {
            tables.Add(new Table("Default"));
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
        }
        private void clear_Click(object sender, EventArgs e)
        {
            tables.Clear();
            tables.Add(new Table("Default"));
            comboBox1.Items.Clear();
            comboBox1.Text = "Default";
            comboBox1.Items.Add("Default");
            dataGridView1.Rows.Clear();
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            isAnyCellsChanged = true;

            var cell = (DataGridView)sender;

            if (cell.CurrentCellAddress.X == 0)
            {

            }
            else if (cell.CurrentCellAddress.X == 5)
            {

            }



        }
        private void dataGridView1_Leave(object sender, EventArgs e)
        {
            isAnyCellsChanged = false;
        }

        
        
       
        #region button
        private async void GenerateCode_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.ValidateNames = true;
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.Filter = "Text File|*.txt" +
                                        "|SQL File|*.sql";
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string s = string.Join("\n\r", tables);
                    
                    using (StreamWriter B = new StreamWriter(saveFileDialog.FileName)) await B.WriteLineAsync(s);
                    f9.Close();
                    Close();
                }
            }
        }

        private void CreateTable_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Table name can't be \"Default\"!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Table name can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (comboBox1.SelectedItem.ToString() == comboBox1.Text)
            {
                MessageBox.Show("This table is already defined!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (comboBox1.SelectedItem.ToString() != comboBox1.Text)
            {

                Table table = new Table(comboBox1.Text);
                table.ImportFrom(dataGridView1);

                tables.Add(table);

                comboBox1.Items.Add(comboBox1.Text);

                dataGridView1.Rows.Clear();
            }
        }

        private void DropTable_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Default table can't be dropped!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Table name can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (comboBox1.SelectedItem.ToString() != comboBox1.Text)
            {
                MessageBox.Show("This table is already defined!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (comboBox1.SelectedItem.ToString() == comboBox1.Text)
            {
                dataGridView1.Rows.Clear();
                comboBox1.SelectedIndex = comboBox1.FindString(comboBox1.Text) - 1;
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
            }
        }
        #endregion


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Count - 1;
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows[i].Cells[2].Value = checkBox1.Checked;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text) && isAnyCellsChanged) tables[comboBox1.FindString(comboBox1.Text)].ImportFrom(dataGridView1);
            tables[comboBox1.SelectedIndex].ExportTo(dataGridView1);
            comboBox1.Text = comboBox1.SelectedItem.ToString();
        }

       
        void f()
        {
            Func<int, int> doubleIt = x => x * 2;
        }
        #region Context_1
        private void toolStripInsertRow_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1 && dataGridView1.SelectedCells.Count != 1)
            {
                MessageBox.Show("Just select one cell!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            dataGridView1.Rows.Insert(dataGridView1.SelectedCells[0].RowIndex, row);
        }
        private void toolStripDeleteRow_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedCells.Count == 0 || dataGridView1.SelectedRows.Count > 1 || dataGridView1.SelectedCells.Count > 1)
            {
                MessageBox.Show("Just select one cell!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Table can't have no columns!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
        }
       
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1 && dataGridView1.SelectedCells.Count != 1)
            {
                MessageBox.Show("Just select one cell!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dataGridView1.Rows[0].Cells["DataType"].Value = toolStripComboBox1.SelectedText;
        }






        #endregion

        private async void Form91_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (tables.Count == 1 && tables[0].name == "Default")
            {
                var r = MessageBox.Show("Don't you want to save?",
                                             "We are closing!",
                                             MessageBoxButtons.YesNoCancel,
                                             MessageBoxIcon.Question,
                                             MessageBoxDefaultButton.Button3);

                if (r == DialogResult.Yes)
                {
                    using (SaveFileDialog A = new SaveFileDialog() { Filter = "Text File|.txt", ValidateNames = true })
                    {
                        if (A.ShowDialog() == DialogResult.OK)
                        {
                            using (StreamWriter B = new StreamWriter(A.FileName)) await B.WriteLineAsync("");
                        }
                    }
                }
                else if (r == DialogResult.Cancel) e.Cancel = true;
            }
        }
    }

    class Attribute
    {
        public string Name, DataType;

    }

    class Column : Attribute
    {
        public bool PrimaryKey, Unique, NotNull;
        public override string ToString()
        {
            return $"[{Name}] {DataType}";
        }
    }

    class Table
    {
        public string name;
        public List<Column> columns = new List<Column>();

        public Table(string name)
        {
            this.name = name;
        }

        public void ExportTo(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            foreach (var column in columns)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView.Rows[0].Clone();
                row.Cells[0].Value = column.PrimaryKey;
                row.Cells[1].Value = column.Unique;
                row.Cells[2].Value = column.NotNull;
                row.Cells[3].Value = column.Name;
                row.Cells[4].Value = column.DataType;
                dataGridView.Rows.Add(row);
            }
        }

        public void ImportFrom(DataGridView dataGridView)
        {
            dataGridView.AllowUserToAddRows = false;
            columns.Clear();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                Column column = new Column();
                column.PrimaryKey = Convert.ToBoolean(row.Cells["PrimaryKey"].Value);
                column.Unique = Convert.ToBoolean(row.Cells["Unique"].Value);
                column.NotNull = Convert.ToBoolean(row.Cells["NotNull"].Value);
                column.Name = (string)row.Cells["ColumnName"].Value;
                column.DataType = (string)row.Cells["DataType"].Value;
                columns.Add(column);
            }
            dataGridView.AllowUserToAddRows = true;
        }

        public override string ToString()
        {
            string s = $"Create Table [{name}] (";
            foreach (var column in columns)
            {
                s += $"";
            }
            s += ")";
            return s;
        }
    }
}
