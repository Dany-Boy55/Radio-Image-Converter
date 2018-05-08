using System;
using System.IO;
using SimpleImages;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace RadioImageConverter
{
    public partial class mainForm : Form
    {
        #region Variables and Objects
#if DEBUG
        private string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
#endif
        // Used to handle the user's settings between sessions
        private string importPath;
        private string exportPath;
        private string imageName;
        private string[] imageFileNames;
        private Image inputImage, outputImage;
        private bool openMultiple = false;
        // Constants for UI arrangement
        private const int padding = 9;
        private const int startLocationX = 12;
        private const int startLocationY = 28;
        private const int maxChar = 6;
        // Constants for Image settings
        private string[] messages = {"Select an Image" , "Select a source Folder", ""};
        private char[] disallowedChars = { ' ', ',', '.', '-', '_'};
        #endregion

        /// <summary>
        /// Initializer for the main form, called when the application starts
        /// </summary>
        public mainForm()
        {
#if DEBUG
            Debug.WriteLine("Debug mode enabled\t" + version);
#endif
            InitializeComponent();
            // As soon as the form shows, make sure the UI elements are propperly sized
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
            // Show input Image with correct picturebox size
            input_PitcureBox.Image = SimpleImageProcessor.Resize(inputImage, input_PitcureBox.Size);
            // Convert output image with desired parameters
            outputImage = SimpleImageProcessor.Resize(inputImage, new Size(64, 32));
            outputImage = SimpleImageProcessor.GetIndexedBitmap(outputImage, 4);
            // Show output image
            output_PictureBox.Size = outputImage.Size;
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
                importPath = folderBrowser.SelectedPath;
                if (!openMultiple)
                {
                    openMultiple = true;
                }
                imageFileNames = Directory.GetFiles(importPath);
                UpdateUI();
                foreach (string item in Directory.EnumerateFiles(importPath))
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
            if (outputImage == null)
                MessageBox.Show("please import an image first", "Error while exporting");
            else
                if (exportPath == null)
                    exportFolderToolStripMenuItem_Click(new object(), new EventArgs());
            try
            {
                outputImage.Save(exportPath + "/" + imageName + ".bmp");
                MessageBox.Show("Image " + imageName + " saved to " + exportPath, "Export successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while exporting");
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
            // Show the user the image they selcted (not very elegant implementation but works for now)
            string fileName = ((CheckedListBox)sender).SelectedItem.ToString();
            fileName = fileName.Replace("\\","/");
            inputImage = Image.FromFile(fileName);
            UpdateImages();
        }

        private void exportFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = "@C:/Users/" + Environment.UserName + "/";
            saveDialog.Title = "Select a folder for export";
            saveDialog.FileName = "Save Exports Here";
            saveDialog.OverwritePrompt = false;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                exportPath = Path.GetDirectoryName(saveDialog.FileName);
                exportPath = exportPath.Replace("\\", "/");
            }
        }

        /// <summary>
        /// Called when the user clicks the view full size image menu option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewFullSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputImage == null)
                MessageBox.Show("Please import an image first", "Error");
            else
            {
                // Show in a new form 
                Form fullSizeImageForm = new Form();
                fullSizeImageForm.BackgroundImage = inputImage;
                fullSizeImageForm.Size = inputImage.Size;
                fullSizeImageForm.Show();
            }
        }

        /// <summary>
        /// Called when the user completes a drag drop into the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainForm_DragDrop(object sender, DragEventArgs e)
        {
            // If the dropped item is not an image, ignore it
            if (e.Data.GetDataPresent(typeof(Bitmap)))
            {
                inputImage = (Bitmap)e.Data.GetData(typeof(Bitmap));
                Debug.WriteLine(e.Data.GetType().ToString());
                UpdateImages();
            }
        }

        private void mainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// Called when the user tries to open a single image file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Promt the user to select a single image file
            OpenFileDialog openFile = new OpenFileDialog();
            string defaultpath = "@C:/Users" + Environment.UserName + "/Pictures";
            openFile.InitialDirectory = defaultpath;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                // Retrieve the filename with path from the selected image
                string fileName = openFile.FileName;
                // Separate path and the filename no extension
                importPath = Path.GetFullPath(fileName);
                imageName = Path.GetFileNameWithoutExtension(fileName);
                // Load the image
                inputImage = Image.FromFile(fileName);
                fileName_textBox.Text = imageName;
                // Change the UI accordingly
                if (openMultiple)
                {
                    openMultiple = false;
                    UpdateUI();
                }
                // Presenet the new images
                UpdateImages();
            }
        }
    }
}
