using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.HepsiBurada
{
    public class ImportProductCheckResult
    {
        public bool success { get; set; }
        public int code { get; set; }
        public int version { get; set; }
        public object message { get; set; }
        public int totalElements { get; set; }
        public int totalPages { get; set; }
        public int number { get; set; }
        public int numberOfElements { get; set; }
        public bool first { get; set; }
        public bool last { get; set; }
        public ImportProductItem[] data { get; set; }
    }




    public class ImportProductItem
    {
        public int itemOrderID { get; set; }
        public string merchant { get; set; }
        public string merchantSku { get; set; }
        public object productStatus { get; set; }
        public object[] taskDetails { get; set; }
        public object[] validationResults { get; set; }
        public string importStatus { get; set; }
        public Importmessage[] importMessages { get; set; }
    }

    public class Importmessage
    {
        public string severity { get; set; }
        public string message { get; set; }
    }

}
