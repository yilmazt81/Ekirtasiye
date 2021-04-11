﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.CicekSepeti
{

    public class CicekSepetiCreate
    {

        public CicekSepetiProduct[] products { get; set; }
    }

    public class CicekSepetiUpdateStock
    {
        public UpdateStockPriceItem[] items { get; set; }
    }

    public class UpdateStockPriceItem
    {
        public string stockCode { get; set; }
        public int StockQuantity { get; set; }
        public float listPrice { get; set; }

        public float salesPrice { get; set; }

    }
    public class CicekSepetiProduct
    {

        public string productName { get; set; }
        public string mainProductCode { get; set; }
        public string stockCode { get; set; }

        public int categoryId { get; set; }

        public string description { get; set; }
        public string mediaLink { get; set; }
        public int deliveryMessageType { get; set; }

        public int deliveryType { get; set; }

        public int stockQuantity { get; set; }
        public decimal salesPrice { get; set; }

        public decimal listPrice { get; set; }
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
