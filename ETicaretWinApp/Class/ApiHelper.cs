using EKirtasiye.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretWinApp
{
    public static class ApiHelper
    {
        static HttpClient client = null;

        static List<string> lProductBrand = new List<string>();
        static List<ProductCategory> productCategories = new List<ProductCategory>();


        static string baseUrl = "";
        static ApiHelper()
        {
            client = new HttpClient();
            baseUrl = System.Configuration.ConfigurationManager.AppSettings["ApiUrl"];
            System.Net.Http.Headers.ProductHeaderValue productInfoHeaderValue = new System.Net.Http.Headers.ProductHeaderValue("EKirtasiye", "1.0.0.1");
            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue(productInfoHeaderValue));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("deflate"));
        }



        public static void DownladImageToLocal(string picturePath, string tmpPath)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add(HttpRequestHeader.UserAgent, "EKirtasiye");
                webClient.DownloadFile(picturePath, tmpPath);

            }
        }

        public static List<ProductCategory> GetProductCategories()
        {
            List<ProductCategory> productCategories = new List<ProductCategory>();

            string url = baseUrl + "api/ProductCategory";

            var result = client.GetAsync(url).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                productCategories = JsonConvert.DeserializeObject<List<ProductCategory>>(str);
            }
;
            return productCategories;
        }
        public static ProductCategory GetCategory(int id)
        {

            return productCategories.SingleOrDefault(s => s.Id == id);
        }
        public static List<ProductCategory> GetAllProductCategories()
        {

            if (productCategories.Count != 0)
                return productCategories;

            string url = baseUrl + "api/ProductCategory/GetAll";

            var result = client.GetAsync(url).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                productCategories = JsonConvert.DeserializeObject<List<ProductCategory>>(str);
            }
