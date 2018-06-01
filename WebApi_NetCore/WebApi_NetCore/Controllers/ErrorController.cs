using Microsoft.AspNetCore.Mvc;

namespace WebApi_NetCore.Controllers
{
    [Route("api/[controller]")]
    public class ErrorController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "Internal error.";
        }
    }
}
