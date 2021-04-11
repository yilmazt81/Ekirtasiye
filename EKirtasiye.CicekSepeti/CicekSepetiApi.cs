using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.CicekSepeti
{
    public class CicekSepetiApi

    {
        public string baseUrl, suplierId, apiKey = string.Empty;

        HttpClient client = null;
        public CicekSepetiApi(string url, string suplierid, string apikey)
        {
            baseUrl = url;
            suplierId = suplierid;
            apiKey = apikey;
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apikey);
        }

        public CicekSepetiCategoryReturn GetCategory()
        {
            string url = baseUrl + "api/v1/Categories";

            return GetRequest<CicekSepetiCategoryReturn>(url);
        }

        public CicekSepetiCategoryAttribute GetCategoryAttribute(int categoryId)
        {
            string url = baseUrl + $"api/v1/categories/{categoryId}/attributes";

            return GetRequest<CicekSepetiCategoryAttribute>(url);
        }

        public CreateReturn CreateProduct(List<CicekSepetiProduct> cicekSepetiProducts)
        {
            string url = baseUrl + $"api/v1/Products";

            CicekSepetiCreate cicekSepetiCreate = new CicekSepetiCreate()
            {
                products = cicekSepetiProducts.ToArray()
            };
            return PostRequest<CreateReturn, CicekSepetiCreate>(url, cicekSepetiCreate);

        }

        public CreateReturn UpdateProductStockAndPrice(CicekSepetiUpdateStock sepetiUpdateStock)
        {
            string url = baseUrl + $"api/v1/Products/price-and-stock";

            return PostRequest<CreateReturn, CicekSepetiUpdateStock>(url, sepetiUpdateStock);
        }

        public CicekSepetiBatchReturn CheckBatchStatus(string batchId)
        {
            string url = baseUrl + $"api/v1/Products/batch-status/{batchId}";

            return GetRequest<CicekSepetiBatchReturn>(url);
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
