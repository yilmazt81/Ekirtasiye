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
        private string _supplierid, _userName, _password, _endPoint = string.Empty;
        HttpClient client = new HttpClient();
        public ProductHelper(string endPoint, string suplierId, string userName, string password)
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

        public FilterRequestReturn FilterApprovedProduct(string barcode, bool approved = true)
        {
            //suppliers/{supplierId}/products?approved=true
            string serviceUrl = $"{_endPoint}suppliers/{_supplierid}/products?approved={approved}&page=0&size=10&barcode={barcode}";
            //string serviceurl= $"{_endPoint}suppliers/{_supplierid}/products?approved=true&page=1&size=10&barcode={barcode}";
            var result = client.GetAsync(serviceUrl).Result;
            FilterRequestReturn trendyolProducts = null;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;
                trendyolProducts = JsonConvert.DeserializeObject<FilterRequestReturn>(str);
            }

            return trendyolProducts;
        }

        public BatchRequestResult GetBatchRequest(string batchRequestId)
        {

            string serviceUrl = $"{_endPoint}/suppliers/{_supplierid}/products/batch-requests/{batchRequestId}";

            return GetRequest<BatchRequestResult>(serviceUrl);

        }

        public CreateRequestReturn CreateProduct(CreateProductRequest createProductRequest)
        {
            string serviceUrl = $"{_endPoint}suppliers/{_supplierid}/v2/products";

            return PostRequest<CreateRequestReturn, CreateProductRequest>(serviceUrl, createProductRequest);
        }

        public CreateRequestReturn UpdatePriceAndInventory(UpdatePriceRequest updatePriceRequest)
        {
            string serviceUrl = $"{_endPoint}suppliers/{_supplierid}/products/price-and-inventory";

            return PostRequest<CreateRequestReturn, UpdatePriceRequest>(serviceUrl, updatePriceRequest);
        }

        public T PostRequest<T, K>(string url, K obj)
        {

            var jsonClass = JsonConvert.SerializeObject(obj);
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");
            T requestReturn;
            var result = client.PostAsync(url, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;
                requestReturn = JsonConvert.DeserializeObject<T>(str);

                return requestReturn;
            }
            else
            {
                throw new Exception("Request Return Code : " + result.StatusCode);

            }
        }

        public T GetRequest<T>(string url)
        {

            T requestReturn;
            var result = client.GetAsync(url).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;
                requestReturn = JsonConvert.DeserializeObject<T>(str);

                return requestReturn;
            }
            else
            {
                throw new Exception("Request Return Code : " + result.StatusCode);

            }
        }

    }
}
