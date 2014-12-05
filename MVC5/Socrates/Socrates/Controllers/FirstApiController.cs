using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Socrates.Controllers
{
    public class FirstApiController : ApiController
    {
        public string Get(string id)
        {
            return "Hello World " + id;
        }
    }
}
