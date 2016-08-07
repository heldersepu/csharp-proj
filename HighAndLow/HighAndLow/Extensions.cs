using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighAndLow
{
    public static class DateTimeExtension
    {
        public static double Diff(this DateTime value)
        {
            return Math.Round((DateTime.Now - value).TotalMilliseconds);
        }
    }
}
