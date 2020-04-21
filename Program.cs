/* 
 * Image Splitter
 * Author: Jeremy M Barker
 * 
 * Splits an image into smaller images given a size.
 * Split images are named "prefix_x-y" where:
 *    x is the relative split position (horizontal)
 *    y is the relative split position (vertical)
 *  
 * Usage: imagesplitter.exe [width] [height] [imagePath] [saveTo] [prefix]
 *           width     = split image width 
 *           height    = split image height
 *           imagePath = path to the source image
 *           saveTo    = path to save directory
 *           prefix    = prefix for each split file
 */

// TODO: Add error checking/handling

using System.Drawing;

namespace ImageSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            var width = int.Parse(args[0]);
            var height = int.Parse(args[1]);
            var imagePath = args[2];
            var saveTo = args[3];
            var prefix = args[4];

            var source = new Bitmap(imagePath);
            var imageWidth = source.Width;
            var imageHeight = source.Height;

            var xSplits = imageWidth / width;
            var ySplits = imageHeight / height;

            for (var i = 0; i < xSplits; i++)
            {
                for (var j = 0; j < ySplits; j++)
                {
                    var bmp = new Bitmap(width, height);
                    for (var x = 0; x < width; x++)
                    {
                        for (var y = 0; y < height; y++)
                        {
                            bmp.SetPixel(x, y, source.GetPixel(i * width + x, j * height + y));
                        }
                    }
                    bmp.Save(string.Format("{0}/{1}_{2}-{3}.png", saveTo, prefix, i, j), System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }
    }
}
