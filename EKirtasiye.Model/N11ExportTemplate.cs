using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class N11ExportTemplate
    {

        public int Id { get; set; }
        public string TemplateName { get; set; }
        public int CargoDay { get; set; }

        public string DeliveryTemplate { get; set; }

        public string CalculatePriceType { get; set; }

        public string CalculateType { get; set; }

        public string CalculateValue { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string SubText { get; set; }

        public override string ToString()
        {
            return TemplateName.ToString();
        }
    }
}
