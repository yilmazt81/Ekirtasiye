using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EKirtasiye.Model;

namespace EKirtasiye.DBLayer
{
    public class N11ExportTemplateRepository
    {

        public static void SaveN11ExportTemplate(N11ExportTemplate n11ExportTemplate)
        {

            DBHelper.ExecuteCommand("pSaveN11ExportTemplate", new SqlParameter[]
            {
                new SqlParameter("@Id",n11ExportTemplate.Id),
                new SqlParameter("@TemplateName",n11ExportTemplate.TemplateName),
                new SqlParameter("@CargoDay",n11ExportTemplate.CargoDay),
                new SqlParameter("@DeliveryTemplate",n11ExportTemplate.DeliveryTemplate),
                new SqlParameter("@CalculatePriceType",n11ExportTemplate.CalculatePriceType),
                new SqlParameter("@CalculateType",n11ExportTemplate.CalculateType),
                new SqlParameter("@CalculateValue",n11ExportTemplate.CalculateValue),
                new SqlParameter("@StartDate", (n11ExportTemplate.StartDate==null?DBNull.Value:(object)n11ExportTemplate.StartDate)),
                new SqlParameter("@EndDate", (n11ExportTemplate.EndDate==null?DBNull.Value:(object)n11ExportTemplate.EndDate)),
                new SqlParameter("@SubText",n11ExportTemplate.SubText),

            });
        }

        public static List<N11ExportTemplate> GetN11ExportTemplates()
        {
            var templateList = DBHelper.GetQuery("select * from N11ExportTemplate");

            return templateList.Rows.Cast<DataRow>().Select(s => ConvertTemplate(s)).ToList();
             
        }

        public static  N11ExportTemplate  GetN11ExportTemplates(int id)
        {
            var templateList = DBHelper.GetQuery("select * from N11ExportTemplate where Id="+id);

            return templateList.Rows.Cast<DataRow>().Select(s => ConvertTemplate(s)).FirstOrDefault();


        }
        private static N11ExportTemplate ConvertTemplate(DataRow s)
        {

            return new N11ExportTemplate()
            {
                Id = Convert.ToInt32(s["Id"]),
                CalculatePriceType = s["CalculatePriceType"].ToString(),
                CalculateType = s["CalculateType"].ToString(),
                CalculateValue = s["CalculateValue"].ToString(),
                CargoDay = Convert.ToInt32(s["CargoDay"]),
                DeliveryTemplate = s["DeliveryTemplate"].ToString(),
                SubText = s["SubText"].ToString(),
                TemplateName = s["TemplateName"].ToString(),
                EndDate = (s["EndDate"] == DBNull.Value ? null : (DateTime?)s["EndDate"]),
                StartDate = (s["StartDate"] == DBNull.Value ? null : (DateTime?)s["StartDate"])


            };
        }
    }
}
