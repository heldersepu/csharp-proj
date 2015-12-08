using RestSharp;
using System;
using System.IO;
using System.Web.Http;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Configuration;

namespace nhc_noaa.Controllers
{
    public class DownloadController : BaseController
    {
        [HttpGet]
        public Dictionary<string, int> EastAtlantic()
        {
            string year = DateTime.Now.Year.ToString();
            return download(ConfigurationManager.AppSettings["DOMAIN"], 
                ConfigurationManager.AppSettings["EAST_ATL"], @">" + year + ".*rb.jpg");
        }

        static private Dictionary<string, int> download(string domain, string path, string pattern)
        {
            var result = new Dictionary<string, int>();
            var client = new RestClient(domain);
            var req = new RestRequest(path, Method.GET);
            var response = client.Get(req);
            string html = response.Content;

            string fld = baseDir(path);          
            foreach (Match match in Regex.Matches(html, pattern))
            {
                foreach (Capture capture in match.Captures)
                {
                    string fileName = capture.Value.Replace(">", "");
                    result.Add(fileName, 0);
                    if (!File.Exists(fld + "\\" + fileName))
                    {
                        try
                        {
                            var img = new RestRequest(path + fileName, Method.GET);
                            response = client.Get(img);
                            result[fileName] = (int)response.StatusCode;
                            if (result[fileName] == 200)
                            {
                                var fs = File.Create(fld + "\\" + fileName);
                                fs.Write(response.RawBytes, 0, response.RawBytes.Length);
                                fs.Close();
                            }
                        }
                        catch
                        {
                            result[fileName] = -3;
                        }
                    }
                }
            }
            return result;
        }


    }
}
