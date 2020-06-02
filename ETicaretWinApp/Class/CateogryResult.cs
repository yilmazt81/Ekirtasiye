using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretWinApp.Class
{
    public class CategoryResult
    {
        public bool result { get; set; }
        public DataCategory data { get; set; }
    }



    public class DataCategory
    {
        public Breadcrumb[] breadcrumb { get; set; }
        public CategoryProduct[] list { get; set; }
        public Pagination pagination { get; set; }
        public string list_type { get; set; }
    }

    public class CategoryProduct
    {
        [JsonProperty("a")]
        public string Id { get; set; }
        [JsonProperty("b")]
        public string StockCode { get; set; }
        [JsonProperty("c")]
        public string ProductName { get; set; }
        
        [JsonProperty("f")]
        public StokDurum[] StokDurumu { get; set; }
    }

    public class Pagination
    {
        public int total_rows { get; set; }
        public int per_page { get; set; }
        public int total_page { get; set; }
        public int current_page { get; set; }
    }

    public class Breadcrumb
    {
        public string a { get; set; }
        public string b { get; set; }
    }






}
