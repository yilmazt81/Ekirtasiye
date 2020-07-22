using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.Trendyol
{

    public class BatchRequestResult
    {
        public string batchRequestId { get; set; }
        public Item[] items { get; set; }
        public string status { get; set; }
        public long creationDate { get; set; }
        public long lastModification { get; set; }
        public string sourceType { get; set; }
        public int itemCount { get; set; }
        public int failedItemCount { get; set; }
        public string batchRequestType { get; set; }
    }

    public class Item
    {
        public Requestitem requestItem { get; set; }
        public string status { get; set; }
        public string[] failureReasons { get; set; }
    }

    public class Requestitem
    {
        public Product product { get; set; }
        public string barcode { get; set; }
    }

    public class Product
    {
        public string barcode { get; set; }
        public string title { get; set; }
        public string productMainId { get; set; }
        public int brandId { get; set; }
        public int categoryId { get; set; }
        public int quantity { get; set; }
        public string stockCode { get; set; }
        public float dimensionalWeight { get; set; }
        public string description { get; set; }
        public string currencyType { get; set; }
        public float listPrice { get; set; }
        public float salePrice { get; set; }
        public int vatRate { get; set; }
        public TrendyolUrl[] images { get; set; }
        public ProductAttribute[] attributes { get; set; }
        public int cargoCompanyId { get; set; }
        public int shipmentAddressId { get; set; }
        public int returningAddressId { get; set; }
    }

   

 



}
