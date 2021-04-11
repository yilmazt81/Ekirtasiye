﻿using EKirtasiye.DBLayer;
using EKirtasiye.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EKirtasiyeRestApi.Controllers
{

    [RoutePrefix("api/cicekSepeti")]
    public class CicekSepetiController : ApiController
    {
        public CicekSepetiController()
        {
            DBHelper.SqlConnectionStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }

        public IEnumerable<CicekSepetiCategory> Get()
        {
            return CicekSepetiCategoryRepository.GetCategory();
        }

        [Route("GetCategoryAttribute/{categoryId}")]
        [HttpGet]
        public List<CicekSepetiAttribute> GetCategoryAttribute(int categoryId)
        {

            return CicekSepetiCategoryRepository.GetCicekSepetiAttributes(categoryId);

        }



        [Route("GetCicekSepetiProductAttribute/{productId}")]
        [HttpGet]
        public List<CicekSepetiProductAttribute> GetCicekSepetiProductAttribute(int productId)
        {

            return CicekSepetiCategoryRepository.GetCicekSepetiProductAttribute(productId);

        }


        [Route("SaveCicekSepetiProductAttribute")]
        [HttpPost]
        public string SaveCicekSepetiProductAttribute(List<CicekSepetiProductAttribute> cicekSepetiProducts)
        {

            try
            {
                CicekSepetiCategoryRepository.SaveCicekSepetiProductAttributes(cicekSepetiProducts);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        [Route("SaveCategoryDefaultAttribute")]
        [HttpPost]
        public string SaveCategoryDefaultAttribute(List<CicekSepetiCategoryDefaultAttribute> cicekSepetiCategoryDefaultAttributes)
        {

            try
            {
                CicekSepetiCategoryRepository.SaveCategoryDefaultAttribute(cicekSepetiCategoryDefaultAttributes);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [Route("SaveCategory")]
        [HttpPost]
        public string Post(CicekSepetiCategory nCategory)
        {
            try
            {
                CicekSepetiCategoryRepository.SaveCategory(nCategory);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("GetCategoryDefaultAttribute/{categoryId}/{attributeId}")]
        [HttpGet]
        public CicekSepetiCategoryDefaultAttribute GetCategoryDefaultAttribute(int categoryId, int attributeId)
        {

            return CicekSepetiCategoryRepository.GetDefaultAttribute(categoryId, attributeId);
        }

        [Route("SaveCicekSepetiCreateRequest")]
        [HttpPost]
        public string SaveCicekSepetiCreateRequest(CicekSepetiCreateRequest createRequest)
        {
            try
            {
                CicekSepetiCategoryRepository.SaveCreateRequest(createRequest);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [Route("SaveCicekSepetiAttributes")]
        [HttpPost]
        public string SaveTrendyolAttributes(List<CicekSepetiAttribute> trendyolAttributes)
        {
            try
            {
                trendyolAttributes.ForEach(s => CicekSepetiCategoryRepository.SaveCicekSepetiAttribute(s));


                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("GetCreateRequestList")]
        [HttpGet]
        public CicekSepetiCreateRequest[] GetCreateRequestList()
        {
            return CicekSepetiCategoryRepository.GetCreateRequestList();

        }
    }
}
