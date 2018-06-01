using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApi_NetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/TestEmail")]
    public class TestEmailController : Controller
    {
        public static IEnumerable<Type> AllNotificationTypes =>
           typeof(TestEmailController).GetTypeInfo().Assembly.GetTypes();

        [HttpGet("[controller]/{templateName}")]
        public async Task<IActionResult> Render(string templateName)
        {
            Type templateType = AllNotificationTypes.FirstOrDefault(t => t.Name == templateName);
            if (templateType == null) return NotFound();
            string renderedHtml = "";
            return Content(renderedHtml, "text/html");
        }
    }
}
