using System;

namespace CLRAssembly
{
    public sealed class Randomness
    {
        public static string Date()
        {
            try
            {
                DateTime start = new DateTime(1950, 1, 1);
                Random gen = new Random();
                int range = (DateTime.Today - start).Days;
                return start.AddDays(gen.Next(range)).ToString("MM/dd/yyyy");
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string Time()
        {
            try
            {
                DateTime start = new DateTime(1950, 1, 1);
                Random gen = new Random();
                return start.AddSeconds(gen.Next(86400)).ToString("HH:mm:ss");
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
