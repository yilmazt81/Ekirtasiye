using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.Trendyol
{

    public class CategoryRequestReturn
    {
        public Category[] categories { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public Subcategory[] subCategories { get; set; }
    }

    public class Subcategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parentId { get; set; }
        public Category[] subCategories { get; set; }
    }
     

}
