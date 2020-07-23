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
    [RoutePrefix("api/ApplicationSetting")]
    public class ApplicationSettingController : ApiController
    {
       

        // GET: api/ApplicationSetting/5

        [Route("GetApplication/{sectionName}/{settingName}")]
        [HttpGet]
        public ApplicationSetting GetApplication(string sectionName,string settingName)
        {
            return ApplicationSettingRepository.GetApplication(sectionName, settingName);
        }

        // POST: api/ApplicationSetting
        public string Post(ApplicationSetting application)
        {
            ApplicationSettingRepository.SaveSetting(application);
            return "ok";
        }

        // PUT: api/ApplicationSetting/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApplicationSetting/5
        public void Delete(int id)
        {
        }
    }
}
