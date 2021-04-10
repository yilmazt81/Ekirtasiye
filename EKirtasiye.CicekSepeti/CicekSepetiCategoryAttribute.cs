using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.CicekSepeti
{
    public class CicekSepetiCategoryAttribute
    {

        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public Categoryattribute[] categoryAttributes { get; set; }
    }


    

    public class Categoryattribute
    {
        public int attributeId { get; set; }
        public string attributeName { get; set; }
        public bool required { get; set; }
        public bool varianter { get; set; }
        public string type { get; set; }
        public Attributevalue[] attributeValues { get; set; }
    }

    public class Attributevalue
    {
        public int id { get; set; }
        public string name { get; set; }
    }

}
