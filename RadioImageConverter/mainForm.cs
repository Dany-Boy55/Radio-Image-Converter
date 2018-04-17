using System;
using System.IO;
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
        private string[] imageFileNames;
        private Image inputImage, outputImage;
        private bool openMultiple = false;
        private string imageName = "";
        // Constants for UI arrangement
        private const int padding = 9;
        private const int startLocationX = 12;
        private const int startLocationY = 28;
        private const int maxChar = 6;
        // Constants for Image settings
        private char[] disallowedChars = { ' ', ',', '.', '-', '_'};
        #endregion

        /// <summary>
        /// Initializer for the main form, called when the application starts
        /// </summary>
        public mainForm()
        {
            InitializeComponent();
            //this.BackColor = SystemColors.;
            UpdateUI();
        }

        /// <summary>
        /// Updates the UI elements to appropriate locations
        /// </summary>
        private void UpdateUI()
        {
            // Arrange the UI for single file processing
            if (!openMultiple)
            {
                // Hide/show appropriate UI elements
                imageSelect_checkListBox.Hide();
                label1.Hide();
                label4.Show();
                fileName_textBox.Show();
                export_Button.Text = "Export";
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
                export_Button.Text = "Export Selected";
                // Move used elements to the top left of the screen
                label1.Location = new Point(startLocationX, startLocationY);
                label2.Location = new Point(startLocationX + imageSelect_checkListBox.Width + padding, startLocationY);
            }
            if (outputImage == null)
                export_Button.Enabled = false;
            // Adjust the rest of the elements accordingly
            input_PitcureBox.Location = new Point(label2.Location.X, startLocationY + label2.Height + padding);
            label3.Location = new Point(label2.Location.X + input_PitcureBox.Width + padding, startLocationY);
            output_PictureBox.Location = new Point(label3.Location.X, startLocationY + padding + label3.Height);
        }

        /// <summary>
        /// Updates the pictureBox elements accordingly
        /// </summary>
        private void UpdateImages()
        {
            input_PitcureBox.Image = SimpleImageProcessor.Resize(inputImage, new Size(200,170));
            outputImage = SimpleImageProcessor.Resize(inputImage, new Size(64, 32));
            outputImage = SimpleImageProcessor.GetIndexedBitmap(outputImage, 4);
            output_PictureBox.Image = outputImage;
        }

        /// <summary>
        /// Called when the user tries to open multiple imagefiles from within a folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openMultipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                selectedPath = folderBrowser.SelectedPath;
                if (!openMultiple)
                {
                    openMultiple = true;
                }
                imageFileNames = Directory.GetFiles(selectedPath);
                UpdateUI();
                foreach (string item in Directory.EnumerateFiles(selectedPath))
                {
                    if(item.Contains(".jpg") || item.Contains(".bmp") || item.Contains(".png"))
                    {
                        Console.WriteLine(item);
                        imageSelect_checkListBox.Items.Add(item, CheckState.Checked);
                    }
                }
            }
        }

        /// <summary>
        /// Called when the user tries to export output image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void export_Button_Click(object sender, EventArgs e)
        {
            if (!openMultiple)
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                if(folder.ShowDialog() == DialogResult.OK)
                {
                    string fileName = folder.SelectedPath + "\\" + fileName_textBox.Text + ".bmp";
                    Console.WriteLine(fileName);
                    try
                    {
                        outputImage.Save(fileName);
                    }
                    catch
                    {
                        MessageBox.Show("Error while saving output image");
                    }
                    
                }
            }
        }

        /// <summary>
        /// Called when the fileName_textBox changes its taxt to ensure it meets certain criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileName_textBox_TextChanged(object sender, EventArgs e)
        {
            imageName = fileName_textBox.Text;
            // fileName no larger than maxNameLength depends on the particular radio system
            if(imageName.Length >= 10)
            {
                imageName = imageName.Remove(0, imageName.Length - 10);
                fileName_textBox.Text = imageName;
            }
            // fileName cannot contain disallowedCharacters
            imageName = imageName.Trim(disallowedChars);
        }

        /// <summary>
        /// When the main form finishes a resize operation, adjust UI and images accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainForm_Resize(object sender, EventArgs e)
        {
            UpdateUI();
            if (inputImage != null)
                UpdateImages();
        }

        /// <summary>
        /// Called when the user selects a single item from the checkListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageSelect_checkListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fileName = ((CheckedListBox)sender).SelectedItem.ToString();
            fileName = fileName.Replace("\\","/");
            inputImage = Image.FromFile(fileName);
            UpdateImages();
        }

        /// <summary>
        /// Called when the user tries to open a single image file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            string defaultpath = "@C:/Users" + Environment.UserName + "/Pictures";
            openFile.InitialDirectory = defaultpath;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                inputImage = Image.FromFile(openFile.FileName);
                Console.WriteLine(openFile.FileName);
                imageName = openFile.SafeFileName.Trim();
                fileName_textBox.Text = imageName;
                if (openMultiple)
                {
                    openMultiple = false;
                    UpdateUI();
                }
                UpdateImages();
            }
        }
    }
}
