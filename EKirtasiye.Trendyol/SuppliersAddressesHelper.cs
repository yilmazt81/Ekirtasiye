
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.Trendyol
{
    public class SuppliersAddressesHelper
    {
        private string _supplierid, _userName, _password, _endPoint = string.Empty;
        HttpClient client = new HttpClient();
        public SuppliersAddressesHelper(string endPoint, string suplierId, string userName, string password)
        {
            _supplierid = suplierId;
            _userName = userName;
            _password = password;
            _endPoint = endPoint;


            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.UTF8.GetBytes(_userName + ":" + _password));

            client.DefaultRequestHeaders.Add("Authorization", "Basic " + svcCredentials);
        }

        public SupplierAddresses GetAdress()
        {
             string serviceUrl = $"{_endPoint}suppliers/{_supplierid}/addresses";

            var result = client.GetAsync(serviceUrl).Result;
            SupplierAddresses supplierAddresses = null;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;
                supplierAddresses = JsonConvert.DeserializeObject<SupplierAddresses>(str);
            }

            return supplierAddresses;
        }
    }
}
