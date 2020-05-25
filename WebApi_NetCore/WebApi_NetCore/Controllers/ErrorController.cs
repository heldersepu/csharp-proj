using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public List<MonthEnum> Enum(string id)
        {
            var l = new List<MonthEnum>();
            l.Add(MonthEnum.July);
            l.Add(MonthEnum.August);
            return l;
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
