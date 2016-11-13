using System.IO;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Drawing;
using System.Drawing.Imaging;
using AviFile;
using System;
using System.Dynamic;

namespace nhc_noaa.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VideosController : BaseController
    {
        [HttpGet]
        public dynamic EastAtlantic(int count = 20)
        {
            FileInfo f = null;
            DateTime sTime = DateTime.Now;
            string fileName = baseDir("videos\\");
            var dinfo = new DirectoryInfo(baseDir(east_atl_path));
            var files = dinfo.GetLatestFiles(count);
            if (files.Length > 1)
            {
                fileName += files[0].Name.Replace(".jpg", "") + "_" + files[files.Length-1].Name.Replace(".jpg", "") + ".avi";
                if (File.Exists(fileName))
                {
                    f = new FileInfo(fileName);
                    f.LastAccessTime = DateTime.Now;
                }
                else
                {
                    var bmp = new Bitmap(1120, 480, PixelFormat.Format24bppRgb);
                    var aviManager = new AviManager(fileName, false);
                    var aviStream = aviManager.AddVideoStream(true, 25, bmp);
                    foreach (var file in files)
                    {
                        bmp = (Bitmap)Bitmap.FromFile(file.FullName);
                        aviStream.AddFrame(bmp);
                        bmp.Dispose();
                    }
                    aviManager.Close();
                }
            }
            if (f == null) f = new FileInfo(fileName);
            dynamic obj = new ExpandoObject();
            obj.File = new ExpandoObject();
            obj.Time = sTime.Diff();
            obj.File.Name = f.Name;
            obj.File.Size = f.Length;
            obj.File.CreationTime = f.CreationTime;
            obj.File.LastAccessTime = f.LastAccessTime;
            return Json(obj);
        }
    }
}
