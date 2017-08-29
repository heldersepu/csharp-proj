using System.Web.Http;

namespace SwashbuckleSample.ApiControllers
{
    public class ClientsController : ApiController
    {

        /// <summary>
        /// List all clients
        /// </summary>
        public string GetClients()
        {
            return "Hello World";
        }
    }
}