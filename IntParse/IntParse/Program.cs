using System;

namespace IntParse
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                Console.Write(arg);
                Console.Write(" = ");
                Console.WriteLine(IntParse(arg));
            }
            Console.Read();
        }

        static int IntParse(string value)
        {
            int count = 0;
            int factor = 1;
            for (int i = value.Length -1; i >= 0; i--)
            {
                if (value[i] >= '0' && value[i] <= '9')
                    count += (value[i] - '0') * factor;
                else
                    return 0;
                factor *= 10;
            }
            return count;
        }
    }
}
