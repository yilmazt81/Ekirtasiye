using Atalasoft.Imaging;
using Atalasoft.Imaging.ImageProcessing.Document;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.Helper
{
    public class ImageHelper
    {

        public static Bitmap ConverToBinarize(Bitmap bitmap)
        {
            using (AtalaImage atalaImage = AtalaImage.FromBitmap(bitmap))
            {
                var binarize = new BinarizeCommand();
                var applyImage = binarize.Apply(atalaImage);

                return applyImage.Image.ToBitmap();
            }
        }

        public static Bitmap ConverToBinarize(string imageFilePath)
        {
            using (AtalaImage atalaImage = new AtalaImage(imageFilePath))
            {
                var binarize = new BinarizeCommand();
                var applyImage = binarize.Apply(atalaImage);

                return applyImage.Image.ToBitmap();
            }
        }

        public static void SaveImage(Bitmap bitmap, string filePath)
        {
            bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

    }
}
