using System.Collections.Generic;
using System.Web.Http;

namespace ToTangoAPI.Controllers
{
    public class CompanyController : BaseApiController
    {
        // GET: Search/Company
        public IHttpActionResult Get()
        {
            var error = new Dictionary<string, string> { { "Error", "You forgot to enter the company" } };
            return Json(error);
        }

        // GET: Search/Company/abc
        public IHttpActionResult Get(string id)
        {
            string myQueryUrl = queryUrl("ToTangoUrlCompanyQuery").Replace("@NAME@", id);
            return ToTangoPost(myQueryUrl);
        }
    }
}
