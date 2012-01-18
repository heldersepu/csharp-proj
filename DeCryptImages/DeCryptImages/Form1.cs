using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DeCryptImages
{
    public partial class Form1 : Form
    {
        private eBridge.AES ebridge = new eBridge.AES();
        public Form1()
        {
            InitializeComponent();
        }

        private void doDecrypt(string source, string destin, string cabId, string passw)
        {
            string [] fileEntries = Directory.GetFiles(source);
            foreach(string fileName in fileEntries)
            {
                try
                {
                    Directory.CreateDirectory(destin); 
                    ebridge.DecryptFile(fileName, destin + fileName.Replace(source, ""), cabId, passw);
                    lblStatus.Text = fileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("doDecrypt Error: " + ex.Message);
                    break;
                }
                Refresh();
            }

            string [] subdirEntries = Directory.GetDirectories(source);
            foreach (string subdir in subdirEntries)
            {
                doDecrypt(subdir, destin + subdir.Replace(source, ""), cabId, passw);
                Refresh();
            }
        }

        private void btnDeCrypt_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;            

            if (txbSource.Text != "" && txbDestin.Text != "")
            {
                if (Directory.Exists(txbSource.Text) && Directory.Exists(txbDestin.Text))
                {
                    try
                    {
                        btnDeCrypt.Hide();
                        doDecrypt(txbSource.Text, txbDestin.Text, txbCabinetID.Text, txbPassw.Text);
                        lblStatus.Text = "DeCryption Completed!!";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Directory!");
                }
            }
            
            Cursor.Current = Cursors.Default;
        }

        private void txbSource_TextChanged(object sender, EventArgs e)
        {
            btnDeCrypt.Enabled = (txbSource.Text != "" && txbDestin.Text != "");
        }

        private void txbDestin_TextChanged(object sender, EventArgs e)
        {
            btnDeCrypt.Enabled = (txbSource.Text != "" && txbDestin.Text != "");
        }
    }
}
