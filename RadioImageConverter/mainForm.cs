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
        private string[] imageFilePaths;
        private string[] imageNames;
        private Image inputImage, outputImage;
        private bool openMultiple = false;
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
                foreach (var item in imageNames)
                {
                    if(item != null)
                        imageSelect_checkListBox.Items.Add(item);
                }
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
            input_PitcureBox.Image = CartesianTransforms.Resize(inputImage, input_PitcureBox.Size);
            // Convert output image with desired parameters
            outputImage = CartesianTransforms.Resize(inputImage, new Size(64, 32));
            outputImage = CartesianTransforms.GetIndexedBitmap(outputImage, 4);
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
                imageFilePaths = Directory.GetFiles(importPath);
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
        // Stores all valid images in a directory within 'imageFilePaths' and 'imageNames'
        private void importMultiple(string dirPath)
        {
            string[] files = Directory.GetFiles(dirPath);
            // Get all file names within the dir
            string temppath = files[0];
            files = Directory.GetFiles(temppath);
            // if the files are not images delete them from the array
            for (int i = 0; i < files.Length; i++)
            {
                if (Path.GetExtension(files[i]) != ".png" && Path.GetExtension(files[i]) != ".jpg")
                    files[i] = null;
            }
            imageFilePaths = files;
            imageNames = files;
            for (int i = 0; i < imageFilePaths.Length; i++)
            {
                imageNames[i] = Path.GetFileNameWithoutExtension( imageFilePaths[i]);
            }
        }

        /// <summary>
        /// Called when the user tries to export output image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void export_Button_Click(object sender, EventArgs e)
        {
            // Check to see that everything we need is there, otherwise inform the user
            if (outputImage == null)
                MessageBox.Show("please import an image first", "Error while exporting");
            else
                if (exportPath == null)
                    exportFolderToolStripMenuItem_Click(new object(), new EventArgs());
            // If all is there, try to save the output image
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
            string _name = fileName_textBox.Text;
            
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

        /// <summary>
        /// Called when the user clicks on the menu option to change the export folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            // retrieve all the the paths that the user retreived
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            // Determine if its a single file, a directory, or multiple files
            if(files.Length == 1)
            {
                // The user droped a directory, open it and get all images in there
                if (!Path.HasExtension(files[0]))
                {
                    // Get all file names within the dir
                    importMultiple(files[0]);
                }

            }
            else
            {
                openMultiple = true;
                // If there are multiple paths, store only those that are images
                for (int i = 0; i < files.Length; i++)
                {
                    if (Path.GetExtension(files[i]) != ".png" &&  Path.GetExtension(files[i]) != ".jpg")
                        files[i] = null;
                }
                imageFilePaths = files;
                imageNames = files;
                for (int i = 0; i < imageFilePaths.Length; i++)
                {
                    imageNames[i] = Path.GetFileNameWithoutExtension(imageFilePaths[i]);
                }
            }
            UpdateUI();
        }

        /// <summary>
        /// Called when the user starts a drag operation in the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainForm_DragEnter(object sender, DragEventArgs e)
        {
            // Anything coming from file browser is treated as a file
            if (e.Data.GetDataPresent(DataFormats.FileDrop) || e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// Method to ensure the name of the image is valid for a radio system
        /// </summary>
        /// <param name="_name">original name to be validated</param>
        /// <returns>Valid image name for a radio system</returns>
        private string validImageName(string _name)
        {
            // fileName no larger than maxNameLength: depends on the particular radio system
            if (_name.Length >= 10)
                _name = _name.Remove(0, imageName.Length - 10);
            // fileName cannot start with a number
            if (Char.IsNumber(_name[0]))
                _name = _name.Remove(0, 1);
            // fileName cannot contain disallowedCharacters
            imageName = imageName.Trim(disallowedChars);
            fileName_textBox.Text = _name;
            return _name;
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
