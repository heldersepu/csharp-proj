using System;
using System.IO;
using System.Web.Http;

namespace nhc_noaa.Controllers
{
    public class BaseController : ApiController
    {
        static protected string baseDir(string path)
        {
            string fld = AppDomain.CurrentDomain.BaseDirectory;
            fld += path.Trim('/').Replace("/", "_");
            if (!Directory.Exists(fld))
                Directory.CreateDirectory(fld);
            return fld;
        }
    }
}
