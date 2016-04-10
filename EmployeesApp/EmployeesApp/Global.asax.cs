using System.Web.Http;
using System.Data.Entity;
using EmployeesApp.DAL;

namespace EmployeesApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer(new DbInitializer());
        }
    }
}
