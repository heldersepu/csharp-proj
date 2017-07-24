using System;

namespace EnumDescription
{
    class Program
    {
        enum workDays { monday, wednesday, friday}
        static void Main(string[] args)
        {
            Console.Write(workDays.monday.GetDescription());
            Console.ReadKey();
        }
    }

    public static class EnumExtension
    {
        public static String GetDescription(this Enum value)
        {
            //var info = value.GetType().GetField(value.ToString());
            //if (info != null)
            //{
            //    var attributes = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);
            //    if (attributes != null && attributes.Length > 0)
            //        return attributes[0].Description;
            //}
            //return value.ToString();

            var info = value.GetType().GetField(value.ToString());
            var attributes = Attribute.GetCustomAttributes(info);
            if (attributes.Length > 0 && (attributes[0] is System.ComponentModel.DescriptionAttribute))
                return ((System.ComponentModel.DescriptionAttribute)attributes[0]).Description;
            return value.ToString();
        }
    }
}
