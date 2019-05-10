using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace WebApi_NetCore.Controllers
{
    [Route("api/[controller]")]
    public class DefaultFromQueryController : Controller
    {
        [HttpGet]
        public MyClass Foo([FromQuery] MyClass request)
        {
            throw new System.NotImplementedException();
        }
    }

    public class MyClass
    {
        [DefaultValue("90210")]
        public string Zip { get; set; }

        [DefaultValue("5361 Doverton Dr")]
        public string StreetAddress { get; set; }
    }
}
