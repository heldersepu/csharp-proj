using System.Configuration;
using System.Web.Mvc;
using Socrates.Models;

namespace Socrates.Controllers
{
    public class SocratesController : Controller
    {
        protected SocratesContext context;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            string connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            context = new SocratesContext(connStr);
        }
    }
}