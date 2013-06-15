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
            string strFilePath = System.Reflection.Assembly.GetEntryAssembly().Location;
            string strDirPath = Path.GetDirectoryName(strFilePath);
            if (args.Length == 0)
            {
                if (Directory.Exists(strDirPath + "\\Stores"))
                {
                    Utils.AddStores2TaskScheduler(strDirPath + "\\Stores", strFilePath);
                }
                showHelp();
            }
            else
            {
                if (args[0].ToLower().StartsWith("tweet"))
                {
                    twitter tw = new twitter(strDirPath);
                    Console.WriteLine(tw.tweet(DateTime.Now.ToString()));
                }
                else
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        if (args[i].ToLower().EndsWith(".xml"))
                        {
                            try
                            {
                                doFile(args[i], strDirPath);
                            }
                            catch (Exception e)
                            {
                                log errLog = new log(strDirPath + "\\error_" + DateTime.Now.Ticks.ToString() + ".log", strDirPath);
                                errLog.append(e.Message + "\r\n" + e.ToString(), "", 0);
                            }
                        }
                    }
                }
            }
            Utils.doSleep();
        }

        static void doFile(string strFile, string strDirPath)
        {
            if (File.Exists(strFile))
            {
                Console.WriteLine("Processing: " + strFile);
                config conf = new config(strFile);
                if (conf.active)
                {
                    log myLog = new log(strFile, strDirPath);
                    BC bigCommerce = new BC(conf.store_api, conf.store_user, conf.store_url, conf.store_lastid);
                    twitter tw = new twitter(strDirPath);
                    if (bigCommerce.newOrder)
                    {
                        SMS smsOut = new SMS(conf.sms_user, conf.sms_pass, conf.sms_url);
                        long store_lastid = Convert.ToInt64(conf.store_lastid);
                        Boolean sendSMS = (store_lastid > 5); // Assume first 5 orders are tests 
                        foreach (order dOrder in bigCommerce.orders)
                        {
                            if (sendSMS)
                            {
                                string strMessage = conf.sms_message.Trim();
                                strMessage = strMessage.Replace("@CUSTOMER_FIRST_NAME@", dOrder.fname);
                                strMessage = strMessage.Replace("@CUSTOMER_LAST_NAME@", dOrder.lname);
                                strMessage = strMessage.Replace("@CUSTOMER_PHONE@", dOrder.phone);
                                strMessage = strMessage.Replace("@ORDER_ITEMS_TOTAL@", dOrder.items.ToString());
                                strMessage = strMessage.Replace("@ORDER_TOTAL_INC_TAX@", dOrder.total.ToString());
                                strMessage = strMessage.Replace("@STORE_PHONE@", conf.store_phone);
                                strMessage = strMessage.Replace("@STORE_NAME@", conf.store_name);
                                strMessage = strMessage.Replace("@STORE_URL@", conf.store_url);
                                strMessage = strMessage.Trim();

                                if (strMessage != "")
                                {
                                    string smsResponse = smsOut.send(dOrder.phone, strMessage);
                                    Console.WriteLine(smsResponse);
                                    myLog.append(smsResponse, dOrder.phone, dOrder.id);
                                    tw.SendUpdate(conf.store_name, dOrder, smsResponse);
                                }
                            }
                            if (dOrder.id > store_lastid) store_lastid = dOrder.id;
                        }
                        conf.store_lastid = (store_lastid + 1).ToString();
                    }
                }
            }
            else
            {
                Console.WriteLine("File not Found: " + strFile);
            }
        }

        static void showHelp()
        {
            Console.WriteLine("");
            Console.WriteLine("      BCReader was sucessfully installed! ");
            Console.WriteLine("---------------------------------------------------- ");
            Console.WriteLine("  Now you should configure your stores (XML files)   ");
            Console.WriteLine("  and always confirm in the windows Task Scheduler   ");
            Console.WriteLine("---------------------------------------------------- ");
            Console.WriteLine("");
            Console.Write("Press ENTER to exit. ");
            Console.ReadLine();
        }
    }
}
