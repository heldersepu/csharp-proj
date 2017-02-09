using System;

namespace PlayMatrix
{
    public static class DateTimeExtension
    {
        public static int Diff(this DateTime value)
        {
            return (int)(DateTime.Now - value).TotalMilliseconds;
        }
    }
}