using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.Trendyol
{
    public class CategoryHelper
    {
        HttpClient client = new HttpClient();
        private string _endPoint = string.Empty;
        public CategoryHelper(string endPoint)
        {
            _endPoint = endPoint;
        }

        public CategoryRequestReturn GetTrendyolCategories()
        {
            string serviceUrl = $"{_endPoint}/product-categories";
            var result = client.GetAsync(serviceUrl).Result;
            CategoryRequestReturn categoriesResult = null;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;
                categoriesResult = JsonConvert.DeserializeObject<CategoryRequestReturn>(str);
            }

            return categoriesResult;
        }
    }
}
