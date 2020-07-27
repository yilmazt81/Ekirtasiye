using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.N11
{
    public class N11CategoryAttribute
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Mandatory { get; set; }
        public bool Multiselect { get; set; }

        public N11CategoryAttributeValue[] N11CategoryAttributes { get; set; }


    }

    public class N11CategoryAttributeValue
    {
        public long Id { get; set; }
        public string Name { get; set; }

    }
}
