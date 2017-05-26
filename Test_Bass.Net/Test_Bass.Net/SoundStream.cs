using System;
using System.Collections.Generic;
using System.Linq;
using Un4seen.Bass;

namespace Test_Bass.Net
{
    class SoundStream
    {
        public static void OutputStream(string file)
        {
            float block = 20;
            var chan = Bass.BASS_StreamCreateFile(file, 0, 0, BASSFlag.BASS_STREAM_DECODE);
            var len = Bass.BASS_ChannelSeconds2Bytes(chan, block / (float)1000 - (float)0.02);

            int level = 0;
            var buffer = new IntPtr();
            var data = new List<int>();
            while (-1 != (level = Bass.BASS_ChannelGetLevel(chan)))
            {
                data.Add(level);
                Bass.BASS_ChannelGetData(chan, buffer, (int)len);
            }
            Bass.BASS_StreamFree(chan);

            double max = data.Max();
            foreach (var item in data)
                OutputLevel(item, max);
        }

        private static void OutputLevel(int item, double max)
        {
            double level = item / max;

            var color = ConsoleColor.Green;
            if (item > max / 2)
                color = ConsoleColor.Red;
            else if (item > max / 3)
                color = ConsoleColor.Yellow;
            Console.ForegroundColor = color;
            Console.BackgroundColor = color;

            int baseLevel = (int)(level * 78);
            for (int i = 0; i < baseLevel; i++)
            {
                Console.Write(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine((char)16);
        }
    }
}
