using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.Trendyol
{
    public class UpdatePriceRequest
    {
        public UpdatePriceAndInventor[] items { get; set; }
    }

    public class UpdatePriceAndInventor
    {
        public string barcode { get; set; }
        public int quantity { get; set; }
        public float salePrice { get; set; }
        public  float listPrice { get; set; }
    }
}
