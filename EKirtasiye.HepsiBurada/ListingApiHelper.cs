using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EKirtasiye.HepsiBurada
{
    public class ListingApiHelper
    {
        private string _endpoint, _merchantid = "";
        ServiceToken serviceToken = null;
        HttpClient client = new HttpClient();
        CatalogProductApiHelper apiHelper = null;
        /// <summary>
        /// Bu api , sistemde satış başlatma işlemleri için kullanılır . 
        /// </summary>
        /// <param name="merchantid"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="endPoint"></param>
        public ListingApiHelper(string merchantid, string userName, string password, string endPoint)
        {

            string userNameAdPassword = $"{userName}:{password}";

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(userNameAdPassword);
            var baseString= System.Convert.ToBase64String(plainTextBytes);
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + baseString);
            _merchantid = merchantid;
            _endpoint = endPoint;
        }



        public SellerListingResult GetSellerListing()
        {

            string serviceUrl = _endpoint + $"/listings/merchantid/{_merchantid}";
            var result = client.GetAsync(serviceUrl).Result;
            SellerListingResult categoriesResult = null;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;
                categoriesResult = JsonConvert.DeserializeObject<SellerListingResult>(str);
            }
            return categoriesResult;

        }

        public void UpdateListing()
        { 
            try
            {
                ImportProductResult importProductResult = new ImportProductResult();
                string serviceUrl = _endpoint + $"/listings/merchantid/{_merchantid}/inventory-uploads";


                XDocument xDocument = new XDocument();
                 
                
                var content = new StringContent("", Encoding.UTF8, "application/xml");

                var result = client.PostAsync(serviceUrl, content).Result;


                if (result.IsSuccessStatusCode)
                {
                    var serviceReturn = result.Content.ReadAsStringAsync().Result;
                    importProductResult = JsonConvert.DeserializeObject<ImportProductResult>(serviceReturn);
                    
                }
                else
                {
                    var statusCode = result.StatusCode;
                    importProductResult.success = false;
                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //File.Delete(tmpFile);
            }
        }


    }
}
