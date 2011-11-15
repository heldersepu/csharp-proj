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
using Microsoft.VisualBasic;


namespace PjtDailyTask
{
    public partial class Form1 : Form
    {  
        private string mypath = @"S:\";
        public string filenameMain = "UploadShar_RecentTasks_Report_" + DateTime.Now.ToString("D") + ".txt";
        string processed, strQQID;
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
            Process.Start(txtSave.Text + filenameMain);
            var QuitApp = MessageBox.Show("Quit Application (Yes/No)", "Quit Application", MessageBoxButtons.YesNo);
            if (QuitApp == DialogResult.Yes)
                System.Windows.Forms.Application.Exit();
            else
                lbldescription.Text = "Waiting for the next operation";
        }

        private void ManipulateRecentFiles()
        {
            Application.DoEvents();
            lbldescription.Text = "Reading Recent Files from Ace...";
            processed = "N";
            CreateReport Mainreport = new CreateReport();
            DateTime SelectedDate = FromDateCalender.SelectionRange.Start;
            string[] filelists = System.IO.Directory.GetFiles(mypath);
            int totalfilecount = filelists.Count();            
            int intcount = 0;
            string strheader = "****This is a report listing the new ZipIt files****";
            TextWriter TW = Mainreport.CreateFile(txtSave.Text + filenameMain, strheader);

            while (intcount < totalfilecount)
            {               
                Application.DoEvents();                
                String strlastmodified = System.IO.File.GetLastWriteTime(filelists[intcount]).ToString();

                if (DateTime.Parse(strlastmodified) > SelectedDate)
                {
                    Application.DoEvents();

                    if ((filelists[intcount].IndexOf("_pm", 0) > 0) || (filelists[intcount].IndexOf("_am", 0) > 0))
                    {
                        processed = "P";
                        Mainreport.Write(filelists[intcount], TW);
                        lbldescription.Text = "Writing Report...";
                    }
                }
                intcount++;
            }
            if (processed != "P")
                Mainreport.Write("No Zip files uploaded on/after " + SelectedDate,TW );
           TW.Close();
            
        }        
       
        private void cmdUploadAce_Click(object sender, EventArgs e)
        { 
            //Create Report            
            ManipulateRecentFiles();
            //Navigate through each ZipIT
            if (processed == "P")
            {
                NavigateZipIT(txtSave.Text + filenameMain);
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("No Tasks to Upload on Ace");
            }            
            System.Windows.Forms.Application.Exit();   
        }

        private Boolean NavigateZipIT(string path)
        {
            string strline, strQQIDbck;
            int i = 0;
            if (File.Exists(path))
            {
                StreamReader file = null;
                file = new StreamReader(path);                
                for (i=0;(strline = file.ReadLine())!=null ;i++)
                {                    
                    int pos = strline.IndexOf("QQ", 0);
                    if (pos > 1) 
                    {
                        strQQIDbck = strline.Substring(pos, 8);
                        if ((strQQIDbck != "") && (strQQID != strQQIDbck))
                        {
                            strQQID = strQQIDbck;
                            AceFillData(strQQIDbck);                   
                        }                        
                    }
                }
                if (i != 0)
                    return true;
            }
            return false;
        }
        
        private void AceFillData(string strQQID)
        {            
            IExplore IE = new IExplore();
            string[,] UserIDs = { {"LChandran", "assign"}, {"hsepulveda", "assign"}, 
                                {"NFitzgerald", "review"}, {"RSequeira", "review"} }; 
            IE.openWebPage("http://qqprojects.com/server01/EditTask.asp?PROJECT_ID=16");
            var AddTaskConfirm = MessageBox.Show("Add Task for " + strQQID, "Add Task Confirmation", MessageBoxButtons.YesNo);
            if (AddTaskConfirm == DialogResult.Yes)
            {
                IE.show();
                IE.FillTask(strQQID + " Desktop New Conversion", "Data is located in UploadShar.");
                IE.ClickElement("value", "Save + Assignment", "document");
                for (int i = 0; i < UserIDs.GetLength(0); i++)
                {
                    lbldescription.Text = "Filling WebPage Information...";
                    string strUserID = IE.GetUserID(UserIDs[i, 0]);
                    if (strUserID != "")
                    {
                        IE.ClickElement("id", UserIDs[i, 1].Substring(0, 3), "incrementAssignation(this,'" + strUserID + "'");
                    }
                    IE.ClickElement("value", "Update", " ");
                }
            }
            IE.CloseWebPage();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
    }
}
