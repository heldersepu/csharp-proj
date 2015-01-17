using System.Collections.Generic;
using System.Web.Http;

namespace ToTangoAPI.Controllers
{
    public class EmailController : BaseApiController
    {
        // GET: Search/Email
        public IHttpActionResult Get()
        {
            return Error("You forgot to enter the email");
        }

        // GET: Search/Email/abc
        public IHttpActionResult Get(string id)
        {
            string myQueryUrl = QueryUrl("ToTangoUrlEmailQuery").Replace("@EMAIL@", id);
            return ToTangoPost(myQueryUrl);
        }
    }
}
