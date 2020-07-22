using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class TrendyolProductAttribute
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Attributeid { get; set; }
        public string AttributeName { get; set; }
        public int AttributeValue { get; set; }
        public string AttributeCustomeValue { get; set; }

    }
}
