using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace CLRAssembly
{
    public sealed class Geom
    {
        public static string CleanIntersections(string polygon)
        {
            try
            {
                string[] splitted = polygon.Split(new char[] { ')' });
                polygon = "";
                for (int i = 0; i < splitted.Length - 1; i++)
                {
                    if (splitted[i] != "")
                    {
                        splitted[i] = cleanCoordinates(splitted[i]);
                        polygon += splitted[i] + ")";
                    }
                    else
                        polygon += splitted[i] + ")";
                }
                return polygon;
            }
            catch (Exception e)
            {
                return "ERROR:" + e.Message;
            }
        }

        private static string cleanCoordinates(string poly)
        {
            Dictionary<int, string> scondSplit = new Dictionary<int, string>();

            //CLEANING STRING FROM NON-COORDINATES CHARACTERS
            int pos = poly.LastIndexOf('(') + 1;
            string firstHalf = poly.Substring(0, pos);
            string secondHalf = poly.Substring(pos);

            //ADD UNIQUE ITEMS TO THE DICTIONARY
            int j = 0;
            int i, dPos;
            string coordinates;
            for (i = 0; i < secondHalf.Length; i++)
            {
                coordinates = "";
                dPos = secondHalf.IndexOf(", ", i);
                if (dPos > -1)
                {
                    coordinates = secondHalf.Substring(i, dPos - i);
                    i = dPos + 1;
                    if (scondSplit.Where(x => x.Value == coordinates).Count() == 0)
                        scondSplit.Add(j++, coordinates);
                }
                else
                {
                    scondSplit.Add(j, secondHalf.Substring(i));
                    break;
                }
            }

            if (scondSplit.Count > 0)
            {   //CONCATENATION OF POLY
                poly = firstHalf;
                foreach (var pair in scondSplit)
                {
                    poly += pair.Value + ", ";
                }
                poly = poly.Substring(0, poly.Length - 2);
            }
            return poly;
        }
    }
}
