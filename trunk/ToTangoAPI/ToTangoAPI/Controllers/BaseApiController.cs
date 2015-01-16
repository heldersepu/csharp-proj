using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Web.Http;
using Newtonsoft.Json;

namespace ToTangoAPI.Controllers
{
    public class BaseApiController : ApiController
    {
        protected string queryUrl(string searchTerm)
        {
            string url = ConfigurationManager.AppSettings.Get("ToTangoUrlBase");
            url += ConfigurationManager.AppSettings.Get(searchTerm);
            url += ConfigurationManager.AppSettings.Get("ToTangoUrlFields");
            url += ConfigurationManager.AppSettings.Get("ToTangoUrlCommon");
            return url.Replace('\'', '"'); 
        }

        protected IHttpActionResult ToTangoPost(string myQueryUrl)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Headers.Add("Authorization", token);
                    string htmlResult = client.UploadString(myQueryUrl, "");                    
                    return Json(JsonConvert.DeserializeObject<dynamic>(htmlResult));
                }
                catch (Exception ex)
                {
                    var error = new Dictionary<string, string> { { "Error", ex.Message } };
                    return Json(error);
                }
            }
        }

        protected string token
        {
            get { return ConfigurationManager.AppSettings.Get("ToTangoToken"); }
        }
    }
}