using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EKirtasiye.DBLayer;
using EKirtasiye.Model;

namespace EKirtasiyeRestApi.Controllers
{
    [RoutePrefix("api/HepsiBurada")]
    public class HepsiBuradaController : ApiController
    {

        public HepsiBuradaController()
        {
            DBHelper.SqlConnectionStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }
        // GET: api/HepsiBurada
        public IEnumerable<HepsiBuradaCategory> Get()
        {
            return HepsiBuradaCategoryRepository.GetHepsiBuradaCategories();
        }



        [Route("SaveCategory")]
        [HttpPost]
        public string SaveCategory(HepsiBuradaCategory hepsiBuradaCategory)
        {
            try
            {
                HepsiBuradaCategoryRepository.SaveCategory(hepsiBuradaCategory);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
          

        }

        // GET: api/HepsiBurada/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HepsiBurada
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/HepsiBurada/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HepsiBurada/5
        public void Delete(int id)
        {
        }
    }
}
