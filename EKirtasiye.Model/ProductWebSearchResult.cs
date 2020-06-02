using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class ProductWebSearchResult
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public string LinkName { get; set; }

        public string ProductUrl { get; set; }
        public string ProductImage { get; set; }
        public string ProductPrice { get; set; }

        public double ProductSimilarity { get; set; }


    }
}
