using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class UpdateProductGroupRequest
    {

        public int[] ProductIdList { get; set; }

        public int MainCategoryId { get; set; }

        public  int CategoryId { get; set; }

        public  int SubCategoryId { get; set; }
    }

    public class UpdateProductPriceRequest
    {
        public int ProductId { get; set; }
        public string WebPrice { get; set; }

    }

    public class UpdateProductPictureRequest
    {
        public int ProductId { get; set; }
        public string PicturePath1 { get; set; }
        public string PicturePath2 { get; set; }
        public string PicturePath3 { get; set; }
        public string PicturePath4 { get; set; }

    }
}
