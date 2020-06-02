using EKirtasiye.DBLayer;
using EKirtasiye.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EKirtasiyeRestApi.Controllers
{

    [RoutePrefix("api/InstagramUser")]
    public class InstagramUserController : ApiController
    {
        public InstagramUserController()
        {
            DBHelper.SqlConnectionStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }
        // GET: api/InstagramUser
        public IEnumerable<InstagramUserFollowing> Get()
        {
            return InstagramUserFollowingRepository.GetInstagramUserFollowing();
        }

        // GET: api/InstagramUser/5
        public string Get(int id)
        {
            return "value";
        }



        [HttpGet]
        [Route("GetShareTypes")]
        public IEnumerable<ShareType> GetAll()
        {
            return InstagramUserFollowingRepository.GetShareTypes();
        }

        [HttpGet]
        [Route("GetShareTypesTemplate/{shareTypeId:int}")]
        public IEnumerable<ShareTypesTemplate> ShareTypesTemplates(int shareTypeId)
        {
            return InstagramUserFollowingRepository.GetShareTypesTemplates(shareTypeId);
        }

        [HttpGet]
        [Route("GetShareTypesTemplateLastUpdate")]
        public IEnumerable<ShareTypesTemplate> GetShareTypesTemplateLastUpdate()
        {
            return InstagramUserFollowingRepository.GetShareTypesTemplateLastUpdate();
        }
        [HttpPost]
        [Route("SaveShareTypeTemplate")]
        public ShareTypesTemplate SaveShareTypeTemplate(ShareTypesTemplate shareTypesTemplate)
        {
            InstagramUserFollowingRepository.SaveShareTypesTemplate(shareTypesTemplate);

            return shareTypesTemplate;
        }

        [HttpGet]
        [Route("GetShareTypeTemplate/{id:int}")]
        public ShareTypesTemplate GetShareTypeTemplate( int id)
        {
          return  InstagramUserFollowingRepository.GetShareTypesTemplate(id);
             
        }
        // POST: api/InstagramUser
        public void Post(InstagramUserFollowing value)
        {
            InstagramUserFollowingRepository.SaveInstagram(value);
        }

       

        // DELETE: api/InstagramUser/5
        public void Delete(int id)
        {
        }
    }
}
