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
    [RoutePrefix("api/N11")]
    public class N11Controller : ApiController
    {
        public N11Controller()
        {
            DBHelper.SqlConnectionStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }
        // GET: api/N11
        public IEnumerable<N11Category> Get()
        {
            return N11CategoryRepository.GetN11Category();
        }

        // GET: api/N11/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("SaveCategory")]
        [HttpPost]
        public string Post(N11Category n11Category)
        {
            try
            {
                N11CategoryRepository.SaveCategory(n11Category);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [Route("SaveExportTemplate")]
        [HttpPost]
        public string Post(N11ExportTemplate n11ExportTemplate)
        {
            try
            {
                N11ExportTemplateRepository.SaveN11ExportTemplate(n11ExportTemplate);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
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


        }

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
