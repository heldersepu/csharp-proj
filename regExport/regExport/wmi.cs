using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace regExport
{
    class wmi
    {
        static public void ExportReg(string RegKey, string SavePath, string ServerName)
        {
            string path = "\"" + SavePath + "\"";
            string key = "\"" + RegKey + "\"";
            object[] theProcessToRun = { "regedit.exe /e " + path + " " + key + "" };
            ManagementClass mClass = new ManagementClass(@"\\" + ServerName + @"\root\cimv2:Win32_Process");
            mClass.InvokeMethod("Create", theProcessToRun);
        }
    }
}
