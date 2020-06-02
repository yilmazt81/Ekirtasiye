using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.HepsiBurada
{
    public class CatalogProductApiHelper
    {
        private string _merchantId, _password, _developerUserName, _endpoint = "";
        ServiceToken serviceToken = null;
        HttpClient client = new HttpClient();
        public CatalogProductApiHelper(string merchantId, string password, string developerUserName, string endPoint)
        {
            _merchantId = merchantId;
            _password = password;
            _developerUserName = developerUserName;
            _endpoint = endPoint;
        }

        public string MerchantId {
            get {
                return _merchantId;
            }
        }

        public HttpClient GetHttpClient()
        {

            return client;
        }

        public bool Authenticate()
        {
            var jsonClass = JsonConvert.SerializeObject(new
            {

                username = _developerUserName,
                password = _password,
                authenticationType = "INTEGRATOR"
            });

            client = new HttpClient();

            string serviceUrl = _endpoint + "/api/authenticate";
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");
            var result = client.PostAsync(serviceUrl, content).Result;


            if (result.IsSuccessStatusCode)
            {

                var serviceReturn = result.Content.ReadAsStringAsync().Result;
                serviceToken = JsonConvert.DeserializeObject<ServiceToken>(serviceReturn);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + serviceToken.id_token);
                return true;
            }
            else
            {
                var statusCode = result.StatusCode;
                return false;
            }

        }

        public string Id_Token {
            get {
                return (serviceToken == null ? string.Empty : serviceToken.id_token);
            }
        }

        public CategoriesResult GetAllCategories(int pageSize = 5, int page = 0)
        {
            string serviceUrl = _endpoint + $"/product/api/categories/get-all-categories?page={page}&size={pageSize}";

            var result = client.GetAsync(serviceUrl).Result;
            CategoriesResult categoriesResult = null;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                categoriesResult = JsonConvert.DeserializeObject<CategoriesResult>(str);
            }
            return categoriesResult;
        }

        public CategoryAttributeResult GetCategoriAttribute(int categoryId)
        {
            string serviceUrl = _endpoint + $"/product/api/categories/{categoryId}/attributes";

            var result = client.GetAsync(serviceUrl).Result;
            CategoryAttributeResult categoriesResult = null;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                categoriesResult = JsonConvert.DeserializeObject<CategoryAttributeResult>(str);
            }

            return categoriesResult;
        }

        public CategoryAttributeValueResult GetCategoriAttributeValues(int categoryId, string attributeId)
        {
            string serviceUrl = _endpoint + $"/product/api/categories/{categoryId}/attribute/{attributeId}";

            var result = client.GetAsync(serviceUrl).Result;
            CategoryAttributeValueResult categoriesResult = null;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                categoriesResult = JsonConvert.DeserializeObject<CategoryAttributeValueResult>(str);
            }

            return categoriesResult;

        }

        public ImportProductCheckResult CheckImportProductStatus(string trackingId, int page = 0, int size = 10)
        {
            string serviceUrl = _endpoint + $"/product/api/products/status/{trackingId}?page={page}&size={size}";

            var result = client.GetAsync(serviceUrl).Result;
            ImportProductCheckResult categoriesResult = null;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                categoriesResult = JsonConvert.DeserializeObject<ImportProductCheckResult>(str);
            }
            else
            {
                categoriesResult = new ImportProductCheckResult()
                {
                    success = false
                };
            }

            return categoriesResult;
        }

        public TrackingHistoryResult TrackingIdHistory()
        {
            string serviceUrl = _endpoint + $"/product/api/products/trackingId-history";

            var result = client.GetAsync(serviceUrl).Result;
            TrackingHistoryResult categoriesResult = new TrackingHistoryResult();
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                categoriesResult = JsonConvert.DeserializeObject<TrackingHistoryResult>(str);
            }
            else
            {
                categoriesResult.success = false;
            }

            return categoriesResult;
        }
        public ImportProductResult ImportProductList(List<ImportProductRequest> importProductRequests)
        {
            string tmpFile = "";
            try
            {
                ImportProductResult importProductResult = new ImportProductResult();
                string serviceUrl = _endpoint + "/product/api/products/import";

                tmpFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".json");


                string fileContent = JsonConvert.SerializeObject(importProductRequests);
                File.WriteAllText(tmpFile, fileContent, Encoding.UTF8);
                var form = new MultipartFormDataContent();

                var fileByteContent = new ByteArrayContent(File.ReadAllBytes(tmpFile));
                fileByteContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                form.Add(fileByteContent, "file", Path.GetFileName(tmpFile));

                var result = client.PostAsync(serviceUrl, form).Result;


                if (result.IsSuccessStatusCode)
                {
                    var serviceReturn = result.Content.ReadAsStringAsync().Result;
                    importProductResult = JsonConvert.DeserializeObject<ImportProductResult>(serviceReturn);

                    return importProductResult;
                }
                else
                {
                    var statusCode = result.StatusCode;
                    importProductResult.success = false;
                    return importProductResult;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                File.Delete(tmpFile);
            }

        }
    }
}
