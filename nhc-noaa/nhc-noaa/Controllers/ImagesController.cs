using System.IO;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Collections.Generic;

namespace nhc_noaa.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ImagesController : BaseController
    {
        [HttpGet]
        public List<string> EastAtlantic(int count = 20)
        {
            return readDir(east_atl_path, count);
        }

        static private List<string> readDir(string path, int count)
        {
            var result = new List<string>();
            var dinfo = new DirectoryInfo(baseDir(path));
            foreach (var file in dinfo.GetLatestFiles(count))
                result.Add(file.Name);
            return result;
        }
    }
}
