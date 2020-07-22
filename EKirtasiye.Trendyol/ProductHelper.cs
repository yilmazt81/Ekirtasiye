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

        public BatchRequestResult GetBatchRequest(string batchRequestId)
        {

            string serviceUrl = $"{_endPoint}/suppliers/{_supplierid}/products/batch-requests/{batchRequestId}";

            return GetRequest<BatchRequestResult>(serviceUrl);

        }

        public CreateRequestReturn CreateProduct(CreateProductRequest createProductRequest)
        {
            string serviceUrl = $"{_endPoint}suppliers/{_supplierid}/v2/products";


            var jsonClass = JsonConvert.SerializeObject(createProductRequest);
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");


            var result = client.PostAsync(serviceUrl, content).Result;

            CreateRequestReturn createRequestReturn = null;
            if (result.IsSuccessStatusCode)
            {

                var serviceReturn = result.Content.ReadAsStringAsync().Result;

                createRequestReturn = JsonConvert.DeserializeObject<CreateRequestReturn>(serviceReturn);
                
            }
            else
            {
                var statusCode = result.StatusCode;
              
            }
            return createRequestReturn;
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
