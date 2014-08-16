using System;

namespace absToTango
{
    class Program
    {
        static void Main(string[] args)
        {            
            string token = "ab63b0d7e591ff0b8209ef9358478c4876c29787heldersepu@gmail.com";

            if (args.Length == 0)
            {
                TestReader(token);
            }
            else
            {
                TestExport(token);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }

        static void TestExport(string token)
        {
            string url = "https://app.totango.com/api/v1/accounts/active_list/10010/current.json";
            var tangoXport = new ToTangoExport(token);
            tangoXport.Start(url);
        }

        static void TestReader(string token)
        {
            dynamic account = null;
            string url = "https://app.totango.com/api/v1/accounts/active_list/1/current.json?return=stats";
            using (ToTangoReader tangoReader = new ToTangoReader(token, url))
            {
                do
                {
                    account = tangoReader.ReadAccount();
                    if (account != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(account.name + " ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(account.totango_id);
                    }
                    else if (tangoReader.Error)
                    {
                        Console.WriteLine(tangoReader.ErrorMessage);
                    }
                }
                while (account != null);
            }
        }
    }
}
