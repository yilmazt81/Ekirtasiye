using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class N11Category
    { 
        public int Id { get; set; }
        public int ParentCategoryId { get; set; }
        public string Name { get; set; }
        public bool TargetCategory { get; set; }


    }

    public class N11CategoryAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Mandatory { get; set; }
        public bool MultiSelect { get; set; }

    }

    public class N11CategoryAttributeValue
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }

        public string Value { get; set; }

    }
}
