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
            _endPoint = "https://api.trendyol.com/sapigw";
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

        public CategoryAttributeReturn GetCategoryAttributes(int categoryId)
        {
            string serviceUrl = $"{_endPoint}/product-categories/{categoryId}/attributes";
            var result = client.GetAsync(serviceUrl).Result;
            CategoryAttributeReturn categoryAttributes = null;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;
                categoryAttributes = JsonConvert.DeserializeObject<CategoryAttributeReturn>(str);
            }

            return categoryAttributes;
        }
    }


    public class CategoryAttributeReturn
    {
        public int id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public Categoryattribute[] categoryAttributes { get; set; }
    }

 
    public class Categoryattribute
    {
        public int categoryId { get; set; }
        public Attribute attribute { get; set; }
        public bool required { get; set; }
        public bool allowCustom { get; set; }
        public bool varianter { get; set; }
        public bool slicer { get; set; }
        public Attributevalue[] attributeValues { get; set; }
    }

    public class Attribute
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Attributevalue
    {
        public int id { get; set; }
        public string name { get; set; }
    }


}
