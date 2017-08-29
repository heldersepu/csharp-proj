using System.Web;
using System.Web.Http;

namespace SwashbuckleSample
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(config =>
            {
                WebApiConfig.Register(config);
            });
        }
    }
}