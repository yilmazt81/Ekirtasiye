using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.CicekSepeti
{

    public class CicekSepetiCreate
    {

    }
    public class CicekSepetiProduct
    {

        public  string productName { get; set; }
        public string mainProductCode { get; set; }
        public string stockCode { get; set; }

        public int categoryId { get; set; }

        public string description { get; set; }
        public string mediaLink { get; set; }
        public string deliveryMessageType { get; set; }

        public string deliveryType { get; set; }

        public int stockQuantity { get; set; }
        public string salesPrice { get; set; }

        public string listPrice { get; set; }
        public string barcode { get; set; }

        public CicekAttribute[] attributes { get; set; }
      

        public string[] images { get; set; }


    }

    public class CicekAttribute
    {
        public int id { get; set; }

        public int valueId { get; set; }

        public int textLength { get; set; }
    }

    public class CreateReturn
    {
        public string batchId { get; set; }

    }
}
