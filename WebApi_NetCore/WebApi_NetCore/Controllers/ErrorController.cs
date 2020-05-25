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

        [HttpPost]
        public MonthEnum Enum(string id)
        {
            return MonthEnum.August;
        }

        public enum MonthEnum
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }
    }
}
