namespace UnHope
{
    partial class Form1_3
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
            this.apply = new System.Windows.Forms.Button();
            this.oldString1 = new System.Windows.Forms.TextBox();
            this.newString1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addingTextBoxes = new System.Windows.Forms.Button();
            this.removingTextBoxes = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(187, 38);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(75, 23);
            this.apply.TabIndex = 0;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // oldString1
            // 
            this.oldString1.Location = new System.Drawing.Point(60, 12);
            this.oldString1.Name = "oldString1";
            this.oldString1.Size = new System.Drawing.Size(100, 20);
            this.oldString1.TabIndex = 1;
            // 
            // newString1
            // 
            this.newString1.Location = new System.Drawing.Point(226, 12);
            this.newString1.Name = "newString1";
            this.newString1.Size = new System.Drawing.Size(100, 20);
            this.newString1.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(361, 15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Special Char";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Old String";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "New String";
            // 
            // addingTextBoxes
            // 
            this.addingTextBoxes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addingTextBoxes.Location = new System.Drawing.Point(332, 12);
            this.addingTextBoxes.Name = "addingTextBoxes";
            this.addingTextBoxes.Size = new System.Drawing.Size(23, 23);
            this.addingTextBoxes.TabIndex = 6;
            this.addingTextBoxes.Text = "+";
            this.addingTextBoxes.UseVisualStyleBackColor = true;
            this.addingTextBoxes.Click += new System.EventHandler(this.addingTextBoxes_Click);
            // 
            // removingTextBoxes
            // 
            this.removingTextBoxes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removingTextBoxes.Location = new System.Drawing.Point(332, 38);
            this.removingTextBoxes.Name = "removingTextBoxes";
            this.removingTextBoxes.Size = new System.Drawing.Size(23, 23);
            this.removingTextBoxes.TabIndex = 7;
            this.removingTextBoxes.Text = "-";
            this.removingTextBoxes.UseVisualStyleBackColor = true;
            this.removingTextBoxes.Click += new System.EventHandler(this.removingTextBoxes_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(364, 38);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 8;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // Form1_3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(448, 67);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.removingTextBoxes);
            this.Controls.Add(this.addingTextBoxes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.newString1);
            this.Controls.Add(this.oldString1);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1_3";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replace";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_3_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_3_FormClosed);
            this.Load += new System.EventHandler(this.Form1_3_Load);
            this.Resize += new System.EventHandler(this.Form1_3_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button apply;
        public System.Windows.Forms.TextBox oldString1;
        public System.Windows.Forms.TextBox newString1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addingTextBoxes;
        private System.Windows.Forms.Button removingTextBoxes;
        public System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button clear;
    }
}