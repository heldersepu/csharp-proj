using System;
using System.IO;
using System.Threading;
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
                Console.Beep(600, 100);
                if (File.Exists(arg))
                {
                    SoundTags.OutputTags(arg);
                    SoundStream.OutputStream(arg);
                }
                else if (arg.Equals("MIDI"))
                {
                    SoundMIDI.Play();
                }
                else if (arg.StartsWith("ENCODE:"))
                {
                    SoundEncoder.Encode(arg.Replace("ENCODE:", ""));
                }
                else if (arg.Equals("WAVE"))
                {
                    string file = SoundWave.CreateFile();
                    SoundStream.OutputStream(file);
                }
                else if (arg.StartsWith("PLAY:"))
                {
                    Play(arg.Replace("PLAY:", ""));
                }
                Console.Beep(800, 100);
            }
            Bass.BASS_Free();

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(false);
        }

        static void Play(string file)
        {
            int stream = Bass.BASS_StreamCreateFile(file, 0L, 0L, BASSFlag.BASS_DEFAULT);
            if (stream != 0)
            {
                Bass.BASS_ChannelPlay(stream, false);
                Thread.Sleep(10000);
                Bass.BASS_StreamFree(stream);
            }
        }
    }
}
