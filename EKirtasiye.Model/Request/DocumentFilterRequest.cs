using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class DocumentFilterRequest
    {

        public DocumentFilterRequest()
        {
            StokCodeList = new string[0];
        }

        public string DateFilterType { get; set; }

        public string WebExportState { get; set; }
        public string StokSource { get; set; }
        public int MainCategoryId { get; set; }

        public int CategoryId { get; set; }

        public  int SubCategoryId { get; set; }

        public string StokCode { get; set; }

        public string HaveInternetPrice { get; set; }

        public string ProductStatus { get; set; }

        public string N11Export { get; set; } 
        public string HepsiBuradaExport { get; set; }

        public string ExportTrendyol { get; set; }

        public string IdeaExport { get; set; }

        public string[] StokCodeList { get; set; }
        public string PriceFilterType { get; set; }
        public string PriceFilter { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string ExportCicekSepeti { get; set; }
        public string HavePicture { get; set; }
    }
}
