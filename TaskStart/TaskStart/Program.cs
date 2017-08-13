using System;
using System.Threading.Tasks;

namespace TaskStart
{
    class Program
    {
        static void Main(string[] args)
        {
            var anim = new Animations();
            new Task(anim.DoLoop).Start();
            new Task(anim.DoSin).Start();
            new Task(anim.DoCos).Start();

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key != ConsoleKey.Escape);
        }
    }
}
