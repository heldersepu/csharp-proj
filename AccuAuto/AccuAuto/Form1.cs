using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Dynamic;
using System.IO;
using System.Linq;


namespace AccuAuto
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
            lblFile.Text = "";
            lblGroup.Text = "";
            lblCounter.Text = "";
        }

        private void updGroupLabel(string strText, int intCounter)
        {
            lblGroup.Text = strText;
            lblCounter.Text  = intCounter.ToString();
            lblFile.Text = "";
            this.Refresh();
            System.Threading.Thread.Sleep(1000);            
        }

        public void updFileLabel(string strText)
        {
            try
            {
                lblCounter.Text = (Convert.ToInt32(lblCounter.Text) - 1).ToString();
                lblCounter.Refresh();
            }
            catch { }
            lblFile.Text = strText;
            lblFile.Refresh(); 
        }
        
        private void btnImport_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;            
            var DirInfo = new System.IO.DirectoryInfo(txbDirectory.Text);
            if (DirInfo.Exists)
            {                           
                DirInfo = new System.IO.DirectoryInfo(txbDirectory.Text + @"\Client");
                if (DirInfo.Exists)
                {                    
                    btnImport.Enabled = false;
                    ClassConvert convert = new ClassConvert(txbServer.Text, txbDB.Text, txbUser.Text, txbPassw.Text);
                    
                    updGroupLabel("Importing Clients", DirInfo.GetFiles().Length);
                    convert.doClients(this, DirInfo);

                    DirInfo = new System.IO.DirectoryInfo(txbDirectory.Text + @"\Policy");
                    if (DirInfo.Exists)
                    {
                        DirInfo = new System.IO.DirectoryInfo(txbDirectory.Text + @"\Policy\PersAutoPolicy");
                        if (DirInfo.Exists)
                        {
                            updGroupLabel("Importing PersAutoPolicy Policies", DirInfo.GetFiles().Length);
                            convert.doPolicies(this, DirInfo, "AUTO");
                        }
                        DirInfo = new System.IO.DirectoryInfo(txbDirectory.Text + @"\Policy\BoatPolicy");
                        if (DirInfo.Exists)
                        {
                            updGroupLabel("Importing PersAutoPolicy Policies", DirInfo.GetFiles().Length);
                            convert.doPolicies(this, DirInfo, "BOAT");
                        }
                    }

                    DirInfo = new System.IO.DirectoryInfo(txbDirectory.Text + @"\FileAttachment");
                    if (DirInfo.Exists)
                    {
                        updGroupLabel("Importing Images", DirInfo.GetFiles().Length);
                        convert.doImages(this, DirInfo, "");
                    }

                    updGroupLabel("  All Done! ", 0);                    
                }
            }
            else
            {
                MessageBox.Show("Directory not found: " + txbDirectory.Text);
            }
            Cursor.Current = Cursors.Default;
        }

    }
}
