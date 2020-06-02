using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.HepsiBurada
{
    public class ImportProductRequest
    {
        public ImportProductRequest()
        {
            attributes = new ImportProductattribute()
            {
                GarantiSuresi = "24"
            };

        }
        public int categoryId { get; set; }
        public string merchant { get; set; }


        public ImportProductattribute attributes { get; set; }
    }

    public class ImportProductattribute
    {
        public string merchantSku { get; set; }
        public string Barcode { get; set; }
        public string UrunAdi { get; set; }
        public string UrunAciklamasi { get; set; }
        public string Marka { get; set; }
        public string GarantiSuresi { get; set; }
        public string kg { get; set; }

        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }

        public string renk_variant_property { get; set; }

        public string ebatlar_variant_property { get; set; }



    }
}
