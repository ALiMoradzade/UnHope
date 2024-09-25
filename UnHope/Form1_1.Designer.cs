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
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.distinctCheckBox = new System.Windows.Forms.CheckBox();
            this.distanceCount = new System.Windows.Forms.NumericUpDown();
            this.checkAscii = new System.Windows.Forms.CheckBox();
            this.checkNonAscii = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.distanceCount)).BeginInit();
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
            "Letter | Latin | ASCII | Lowercase",
            "Letter | Latin | ASCII | Uppercase",
            "Letter | Latin | Non-ASCII | Lowercase",
            "Letter | Latin | Non-ASCII | Uppercase",
            "Letter | Non-Latin",
            "Number | ASCII",
            "Number | Non-ASCII",
            "Symbol & Punctuation | ASCII",
            "Symbol & Punctuation | Non-ASCII"});
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(205, 135);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(70, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 21);
            this.button1.TabIndex = 3;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.Checked = true;
            this.checkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAll.Location = new System.Drawing.Point(12, 141);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(71, 17);
            this.checkAll.TabIndex = 2;
            this.checkAll.Text = "Check All";
            this.checkAll.UseVisualStyleBackColor = true;
            this.checkAll.Click += new System.EventHandler(this.checkAll_Click);
            // 
            // distinctCheckBox
            // 
            this.distinctCheckBox.AutoSize = true;
            this.distinctCheckBox.Location = new System.Drawing.Point(12, 207);
            this.distinctCheckBox.Name = "distinctCheckBox";
            this.distinctCheckBox.Size = new System.Drawing.Size(110, 17);
            this.distinctCheckBox.TabIndex = 1;
            this.distinctCheckBox.Text = "Distinct Password";
            this.distinctCheckBox.UseVisualStyleBackColor = true;
            // 
            // distanceCount
            // 
            this.distanceCount.BackColor = System.Drawing.Color.White;
            this.distanceCount.Location = new System.Drawing.Point(101, 230);
            this.distanceCount.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.distanceCount.Name = "distanceCount";
            this.distanceCount.Size = new System.Drawing.Size(34, 20);
            this.distanceCount.TabIndex = 5;
            this.distanceCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkAscii
            // 
            this.checkAscii.AutoSize = true;
            this.checkAscii.Checked = true;
            this.checkAscii.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAscii.Location = new System.Drawing.Point(12, 161);
            this.checkAscii.Name = "checkAscii";
            this.checkAscii.Size = new System.Drawing.Size(87, 17);
            this.checkAscii.TabIndex = 6;
            this.checkAscii.Text = "Check ASCII";
            this.checkAscii.UseVisualStyleBackColor = true;
            this.checkAscii.Click += new System.EventHandler(this.checkAscii_Click);
            // 
            // checkNonAscii
            // 
            this.checkNonAscii.AutoSize = true;
            this.checkNonAscii.Checked = true;
            this.checkNonAscii.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkNonAscii.Location = new System.Drawing.Point(12, 184);
            this.checkNonAscii.Name = "checkNonAscii";
            this.checkNonAscii.Size = new System.Drawing.Size(110, 17);
            this.checkNonAscii.TabIndex = 7;
            this.checkNonAscii.Text = "Check Non-ASCII";
            this.checkNonAscii.UseVisualStyleBackColor = true;
            this.checkNonAscii.Click += new System.EventHandler(this.checkNonAscii_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Distance Count:";
            // 
            // Form1_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(205, 281);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkNonAscii);
            this.Controls.Add(this.checkAscii);
            this.Controls.Add(this.distanceCount);
            this.Controls.Add(this.checkAll);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.distinctCheckBox);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1_1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.distanceCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.CheckedListBox checkedListBox1;
        public System.Windows.Forms.CheckBox distinctCheckBox;
        public System.Windows.Forms.CheckBox checkAll;
        internal System.Windows.Forms.NumericUpDown distanceCount;
        public System.Windows.Forms.CheckBox checkAscii;
        public System.Windows.Forms.CheckBox checkNonAscii;
        private System.Windows.Forms.Label label1;
    }
}