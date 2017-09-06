using System.Web.Http;

namespace SwashbuckleSample.ApiControllers
{
    public class ClientsController : ApiController
    {

        /// <summary>
        /// List all clients
        /// </summary>
        [Authorize]
        public IHttpActionResult GetClients()
        {
            var obj = new
            {
                User.Identity.AuthenticationType,
                User.Identity.IsAuthenticated,
                User.Identity.Name
            };
            return Ok(obj);
        }
    }
}