using Atalasoft.Imaging;
using Atalasoft.Imaging.ImageProcessing;
using Atalasoft.Imaging.WinControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace EKirtasiye.Controls
{
    public class ViewerHelper
    {
        public enum ZoomType
        {
            In,
            Out,
            BestFit,
            FitToWidth,
            FitToHeight,
            None
        }

        public enum MouseMission
        {
            None,
            Cut,

        }


        public static AtalaImage CropImage(AtalaImage atalaImage,Rectangle rectangle)
        {
            var cropCommand = new CropCommand(rectangle);

           var cropResult= cropCommand.Apply(atalaImage);

            return cropResult.Image;
        }

        public static AtalaImage ReSizeImage(AtalaImage atalaImage, Size size)
        {
            var cropCommand = new ResampleCommand(size);

            var cropResult = cropCommand.Apply(atalaImage);

            return cropResult.Image;
        }


        public static void Zoom(ImageViewer imageViewer ,ZoomType mode )
        {
            imageViewer.AutoZoom = AutoZoomMode.None;
            switch (mode)
            {
                case ZoomType.In:
                    imageViewer.Zoom += 0.1;
                    break;
                case ZoomType.Out:
                    imageViewer.Zoom -= 0.1;
                    break;
                case ZoomType.None:
                    imageViewer.Zoom = 1.0;

                    break;
                case ZoomType.BestFit:
                    imageViewer.AutoZoom = AutoZoomMode.BestFit;
                    break;
                case ZoomType.FitToWidth:
                    imageViewer.AutoZoom = AutoZoomMode.FitToWidth;
                    break;
                case ZoomType.FitToHeight:
                    imageViewer.AutoZoom = AutoZoomMode.FitToHeight;
                    break;
            }
        }
    }
}
