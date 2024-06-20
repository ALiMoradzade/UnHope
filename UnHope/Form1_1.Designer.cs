namespace UnHope
{
    partial class Form1_1
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.distinctCheckBox = new System.Windows.Forms.CheckBox();
            this.repeatStepsCount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.repeatStepsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.White;
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Letter | ASCII Lowercase",
            "Letter | ASCII Uppercase",
            "Letter | Non-ASCII Lowercase",
            "Letter | Non-ASCII Uppercase",
            "Digit | ASCII",
            "Digit | Non-ASCII",
            "Symbol | ASCII",
            "Symbol | Non-ASCII"});
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(182, 120);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(59, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 21);
            this.button1.TabIndex = 3;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(1, 142);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Clicked);
            // 
            // distinctCheckBox
            // 
            this.distinctCheckBox.AutoSize = true;
            this.distinctCheckBox.Location = new System.Drawing.Point(1, 125);
            this.distinctCheckBox.Name = "distinctCheckBox";
            this.distinctCheckBox.Size = new System.Drawing.Size(110, 17);
            this.distinctCheckBox.TabIndex = 1;
            this.distinctCheckBox.Text = "Distinct Password";
            this.distinctCheckBox.UseVisualStyleBackColor = true;
            // 
            // repeatStepsCount
            // 
            this.repeatStepsCount.BackColor = System.Drawing.Color.White;
            this.repeatStepsCount.Location = new System.Drawing.Point(136, 126);
            this.repeatStepsCount.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.repeatStepsCount.Name = "repeatStepsCount";
            this.repeatStepsCount.Size = new System.Drawing.Size(34, 20);
            this.repeatStepsCount.TabIndex = 5;
            this.repeatStepsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(182, 167);
            this.Controls.Add(this.repeatStepsCount);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.distinctCheckBox);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1_1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.repeatStepsCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.CheckedListBox checkedListBox1;
        public System.Windows.Forms.CheckBox distinctCheckBox;
        public System.Windows.Forms.CheckBox checkBox1;
        internal System.Windows.Forms.NumericUpDown repeatStepsCount;
    }
}