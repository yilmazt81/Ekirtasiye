using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class TrendyolCategoryDefaultAttribute
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public int AttributeValue { get; set; }

    }
}
