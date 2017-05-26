using System;
using System.IO;

namespace Test_Bass.Net
{
    static class FileStreamExtension
    {
        static byte[] RIFF_HEADER = new byte[] { 0x52, 0x49, 0x46, 0x46 };
        static byte[] FORMAT_WAVE = new byte[] { 0x57, 0x41, 0x56, 0x45 };
        static byte[] FORMAT_TAG = new byte[] { 0x66, 0x6d, 0x74, 0x20 };
        static byte[] AUDIO_FORMAT = new byte[] { 0x01, 0x00 };
        static byte[] SUBCHUNK_ID = new byte[] { 0x64, 0x61, 0x74, 0x61 };
        private const int BYTES_PER_SAMPLE = 2;

        public static void WriteWavHeader(this FileStream targetStream, int byteStreamSize, int channelCount, int sampleRate)
        {

            int byteRate = sampleRate * channelCount * BYTES_PER_SAMPLE;
            int blockAlign = channelCount * BYTES_PER_SAMPLE;

            targetStream.Write(RIFF_HEADER, 0, RIFF_HEADER.Length);
            targetStream.Write(PackageInt(byteStreamSize + 42, 4), 0, 4);

            targetStream.Write(FORMAT_WAVE, 0, FORMAT_WAVE.Length);
            targetStream.Write(FORMAT_TAG, 0, FORMAT_TAG.Length);
            targetStream.Write(PackageInt(16, 4), 0, 4);//Subchunk1Size

            targetStream.Write(AUDIO_FORMAT, 0, AUDIO_FORMAT.Length);//AudioFormat
            targetStream.Write(PackageInt(channelCount, 2), 0, 2);
            targetStream.Write(PackageInt(sampleRate, 4), 0, 4);
            targetStream.Write(PackageInt(byteRate, 4), 0, 4);
            targetStream.Write(PackageInt(blockAlign, 2), 0, 2);
            targetStream.Write(PackageInt(BYTES_PER_SAMPLE * 8), 0, 2);
            //targetStream.Write(PackageInt(0,2), 0, 2);//Extra param size
            targetStream.Write(SUBCHUNK_ID, 0, SUBCHUNK_ID.Length);
            targetStream.Write(PackageInt(byteStreamSize, 4), 0, 4);
        }

        static byte[] PackageInt(int source, int length = 2)
        {
            if ((length != 2) && (length != 4))
                throw new ArgumentException("length must be either 2 or 4", "length");
            var retVal = new byte[length];
            retVal[0] = (byte)(source & 0xFF);
            retVal[1] = (byte)((source >> 8) & 0xFF);
            if (length == 4)
            {
                retVal[2] = (byte)((source >> 0x10) & 0xFF);
                retVal[3] = (byte)((source >> 0x18) & 0xFF);
            }
            return retVal;
        }
    }

    class SoundWave
    {
        public static byte[] CreateSinWave( int sampleRate, double frequency, double seconds, double magnitude )
        {
            int sampleCount = (int)(((double)sampleRate) * seconds);
            short[] tempBuffer = new short[sampleCount];

            for (int i = 0; i < sampleCount; ++i)
                tempBuffer[i] = (short)(Math.Sin(i/360) * short.MaxValue);

            byte[] retVal = new byte[sampleCount * 2];
            Buffer.BlockCopy(tempBuffer, 0, retVal, 0, retVal.Length);
            return retVal;
        }

        public static string CreateFile(string fileName = "sound.wav", int loops = 10)
        {
            var soundData = CreateSinWave(44000, 120, 1, 1d);
            var silence = new byte[44000]; // half sec silence

            var d = soundData.Length;
            var s = silence.Length;

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                fs.WriteWavHeader((d+s) * loops, 1, 44100);
                for (int i = 0; i <loops; i++)
                {
                    fs.Write(soundData, 0, d);
                    fs.Write(silence, 0, s);
                }
                fs.Close();
            }
            return fileName;
        }
    }
}
