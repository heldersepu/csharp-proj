using System.Collections.Generic;
using System.Web.Http;

namespace ToTangoAPI.Controllers
{
    public class AccountIdController : BaseApiController
    {
        // GET: Search/AccountId
        public IHttpActionResult Get()
        {
            return Error("You forgot to enter the AccountId");            
        }

        // GET: Search/AccountId/123
        public IHttpActionResult Get(string id)
        {
            string myQueryUrl = QueryUrl("ToTangoUrlIDQuery").Replace("@ID@", id);
            return ToTangoPost(myQueryUrl);
        }
    }
}