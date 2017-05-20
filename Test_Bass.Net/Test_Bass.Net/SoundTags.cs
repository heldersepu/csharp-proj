using System;
using Un4seen.Bass.AddOn.Tags;

namespace Test_Bass.Net
{
    class SoundTags
    {
        public static void OutputTags(string file)
        {
            var tagInfo = BassTags.BASS_TAG_GetFromFile(file);
            Console.WriteLine("  album: " + tagInfo.album);
            Console.WriteLine(" artist: " + tagInfo.artist);
            Console.WriteLine("bitrate: " + tagInfo.bitrate);
            Console.WriteLine("");
        }
    }
}
