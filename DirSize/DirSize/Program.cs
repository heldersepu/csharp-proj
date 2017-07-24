using System.IO;
using System.Linq;

namespace DirSize
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                if (Directory.Exists(arg))
                    WriteSize(arg);
            }
        }

        static void WriteSize(string path)
        {
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            int total = 0;
            using (StreamWriter writetext = new StreamWriter("write.txt"))
            {
                foreach (var file in files.OrderBy(x => x.Length))
                {
                    writetext.WriteLine($"The file name : {file} is of size {file.Length} bytes");
                    total += file.Length;
                }
                writetext.WriteLine($"The directory size is : {total} bytes");
            }
        }
    }
}
