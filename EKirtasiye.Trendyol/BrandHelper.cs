using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.Trendyol
{
    public class BrandHelper
    {
        private string _endPoint = string.Empty;

        HttpClient client = new HttpClient();

        public BrandHelper(string endPoint)
        {
            _endPoint = "https://api.trendyol.com/sapigw/";
        }

        public BrandReturn  GetBrands()
        {
            string serviceUrl = $"{_endPoint}brands";

            var result = client.GetAsync(serviceUrl).Result;
            BrandReturn brands = null;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;
                brands = JsonConvert.DeserializeObject<BrandReturn>(str);
            }

            return brands;
        }
    }

    public class Brand
    {
        public int id { get; set; }
        public string name { get; set; }

    }


    public class BrandReturn
    {
        public Brand[] brands { get; set; }
    }

   

}
