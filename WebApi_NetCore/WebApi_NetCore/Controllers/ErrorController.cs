using Microsoft.AspNetCore.Mvc;

namespace WebApi_NetCore.Controllers
{
    [Route("api/[controller]")]
    public class ErrorController : Controller
    {
        public string Index()
        {
            return "Internal error.";
        }
    }
}
