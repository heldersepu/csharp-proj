using System;
using System.Threading;

namespace TaskStart
{
    public class Animations
    {
        public Animations()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void DoLoop()
        {
            string chars = "-\\|/-.oO0Oo.";
            while (1 == 1)
            {
                foreach (char chr in chars)
                {
                    WriteXY(chr, 4, 2, ConsoleColor.Green);
                    Thread.Sleep(100);
                    WriteXY((char)8, 4, 2);
                }
            }
        }

        public void DoSinCos(char mychar, bool sin)
        {
            int y;
            while (1 == 1)
            {
                for (int x = 0; x < Console.WindowWidth; x++)
                {
                    y = (int)Math.Round(((sin)?Math.Sin(x): Math.Cos(x)) * 2) + 10;
                    WriteXY(mychar, x, y, (sin) ? ConsoleColor.Red: ConsoleColor.Cyan);
                    Thread.Sleep(80);
                    WriteXY(' ', x, y);
                }
            }
        }

        public void DoSin()
        {
            DoSinCos('O', true);
        }

        public void DoCos()
        {
            DoSinCos('*', false);
        }

        public void WriteXY(char c, int left, int top, ConsoleColor color = ConsoleColor.Black)
        {
            lock (this)
            {
                ConsoleColor co = Console.ForegroundColor;
                int x = Console.CursorLeft;
                int y = Console.CursorTop;

                Console.ForegroundColor = color;
                Console.CursorLeft = left;
                Console.CursorTop = top;

                Console.Write(c);

                Console.ForegroundColor = co;
                Console.CursorLeft = x;
                Console.CursorTop = y;
            }
        }
    }
}