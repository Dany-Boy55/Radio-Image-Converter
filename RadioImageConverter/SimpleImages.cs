using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System;

/// <summary>
/// A series of wrappers for the build in GDI+ System.Drawing
/// Meant to simplify image usage and manipulation
/// Not really efficient (for now), but really simple to use
/// </summary>
namespace SimpleImages
{
    /// <summary>
    /// An abstract class that provides static methods for (X,Y) image manipulation
    /// </summary>
    public abstract class CartesianTransforms
    {
        /// <summary>
        /// Returns an indexed bitmap of the specified image with the specified parameters
        /// </summary>
        /// <param name="sourceImage"> Image from which the bitmap will be generated</param>
        /// <param name="colordepth"> Color depth per pixel for the indexed bitmap</param>
        /// <param name="blackAndWhite"> False->Color / True->B&W defaults to color images</param>
        /// <returns></returns> 
        public static Bitmap GetIndexedBitmap(Image sourceImage, int colordepth, bool blackAndWhite = false)
        {
            switch (colordepth)
            {
                case 1:
                    break;
                case 4:
                    break;
                case 8:
                    break;
            }
            // Create a temporary bitmap object to pereform the operations
            Bitmap temp = new Bitmap(sourceImage);
            Bitmap targetImage = temp.Clone(new Rectangle(0,0,temp.Width,temp.Height),PixelFormat.Format4bppIndexed);
            temp.Dispose();
            ColorPalette targetPalette = targetImage.Palette;
            for (int i = 0; i<targetPalette.Entries.Length; i++)
            {
                double brightness = targetPalette.Entries[i].GetBrightness() * 255;
                int brightnessInt = (int)brightness;
                targetPalette.Entries[i] = Color.FromArgb(255, brightnessInt, brightnessInt, brightnessInt);
            }
            targetImage.Palette = targetPalette;
            return targetImage;
        }

        /// <summary>
        /// Returns a resized version of the specified image mainteining the original aspect ratio
        /// </summary>
        /// <param name="sourceImage"> Image to be resized</param>
        /// <param name="ratio"> Resize ratio: 0-1 shrink, >1 grow</param>
        /// <returns></returns>
        public static Image resizeProportional(Image sourceImage, float ratio)
        {
            Size newSize = new Size((int)(sourceImage.Width * ratio), (int)(sourceImage.Height * ratio));
            Image targetImage = new Bitmap(newSize.Width, newSize.Height);
            using(Graphics g = Graphics.FromImage(targetImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingMode = CompositingMode.SourceCopy;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(sourceImage, new Rectangle(0, 0, newSize.Width, newSize.Height));
            }
            return targetImage;
        }

        /// <summary>
        /// Returns a resized version of the specified Image with the given parameters
        /// </summary>
        /// <param name="sourceImage"> Image to be resized</param>
        /// <param name="newWidth"> Desired width for the resized image</param>
        /// <param name="newHeight"> Desired Height for the resized image</param>
        /// <returns></returns>
        public static Image Resize(Image sourceImage, int newWidth, int newHeight)
        {
            Size newSize = new Size(newWidth, newHeight);
            Bitmap targetImage = new Bitmap(newSize.Width, newSize.Height);
            using (Graphics g = Graphics.FromImage(targetImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingMode = CompositingMode.SourceCopy;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(sourceImage, new Rectangle(0, 0, newSize.Width, newSize.Height));
            }
            return targetImage;
        }

        /// <summary>
        /// Returns a resized version of the specified Image with the given parameters
        /// </summary>
        /// <param name="sourceImage"> Image to be resized</param>
        /// <param name="newSize"> Desired Size for the resized image</param>
        /// <returns></returns>
        public static Image Resize(Image sourceImage, Size newSize)
        {   
            Bitmap targetImage = new Bitmap(newSize.Width, newSize.Height);
            using (Graphics g = Graphics.FromImage(targetImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingMode = CompositingMode.SourceCopy;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(sourceImage, new Rectangle(0, 0, newSize.Width, newSize.Height));
            }
            return targetImage;
        }
    }

    /// <summary>
    /// An abstract class that provides static methods for (r,theta) image manipulation
    /// </summary>
    public abstract class PolarTransforms
    {

    }

    /// <summary>
    /// A wrapper class for System.Drawing.Image for higher level manipulation
    /// </summary>
    public class SimpleImage
    {
        private Bitmap image;
        public Size size { get; }

        /// <summary>
        /// initialize an instace of SimpleImage from an image object
        /// </summary>
        /// <param name="input">Source Image</param>
        public SimpleImage(Image input)
        {
            image = new Bitmap(input);
            size = image.Size;
        }

        /// <summary>
        /// Initializes an instance of SimpleImage from a source file
        /// </summary>
        /// <param name="path">File name including absolute path</param>
        public SimpleImage(string path)
        {
            try
            {
                Image temp = Image.FromFile(path);
            }
            catch
            {

                throw;
            }

        }

        /// <summary>
        /// Initializes an instace of SimpleImage from a bitmap
        /// </summary>
        /// <param name="input">Source bitmap</param>
        public SimpleImage(Bitmap input)
        {
            image = input;
            size = image.Size;
        }

        /// <summary>
        /// Resizes an image to the specifies size
        /// </summary>
        /// <param name="target"></param>
        public Image Resize(Size target)
        {
            Bitmap temp = new Bitmap(target.Width, target.Height);
            using (Graphics g = Graphics.FromImage(temp))
            {
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(image, new Rectangle(0, 0, target.Width, target.Height));
            }
            return temp;
        }

        /// <summary>
        /// Resizes an image to the specified size
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Image Resize(int width, int height)
        {
            Bitmap temp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(temp))
            {
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(image, new Rectangle(0, 0, width, height));
            }
            return temp;
        }

        /// <summary>
        /// Crops an image with the specified parameters
        /// </summary>
        /// <param name="cropArea">Zone of the image to be cropped</param>
        public Image Crop(Rectangle cropArea)
        {
            Bitmap temp = new Bitmap(cropArea.Width, cropArea.Height);
            using (Graphics g = Graphics.FromImage(temp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(image, cropArea);
            }
            return temp;
        }

        /// <summary>
        /// Crops an image with the specified parameters
        /// </summary>
        /// <param name="origin">Starting position for the crop operation</param>
        /// <param name="Area">Size of the image to be croped</param>
        public Image Crop(Point origin, Size Area)
        {
            throw new NotImplementedException("I'm lazy :P");
        }
    }
}
