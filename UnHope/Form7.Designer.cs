namespace UnHope
{
    partial class Form7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxR = new System.Windows.Forms.TextBox();
            this.textBoxG = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.trackBarR = new System.Windows.Forms.TrackBar();
            this.trackBarG = new System.Windows.Forms.TrackBar();
            this.trackBarB = new System.Windows.Forms.TrackBar();
            this.labelR = new System.Windows.Forms.Label();
            this.labelG = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.hexaCode = new System.Windows.Forms.TextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.stepBox = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.spectrum = new System.Windows.Forms.PictureBox();
            this.colorName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spectrum)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 12);
            this.progressBar1.Maximum = 16777216;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(632, 23);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Value = 5;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxR
            // 
            this.textBoxR.BackColor = System.Drawing.Color.White;
            this.textBoxR.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxR.Location = new System.Drawing.Point(609, 22);
            this.textBoxR.MaxLength = 3;
            this.textBoxR.Name = "textBoxR";
            this.textBoxR.Size = new System.Drawing.Size(31, 25);
            this.textBoxR.TabIndex = 1;
            this.textBoxR.Text = "0";
            this.textBoxR.TextChanged += new System.EventHandler(this.textBoxR_TextChanged);
            this.textBoxR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_JustNumber);
            this.textBoxR.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // textBoxG
            // 
            this.textBoxG.BackColor = System.Drawing.Color.White;
            this.textBoxG.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxG.Location = new System.Drawing.Point(609, 73);
            this.textBoxG.MaxLength = 3;
            this.textBoxG.Name = "textBoxG";
            this.textBoxG.Size = new System.Drawing.Size(31, 25);
            this.textBoxG.TabIndex = 2;
            this.textBoxG.Text = "0";
            this.textBoxG.TextChanged += new System.EventHandler(this.textBoxG_TextChanged);
            this.textBoxG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_JustNumber);
            this.textBoxG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // textBoxB
            // 
            this.textBoxB.BackColor = System.Drawing.Color.White;
            this.textBoxB.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxB.Location = new System.Drawing.Point(609, 124);
            this.textBoxB.MaxLength = 3;
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(31, 25);
            this.textBoxB.TabIndex = 3;
            this.textBoxB.Text = "0";
            this.textBoxB.TextChanged += new System.EventHandler(this.textBoxB_TextChanged);
            this.textBoxB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_JustNumber);
            this.textBoxB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // trackBarR
            // 
            this.trackBarR.LargeChange = 15;
            this.trackBarR.Location = new System.Drawing.Point(64, 12);
            this.trackBarR.Maximum = 255;
            this.trackBarR.Name = "trackBarR";
            this.trackBarR.Size = new System.Drawing.Size(539, 45);
            this.trackBarR.SmallChange = 5;
            this.trackBarR.TabIndex = 4;
            this.trackBarR.Scroll += new System.EventHandler(this.trackBarR_Scroll);
            this.trackBarR.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // trackBarG
            // 
            this.trackBarG.LargeChange = 15;
            this.trackBarG.Location = new System.Drawing.Point(64, 63);
            this.trackBarG.Maximum = 255;
            this.trackBarG.Name = "trackBarG";
            this.trackBarG.Size = new System.Drawing.Size(539, 45);
            this.trackBarG.SmallChange = 5;
            this.trackBarG.TabIndex = 5;
            this.trackBarG.Scroll += new System.EventHandler(this.trackBarG_Scroll);
            this.trackBarG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // trackBarB
            // 
            this.trackBarB.LargeChange = 15;
            this.trackBarB.Location = new System.Drawing.Point(64, 114);
            this.trackBarB.Maximum = 255;
            this.trackBarB.Name = "trackBarB";
            this.trackBarB.Size = new System.Drawing.Size(539, 45);
            this.trackBarB.SmallChange = 5;
            this.trackBarB.TabIndex = 6;
            this.trackBarB.Scroll += new System.EventHandler(this.trackBarB_Scroll);
            this.trackBarB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // labelR
            // 
            this.labelR.AutoSize = true;
            this.labelR.BackColor = System.Drawing.Color.Transparent;
            this.labelR.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR.ForeColor = System.Drawing.Color.White;
            this.labelR.Location = new System.Drawing.Point(12, 26);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(34, 16);
            this.labelR.TabIndex = 8;
            this.labelR.Text = "Red:";
            this.labelR.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // labelG
            // 
            this.labelG.AutoSize = true;
            this.labelG.BackColor = System.Drawing.Color.Transparent;
            this.labelG.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelG.ForeColor = System.Drawing.Color.White;
            this.labelG.Location = new System.Drawing.Point(12, 77);
            this.labelG.Name = "labelG";
            this.labelG.Size = new System.Drawing.Size(46, 16);
            this.labelG.TabIndex = 9;
            this.labelG.Text = "Green:";
            this.labelG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.BackColor = System.Drawing.Color.Transparent;
            this.labelB.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelB.ForeColor = System.Drawing.Color.White;
            this.labelB.Location = new System.Drawing.Point(12, 128);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(37, 16);
            this.labelB.TabIndex = 10;
            this.labelB.Text = "Blue:";
            this.labelB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // hexaCode
            // 
            this.hexaCode.BackColor = System.Drawing.Color.White;
            this.hexaCode.ContextMenuStrip = this.contextMenuStrip2;
            this.hexaCode.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexaCode.Location = new System.Drawing.Point(575, 165);
            this.hexaCode.MaxLength = 7;
            this.hexaCode.Name = "hexaCode";
            this.hexaCode.Size = new System.Drawing.Size(69, 25);
            this.hexaCode.TabIndex = 15;
            this.hexaCode.Text = "#000000";
            this.hexaCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hexaCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hexaCode_KeyPress);
            this.hexaCode.Validated += new System.EventHandler(this.hexaCode_Validated);
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
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // intervalBox
            // 
            this.intervalBox.BackColor = System.Drawing.Color.White;
            this.intervalBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intervalBox.Location = new System.Drawing.Point(148, 165);
            this.intervalBox.MaxLength = 4;
            this.intervalBox.Name = "intervalBox";
            this.intervalBox.Size = new System.Drawing.Size(40, 25);
            this.intervalBox.TabIndex = 17;
            this.intervalBox.Text = "1";
            this.intervalBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.intervalBox.TextChanged += new System.EventHandler(this.null_TextChanged);
            this.intervalBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_JustNumber);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(218, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Step:";
            // 
            // stepBox
            // 
            this.stepBox.BackColor = System.Drawing.Color.White;
            this.stepBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepBox.Location = new System.Drawing.Point(262, 194);
            this.stepBox.MaxLength = 4;
            this.stepBox.Name = "stepBox";
            this.stepBox.Size = new System.Drawing.Size(40, 25);
            this.stepBox.TabIndex = 20;
            this.stepBox.Text = "1";
            this.stepBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stepBox.TextChanged += new System.EventHandler(this.null_TextChanged);
            this.stepBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_JustNumber);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.Black;
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.ForeColor = System.Drawing.Color.White;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Timer ",
            "Timer Random",
            "Mouse Move Random",
            "Spectrum Select"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 165);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(130, 60);
            this.checkedListBox1.TabIndex = 21;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(187, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "ms";
            // 
            // spectrum
            // 
            this.spectrum.Image = global::UnHope.Properties.Resources.rgbSpectrum;
            this.spectrum.Location = new System.Drawing.Point(101, 12);
            this.spectrum.Name = "spectrum";
            this.spectrum.Size = new System.Drawing.Size(226, 156);
            this.spectrum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.spectrum.TabIndex = 23;
            this.spectrum.TabStop = false;
            this.spectrum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.spectrum.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.spectrum.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // colorName
            // 
            this.colorName.BackColor = System.Drawing.Color.White;
            this.colorName.ContextMenuStrip = this.contextMenuStrip2;
            this.colorName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorName.Location = new System.Drawing.Point(575, 196);
            this.colorName.MaxLength = 7;
            this.colorName.Name = "colorName";
            this.colorName.Size = new System.Drawing.Size(69, 25);
            this.colorName.TabIndex = 24;
            this.colorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(656, 230);
            this.Controls.Add(this.colorName);
            this.Controls.Add(this.spectrum);
            this.Controls.Add(this.hexaCode);
            this.Controls.Add(this.labelB);
            this.Controls.Add(this.labelG);
            this.Controls.Add(this.labelR);
            this.Controls.Add(this.textBoxB);
            this.Controls.Add(this.textBoxG);
            this.Controls.Add(this.textBoxR);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.stepBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.intervalBox);
            this.Controls.Add(this.trackBarG);
            this.Controls.Add(this.trackBarR);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.trackBarB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RGB";
            this.Load += new System.EventHandler(this.Form7_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.Resize += new System.EventHandler(this.Form7_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spectrum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxR;
        private System.Windows.Forms.TextBox textBoxG;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.TrackBar trackBarR;
        private System.Windows.Forms.TrackBar trackBarG;
        private System.Windows.Forms.TrackBar trackBarB;
        private System.Windows.Forms.Label labelR;
        private System.Windows.Forms.Label labelG;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.TextBox hexaCode;
        private System.Windows.Forms.TextBox intervalBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stepBox;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox spectrum;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TextBox colorName;
    }
}