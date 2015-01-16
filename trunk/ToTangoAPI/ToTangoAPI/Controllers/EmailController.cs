using System.Collections.Generic;
using System.Web.Http;

namespace ToTangoAPI.Controllers
{
    public class EmailController : BaseApiController
    {
        // GET: Search/Email
        public IHttpActionResult Get()
        {
            var error = new Dictionary<string, string> {{"Error", "You forgot to enter the email"}};
            return Json(error);
        }

        // GET: Search/Email/abc
        public IHttpActionResult Get(string id)
        {
            string myQueryUrl = queryUrl("ToTangoUrlEmailQuery").Replace("@EMAIL@", id);
            return ToTangoPost(myQueryUrl);
        }
    }
}
