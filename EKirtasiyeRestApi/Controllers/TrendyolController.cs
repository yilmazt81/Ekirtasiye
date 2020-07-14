using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EKirtasiye.Model;
using EKirtasiye.DBLayer;

namespace EKirtasiyeRestApi.Controllers
{
    [RoutePrefix("api/trendyol")]
    public class TrendyolController : ApiController
    {
        public TrendyolController()
        {
            DBHelper.SqlConnectionStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }
        // GET: api/trendyol
        public IEnumerable<TrendyolCategory> Get()
        {
            return TrendyolCategoryRepository.GetCategory();
        }

        // GET: api/N11/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("SaveCategory")]
        [HttpPost]
        public string Post(TrendyolCategory nCategory)
        {
            try
            {
                TrendyolCategoryRepository.SaveCategory(nCategory);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("GetCategoryAttribute/{categoryId}")]
        [HttpGet]
        public List<TrendyolAttribute> GetCategoryAttribute(int categoryId)
        {

         return   TrendyolCategoryRepository.GetTrendyolAttributes(categoryId);



        }
        [Route("SaveDefaultAttributes")]
        [HttpPost]
        public string SaveDefaultAttribute(TrendyolCategoryDefaultAttribute categoryDefaultAttribute)
        {
            try
            {
                TrendyolCategoryRepository.SaveTrendyolDefaulAttribute(categoryDefaultAttribute);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("SaveTrendyolAttribute")]
        [HttpPost]
        public string SaveTrendyolAttribute(TrendyolAttribute trendyolAttribute)
        {
            try
            {
                TrendyolCategoryRepository.SaveTrendyolAttribute(trendyolAttribute);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /*
        [Route("GetEXportTemplates")]
        [HttpGet]
        public List<N11ExportTemplate> GetEXportTemplates()
        {

            return N11ExportTemplateRepository.GetN11ExportTemplates();


        }
        [Route("GetEXportTemplate/{id}")]
        [HttpGet]
        public N11ExportTemplate GetExportTemplate(int id)
        {

            return N11ExportTemplateRepository.GetN11ExportTemplates(id);


        }*/

        // PUT: api/N11/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/N11/5
        public void Delete(int id)
        {
        }
    }
}
