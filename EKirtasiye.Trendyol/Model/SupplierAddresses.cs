using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.Trendyol
{

    public class SupplierAddresses
    {
        public Supplieraddress[] supplierAddresses { get; set; }
        public Defaultshipmentaddress defaultShipmentAddress { get; set; }
        public Defaultinvoiceaddress defaultInvoiceAddress { get; set; }
        public Defaultreturningaddress defaultReturningAddress { get; set; }
    }

    public class Defaultshipmentaddress
    {
        public int id { get; set; }
        public string addressType { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public int cityCode { get; set; }
        public string district { get; set; }
        public int districtId { get; set; }
        public string postCode { get; set; }
        public string address { get; set; }
        public string fullAddress { get; set; }
        public bool shipmentAddress { get; set; }
        public bool returningAddress { get; set; }
        public bool invoiceAddress { get; set; }
        public bool _default { get; set; }
    }

    public class Defaultinvoiceaddress
    {
        public int id { get; set; }
        public string addressType { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public int cityCode { get; set; }
        public string district { get; set; }
        public int districtId { get; set; }
        public string postCode { get; set; }
        public string address { get; set; }
        public string fullAddress { get; set; }
        public bool shipmentAddress { get; set; }
        public bool returningAddress { get; set; }
        public bool invoiceAddress { get; set; }
        public bool _default { get; set; }
    }

    public class Defaultreturningaddress
    {
        public bool present { get; set; }
    }

    public class Supplieraddress
    {
        public int id { get; set; }
        public string addressType { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public int cityCode { get; set; }
        public string district { get; set; }
        public int districtId { get; set; }
        public string postCode { get; set; }
        public string address { get; set; }
        public string fullAddress { get; set; }
        public bool shipmentAddress { get; set; }
        public bool returningAddress { get; set; }
        public bool invoiceAddress { get; set; }
        public bool _default { get; set; }
    }

}
