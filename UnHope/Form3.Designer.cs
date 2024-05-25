namespace UnHope
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Copy = new System.Windows.Forms.Button();
            this.Paste = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Input = new System.Windows.Forms.RichTextBox();
            this.Output = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip1.DropShadowEnabled = false;
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 70);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // Copy
            // 
            this.Copy.BackColor = System.Drawing.Color.White;
            this.Copy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Copy.Location = new System.Drawing.Point(222, 168);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(111, 21);
            this.Copy.TabIndex = 5;
            this.Copy.Text = "Copy";
            this.Copy.UseVisualStyleBackColor = false;
            this.Copy.Click += new System.EventHandler(this.button_Copy);
            // 
            // Paste
            // 
            this.Paste.BackColor = System.Drawing.Color.White;
            this.Paste.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Paste.Location = new System.Drawing.Point(111, 168);
            this.Paste.Name = "Paste";
            this.Paste.Size = new System.Drawing.Size(111, 21);
            this.Paste.TabIndex = 4;
            this.Paste.Text = "Paste";
            this.Paste.UseVisualStyleBackColor = false;
            this.Paste.Click += new System.EventHandler(this.button_Paste);
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.White;
            this.Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Clear.Location = new System.Drawing.Point(0, 168);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(111, 21);
            this.Clear.TabIndex = 3;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.button_Clear);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip2.DropShadowEnabled = false;
            this.contextMenuStrip2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(108, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem1.Text = "Copy";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.copytoolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Typographical Text",
            "Binary Code",
            "Octal Code",
            "Decimal Code",
            "Hexadecimal Code",
            "UTF-8 (Hex)",
            "UTF-16 (Hex)",
            "UTF-32 (Hex)",
            "Morse Code",
            "Normal Text",
            "Pascal Case",
            "Uppercase",
            "Lowercase",
            "Oppositecase Upper-Lowercase",
            "One By One Upper-Lowercase",
            "Reverse All",
            "Reverse Words",
            "Remove Gaps"});
            this.comboBox1.Location = new System.Drawing.Point(333, 168);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(176, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Typographical Text";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Input
            // 
            this.Input.BackColor = System.Drawing.Color.White;
            this.Input.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Input.Dock = System.Windows.Forms.DockStyle.Top;
            this.Input.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this.Input.Location = new System.Drawing.Point(0, 0);
            this.Input.Name = "Input";
            this.Input.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Input.Size = new System.Drawing.Size(509, 84);
            this.Input.TabIndex = 7;
            this.Input.Text = "sghlو hdk[h ldj,hkdn fvu;s fk,dsdn , kjd[i a v, ffdkdn آهو غخع زشد فغحث قثرثقسث &" +
    " سثث فاث قثسعمف";
            this.Input.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.Input.DoubleClick += new System.EventHandler(this.InputOutput_DoubleClick);
            // 
            // Output
            // 
            this.Output.BackColor = System.Drawing.Color.White;
            this.Output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Output.Dock = System.Windows.Forms.DockStyle.Top;
            this.Output.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this.Output.Location = new System.Drawing.Point(0, 84);
            this.Output.MaxLength = 999999999;
            this.Output.Name = "Output";
            this.Output.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Output.Size = new System.Drawing.Size(509, 84);
            this.Output.TabIndex = 8;
            this.Output.Text = "سلام, اینجا میتوانید برعکس بنویسید و نتیجه ش رو ببینید Hi, you can type reverse &" +
    " see the result";
            this.Output.DoubleClick += new System.EventHandler(this.InputOutput_DoubleClick);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(509, 189);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Paste);
            this.Controls.Add(this.Copy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Changer";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Copy;
        private System.Windows.Forms.Button Paste;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RichTextBox Input;
        private System.Windows.Forms.RichTextBox Output;
    }
}