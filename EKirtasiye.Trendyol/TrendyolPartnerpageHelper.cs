using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.Trendyol
{
    public class TrendyolPartnerpageHelper
    {
        // /mpe/account/api/user/login
        string baseUrl = "https://partner.trendyol.com/";
        private string _userName = string.Empty;
        private string _password = string.Empty;
        HttpClient client = null;
        public TrendyolPartnerpageHelper()
        {
            client = new HttpClient();
           // System.Net.Http.Headers.ProductHeaderValue productInfoHeaderValue = new System.Net.Http.Headers.ProductHeaderValue("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.89 Safari/537.36", "1.0.0.1");
            //client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue(productInfoHeaderValue));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("gzip"));
            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

        }

        public bool Login(string email, string password)
        {
            try
            {
                string url = $"{baseUrl}mpe/account/api/user/login";
                var loginReturn = PostRequest<LoginReturn, UserLogin>(url, new UserLogin()
                {
                    email = email,
                    password = password
                });

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
