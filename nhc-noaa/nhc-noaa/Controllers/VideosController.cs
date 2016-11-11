using System.IO;
using System.Web.Http;
using System.Web.Http.Cors;
using Accord.Video.FFMPEG;
using System.Drawing;
using System.Drawing.Imaging;

namespace nhc_noaa.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VideosController : BaseController
    {
        [HttpGet]
        public string EastAtlantic(int count = 20)
        {
            var dinfo = new DirectoryInfo(baseDir(east_atl_path));

            var vFWriter = new VideoFileWriter();
            vFWriter.Open("test.avi", 1120, 480, 25, VideoCodec.MPEG4);
            var image = new Bitmap(1120, 480, PixelFormat.Format24bppRgb);

            //foreach (var file in dinfo.GetLatestFiles(count))
            for (int i = 0; i < 1000; i++)
            {
                image.SetPixel(i % 1120, i % 480, Color.Red);
                vFWriter.WriteVideoFrame(image);
            }
            vFWriter.Close();
            return "VideosController";
        }
    }
}
