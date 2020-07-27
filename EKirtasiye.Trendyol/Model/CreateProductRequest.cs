using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.Trendyol
{
    public class CreateProductRequest
    {
        public CreateTrendyolProduct[] items { get; set; }

    }

    public class CreateTrendyolProduct
    {
        public string barcode { get; set; }

        public string title { get; set; }

        public string productMainId { get; set; }

        public int brandId { get; set; }

        public int categoryId { get; set; }
        public int quantity { get; set; }

        public string stockCode { get; set; }
        public int dimensionalWeight { get; set; }
        public string description { get; set; }
        public string currencyType { get; set; }

        public string listPrice { get; set; }
        public string salePrice { get; set; }
        public int vatRate { get; set; }
        public int cargoCompanyId { get; set; }
        public int shipmentAddressId { get; set; }
        public object returningAddressId { get; set; }
      // public int deliveryDuration { get; set; }

        public TrendyolUrl[] images { get; set; }
        public ProductCreateAttribute[] attributes { get; set; }

    }


    public class CreateRequestReturn
    {
        public string batchRequestId { get; set; }
    }

}
