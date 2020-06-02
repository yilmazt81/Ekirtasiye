using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class HepsiBuradaCategory
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
        public bool Leaf { get; set; }
        public string Status { get; set; }
        public bool Available { get; set; }

        public bool TargetCategory { get; set; }

    }
}
