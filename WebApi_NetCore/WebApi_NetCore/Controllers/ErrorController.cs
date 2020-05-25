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
        public List<MonthEnum> EnumPost(string id)
        {
            var l = new List<MonthEnum>();
            l.Add(MonthEnum.July);
            l.Add(MonthEnum.August);
            return l;
        }

        [HttpPut]
        public MyData EnumPut(string id)
        {
            var data = new MyData();
            data.id = 1;
            data.months = new List<MonthEnum>();
            data.months.Add(MonthEnum.July);
            data.months.Add(MonthEnum.August);
            return data;
        }
    }

    public class MyData
    {
        public int id { get; set; }
        public List<MonthEnum> months { get; set; }
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
