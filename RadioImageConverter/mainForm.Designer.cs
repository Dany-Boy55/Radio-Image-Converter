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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.imageSelect_checkListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.input_PitcureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.output_PictureBox = new System.Windows.Forms.PictureBox();
            this.fileName_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.export_Button = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMultipleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taranisX9DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewFullSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.input_PitcureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.output_PictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageSelect_checkListBox
            // 
            this.imageSelect_checkListBox.FormattingEnabled = true;
            this.imageSelect_checkListBox.Location = new System.Drawing.Point(14, 60);
            this.imageSelect_checkListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.imageSelect_checkListBox.Name = "imageSelect_checkListBox";
            this.imageSelect_checkListBox.Size = new System.Drawing.Size(188, 214);
            this.imageSelect_checkListBox.TabIndex = 1;
            this.imageSelect_checkListBox.SelectedIndexChanged += new System.EventHandler(this.imageSelect_checkListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Images:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Source Image";
            // 
            // input_PitcureBox
            // 
            this.input_PitcureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input_PitcureBox.Location = new System.Drawing.Point(207, 61);
            this.input_PitcureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.input_PitcureBox.Name = "input_PitcureBox";
            this.input_PitcureBox.Size = new System.Drawing.Size(225, 212);
            this.input_PitcureBox.TabIndex = 4;
            this.input_PitcureBox.TabStop = false;
            this.input_PitcureBox.DoubleClick += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output";
            // 
            // output_PictureBox
            // 
            this.output_PictureBox.Location = new System.Drawing.Point(439, 61);
            this.output_PictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.output_PictureBox.Name = "output_PictureBox";
            this.output_PictureBox.Size = new System.Drawing.Size(72, 40);
            this.output_PictureBox.TabIndex = 6;
            this.output_PictureBox.TabStop = false;
            // 
            // fileName_textBox
            // 
            this.fileName_textBox.AllowDrop = true;
            this.fileName_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fileName_textBox.Location = new System.Drawing.Point(68, 299);
            this.fileName_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileName_textBox.Name = "fileName_textBox";
            this.fileName_textBox.Size = new System.Drawing.Size(165, 26);
            this.fileName_textBox.TabIndex = 7;
            this.fileName_textBox.TextChanged += new System.EventHandler(this.fileName_textBox_TextChanged);
            this.fileName_textBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.mainForm_DragDrop);
            this.fileName_textBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.mainForm_DragEnter);
            this.fileName_textBox.DoubleClick += new System.EventHandler(this.export_Button_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Name";
            // 
            // export_Button
            // 
            this.export_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.export_Button.Location = new System.Drawing.Point(240, 298);
            this.export_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.export_Button.Name = "export_Button";
            this.export_Button.Size = new System.Drawing.Size(84, 29);
            this.export_Button.TabIndex = 9;
            this.export_Button.Text = "Export";
            this.export_Button.UseVisualStyleBackColor = true;
            this.export_Button.Click += new System.EventHandler(this.export_Button_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openMultipleToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exportFolderToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(262, 30);
            this.openToolStripMenuItem.Text = "Import Image";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openMultipleToolStripMenuItem
            // 
            this.openMultipleToolStripMenuItem.Name = "openMultipleToolStripMenuItem";
            this.openMultipleToolStripMenuItem.Size = new System.Drawing.Size(262, 30);
            this.openMultipleToolStripMenuItem.Text = "Import Multiple...";
            this.openMultipleToolStripMenuItem.Click += new System.EventHandler(this.openMultipleToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(262, 30);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.export_Button_Click);
            // 
            // exportFolderToolStripMenuItem
            // 
            this.exportFolderToolStripMenuItem.Name = "exportFolderToolStripMenuItem";
            this.exportFolderToolStripMenuItem.Size = new System.Drawing.Size(262, 30);
            this.exportFolderToolStripMenuItem.Text = "Select Export folder...";
            this.exportFolderToolStripMenuItem.Click += new System.EventHandler(this.exportFolderToolStripMenuItem_Click);
            // 
            // imageSettingsToolStripMenuItem
            // 
            this.imageSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resolutionToolStripMenuItem,
            this.presetsToolStripMenuItem,
            this.viewFullSizeToolStripMenuItem});
            this.imageSettingsToolStripMenuItem.Name = "imageSettingsToolStripMenuItem";
            this.imageSettingsToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.imageSettingsToolStripMenuItem.Text = "Options";
            // 
            // resolutionToolStripMenuItem
            // 
            this.resolutionToolStripMenuItem.Name = "resolutionToolStripMenuItem";
            this.resolutionToolStripMenuItem.Size = new System.Drawing.Size(216, 30);
            this.resolutionToolStripMenuItem.Text = "Export Settings";
            // 
            // presetsToolStripMenuItem
            // 
            this.presetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taranisX9DToolStripMenuItem});
            this.presetsToolStripMenuItem.Name = "presetsToolStripMenuItem";
            this.presetsToolStripMenuItem.Size = new System.Drawing.Size(216, 30);
            this.presetsToolStripMenuItem.Text = "Presets";
            // 
            // taranisX9DToolStripMenuItem
            // 
            this.taranisX9DToolStripMenuItem.Name = "taranisX9DToolStripMenuItem";
            this.taranisX9DToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.taranisX9DToolStripMenuItem.Text = "Taranis X9D";
            // 
            // viewFullSizeToolStripMenuItem
            // 
            this.viewFullSizeToolStripMenuItem.Name = "viewFullSizeToolStripMenuItem";
            this.viewFullSizeToolStripMenuItem.Size = new System.Drawing.Size(216, 30);
            this.viewFullSizeToolStripMenuItem.Text = "View Full Size";
            this.viewFullSizeToolStripMenuItem.Click += new System.EventHandler(this.viewFullSizeToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.imageSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(593, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 348);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(543, 392);
            this.Name = "mainForm";
            this.Text = "Image Converter";
            this.ResizeEnd += new System.EventHandler(this.mainForm_Resize);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.mainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.mainForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.input_PitcureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.output_PictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckedListBox imageSelect_checkListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox input_PitcureBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox output_PictureBox;
        private System.Windows.Forms.TextBox fileName_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button export_Button;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMultipleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resolutionToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewFullSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taranisX9DToolStripMenuItem;
    }
}

