using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Microsoft.Win32.TaskScheduler;

namespace BCReader
{
    class Utils
    {
        public static void doSleep()
        {
            string[] chrs = { "-", "\\", "|", "/", "-", "." };
            for (int i = 0; i < 60; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (string chr in chrs)
                {                     
                    Console.Write(chr);                     
                    Thread.Sleep(20);
                    Console.Write((char)8);
                }
                Console.ForegroundColor = ConsoleColor.Green; 
                Console.Write(".");
                Thread.Sleep(5);
            }
            Console.WriteLine("");
        }
        
        public static string onlyNumbers(string myString)
        {
            return Regex.Replace(myString, "[^0-9]", "");
        }

        #region " Crypto "
        public static string Encrypt(string strText) 
        {
            string text1;
            if (strText == String.Empty)
            {
                return strText;
            }
            byte[] buffer2 = GetCryptArr();
            try
            {
                byte[] buffer1 = Encoding.UTF8.GetBytes(GetCryptKey().Substring(0,8));
                DESCryptoServiceProvider provider1 =  new DESCryptoServiceProvider();
                byte[] buffer3 = Encoding.UTF8.GetBytes(strText);
                MemoryStream stream2 = new MemoryStream();
                using (CryptoStream stream1 = new CryptoStream(stream2, provider1.CreateEncryptor(buffer1, buffer2), CryptoStreamMode.Write))
                {
                    stream1.Write(buffer3, 0, buffer3.Length);
                    stream1.FlushFinalBlock();
                    text1 = Convert.ToBase64String(stream2.ToArray());
                }
            }
            catch 
            {
                return "Error";
            }
            return text1;
        }

        public static string Decrypt(string strText)
        {
            string text1;
            if (strText == String.Empty)
            {
                return strText;
            }
            byte[] buffer1;            
            byte[] buffer2;
            byte[] buffer3 = GetCryptArr();
            try
            {
                buffer1 = Encoding.UTF8.GetBytes(GetCryptKey().Substring(0,8));
                DESCryptoServiceProvider provider1 =  new DESCryptoServiceProvider();
                buffer2 = Convert.FromBase64String(strText);
                MemoryStream stream2 = new MemoryStream();
                using (CryptoStream stream1 = new CryptoStream(stream2, provider1.CreateDecryptor(buffer1, buffer3), CryptoStreamMode.Write))
                {
                    stream1.Write(buffer2, 0, buffer2.Length);
                    stream1.FlushFinalBlock();
                    text1 = Encoding.UTF8.GetString(stream2.ToArray());
                }
            }
            catch
            {
                return "Error";
            }
            return text1;
        }

        private static string GetCryptKey() 
        {
            return "BCReaderCrypto";
        }

        private static byte[] GetCryptArr() 
        {
            return new byte[] { 18, 52, 86, 120, 111, 171, 205, 239 };
        }
        #endregion " Crypto "

        public static void AddStores2TaskScheduler(string strStoresPath, string strActionPath)
        {
            string[] strXMLFiles = Directory.GetFiles(strStoresPath, "*.xml");
            TaskService ts = new TaskService();            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.WriteLine("Adding stores to the Task Scheduler");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string strXMLFile in strXMLFiles)
            {
                string storeName = Path.GetFileName(strXMLFile);
                string taskName = @"BC Store " + storeName;
                Task t = ts.FindTask(taskName);
                if (t == null)
                {                    
                    Console.WriteLine("  + " + storeName);
                    DailyTrigger dt = new DailyTrigger();
                    dt.StartBoundary = DateTime.Today.Date;
                    dt.Repetition.Duration = TimeSpan.FromMinutes(1430);
                    dt.Repetition.Interval = TimeSpan.FromMinutes(2);
                    ts.AddTask(taskName, dt, new ExecAction(strActionPath, strXMLFile, null));
                    Thread.Sleep(500);
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("All stores added");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
