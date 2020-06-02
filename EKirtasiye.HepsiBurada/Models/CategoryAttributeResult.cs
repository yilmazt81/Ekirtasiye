using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.HepsiBurada
{

    public class CategoryAttributeResult
    {
        public bool success { get; set; }
        public int code { get; set; }
        public int version { get; set; }
        public object message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public Baseattribute[] baseAttributes { get; set; }
        public Attribute[] attributes { get; set; }
        public object[] variantAttributes { get; set; }
    }

    public class Baseattribute
    {
        public string name { get; set; }
        public string id { get; set; }
        public bool mandatory { get; set; }
        public string type { get; set; }
        public bool multiValue { get; set; }
    }

    public class Attribute
    {
        public string name { get; set; }
        public string id { get; set; }
        public bool mandatory { get; set; }
        public string type { get; set; }
        public bool multiValue { get; set; }
    }

}
