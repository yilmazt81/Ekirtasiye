using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class N11Category
    { 
        public long Id { get; set; }
        public long ParentCategoryId { get; set; }
        public string Name { get; set; }
        public bool TargetCategory { get; set; }


    }
}
