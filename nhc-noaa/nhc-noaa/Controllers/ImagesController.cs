using System.IO;
using System.Linq;
using System.Web.Http;
using System.Collections.Generic;
using System.Configuration;

namespace nhc_noaa.Controllers
{
    public class ImagesController : BaseController
    {
        [HttpGet]
        public List<string> EastAtlantic(int count = 20)
        {
            return readDir(ConfigurationManager.AppSettings["EAST_ATL"], count);
        }

        static private List<string> readDir(string path, int count)
        {
            var result = new List<string>();
            var dinfo = new DirectoryInfo(baseDir(path));
            foreach (var file in dinfo.GetFiles().OrderByDescending(p => p.CreationTime).Take(count).ToArray())
                result.Add(file.Name);
            return result;
        }
    }
}
