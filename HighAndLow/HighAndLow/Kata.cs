using System.Linq;

namespace HighAndLow
{
    public static class Kata
    {
        public static string HighAndLow1(string numbers)
        {
            var parsed = numbers.Split().Select(int.Parse);
            return parsed.Max() + " " + parsed.Min();
        }

        public static string HighAndLow2(string numbers)
        {
            int max, min;
            var arrNum = numbers.Split();
            max = min = int.Parse(arrNum[0]);
            for (var i = 1; i < arrNum.Length; i++)
            {
                int num = int.Parse(arrNum[i]);
                if (num > max)
                    max = num;
                else if (num < min)
                    min = num;
            }
            return $"{max} {min}";
        }
    }
}
