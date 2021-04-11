using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.CicekSepeti
{
    public class CicekSepetiBatchReturn
    {

        public string batchId { get; set; }
        public int itemCount { get; set; }
        public Item[] items { get; set; }

    }


    

    public class Item
    {
        public DataProduct data { get; set; }
        public string itemId { get; set; }
        public string status { get; set; }
        public Failurereason[] failureReasons { get; set; }
        public DateTime lastModificationDate { get; set; }
    }

    public class DataProduct
    {
        public object siteCode { get; set; }
        public string productName { get; set; }
        public string mainProductCode { get; set; }
        public string stockCode { get; set; }
        public int categoryId { get; set; }
        public string description { get; set; }
        public string mediaLink { get; set; }
        public int deliveryMessageType { get; set; }
        public int deliveryType { get; set; }
        public int stockQuantity { get; set; }
        public float salesPrice { get; set; }
        public float listPrice { get; set; }
        public string barcode { get; set; }
        public string[] images { get; set; }
        public Attribute[] attributes { get; set; }
    }

    public class Attribute
    {
        public int id { get; set; }
        public int valueId { get; set; }
        public int textLength { get; set; }
    }

    public class Failurereason
    {
        public string message { get; set; }
        public int code { get; set; }
    }

}
