using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.Trendyol
{
    public class FilterRequestReturn
    {
        public int totalElements { get; set; }
        public int totalPages { get; set; }
        public int page { get; set; }
        public int size { get; set; }
        public FilterRequestDocument[] content { get; set; }
    }


    public class FilterRequestDocument
    {
        public string id { get; set; }
        public bool approved { get; set; }
        public string batchRequestId { get; set; }
        public int supplierId { get; set; }
        public long createDateTime { get; set; }
        public long lastUpdateDate { get; set; }
        public long lastPriceChangeDate { get; set; }
        public long lastStockChangeDate { get; set; }
        public string gender { get; set; }
        public string brand { get; set; }
        public string barcode { get; set; }
        public string title { get; set; }
        public string categoryName { get; set; }
        public string productMainId { get; set; }
        public string description { get; set; }
        public string stockUnitType { get; set; }
        public int quantity { get; set; }
        public float listPrice { get; set; }
        public float salePrice { get; set; }
        public int vatRate { get; set; }
        public float dimensionalWeight { get; set; }
        public string stockCode { get; set; }
        public TrendyolUrl[] images { get; set; }
        public ProductAttribute[] attributes { get; set; }
        public bool hasActiveCampaign { get; set; }
        public bool locked { get; set; }
        public int shipmentAddressId { get; set; }
        public int pimCategoryId { get; set; }
        public int version { get; set; }
        public bool lockedByUnSuppliedReason { get; set; }
        public bool onsale { get; set; }
    }

   
    


}
