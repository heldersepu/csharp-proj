using System;
using System.IO;
using Un4seen.Bass.Misc;

namespace Test_Bass.Net
{
    class SoundEncoder
    {
        public static void Encode(string file)
        {
            if (File.Exists(file))
            {
                var encoderLAME = new EncoderLAME(0)
                {
                    LAME_Bitrate = (int)EncoderLAME.BITRATE.kbps_192,
                    LAME_Mode = EncoderLAME.LAMEMode.Default,
                    LAME_Quality = EncoderLAME.LAMEQuality.Quality
                };

                var resp = BaseEncoder.EncodeFile(
                    inputFile: file,
                    outputFile: file + "_small.mp3",
                    encoder: encoderLAME,
                    proc: null,
                    overwriteOutput: true,
                    deleteInput: false,
                    updateTags: false,
                    fromPos: 5.0f,
                    toPos: 10.0f
                );
                Console.WriteLine(resp);
            }
        }
    }
}
