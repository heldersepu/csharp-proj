using System;
using System.IO;
using System.Web.Http;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace nhc_noaa.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected string domain { get { return ConfigurationManager.AppSettings["DOMAIN"]; } }
        protected string year { get { return DateTime.Now.Year.ToString(); } }
        protected string east_atl_path { get { return ConfigurationManager.AppSettings["EAST_ATL"]; } }
        protected string images { get { return @">" + year + ".*rb.jpg"; } }

        static protected string baseDir(string path)
        {
            string fld = AppDomain.CurrentDomain.BaseDirectory;
            fld += path.Trim('/').Replace("/", "_");
            if (!Directory.Exists(fld))
                Directory.CreateDirectory(fld);
            return fld;
        }
    }

    public static class DateTimeExtension
    {
        public static double Diff(this DateTime value)
        {
            return Math.Round((DateTime.Now - value).TotalMilliseconds);
        }
    }

    public static class DirectoryInfoExtension
    {
        public static FileInfo[] GetLatestFiles(this DirectoryInfo value, int count)
        {
            return value.GetFiles().OrderByDescending(p => p.CreationTime).Take(count).ToArray();
        }
    }

    public class Images : Dictionary<string, int> { }
}
