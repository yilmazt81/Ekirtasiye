using EKirtasiye.DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EKirtasiyeRestApi.Controllers
{
    [RoutePrefix("api/ProductCategory")]

    public class ProductCategoryController : ApiController
    {
        public ProductCategoryController()
        {
            DBHelper.SqlConnectionStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        }

        [HttpGet]
        public IEnumerable<ProductCategory> Get()
        {
            return ProductCategoryRepository.GetProductCategories();
        }
        
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<ProductCategory> GetAll()
        {
            return ProductCategoryRepository.GetProductCategoriesAll();
        }
       
        // GET api/values/5
        [HttpGet]
        public ProductCategory Get(int id)
        {
            return ProductCategoryRepository.GetProductCategori(id);
        }

        [HttpGet]
        [Route("getFromUpId/{id:int}")]
        public List<ProductCategory> GetFromUpId(int id)
        {
            return ProductCategoryRepository.GetProductCategories(id);
        }

        // POST api/values
        [HttpPost]
        public ProductCategory Post(ProductCategory value)
        {
            ProductCategoryRepository.SaveCategory(value);

            return value;
        }



    }
}
