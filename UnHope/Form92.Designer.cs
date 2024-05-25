namespace UnHope
{
    partial class Form92
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
            this.generateButton = new System.Windows.Forms.Button();
            this.syntaxBox = new System.Windows.Forms.TextBox();
            this.collectionBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.selectedIndexLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(272, 133);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // syntaxBox
            // 
            this.syntaxBox.Font = new System.Drawing.Font("Arial", 12F);
            this.syntaxBox.Location = new System.Drawing.Point(12, 32);
            this.syntaxBox.Multiline = true;
            this.syntaxBox.Name = "syntaxBox";
            this.syntaxBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.syntaxBox.Size = new System.Drawing.Size(411, 95);
            this.syntaxBox.TabIndex = 1;
            this.syntaxBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.syntaxBox_KeyUp);
            this.syntaxBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.syntaxBox_MouseDown);
            // 
            // collectionBox
            // 
            this.collectionBox.Font = new System.Drawing.Font("Arial", 12F);
            this.collectionBox.Location = new System.Drawing.Point(429, 32);
            this.collectionBox.Multiline = true;
            this.collectionBox.Name = "collectionBox";
            this.collectionBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.collectionBox.Size = new System.Drawing.Size(177, 95);
            this.collectionBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Code Syntax:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(425, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Collection:";
            // 
            // selectedIndexLabel
            // 
            this.selectedIndexLabel.AutoSize = true;
            this.selectedIndexLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedIndexLabel.Location = new System.Drawing.Point(12, 133);
            this.selectedIndexLabel.Name = "selectedIndexLabel";
            this.selectedIndexLabel.Size = new System.Drawing.Size(127, 20);
            this.selectedIndexLabel.TabIndex = 5;
            this.selectedIndexLabel.Text = "Selected Index : ";
            // 
            // Form92
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(618, 161);
            this.Controls.Add(this.selectedIndexLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.collectionBox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.syntaxBox);
            this.Name = "Form92";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "C# Coder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox syntaxBox;
        private System.Windows.Forms.TextBox collectionBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label selectedIndexLabel;
    }
}