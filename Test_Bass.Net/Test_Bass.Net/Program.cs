using System;
using System.IO;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Tags;

namespace Test_Bass.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            BassNet.Registration("heldersepu@gmail.com", "2X3123820152222");
            foreach (var file in args)
            {
                if (File.Exists(file))
                {
                    var tagInfo = BassTags.BASS_TAG_GetFromFile(file);
                    Console.WriteLine("  album: " + tagInfo.album);
                    Console.WriteLine(" artist: " + tagInfo.artist);
                    Console.WriteLine("bitrate: " + tagInfo.bitrate);
                    Console.WriteLine("");
                }
            }
            Console.Write("Press any key to continue . . . ");
            Console.ReadLine();
        }
    }
}
