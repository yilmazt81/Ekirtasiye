using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class TrendyolCreateRequest
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string BatchRequest { get; set; }

        public DateTime RequestDate { get; set; }

        public string RequestType { get; set; }


    }
}
