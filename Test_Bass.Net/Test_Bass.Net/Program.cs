using System;
using System.IO;
using Un4seen.Bass;

namespace Test_Bass.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.BufferHeight = 9999;

            BassNet.Registration("heldersepu@gmail.com", "2X3123820152222");
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);

            foreach (var arg in args)
            {
                if (File.Exists(arg))
                {
                    SoundTags.OutputTags(arg);
                    SoundStream.OutputStream(arg);
                }
                else if (arg.StartsWith("ENCODE:"))
                {
                    SoundEncoder.Encode(arg.Replace("ENCODE:", ""));
                }
                else if (arg.StartsWith("PLAY:"))
                {
                    int stream = Bass.BASS_StreamCreateFile(arg.Replace("PLAY:", ""), 0L, 0L, BASSFlag.BASS_DEFAULT);
                    if (stream != 0)
                    {
                        Bass.BASS_ChannelPlay(stream, false);
                        Console.ReadKey(false);
                        Bass.BASS_StreamFree(stream);
                    }
                }
            }
            Bass.BASS_Free();

            Console.Write("Press any key to continue . . . ");
            Console.ReadLine();
        }
    }
}
