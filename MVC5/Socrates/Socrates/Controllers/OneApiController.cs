using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Socrates.Models;

namespace Socrates.Controllers
{

    public class OneApiController : ApiController
    {

        public IHttpActionResult Get(int id)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            var context = new SocratesContext(connStr);
            var crs = context.Courses.ToList();

            if (crs == null)
            {
                return NotFound();
            }
            return Ok(crs);
        }
    }
}
