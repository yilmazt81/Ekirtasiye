using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.HepsiBurada
{

    public class CategoriesResult

    {
        public bool success { get; set; }
        public int code { get; set; }
        public int version { get; set; }
        public object message { get; set; }
        public int totalElements { get; set; }
        public int totalPages { get; set; }
        public int number { get; set; }
        public int numberOfElements { get; set; }
        public bool first { get; set; }
        public bool last { get; set; }
        public Hcategory[] data { get; set; }
    }

    public class Hcategory
    {
        public int categoryId { get; set; }
        public string name { get; set; }
        public int parentCategoryId { get; set; }
        public string[] paths { get; set; }
        public bool leaf { get; set; }
        public string status { get; set; }
        public bool available { get; set; }
    }

}
