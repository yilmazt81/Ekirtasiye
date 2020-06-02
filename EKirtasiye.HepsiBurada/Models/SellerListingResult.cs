using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.HepsiBurada
{
    public class SellerListingResult
    {

        public Listing[] listings { get; set; }
        public int totalCount { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
    }




    public class Listing
    {
        public string uniqueIdentifier { get; set; }
        public string hepsiburadaSku { get; set; }
        public string merchantSku { get; set; }
        public float price { get; set; }
        public int availableStock { get; set; }
        public int dispatchTime { get; set; }
        public string cargoCompany1 { get; set; }
        public string cargoCompany2 { get; set; }
        public string cargoCompany3 { get; set; }
        public string shippingAddressLabel { get; set; }
        public string claimAddressLabel { get; set; }
        public int maximumPurchasableQuantity { get; set; }
        public int minimumPurchasableQuantity { get; set; }
        public object[] pricings { get; set; }
        public bool isSalable { get; set; }
        public Customizableproperty[] customizableProperties { get; set; }
        public string[] deactivationReasons { get; set; }
        public bool isSuspended { get; set; }
        public bool isLocked { get; set; }
        public object[] lockReasons { get; set; }
        public bool isFrozen { get; set; }
        public float commissionRate { get; set; }
        public object buyboxOrder { get; set; }
    }

    public class Customizableproperty
    {
        public string displayName { get; set; }
        public int displayLength { get; set; }
        public string displayDescription { get; set; }
    }

}
