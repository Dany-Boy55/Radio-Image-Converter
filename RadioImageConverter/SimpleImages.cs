using System.Windows;
using System.Drawing;
using System;

namespace Core
{
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
        public void Resize(Size target)
        {
            Bitmap temp = new Bitmap(target.Width, target.Height);
            using (Graphics g = Graphics.FromImage(temp))
            {
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(image, new Rectangle(0, 0, target.Width, target.Height));
            }
            image = temp;
            temp.Dispose();
        }

        /// <summary>
        /// Resizes an image to the specified size
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Resize(int width, int height)
        {
            Bitmap temp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(temp))
            {
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(image, new Rectangle(0, 0, width, height));
            }
            image = temp;
            temp.Dispose();
        }

        /// <summary>
        /// Crops an image with the specified parameters
        /// </summary>
        /// <param name="cropArea">Zone of the image to be cropped</param>
        public void Crop(Rectangle cropArea)
        {
            Bitmap temp = new Bitmap(cropArea.Width, cropArea.Height);
            using (Graphics g = Graphics.FromImage(temp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(image, cropArea);
            }
            image = temp;
            temp.Dispose();
        }

        /// <summary>
        /// Crops an image with the specified parameters
        /// </summary>
        /// <param name="origin">Starting position for the crop operation</param>
        /// <param name="Area">Size of the image to be croped</param>
        public void Crop(Point origin, Size Area)
        {
            throw new NotImplementedException("I'm lazy :P");
        }
    }
}
