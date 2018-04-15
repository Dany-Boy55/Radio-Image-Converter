namespace RadioImageConverter
{
    partial class mainForm
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMultipleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSelect_checkListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.input_PitcureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.output_PictureBox = new System.Windows.Forms.PictureBox();
            this.fileName_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.export_Button = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_PitcureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.output_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.imageSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(429, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openMultipleToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openMultipleToolStripMenuItem
            // 
            this.openMultipleToolStripMenuItem.Name = "openMultipleToolStripMenuItem";
            this.openMultipleToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openMultipleToolStripMenuItem.Text = "Open Multiple";
            this.openMultipleToolStripMenuItem.Click += new System.EventHandler(this.openMultipleToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // imageSettingsToolStripMenuItem
            // 
            this.imageSettingsToolStripMenuItem.Name = "imageSettingsToolStripMenuItem";
            this.imageSettingsToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.imageSettingsToolStripMenuItem.Text = "Image Settings";
            // 
            // imageSelect_checkListBox
            // 
            this.imageSelect_checkListBox.FormattingEnabled = true;
            this.imageSelect_checkListBox.Location = new System.Drawing.Point(12, 48);
            this.imageSelect_checkListBox.Name = "imageSelect_checkListBox";
            this.imageSelect_checkListBox.Size = new System.Drawing.Size(120, 191);
            this.imageSelect_checkListBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Images:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Source Image";
            // 
            // input_PitcureBox
            // 
            this.input_PitcureBox.Location = new System.Drawing.Point(139, 49);
            this.input_PitcureBox.Name = "input_PitcureBox";
            this.input_PitcureBox.Size = new System.Drawing.Size(200, 170);
            this.input_PitcureBox.TabIndex = 4;
            this.input_PitcureBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output";
            // 
            // output_PictureBox
            // 
            this.output_PictureBox.Location = new System.Drawing.Point(345, 49);
            this.output_PictureBox.Name = "output_PictureBox";
            this.output_PictureBox.Size = new System.Drawing.Size(50, 50);
            this.output_PictureBox.TabIndex = 6;
            this.output_PictureBox.TabStop = false;
            // 
            // fileName_textBox
            // 
            this.fileName_textBox.Location = new System.Drawing.Point(83, 247);
            this.fileName_textBox.Name = "fileName_textBox";
            this.fileName_textBox.Size = new System.Drawing.Size(100, 22);
            this.fileName_textBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Filename";
            // 
            // export_Button
            // 
            this.export_Button.Location = new System.Drawing.Point(189, 246);
            this.export_Button.Name = "export_Button";
            this.export_Button.Size = new System.Drawing.Size(75, 23);
            this.export_Button.TabIndex = 9;
            this.export_Button.Text = "Export";
            this.export_Button.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 290);
            this.Controls.Add(this.export_Button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fileName_textBox);
            this.Controls.Add(this.output_PictureBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.input_PitcureBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageSelect_checkListBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_PitcureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.output_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMultipleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageSettingsToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox imageSelect_checkListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox input_PitcureBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox output_PictureBox;
        private System.Windows.Forms.TextBox fileName_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button export_Button;
    }
}

