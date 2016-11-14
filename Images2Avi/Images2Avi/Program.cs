using Accord.Video.FFMPEG;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Images2Avi
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
                printHelp();
            else
            {
                var dinfo = new DirectoryInfo(args[0]);
                var files = dinfo.GetFiles(args[1]).OrderBy(p => p.Name).ToArray();
                if (files.Length > 0)
                {
                    Bitmap image = (Bitmap)Image.FromFile(files[0].FullName);
                    var vFWriter = new VideoFileWriter();
                    vFWriter.Open(args[2], image.Width, image.Height, 50, VideoCodec.MPEG4);
                    foreach (var file in files)
                    {
                        Console.WriteLine(file.FullName);
                        image = (Bitmap)Image.FromFile(file.FullName);
                        vFWriter.WriteVideoFrame(image);
                    }
                    vFWriter.Close();
                }
            }
        }

        static void printHelp()
        {
            Console.WriteLine("Invalid Args...");
            Console.WriteLine("You should provide 3 arguments:");
            Console.WriteLine("[directory with images] [searchPattern for images (*.jpg)] [outputfile]");
        }
    }
}
