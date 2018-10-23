using Microsoft.AspNetCore.Mvc;

namespace WebApi_NetCore.Controllers
{
    [Route("api/[controller]")]
    public class ErrorController : Controller
    {
        /// <summary>
        /// Testing xml comments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Index()
        {
            return "Internal error.";
        }
    }
}
