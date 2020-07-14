using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.Trendyol
{
    public class TrendyolProduct
    {
        public string id { get; set; }

        public bool approved { get; set; }

        public Int64 productCode { get; set; }
        public string batchRequestId { get; set; }

        public string supplierId { get; set; }

        public string createDateTime { get; set; }
        public string lastUpdateDate { get; set; }

        public string gender { get; set; }

        public string brand { get; set; }

        public string barcode { get; set; }
        public string title { get; set; }
        public string categoryName { get; set; }
        public string productMainId { get; set; }
        public string description { get; set; }
        public string stockUnitType { get; set; }

        public int quantity { get; set; }

        public string listPrice { get; set; }
        public string salePrice { get; set; }
        public string vatRate { get; set; }

        public string dimensionalWeight { get; set; }
        public string stockCode { get; set; }

        public TrendyolUrl[] images { get; set; }

        public string platformListingId { get; set; }
        public string stockId { get; set; }
        public string color { get; set; }
        public ProductAttribute[] variantAttributes { get; set; }

    }

    public class TrendyolUrl
    {
        public string url { get; set; }
    }

    public class ProductAttribute
    {
        public string attributeName { get; set; }
        public string attributeValue { get; set; }
    }
}
