using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using SHDocVw;

namespace PjtDailyTask
{
   
    public partial class Form1 : Form
    {
        private string mypath = @"S:\";
        private SHDocVw.InternetExplorer IExplorer = new SHDocVw.InternetExplorer();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenUploadShar(mypath);
        }

        private void OpenUploadShar(string mypath)
        {
            Process.Start(mypath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManipulateRecentFiles();
            MessageBox.Show("Report Created");
            System.Windows.Forms.Application.Exit();
        }

        private void ManipulateRecentFiles()
        {
            DateTime SelectedDate = FromDateCalender.SelectionRange.Start;

            string[] filelists = System.IO.Directory.GetFiles(mypath);
            int totalfilecount = filelists.Count();
            int intcount = 0;
            string strheader = "This is a report listing the new ZipIt files: ";
            CreateReport Mainreport = new CreateReport();
            TextWriter TW = Mainreport.CreateFile("C:\\Temp\\test\\test-" + DateTime.Now.ToString("D") + ".txt", strheader);

            while (intcount < totalfilecount)
            {
                String strlastmodified = System.IO.File.GetLastWriteTime(filelists[intcount]).ToString();

                if (DateTime.Parse(strlastmodified) > SelectedDate)
                {
                    Mainreport.Write(filelists[intcount], TW);
                }
                intcount++;
            }
            TW.Close();
        }

        private void cmdUploadAce_Click(object sender, EventArgs e)
        {
            //Create Report
            ManipulateRecentFiles();
            //Navigate through each ZipIT
            string strfilepath = "C:\\Temp\\test\\test-" + DateTime.Now.ToString("D") + ".txt";
            NavigateZipIT(strfilepath);
            Console.WriteLine("Test");
            MessageBox.Show("Done");
            System.Windows.Forms.Application.Exit();   
        }

        private void NavigateZipIT(string path)
        {
            string strline, strQQID;
            int i = 0;
            if (File.Exists(path))
            {
                StreamReader file = null;
                file = new StreamReader(path);
                for (i=0;file.ReadLine()!=null ;i++)
                {
                    strline = file.ReadLine();
                    Console.WriteLine (strline);
                    int pos = strline.IndexOf("QQ", 0);
                    if (pos > 1)
                    {
                        strQQID = strline.Substring(pos, 8);

                        //Open Ace, Login
                        if (strQQID != "")
                        {
                            string strpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData );
                            string strLoginHtml = strpath + @"\Login.html";
                                
                            strLoginHtml = strLoginHtml.Replace(@"\", @"/");
                            strLoginHtml = strLoginHtml.Replace(":", "$");
                            strLoginHtml = "file://127.0.0.1/" + strLoginHtml;

                            OpenWebPage(strLoginHtml,0,"" );
                            OpenWebPage("http://qqprojects.com/server01/EditTask.asp?PROJECT_ID=16", 1, strQQID);
                            
                            CloseWebPage();
                        }
                    }
                }                
            }          
        }

        private void OpenWebPage( string webpage,int pageind,string qqid)
        {
            object url = webpage;
            object empty = 0;
            IExplorer.Visible = true;
            IExplorer.Navigate2(ref url, ref  empty, ref empty, ref empty, ref empty);
            System.Threading.Thread.Sleep(5000);
            if (pageind == 1)
                FillPageData(qqid);
        }

        private void FillPageData(string QQID)
        {
           
        }
        private void CloseWebPage()
        {
            IExplorer.Quit();
        }
    }
}
