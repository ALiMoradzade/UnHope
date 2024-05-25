namespace UnHope
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.x_Date_Type = new System.Windows.Forms.ComboBox();
            this.Year_label = new System.Windows.Forms.Label();
            this.Month_label = new System.Windows.Forms.Label();
            this.Day_label = new System.Windows.Forms.Label();
            this.Year = new System.Windows.Forms.TextBox();
            this.Month = new System.Windows.Forms.ComboBox();
            this.Day = new System.Windows.Forms.ComboBox();
            this.xLeapYear = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Convert_Date = new System.Windows.Forms.Button();
            this.y_Date_Type = new System.Windows.Forms.ComboBox();
            this.PC_Date = new System.Windows.Forms.Button();
            this.Type_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // x_Date_Type
            // 
            this.x_Date_Type.BackColor = System.Drawing.Color.White;
            this.x_Date_Type.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.x_Date_Type.FormattingEnabled = true;
            this.x_Date_Type.Items.AddRange(new object[] {
            "Solar Hijri Calender",
            "Gregorian Calender",
            "Lunar Calender"});
            this.x_Date_Type.Location = new System.Drawing.Point(44, 5);
            this.x_Date_Type.Name = "x_Date_Type";
            this.x_Date_Type.Size = new System.Drawing.Size(116, 21);
            this.x_Date_Type.TabIndex = 1;
            this.x_Date_Type.SelectedIndexChanged += new System.EventHandler(this.x_Date_Type_SelectedIndexChanged);
            // 
            // Year_label
            // 
            this.Year_label.AutoSize = true;
            this.Year_label.Location = new System.Drawing.Point(5, 35);
            this.Year_label.Name = "Year_label";
            this.Year_label.Size = new System.Drawing.Size(32, 13);
            this.Year_label.TabIndex = 19;
            this.Year_label.Text = "Year:";
            // 
            // Month_label
            // 
            this.Month_label.AutoSize = true;
            this.Month_label.Location = new System.Drawing.Point(5, 62);
            this.Month_label.Name = "Month_label";
            this.Month_label.Size = new System.Drawing.Size(40, 13);
            this.Month_label.TabIndex = 20;
            this.Month_label.Text = "Month:";
            // 
            // Day_label
            // 
            this.Day_label.AutoSize = true;
            this.Day_label.Location = new System.Drawing.Point(5, 89);
            this.Day_label.Name = "Day_label";
            this.Day_label.Size = new System.Drawing.Size(29, 13);
            this.Day_label.TabIndex = 21;
            this.Day_label.Text = "Day:";
            // 
            // Year
            // 
            this.Year.BackColor = System.Drawing.Color.White;
            this.Year.Location = new System.Drawing.Point(44, 32);
            this.Year.MaxLength = 9;
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(61, 20);
            this.Year.TabIndex = 2;
            this.Year.TextChanged += new System.EventHandler(this.Year_Input_Changed);
            this.Year.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_JustNumberAbs);
            // 
            // Month
            // 
            this.Month.BackColor = System.Drawing.Color.White;
            this.Month.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Month.FormattingEnabled = true;
            this.Month.ItemHeight = 13;
            this.Month.Location = new System.Drawing.Point(44, 59);
            this.Month.MaxLength = 2;
            this.Month.Name = "Month";
            this.Month.Size = new System.Drawing.Size(83, 21);
            this.Month.TabIndex = 3;
            this.Month.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_JustNumberAbs);
            this.Month.Validated += new System.EventHandler(this.Month_Validated);
            // 
            // Day
            // 
            this.Day.BackColor = System.Drawing.Color.White;
            this.Day.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Day.FormattingEnabled = true;
            this.Day.Location = new System.Drawing.Point(44, 86);
            this.Day.MaxLength = 2;
            this.Day.Name = "Day";
            this.Day.Size = new System.Drawing.Size(37, 21);
            this.Day.TabIndex = 4;
            this.Day.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_JustNumberAbs);
            this.Day.Validated += new System.EventHandler(this.Day_Validated);
            // 
            // xLeapYear
            // 
            this.xLeapYear.AutoSize = true;
            this.xLeapYear.BackColor = System.Drawing.Color.White;
            this.xLeapYear.Location = new System.Drawing.Point(106, 35);
            this.xLeapYear.Name = "xLeapYear";
            this.xLeapYear.Size = new System.Drawing.Size(0, 13);
            this.xLeapYear.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "To";
            // 
            // Convert_Date
            // 
            this.Convert_Date.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Convert_Date.Location = new System.Drawing.Point(7, 112);
            this.Convert_Date.Name = "Convert_Date";
            this.Convert_Date.Size = new System.Drawing.Size(78, 21);
            this.Convert_Date.TabIndex = 6;
            this.Convert_Date.Text = "Convert Date";
            this.Convert_Date.UseVisualStyleBackColor = true;
            this.Convert_Date.Click += new System.EventHandler(this.Convert_Button);
            // 
            // y_Date_Type
            // 
            this.y_Date_Type.BackColor = System.Drawing.Color.White;
            this.y_Date_Type.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.y_Date_Type.FormattingEnabled = true;
            this.y_Date_Type.Items.AddRange(new object[] {
            "Solar Hijri Calender",
            "Gregorian Calender",
            "Lunar Calender"});
            this.y_Date_Type.Location = new System.Drawing.Point(125, 112);
            this.y_Date_Type.Name = "y_Date_Type";
            this.y_Date_Type.Size = new System.Drawing.Size(116, 21);
            this.y_Date_Type.TabIndex = 5;
            // 
            // PC_Date
            // 
            this.PC_Date.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PC_Date.Location = new System.Drawing.Point(174, 5);
            this.PC_Date.Name = "PC_Date";
            this.PC_Date.Size = new System.Drawing.Size(65, 21);
            this.PC_Date.TabIndex = 0;
            this.PC_Date.Text = "PC";
            this.PC_Date.UseVisualStyleBackColor = true;
            this.PC_Date.Click += new System.EventHandler(this.PC_Date_Button);
            // 
            // Type_label
            // 
            this.Type_label.AutoSize = true;
            this.Type_label.Location = new System.Drawing.Point(5, 9);
            this.Type_label.Name = "Type_label";
            this.Type_label.Size = new System.Drawing.Size(34, 13);
            this.Type_label.TabIndex = 28;
            this.Type_label.Text = "Type:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(253, 137);
            this.Controls.Add(this.Type_label);
            this.Controls.Add(this.PC_Date);
            this.Controls.Add(this.y_Date_Type);
            this.Controls.Add(this.Convert_Date);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Day);
            this.Controls.Add(this.Month);
            this.Controls.Add(this.Year);
            this.Controls.Add(this.Day_label);
            this.Controls.Add(this.Month_label);
            this.Controls.Add(this.Year_label);
            this.Controls.Add(this.x_Date_Type);
            this.Controls.Add(this.xLeapYear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Date Convertor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Year_label;
        private System.Windows.Forms.Label Month_label;
        private System.Windows.Forms.Label Day_label;
        private System.Windows.Forms.Label xLeapYear;
        public System.Windows.Forms.TextBox Year;
        public System.Windows.Forms.ComboBox Month;
        public System.Windows.Forms.ComboBox Day;
        public System.Windows.Forms.ComboBox x_Date_Type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Convert_Date;
        public System.Windows.Forms.ComboBox y_Date_Type;
        private System.Windows.Forms.Button PC_Date;
        private System.Windows.Forms.Label Type_label;
    }
}