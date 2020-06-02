using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETicaretWinApp
{
    public class WebPageProduct
    {


        public int PageOrder { get; set; }

        public string ProductName { get; set; }

        public string ProductImageHref { get; set; }

        public string ImageBase64 { get; set; }

        public byte[] ImageBytes {
            get {
                return Convert.FromBase64String(ImageBase64);
            }
        }

        public string ProductPrice { get; set; }

        public string InnerHtml { get; set; }

        public double Similarity { get; set; }


    }

    public class WebPagePRoductSelected:WebPageProduct
    {
        public List<ProductImage> ProductImages { get; set; }
        public string Description { get; set; }

    }

    public class ProductImage
    {
        public string ImageLink { get; set; }
        public string ImageData { get; set; }

    }
}
