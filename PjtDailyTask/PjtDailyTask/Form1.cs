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
        object empty = 0;
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

                            OpenWebPage(strLoginHtml);
                            IExplorer.Visible = true;
                            OpenWebPage("http://qqprojects.com/server01/EditTask.asp?PROJECT_ID=16");
                            FillPageData(strQQID);

                        }
                    }
                }                
            }          
        }

        private void OpenWebPage( string webpage)
        {
            object url = webpage;            
            IExplorer.Navigate2(ref url, ref empty, ref empty, ref empty, ref empty);
            do {System.Threading.Thread.Sleep(500);} while (IExplorer.Busy);
        }

        private void FillPageData(string QQID)
        {
            mshtml.HTMLDocumentClass htmlDoc = (mshtml.HTMLDocumentClass)IExplorer.Document;
            var TaskNo = htmlDoc.getElementById("TASK_NUMBER").getAttribute("Value", 0);
            int ConvertIntTaskno = int.Parse(string.Format("{0}",TaskNo)) + 50 ;
            htmlDoc.getElementById("TASK_NUMBER").innerText = ConvertIntTaskno.ToString();
            htmlDoc.getElementById("TASK_RESUME").innerText = QQID + " Desktop New Conversion";
            htmlDoc.getElementById("TASK_DESC_CREATOR").innerText = "Data is located in UploadShar.";
            htmlDoc.getElementById("TASK_DESC_CREATOR").style.display = "block";
            htmlDoc.getElementById("TASK_DESC_CREATOR___Frame").outerHTML = "";
            
            ClickElement("value", "Save + Assignment", "document", htmlDoc.getElementsByTagName("input"));
            string strUserID = GetUserID("LChandran", htmlDoc.getElementsByTagName("tr"));
            if (strUserID != "") {
                ClickElement("id", "ass", "incrementAssignation(this,'" + strUserID, htmlDoc.getElementsByTagName("input"));
            }
        }

        private void ClickElement(string strAttrib, string strID, string strValue, mshtml.IHTMLElementCollection Tags)
        {
            foreach (mshtml.IHTMLElement cTag in Tags) {
                object objAtrib = cTag.getAttribute(strAttrib, 0);
                if (objAtrib != null) {
                    if (objAtrib.Equals(strID)) {
                        if (cTag.outerHTML.IndexOf(strValue) > 0) {
                            cTag.click();
                            do { System.Threading.Thread.Sleep(500); } while (IExplorer.Busy);
                            break;
                        }
                    }
                }
            }
        }

        private string GetUserID(string strUserName, mshtml.IHTMLElementCollection Tags)
        {
            string strUserId = "";
            foreach (mshtml.IHTMLElement cTag in Tags) {
                if (cTag.innerHTML.Substring(0, 7).ToUpper().Equals("<TD ID=")) {
                    if (cTag.innerText.IndexOf(strUserName) >= 0) {
                        int pos = cTag.innerHTML.IndexOf("incrementAssignation(this,");
                        if (pos > 0) {
                            strUserId = cTag.innerHTML.Substring(pos + 27, 3);
                            strUserId = strUserId.Replace("'", "");
                            break;
                        }
                    }
                }
            }
            return strUserId;
        }

        private void CloseWebPage()
        {
            IExplorer.Quit();
        }
    }
}
