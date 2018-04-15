using System;
using SimpleImages;
using System.Windows.Forms;
using System.Drawing;

namespace RadioImageConverter
{
    public partial class mainForm : Form
    {
        #region Variables and Objects
        // Used to handle the user's settings between sessions
        private string selectedPath;
        private Image inputImage, outputImage;
        private bool openMultiple = false;
        // Constants for UI arrangement
        private const int padding = 9;
        private const int startLocationX = 12;
        private const int startLocationY = 28;
        #endregion

        public mainForm()
        {
            InitializeComponent();
            //this.BackColor = SystemColors.;
            updateUI();
        }

        /// <summary>
        /// Updates the UI elements to appropriate locations
        /// </summary>
        private void updateUI()
        {
            // Arrange the UI for single file processing
            if (!openMultiple)
            {
                // Hide/show appropriate UI elements
                imageSelect_checkListBox.Hide();
                label1.Hide();
                label4.Show();
                fileName_textBox.Show();
                // Move used elements to the top left of the screen
                label2.Location = new Point(startLocationX, startLocationY);
            }
            else
            {
                // Hide/show appropriate UI elements
                imageSelect_checkListBox.Show();
                label1.Show();
                label4.Hide();
                fileName_textBox.Hide();
                // Move used elements to the top left of the screen
                label1.Location = new Point(startLocationX, startLocationY);
                label2.Location = new Point(startLocationX + label1.Width + padding, startLocationY);
            }
            // Adjust the rest of the elements accordingly
            input_PitcureBox.Location = new Point(label2.Location.X, startLocationY +label2.Height + padding);
            label3.Location = new Point(label2.Location.X + input_PitcureBox.Width, startLocationY);
            output_PictureBox.Location = new Point(label3.Location.X, startLocationY + padding + label3.Height);
        }

        /// <summary>
        /// Updates the pictureBox elements accordingly
        /// </summary>
        private void UpdateImages()
        {
            input_PitcureBox.Image = SimpleImageProcessor.Resize(inputImage, new Size(200,170));
            outputImage = SimpleImageProcessor.Resize(inputImage, new Size(32, 32));
            outputImage = SimpleImageProcessor.GetIndexedBitmap(outputImage, 4);
            output_PictureBox.Image = outputImage;
        }

        private void openMultipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateUI();
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.RootFolder = Environment.SpecialFolder.MyPictures;
            if(folderBrowser.ShowDialog() == DialogResult.OK)
            {
                selectedPath = folderBrowser.SelectedPath;
                if (!openMultiple)
                {
                    openMultiple = true;
                    updateUI();
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            string defaultpath = "@C:/Users" + Environment.UserName + "/Pictures";
            openFile.InitialDirectory = defaultpath;
            openFile.Filter = "Image Files| *.BMP; *.JPG; *.GIF";
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                inputImage = Image.FromFile(openFile.FileName);
                if (openMultiple)
                {
                    openMultiple = false;
                    updateUI();
                }
                UpdateImages();
            }
        }
    }
}
