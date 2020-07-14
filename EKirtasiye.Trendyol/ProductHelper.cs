using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.Trendyol
{
    public class ProductHelper
    {
        private string _supplierid, _userName,_password, _endPoint = string.Empty;
        HttpClient client = new HttpClient(); 
        public ProductHelper(string endPoint,string suplierId,string userName,string password)
        {
            _supplierid = suplierId;
            _userName = userName;
            _password = password;
            _endPoint = endPoint;

             
            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.UTF8.GetBytes(_userName + ":" + _password));

            client.DefaultRequestHeaders.Add("Authorization", "Basic " + svcCredentials);
        }

        public bool CreateProducts()
        {
            return true;
        }

        public TrendyolProduct[] FilterApprovedProduct(string barcode)
        {
            //suppliers/{supplierId}/products?approved=true
            string serviceUrl = $"{_endPoint}suppliers/{_supplierid}/products?approved=true&page=0&size=10&barcode={barcode}";
            var result = client.GetAsync(serviceUrl).Result;
            TrendyolProduct[] trendyolProducts = null;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;
                trendyolProducts = JsonConvert.DeserializeObject<TrendyolProduct[]>(str);
            }

            return trendyolProducts;
        }

        public bool CreateProduct(CreateProductRequest createProductRequest)
        {
            string serviceUrl = $"{_endPoint}suppliers/{_supplierid}/v2/products";


            var jsonClass = JsonConvert.SerializeObject(createProductRequest);
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");


            var result = client.PostAsync(serviceUrl, content).Result;


            if (result.IsSuccessStatusCode)
            {

                var serviceReturn = result.Content.ReadAsStringAsync().Result;

                //serviceToken = JsonConvert.DeserializeObject<ServiceToken>(serviceReturn);
                  return true;
            }
            else
            {
                var statusCode = result.StatusCode;
                return false;
            }
             
        }

    }
}
