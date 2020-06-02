using EKirtasiye.DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EKirtasiyeRestApi.Controllers
{
    [RoutePrefix("api/ProductUrl")]
    public class ProductUrlController : ApiController
    {
        public ProductUrlController()
        {
            DBHelper.SqlConnectionStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }
        // GET: api/ProductUrl
        public IEnumerable<ProductUrl> Get()
        {
            return new ProductUrl[] { new ProductUrl(), new ProductUrl() };
        }

        // GET: api/ProductUrl/5
        public ProductUrl Get(int id)
        {
            return new ProductUrl();
        }

        [HttpGet]
        [Route("GetUrlLocked/{lockedBy}/{source}")]
        public List<ProductUrl> GetUrlLocked(int lockedBy,string source)
        {
           return IdeaCatalogRepository.GetReadProductUrls(lockedBy, source);
        }

        // POST: api/ProductUrl
        public void Post(ProductUrl value)
        {

            IdeaCatalogRepository.SaveProductUrl(value);
        }

        // PUT: api/ProductUrl/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductUrl/5
        public void Delete(int id)
        {
        }
    }
}
