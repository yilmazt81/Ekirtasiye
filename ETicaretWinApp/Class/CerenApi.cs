using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretWinApp
{
    public class CerenApi
    {
        private HttpClient client = null;
        string rootUrl = "http://www.cerenb2b.com/";
        public CerenApi()
        {
            client = new HttpClient();
            System.Net.Http.Headers.ProductHeaderValue productInfoHeaderValue = new System.Net.Http.Headers.ProductHeaderValue("EKirtasiye", "1.0.0.1");
            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue(productInfoHeaderValue));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("gzip"));
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

        }
        public async Task<bool> Login(string mail, string password)
        {
            var form = new Dictionary<string, string>
               {

                   {"mail",mail},
                   {"password", password},
                   {"remember","true" }
               };

            string serviceUrl = rootUrl + "/login/login_request";

            var result = await client.PostAsync(serviceUrl, new FormUrlEncodedContent(form));

            if (result.IsSuccessStatusCode)
            {

                var serviceReturn = result.Content.ReadAsStringAsync().Result;

                //token = JsonConvert.DeserializeObject<Token>(serviceReturn);
                // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.AccessToken);
                return true;
            }
            else
            {
                var statusCode = result.StatusCode;
                return false;
            }

        }

        public async Task<Class.CerenProduct> GetProductDetail(int productId)
        {
            var form = new Dictionary<string, string>
               {

                   {"stock_id",productId.ToString()}
               };

            string serviceUrl = rootUrl + "/product/get_product_detail";

            var result = await client.PostAsync(serviceUrl, new FormUrlEncodedContent(form));
            Class.CerenProduct cerenProduct = null;
            if (result.IsSuccessStatusCode)
            {

                var serviceReturn = result.Content.ReadAsStringAsync().Result;

                cerenProduct = JsonConvert.DeserializeObject<Class.CerenProduct>(serviceReturn);
                // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.AccessToken);
                return cerenProduct;
            }
            else
            {
                var statusCode = result.StatusCode;
                return cerenProduct;
            }
        }
        public async Task<Class.CategoryResult> GetCategoryProducts(string categoryId, int page = 1)
        {
            var form = new Dictionary<string, string>
               {

                   {"type","category"},
                   {"parameter",categoryId},
                   {"search",""},
                    {"page",page.ToString() }

               };

            string serviceUrl = rootUrl + "/category/get_product_list";

            var result = await client.PostAsync(serviceUrl, new FormUrlEncodedContent(form));
            Class.CategoryResult cerenProduct = null;
            if (result.IsSuccessStatusCode)
            {

                var serviceReturn = result.Content.ReadAsStringAsync().Result;

                cerenProduct = JsonConvert.DeserializeObject<Class.CategoryResult>(serviceReturn);
                // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.AccessToken);
                return cerenProduct;
            }
            else
            {
                var statusCode = result.StatusCode;
                return cerenProduct;
            }
        }

        public async Task<Class.CategoryResult> GetProductCode(string code)
        {


            string serviceUrl = rootUrl + "/search/get_product_list";
            var form = new Dictionary<string, string>
               {

                   {"type","product"},
                   {"parameter",code},
                   {"search",""}

               };
            var result = await client.PostAsync(serviceUrl, new FormUrlEncodedContent(form));
            Class.CategoryResult cerenProduct = null;
            if (result.IsSuccessStatusCode)
            {

                var serviceReturn = result.Content.ReadAsStringAsync().Result;

                cerenProduct = JsonConvert.DeserializeObject<Class.CategoryResult>(serviceReturn);
                // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.AccessToken);
              
            }
            else
            {
                var statusCode = result.StatusCode;
                
            }

            return cerenProduct;
        }

    }
}
