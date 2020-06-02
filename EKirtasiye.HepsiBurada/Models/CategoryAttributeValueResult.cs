using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.HepsiBurada
{
    

    public class CategoryAttributeValueResult
    {
        public bool success { get; set; }
        public int code { get; set; }
        public int version { get; set; }
        public object message { get; set; }
        public Datum[] data { get; set; }
    }

    public class Datum
    {

        public string id { get; set; }
        public string value { get; set; }
    }

}
