using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;


namespace geom
{
    class Program
    {

        static string clean_intersections(string polygon)
        {
            string[] splitted = polygon.Split(new char[] { ')' });
            polygon = "";
            for(int i = 0; i < splitted.Length - 1; i++)
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

        private static string cleanCoordinates(string poly)
        {
            Dictionary<int, string> scondSplit = new Dictionary<int, string>();

            //CLEANING STRING FROM NON-COORDINATES CHARACTERS
            int pos = poly.LastIndexOf('(') + 1;
            string firstHalf = poly.Substring(0, pos);
            string secondHalf = poly.Substring(pos);
            try
            {
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

            }
            finally
            {
                if (scondSplit.Count > 0)
                {   //CONCATENATION OF POLY
                    poly = firstHalf;
                    foreach (var pair in scondSplit)
                    {
                        poly += pair.Value + ", ";
                    }
                    poly = poly.Substring(0, poly.Length - 2);
                }
            }
            return poly;
        }

        static void Main(string[] args)
        {
            Console.BufferHeight = 2400;
            Console.BufferWidth = 120;
            Console.WindowWidth = 120;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("  --- geom ---  ");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Press Enter to proceed...");
            Console.ReadLine();


            Console.ForegroundColor = ConsoleColor.DarkGray;
            foreach (string poly in util.polygons)
            {
                Console.ForegroundColor++;
                string cleanPoly = clean_intersections(poly);
                File.WriteAllText("poly_clean.txt", cleanPoly);
                Console.WriteLine(cleanPoly);
                Console.WriteLine("");

            }

            Console.WriteLine("");
            Console.ReadLine();
        }
    }
}
