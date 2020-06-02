using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.N11
{
    public class N11Product
    { 
        public N11Product()
        {
            ProductImages = new N11Image[0];
        }

        public Int64 Id { get; set; }

        public int CategoryId { get; set; } 
        public N11Category Category { get; set; }
        public string ProductSellerCode { get; set; }
        public string Title { get; set; }
        public string Subtitle{ get; set; }
        public string Description { get; set; }
        public bool Domestic { get; set; }
        public decimal Price { get; set; }
        public string CurrencyType { get; set; }    
        public string approvalStatus { get; set; }
        public string groupAttribute { get; set; }
        private string groupItemCode { get; set; }
        public string itemName { get; set; }
        public string saleStartDate { get; set; }
        public string saleEndDate { get; set; }
        public string productionDate { get; set; }
        public string expirationDate{ get; set; }
        public string productCondition{ get; set; }
        public string preparingDay { get; set; }
        public string shipmentTemplate { get; set; }

        public string GroupItemCode { get; set; }

        public N11Image[] ProductImages { get; set; }

        public string ProductBrand { get; set; }

        public string Barcode { get; set; }




    }

    public class N11Image
    {
        public int Order { get; set; }
        public string Url { get; set; }
    }
}
