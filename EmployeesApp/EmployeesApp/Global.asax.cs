using System.Web.Http;
using EmployeesApp.DAL;

namespace EmployeesApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DbInitializer.Initialize().Wait();
        }
    }
}
