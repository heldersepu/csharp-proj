using System;

namespace absToTango
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic account = null;
            string token = "";
            string url = "https://app.totango.com/api/v1/accounts/active_list/1/current.json?return=stats";
            using (ToTangoReader tangoReader = new ToTangoReader(token, url))
            {
                do
                {
                    account = tangoReader.ReadAccount();
                    if (account != null)
                    {
                        Console.WriteLine(account.name);
                        Console.WriteLine(account.account_id);
                    } else if (tangoReader.Error) {
                        Console.WriteLine(tangoReader.ErrorMessage);
                    }
                }
                while (account != null);
            }
            Console.WriteLine("");
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }
    }
}
