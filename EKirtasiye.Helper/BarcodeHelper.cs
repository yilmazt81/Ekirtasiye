using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintasoft.Barcode;

namespace EKirtasiye.Helper
{
    public class BarcodeHelper
    {
        private static Vintasoft.Barcode.BarcodeReader _vintaBarcodeReader = null;
        static BarcodeHelper()
        {
            Vintasoft.Barcode.BarcodeGlobalSettings.RegisterBarcodeReader("Orhan Baloglu", "orhan.baloglu@kod-a.com", "H9Li/gwrPAZ0MQNkLTqzdzHHIRsIPU2SmQ0VlaGqpzkeLQQspSwCtIts1wCXSLCh/dgvAOPUGCaPmqaVKk8+jjbGnFxWhdntP6wBPA8qiHdkKCtkckKeOwKWC23aTFrr9EnouSx2z4ZEjVSZBb4TE+IXvivIKlboAa7uGMEoks6o");
            _vintaBarcodeReader = new Vintasoft.Barcode.BarcodeReader();
           /* _vintaBarcodeReader.Settings.ScanInterval = 6;
            _vintaBarcodeReader.Settings.ExpectedBarcodes = 20;
            _vintaBarcodeReader.Settings.ScanBarcodeTypes = BarcodeType.EAN13| BarcodeType.UPCE| BarcodeType.Code128;
            _vintaBarcodeReader.Settings.MaximalThreadsCount = 4;
            _vintaBarcodeReader.Settings.ScanDirection = ScanDirection.Angle45and135 | ScanDirection.Vertical | ScanDirection.Horizontal;
            */
            _vintaBarcodeReader.Settings.AutomaticRecognition = true;
        }
        public static BarcodeReadResult[] ReadBarcodeFromImage(string imagePath)
        {
            /*
            ZXing.BarcodeReader barcodeReader = new ZXing.BarcodeReader();
            barcodeReader.Options.PossibleFormats = new List<ZXing.BarcodeFormat>() {ZXing.BarcodeFormat.All_1D,ZXing.BarcodeFormat.QR_CODE };
             
            barcodeReader.Options.PureBarcode = true;
            barcodeReader.Options.TryHarder = true;
 
        
     var resulst= barcodeReader.Decode(bwBitmap);
          */

            var bwBitmap = ImageHelper.ConverToBinarize(imagePath);

            //bwBitmap.Save(@"D:\testx.tif");

            var barcodeResult = _vintaBarcodeReader.ReadBarcodes(bwBitmap);




            return null;
        }
    }
}
