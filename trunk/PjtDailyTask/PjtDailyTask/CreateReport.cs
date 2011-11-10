using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PjtDailyTask
{
    class CreateReport
    {
        public TextWriter CreateFile(string filename,string header)
        {
            string filenameTemp = filename;
            if (File.Exists(filename))
                File.Delete(filename);
            if (!Directory.Exists(filename))
            { 
                filenameTemp = filenameTemp.Replace("UploadShar_RecentTasks_Report_" + DateTime.Now.ToString("D") + ".txt", "");
                Directory.CreateDirectory(filenameTemp);
            }

            TextWriter tw = new StreamWriter(filename, true);
            tw.WriteLine(header);
            return tw;
            
        }

        public void Write(string strline, TextWriter tw)
        {
            tw.WriteLine(strline);
        }
    }

}
