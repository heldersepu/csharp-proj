using System.IO;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Drawing;
using System.Drawing.Imaging;
using AviFile;

namespace nhc_noaa.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VideosController : BaseController
    {
        [HttpGet]
        public string EastAtlantic(int count = 20)
        {
            string fileName = string.Empty;
            var dinfo = new DirectoryInfo(baseDir(east_atl_path));
            var files = dinfo.GetLatestFiles(count);
            if (files.Length > 1)
            {
                fileName = files[0].Name.Replace(".jpg", "") + "_" + files[files.Length-1].Name.Replace(".jpg", "") + ".avi";
                var bmp = new Bitmap(1120, 480, PixelFormat.Format24bppRgb);
                var aviManager = new AviManager(baseDir("videos\\") + fileName, false);
                var aviStream = aviManager.AddVideoStream(true, 25, bmp);

                foreach (var file in files)
                {
                    bmp = (Bitmap)Bitmap.FromFile(file.FullName);
                    aviStream.AddFrame(bmp);
                    bmp.Dispose();
                }

                aviManager.Close();
            }
            return fileName;
        }
    }
}
