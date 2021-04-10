using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.CicekSepeti
{
    public class CicekSepetiCategoryReturn
    {
        public CicekCategory[] categories { get; set; }
    }


 

    public class CicekCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public object parentCategoryId { get; set; }
        public CicekCategory[] subCategories { get; set; }
    } 

}
