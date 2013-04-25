using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace BCReader
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].ToLower().EndsWith(".xml"))
                {
                    doFile(args[i]);
                }
            }
            Utils.doSleep();
        }

        static void doFile(string strFile)
        {
            if (File.Exists(strFile))
            {
                Console.WriteLine("Processing: " + strFile);
                config conf = new config(strFile);
                BC bigCommerce = new BC(conf.store_api, conf.store_url);
                if (bigCommerce.newOrder)
                {
                    SMS smsOut = new SMS(conf.sms_user, conf.sms_pass, conf.sms_url);
                    Console.WriteLine(smsOut.send("13054508292", "Hello World"));
                }

            }
            else
            {
                Console.WriteLine("File not Found: " + strFile);
            }
        }


    }
}
