using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;


namespace regExport
{
    class Program
    {
        static void Main(string[] args)
        {
            ExportReg("HKEY_LOCAL_MACHINE\\Software\\RCI", "C:\\myLocal.reg", "ServerName");
        }

        static public void ExportReg(string RegKey, string SavePath, string ServerName)
        {
            string path = "\"" + SavePath + "\"";
            string key = "\"" + RegKey + "\"";

            var proc = new Process();
            try
            {
                proc.StartInfo.FileName = "regedit.exe";
                proc.StartInfo.UseShellExecute = false;
                proc = Process.Start("regedit.exe", "/e " + path + " " + key + "");

                if (proc != null) proc.WaitForExit();
            }
            finally
            {
                if (proc != null) proc.Dispose();
            }

        }
    }
}
