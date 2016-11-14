using AviFile;
using NLog;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Dynamic;
using System.IO;
using System.Web.Http;
using System.Web.Http.Cors;

namespace nhc_noaa.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VideosController : BaseController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        public dynamic EastAtlantic(int count = 20, bool isCompressed = true)
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
                    CreateVideo(fileName, files, isCompressed);
                }
            }
            if (f == null) f = new FileInfo(fileName);
            dynamic obj = new ExpandoObject();
            obj.Time = sTime.Diff();
            obj.File = FileDetails(f);
            return Json(obj);
        }

        private dynamic FileDetails(FileInfo f)
        {
            dynamic file = new ExpandoObject();
            file.Name = f.Name;
            file.Size = f.Length;
            file.CreationTime = f.CreationTime;
            file.LastAccessTime = f.LastAccessTime;
            return file;
        }

        private void CreateVideo(string fileName, FileInfo[] files, bool isCompressed)
        {
            try
            {
                var bmp = new Bitmap(1120, 480, PixelFormat.Format24bppRgb);
                var aviManager = new AviManager(fileName, false);
                var aviStream = aviManager.AddVideoStream(isCompressed, 25, bmp);
                foreach (var file in files)
                {
                    bmp = (Bitmap)Bitmap.FromFile(file.FullName);
                    aviStream.AddFrame(bmp);
                    bmp.Dispose();
                }
                aviManager.Close();
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }
        }
    }
}
