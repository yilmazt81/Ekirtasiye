using EKirtasiye.DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EKirtasiyeRestApi.Controllers
{
    public class CatalogCategoryMatchController : ApiController
    {
        public CatalogCategoryMatchController()
        {
            DBHelper.SqlConnectionStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }
        // GET: api/CatalogCategoryMatch
        public IEnumerable<IdeaCatalogCategoryMatch> Get()
        {
            return ProductCategoryRepository.GetIdeaCatalogCategoryMatches();
        }

        // GET: api/CatalogCategoryMatch/5
        public IdeaCatalogCategoryMatch Get(int id)
        {
            return ProductCategoryRepository.GetIdeaCatalogCategoryMatches().SingleOrDefault(s => s.Id == id);
        }

        // POST: api/CatalogCategoryMatch
        public void Post(IdeaCatalogCategoryMatch value)
        {
            ProductCategoryRepository.SaveIdeaCatalogCategoryMatch(value);
        }

        
    }
}
