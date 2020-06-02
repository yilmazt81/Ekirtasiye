using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class UpdateProductShopRequest
    {

        public int Id { get; set; }
        public Int64 ProductId { get; set; }
        public string ShopName { get; set; }
        public bool Exported { get; set; }

        public string ShopPrice { get; set; }

    }

    public class UpdateProductShopSaleRequest
    {

        public int Id { get; set; }
        
        public string ShopName { get; set; } 

        public string ApprovalStatus { get; set; }

    }
}
