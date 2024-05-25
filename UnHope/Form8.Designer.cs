namespace UnHope
{
    partial class Form8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8));
            this.asterisk = new System.Windows.Forms.Button();
            this.beep = new System.Windows.Forms.Button();
            this.exclamation = new System.Windows.Forms.Button();
            this.hand = new System.Windows.Forms.Button();
            this.question = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.buttonComboBox = new System.Windows.Forms.ComboBox();
            this.iconComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.optionCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.captionTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.defaultButtonComboBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // asterisk
            // 
            this.asterisk.BackColor = System.Drawing.Color.White;
            this.asterisk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.asterisk.Location = new System.Drawing.Point(25, 12);
            this.asterisk.Name = "asterisk";
            this.asterisk.Size = new System.Drawing.Size(73, 23);
            this.asterisk.TabIndex = 33;
            this.asterisk.Text = "Asterisk";
            this.asterisk.UseVisualStyleBackColor = false;
            this.asterisk.Click += new System.EventHandler(this.asterisk_Click);
            // 
            // beep
            // 
            this.beep.BackColor = System.Drawing.Color.White;
            this.beep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.beep.Location = new System.Drawing.Point(25, 41);
            this.beep.Name = "beep";
            this.beep.Size = new System.Drawing.Size(73, 23);
            this.beep.TabIndex = 34;
            this.beep.Text = "Beep";
            this.beep.UseVisualStyleBackColor = false;
            this.beep.Click += new System.EventHandler(this.beep_Click);
            // 
            // exclamation
            // 
            this.exclamation.BackColor = System.Drawing.Color.White;
            this.exclamation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exclamation.Location = new System.Drawing.Point(25, 70);
            this.exclamation.Name = "exclamation";
            this.exclamation.Size = new System.Drawing.Size(73, 23);
            this.exclamation.TabIndex = 35;
            this.exclamation.Text = "Exclamation";
            this.exclamation.UseVisualStyleBackColor = false;
            this.exclamation.Click += new System.EventHandler(this.exclamation_Click);
            // 
            // hand
            // 
            this.hand.BackColor = System.Drawing.Color.White;
            this.hand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hand.Location = new System.Drawing.Point(25, 99);
            this.hand.Name = "hand";
            this.hand.Size = new System.Drawing.Size(73, 23);
            this.hand.TabIndex = 36;
            this.hand.Text = "Hand";
            this.hand.UseVisualStyleBackColor = false;
            this.hand.Click += new System.EventHandler(this.hand_Click);
            // 
            // question
            // 
            this.question.BackColor = System.Drawing.Color.White;
            this.question.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.question.Location = new System.Drawing.Point(25, 128);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(73, 23);
            this.question.TabIndex = 37;
            this.question.Text = "Question";
            this.question.UseVisualStyleBackColor = false;
            this.question.Click += new System.EventHandler(this.question_Click);
            // 
            // runButton
            // 
            this.runButton.BackColor = System.Drawing.Color.White;
            this.runButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.runButton.Location = new System.Drawing.Point(400, 111);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(73, 23);
            this.runButton.TabIndex = 38;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // buttonComboBox
            // 
            this.buttonComboBox.BackColor = System.Drawing.Color.White;
            this.buttonComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonComboBox.FormattingEnabled = true;
            this.buttonComboBox.Items.AddRange(new object[] {
            "OK",
            "OKCancel",
            "AbortRetryIgnore",
            "YesNoCancel",
            "YesNo",
            "RetryCancel"});
            this.buttonComboBox.Location = new System.Drawing.Point(234, 3);
            this.buttonComboBox.MaxLength = 9;
            this.buttonComboBox.Name = "buttonComboBox";
            this.buttonComboBox.Size = new System.Drawing.Size(140, 21);
            this.buttonComboBox.TabIndex = 39;
            this.buttonComboBox.Text = "Chooose Button";
            // 
            // iconComboBox
            // 
            this.iconComboBox.BackColor = System.Drawing.Color.White;
            this.iconComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconComboBox.FormattingEnabled = true;
            this.iconComboBox.Items.AddRange(new object[] {
            "None",
            "Hand",
            "Question",
            "Exclamation",
            "Asterisk",
            "Stop",
            "Error",
            "Warning",
            "Information"});
            this.iconComboBox.Location = new System.Drawing.Point(234, 30);
            this.iconComboBox.MaxLength = 9;
            this.iconComboBox.Name = "iconComboBox";
            this.iconComboBox.Size = new System.Drawing.Size(140, 21);
            this.iconComboBox.TabIndex = 40;
            this.iconComboBox.Text = "Chooose Icon";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.optionCheckedListBox);
            this.panel1.Controls.Add(this.resultLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.captionTextBox);
            this.panel1.Controls.Add(this.titleTextBox);
            this.panel1.Controls.Add(this.runButton);
            this.panel1.Controls.Add(this.defaultButtonComboBox);
            this.panel1.Controls.Add(this.iconComboBox);
            this.panel1.Controls.Add(this.buttonComboBox);
            this.panel1.Location = new System.Drawing.Point(113, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 139);
            this.panel1.TabIndex = 41;
            // 
            // optionCheckedListBox
            // 
            this.optionCheckedListBox.FormattingEnabled = true;
            this.optionCheckedListBox.Items.AddRange(new object[] {
            "ServiceNotification",
            "DefaultDesktopOnly",
            "RightAlign",
            "RtlReading"});
            this.optionCheckedListBox.Location = new System.Drawing.Point(380, 3);
            this.optionCheckedListBox.Name = "optionCheckedListBox";
            this.optionCheckedListBox.Size = new System.Drawing.Size(120, 64);
            this.optionCheckedListBox.TabIndex = 49;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(231, 111);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 13);
            this.resultLabel.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Caption:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Title:";
            // 
            // captionTextBox
            // 
            this.captionTextBox.Location = new System.Drawing.Point(55, 29);
            this.captionTextBox.Multiline = true;
            this.captionTextBox.Name = "captionTextBox";
            this.captionTextBox.Size = new System.Drawing.Size(162, 76);
            this.captionTextBox.TabIndex = 44;
            this.captionTextBox.Text = "This is caption";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(55, 3);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(162, 20);
            this.titleTextBox.TabIndex = 43;
            this.titleTextBox.Text = "This is title";
            // 
            // defaultButtonComboBox
            // 
            this.defaultButtonComboBox.BackColor = System.Drawing.Color.White;
            this.defaultButtonComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.defaultButtonComboBox.FormattingEnabled = true;
            this.defaultButtonComboBox.Items.AddRange(new object[] {
            "Button1",
            "Button2",
            "Button3"});
            this.defaultButtonComboBox.Location = new System.Drawing.Point(234, 57);
            this.defaultButtonComboBox.MaxLength = 9;
            this.defaultButtonComboBox.Name = "defaultButtonComboBox";
            this.defaultButtonComboBox.Size = new System.Drawing.Size(140, 21);
            this.defaultButtonComboBox.TabIndex = 41;
            this.defaultButtonComboBox.Text = "Chooose Default Button";
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(626, 163);
            this.Controls.Add(this.question);
            this.Controls.Add(this.hand);
            this.Controls.Add(this.exclamation);
            this.Controls.Add(this.beep);
            this.Controls.Add(this.asterisk);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Form8_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button asterisk;
        private System.Windows.Forms.Button beep;
        private System.Windows.Forms.Button exclamation;
        private System.Windows.Forms.Button hand;
        private System.Windows.Forms.Button question;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.ComboBox buttonComboBox;
        private System.Windows.Forms.ComboBox iconComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox captionTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.ComboBox defaultButtonComboBox;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.CheckedListBox optionCheckedListBox;
    }
}