using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace BCReader
{
    class log
    {
        private string strFile = "";
        public log(string _strFile)
        {
            string strFilePath = System.Reflection.Assembly.GetEntryAssembly().Location;
            string strDirPath = Path.GetDirectoryName(strFilePath);
            if (File.Exists(strDirPath + "\\dolog.txt"))
            {
                strFile = _strFile;
                if (strFile.EndsWith(".log", true, null))
                {
                    strFile += ".log";
                }
                if (!File.Exists(strFile))
                {
                    File.CreateText(strFile);
                }
            }
        }

        public void append(string message, string phone, long id)
        {
            if (strFile != "")
            {
                using (StreamWriter w = File.AppendText(strFile))
                {
                    w.WriteLine(DateTime.Now.ToString());
                    w.WriteLine(id.ToString() + ' ' + phone + ' ' + message);
                    w.WriteLine("   ---   ---   ---   ---");
                }
            }
        }
    }
}