;
            return productCategories;
        }


        public static List<ProductCategory> GetProductCategoriesByUpId(int upId)
        {
            if (productCategories.Count() == 0)
            {
                GetAllProductCategories();
            }
          
            return productCategories.Where(s => s.UpId == upId).ToList();
        }

        public static List<IdeaCatalogCategoryMatch> GetIdeaCatalogCategoryMatches()
        {

            List<IdeaCatalogCategoryMatch> productCategories = new List<IdeaCatalogCategoryMatch>();

            string url = baseUrl + $"api/CatalogCategoryMatch";

            var result = client.GetAsync(url).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                productCategories = JsonConvert.DeserializeObject<List<IdeaCatalogCategoryMatch>>(str);
            }

            return productCategories;
        }

        public static bool InsertCategory(ProductCategory productCategory)
        {
            string url = baseUrl + $"api/ProductCategory";
            var jsonClass = JsonConvert.SerializeObject(productCategory);
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");

            var result = client.PostAsync(url, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;
                var newproductCategory = JsonConvert.DeserializeObject<ProductCategory>(str);
                if (!productCategories.Any(s => s.Id == newproductCategory.Id))
                {
                    productCategories.Add(newproductCategory);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool InsertIdeaCatalog(IdeaCatalog ideaCatalog)
        {

            string url = baseUrl + $"api/IdeaCatalog";
            var jsonClass = JsonConvert.SerializeObject(ideaCatalog);
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");

            var result = client.PostAsync(url, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                return true;
            }
            else
            {
                return false;
            }
        }
        public static string[] GetWebExportStatus()
        {

            List<string> productCategories = new List<string>();

            string url = baseUrl + $"api/IdeaCatalog/getwebexportstatus";

            var result = client.GetAsync(url).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                productCategories = JsonConvert.DeserializeObject<List<string>>(str);
            }

            return productCategories.ToArray();
        }
        public static string[] GetStockSourceStatus()
        {

            List<string> productCategories = new List<string>();

            string url = baseUrl + $"api/IdeaCatalog/GetStokSourceStatus";

            var result = client.GetAsync(url).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                productCategories = JsonConvert.DeserializeObject<List<string>>(str);
            }

            return productCategories.ToArray();
        }

        public static List<string> GetProductBrands()
        {

            return lProductBrand;
        }

        public static bool IsExistImageUrl(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
                return false;

            if (!imageUrl.StartsWith("http"))
            {
                return System.IO.File.Exists(imageUrl);
            }

            bool exists;
            try
            {

                var result = client.GetAsync(imageUrl).Result;

                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    exists = true;
                }
                else
                {
                    exists = true;
                }

            }
            catch (Exception ex)
            {
                exists = false;
            }

            return exists;
        }

        public static string[] GetInternetPrice()
        {

            return new string[] { "Tümü", "Var", "Yok" };
        }
        public static List<IdeaCatalog> FilterCatalog(DocumentFilterRequest documentFilterRequest)
        {
            List<IdeaCatalog> ideaCatalogs = new List<IdeaCatalog>();

            string url = baseUrl + $"api/IdeaCatalog/getProductWebWithStatus";

            var jsonClass = JsonConvert.SerializeObject(documentFilterRequest);
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");

            var result = client.PostAsync(url, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                ideaCatalogs = JsonConvert.DeserializeObject<List<IdeaCatalog>>(str);
                lProductBrand = ideaCatalogs.Where(s => !string.IsNullOrEmpty(s.Brand)).Select(s => s.Brand).Distinct().ToList();
            }

            return ideaCatalogs;
        }

        public static bool SaveProductUrl(ProductUrl productUrl)
        {


            string url = baseUrl + $"api/ProductUrl";
            var jsonClass = JsonConvert.SerializeObject(productUrl);
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");

            var result = client.PostAsync(url, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool UpdateProductCategoryList(UpdateProductGroupRequest updateProductGroup)
        {
            string url = baseUrl + $"api/IdeaCatalog/UpdateProductCategory";
            var jsonClass = JsonConvert.SerializeObject(updateProductGroup);
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");

            var result = client.PostAsync(url, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                return true;
            }
            else
            {
                return false;
            }
        }
        //GetUrlLocked/lockedBy/source

        public static List<ProductUrl> GetIdeaCatalogFromBarcode(int lockedby, string productSource)
        {
            List<ProductUrl> productUrls = null;

            string url = baseUrl + $"api/ProductUrl/GetUrlLocked/{lockedby}/{productSource}";

            var result = client.GetAsync(url).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                productUrls = JsonConvert.DeserializeObject<List<ProductUrl>>(str);
            }

            return productUrls;
        }
        public static IdeaCatalog GetIdeaCatalogFromBarcode(string barcode, bool getFromBackup)
        {
            IdeaCatalog ideaCatalog = null;

            string url = baseUrl + $"api/IdeaCatalog/GetIdeaCatalogFromBarcode/{barcode}/{getFromBackup}";

            var result = client.GetAsync(url).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                ideaCatalog = JsonConvert.DeserializeObject<IdeaCatalog>(str);
            }

            return ideaCatalog;
        }

        public static bool UpdateProductPrice(UpdateProductPriceRequest updateProductPrice)
        {

            string url = baseUrl + $"api/IdeaCatalog/UpdateProductPrice";
            var jsonClass = JsonConvert.SerializeObject(updateProductPrice);
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");

            var result = client.PostAsync(url, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool UpdateProductPictures(UpdateProductPictureRequest updateProductPicture)
        {

            string url = baseUrl + $"api/IdeaCatalog/UpdateProductPictures";
            var jsonClass = JsonConvert.SerializeObject(updateProductPicture);
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");

            var result = client.PostAsync(url, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool UpdateProductWebExportState(UpdateProductStatusRequest updateProductPicture)
        {

            string url = baseUrl + $"api/IdeaCatalog/UpdateProductWebExportStatus";
            var jsonClass = JsonConvert.SerializeObject(updateProductPicture);
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");

            var result = client.PostAsync(url, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool SaveProductWebResult(List<ProductWebSearchResult> productWebSearchResults)
        {
            string url = baseUrl + $"api/IdeaCatalog/SaveProductWebResult";
            var jsonClass = JsonConvert.SerializeObject(productWebSearchResults);
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");

            var result = client.PostAsync(url, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool SaveInstagramUser(InstagramUserFollowing instagramUserFollowing)
        {
            string url = baseUrl + $"api/InstagramUser";
            var jsonClass = JsonConvert.SerializeObject(instagramUserFollowing);
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");

            var result = client.PostAsync(url, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<InstagramUserFollowing> GetInstagramUser()
        {
            string url = baseUrl + $"api/InstagramUser";

            List<InstagramUserFollowing> userFollowings = new List<InstagramUserFollowing>();
            var result = client.GetAsync(url).Result;

            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;
                userFollowings = JsonConvert.DeserializeObject<List<InstagramUserFollowing>>(str);

            }

            return userFollowings;
        }

        public static List<ShareType> GetShareTypes()
        {
            string url = baseUrl + $"api/InstagramUser/GetShareTypes";

            var result = client.GetAsync(url).Result;
            List<ShareType> shareTypes = new List<ShareType>();
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                shareTypes = JsonConvert.DeserializeObject<List<ShareType>>(str);
            }

            return shareTypes;
        }

        public static List<ShareTypesTemplate> GetShareTemplates(int shareTypeId)
        {
            string url = baseUrl + $"api/InstagramUser/GetShareTypesTemplate/{shareTypeId}";

            var result = client.GetAsync(url).Result;
            List<ShareTypesTemplate> shareTypes = new List<ShareTypesTemplate>();
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                shareTypes = JsonConvert.DeserializeObject<List<ShareTypesTemplate>>(str);
            }

            return shareTypes;
        }
        public static List<ShareTypesTemplate> GetAllTemplates()
        {
            string url = baseUrl + $"api/InstagramUser/GetShareTypesTemplateLastUpdate";

            var result = client.GetAsync(url).Result;
            List<ShareTypesTemplate> shareTypes = new List<ShareTypesTemplate>();
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                shareTypes = JsonConvert.DeserializeObject<List<ShareTypesTemplate>>(str);
            }

            return shareTypes;
        }

        public static ShareTypesTemplate GetShareTemplate(int id)
        {
            string url = baseUrl + $"api/InstagramUser/GetShareTypeTemplate/{id}";

            var result = client.GetAsync(url).Result;
            ShareTypesTemplate shareTypes = null;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                shareTypes = JsonConvert.DeserializeObject<ShareTypesTemplate>(str);
            }

            return shareTypes;
        }
        public static bool SaveShareTypesTemplate(ShareTypesTemplate shareTypesTemplate)
        {
            string url = baseUrl + $"api/InstagramUser/SaveShareTypeTemplate";
            var jsonClass = JsonConvert.SerializeObject(shareTypesTemplate);
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");

            var result = client.PostAsync(url, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;
                shareTypesTemplate = JsonConvert.DeserializeObject<ShareTypesTemplate>(str);
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool SaveHepsiBuradaCategory(HepsiBuradaCategory hepsiBuradaCategory)
        {

            string url = baseUrl + $"api/HepsiBurada/SaveCategory";
            var jsonClass = JsonConvert.SerializeObject(hepsiBuradaCategory);
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");

            var result = client.PostAsync(url, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                return (str == "ok");
            }
            else
            {
                return false;
            }
        }

        public static bool SaveN11Category(N11Category n11Category)
        {

            string url = baseUrl + $"api/N11/SaveCategory";
            var jsonClass = JsonConvert.SerializeObject(n11Category);
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");

            var result = client.PostAsync(url, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                return (str == "ok");
            }
            else
            {
                return false;
            }
        }
        public static bool SaveN11ExportTemplate(N11ExportTemplate n11ExportTemplate)
        {

            string url = baseUrl + $"api/N11/SaveExportTemplate";
            var jsonClass = JsonConvert.SerializeObject(n11ExportTemplate);
            var content = new StringContent(jsonClass, Encoding.UTF8, "application/json");

            var result = client.PostAsync(url, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                return (str == "ok");
            }
            else
            {
                return false;
            }
        }

        public static List<N11ExportTemplate> GetN11ExportTemplate()
        {

            string url = baseUrl + $"api/N11/GetEXportTemplates";

            var result = client.GetAsync(url).Result;

            List<N11ExportTemplate> n11ExportTemplates = new List<N11ExportTemplate>();
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                n11ExportTemplates = JsonConvert.DeserializeObject<List<N11ExportTemplate>>(str);
            }

            return n11ExportTemplates;
        }
        public static N11ExportTemplate GetN11ExportTemplate(int id)
        {

            string url = baseUrl + $"api/N11/GetEXportTemplate/{id}";

            var result = client.GetAsync(url).Result;

            N11ExportTemplate n11ExportTemplate = null;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                n11ExportTemplate = JsonConvert.DeserializeObject<N11ExportTemplate>(str);
            }

            return n11ExportTemplate;
        }

        public static List<N11Category> GetN11Category()
        {

            string url = baseUrl + $"api/N11";
            
            List<N11Category> n11Categories = null;

            var result = client.GetAsync(url).Result;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;

                n11Categories = JsonConvert.DeserializeObject<List<N11Category>>(str);
            }

            return n11Categories;

        }

        public static List<HepsiBuradaCategory> GetHepsiBuradaCategories()
        {
            string url = baseUrl + $"api/HepsiBurada/";
             
            return GetRequest<List<HepsiBuradaCategory>>(url);
        }

        public static IdeaCatalog[] GetExportExternalShopExportProducts(string shopName)
        {
            string url = baseUrl + $"api/IdeaCatalog/exportexternalshop/{shopName}";

            return GetRequest<IdeaCatalog[]>(url);
            
        }



        public static bool UpdateProductShopId(UpdateProductShopRequest updateProductShopRequest)
        {

            string url = baseUrl + $"api/IdeaCatalog/exportexternalshop/UpdateProductShop";            
             
            var saveOk = PostRequest<string, UpdateProductShopRequest>(url, updateProductShopRequest);
            return (saveOk == "ok");
        }

        public static bool UpdateShopProductState(UpdateProductShopSaleRequest productShopSaleRequest)
        {
            string url = baseUrl + $"api/IdeaCatalog/exportexternalshop/UpdateShopProductState";
            var saveOk = PostRequest<string, UpdateProductShopSaleRequest>(url, productShopSaleRequest);
            return (saveOk == "ok");
        }
        /*
        public static bool TrendyolSaveDefaultAttribute(TrendyolCategoryDefaultAttribute defaultAttribute)
        {
            string url = baseUrl + $"api/trendyol/SaveDefaultAttributes";
            var saveOk = PostRequest<string, TrendyolCategoryDefaultAttribute>(url, defaultAttribute);
            return (saveOk == "ok");
        }*/

        public static bool TrendyolSaveCategory(TrendyolCategory trendyolCategory)
        {
            string url = baseUrl + $"api/trendyol/SaveCategory";
            var saveOk = PostRequest<string, TrendyolCategory>(url, trendyolCategory);
            return (saveOk == "ok");
        }

        public static bool SaveCategoryDefaultAttribute(List<TrendyolCategoryDefaultAttribute> trendyolCategoryDefaultAttributes)
        {
            string url = baseUrl + $"api/trendyol/SaveCategoryDefaultAttribute";
            var saveOk = PostRequest<string, List<TrendyolCategoryDefaultAttribute>>(url, trendyolCategoryDefaultAttributes);
            return (saveOk == "ok");
        }
        public static bool TrendyolSaveAttribute(TrendyolAttribute trendyolAttribute)
        {
            string url = baseUrl + $"api/trendyol/SaveTrendyolAttribute";
            var saveOk = PostRequest<string, TrendyolAttribute>(url, trendyolAttribute);
            return (saveOk == "ok");
        }

        public static List<TrendyolCategory> GetTrendyolCategories()
        {
            string url = baseUrl + $"api/trendyol/";

            return GetRequest<List<TrendyolCategory>>(url);
            
        }
        public static List<TrendyolAttribute> GetTrendyolCategorieAttributes(int categoryId)
        {
            string url = baseUrl + $"api/trendyol/GetCategoryAttribute/{categoryId}";

            return GetRequest<List<TrendyolAttribute>>(url);
            //GetCategoryAttribute
        }

        public static TrendyolCategoryDefaultAttribute GetTrendyolCategoryDefaultAttribute(int categoryId,int attributeId)
        {
            string url = baseUrl + $"api/trendyol/GetTrendyolCategoryDefaultAttribute/{categoryId}/{attributeId}";

            return GetRequest<TrendyolCategoryDefaultAttribute>(url);
        }

        public static List<TrendyolCategoryDefaultAttribute> GetCategoryDefaultAttributes(int categoryId)
        {
            string url = baseUrl + $"api/trendyol/GetCategoryDefaultAttributes/{categoryId}";

            return GetRequest<List<TrendyolCategoryDefaultAttribute>>(url);
        }

        public static bool SaveTrendyolCreateRequest(TrendyolCreateRequest trendyolCreateRequest)
        {
            string url = baseUrl + $"api/trendyol/SaveTrendyolCreateRequest/";

            var saveOk = PostRequest<string, TrendyolCreateRequest>(url, trendyolCreateRequest);
            return (saveOk == "ok");
        }

        public static T PostRequest<T, K>(string url, K obj)
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

        public static T GetRequest<T>(string url)
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
