﻿using System;
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
            TextWriter TW = Mainreport.CreateFile(txtSave.Text + "test-" + DateTime.Now.ToString("D") + ".txt", strheader);

            while (intcount < totalfilecount)
            {
                String strlastmodified = System.IO.File.GetLastWriteTime(filelists[intcount]).ToString();

                if (DateTime.Parse(strlastmodified) > SelectedDate)
                {
                    Mainreport.Write(filelists[intcount], TW);
                }
                intcount++;
            }
            if (TW != null)
                TW.Close();
        }
        
       
        private void cmdUploadAce_Click(object sender, EventArgs e)
        { 
            //Create Report
            ManipulateRecentFiles();
            //Navigate through each ZipIT
            string strfilepath = "C:\\Temp\\test\\test-" + DateTime.Now.ToString("D") + ".txt";
            //Boolean CheckProcessed = NavigateZipIT("C:\\TEMP\\test\\test-Monday, November 07, 2011.txt");
            Boolean CheckProcessed = NavigateZipIT(strfilepath);
            if (CheckProcessed == true)
                MessageBox.Show("Tasks Created on Ace");
            else
                MessageBox.Show("No Tasks to Upload on Ace");
            System.Windows.Forms.Application.Exit();   
        }

        private Boolean NavigateZipIT(string path)
        {
            string strline, strQQID;
            Boolean  processed = false;
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
                        strQQID = strline.Substring(pos, 8);
                        if (strQQID != "")
                        {
                            processed = true;
                            AceFillData(strQQID);
                        }
                    }
                }                
            }
            return processed;
        }
        
        private void AceFillData(string strQQID)
        {            
            IExplore IE = new IExplore();
            string [] AssUserIDs = {"LChandran","hsepulveda"};
            string[] RevUserIDs = {"NFitzgerald", "RSequeira" };
            IE.show();
            IE.openWebPage("http://qqprojects.com/server01/EditTask.asp?PROJECT_ID=16");            
            IE.FillTask("test" + strQQID + " Desktop New Conversion", "Data is located in UploadShar.");            
            
            IE.ClickElement("value", "Save + Assignment", "document");
            foreach (string UserID in AssUserIDs)
            {
                string strUserID = IE.GetUserID(UserID);
                if (strUserID != "")
                {
                    IE.ClickElement("id", "ass", "incrementAssignation(this,'" + strUserID);
                    
                }
            }
            foreach (string UserID in RevUserIDs)
            {
                string strUserID = IE.GetUserID(UserID);
                if (strUserID != "")
                {
                    IE.ClickElement("id", "rev", "incrementAssignation(this,'" + strUserID);

                }
            }
            //IE.CloseWebPage();
        }

       
    }
}