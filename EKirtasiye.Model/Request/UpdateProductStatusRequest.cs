using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class UpdateProductStatusRequest
    {
        public List<IdeaCatalog> ProductIdList { get; set; }

        public string WebStatus { get; set; }

    }
}
