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
        [Route("GetTrendyolCategoryDefaultAttribute/{categoryId}/{attributeId}")]
        [HttpGet]
        public TrendyolCategoryDefaultAttribute GetTrendyolCategoryDefaultAttribute(int categoryId,int attributeId)
        {
            
            return TrendyolCategoryRepository.GetDefaultAttribute(categoryId, attributeId);
        }

        [Route("GetCategoryDefaultAttributes/{categoryId}")]
        [HttpGet]
        public List<TrendyolCategoryDefaultAttribute> GetCategoryDefaultAttributes(int categoryId )
        {
            //GetCategoryDefaultAttributes
            return TrendyolCategoryRepository.GetCategoryDefaultAttributes(categoryId);
        }

        [Route("SaveCategoryDefaultAttribute")]
        [HttpPost]
        public string SaveCategoryDefaultAttribute(List<TrendyolCategoryDefaultAttribute> trendyolCategoryDefaultAttributes)
        {

            try
            {
                TrendyolCategoryRepository.SaveCategoryDefaultAttribute(trendyolCategoryDefaultAttributes);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [Route("SaveTrendyolCreateRequest")]
        [HttpPost]
        public string SaveTrendyolCreateRequest(TrendyolCreateRequest trendyolCreateRequest)
        {
            try
            {
                TrendyolCategoryRepository.SaveTrendyolCreateRequest(trendyolCreateRequest);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /*

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
        }*/

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
        [Route("SaveTrendyolAttributes")]
        [HttpPost]
        public string SaveTrendyolAttributes(List<TrendyolProductAttribute> trendyolAttributes)
        {
            try
            {
                TrendyolCategoryRepository.SaveTrendyolProductAttributes(trendyolAttributes);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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
