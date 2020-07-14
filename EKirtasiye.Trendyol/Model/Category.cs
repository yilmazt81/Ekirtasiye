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

        public int parentId { get; set; }
        public Category[] subCategories { get; set; }
    }
 

    public class CategoryAttribute
    {
        public string name { get; set; }
        public string displayName { get; set; }     
        public bool allowCustom { get; set; }
        public bool required { get; set; }
        public bool slicer { get; set; }
        public bool varianter { get; set; }

        public cAttribute[] attribute { get; set; }

        public cAttribute[] attributeValues { get; set; }
         
    }

    public class cAttribute
    {
        public string id { get; set; }
        public string name { get; set; }
    }



}
