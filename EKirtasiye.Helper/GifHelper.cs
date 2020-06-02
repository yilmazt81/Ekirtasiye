using Atalasoft.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atalasoft.Imaging.Codec;
using System.IO;

namespace EKirtasiye.Helper
{
    public class GifHelper
    {
        private static AtalaImage ConvertImage8Byte(string tmpFile)
        {
            AtalaImage atalaImage = new AtalaImage(tmpFile);
            var newImage = atalaImage.GetChangedPixelFormat(PixelFormat.Pixel8bppIndexed);
            return newImage;
        }

        public static string MargetImage(string[] imageFiles)
        {
            GifFrameCollection gifFrameCollection = new GifFrameCollection();

            GifEncoder gifEncoder = new GifEncoder();

            gifEncoder.OptimizeColorDepth = true;
            bool supp = gifEncoder.IsPixelFormatSupported(PixelFormat.Pixel24bppBgr);

            var pixelFormats = gifEncoder.SupportedPixelFormats;

            string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".gif");

            foreach (var oneImage in imageFiles)
            {
                AtalaImage atalaImage = ConvertImage8Byte(oneImage);
                var gifFrame = new GifFrame(atalaImage);
                gifFrame.DelayTime = 100;
                gifFrameCollection.Add(gifFrame);
            }


            FileStream fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write);
            GifEncoder encoder = new GifEncoder();
            encoder.Save(fs, gifFrameCollection, null);
            fs.Close();

            return tempPath;


        }
    }
}
