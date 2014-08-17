using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using absToTango;

namespace ToTangoXport
{
    public partial class ToTangoXport
    {
        private ToTangoExport toTango;
        private string token = "";
        private string headerFile = "";
        public ToTangoXport()
        {
            InitializeComponent();
            InitializeDialog();
            InitializeTotango();            
        }

        private void InitializeTotango()
        {            
            try
            {
                token = ConfigurationManager.AppSettings.Get("ToTangoToken");
                headerFile = ConfigurationManager.AppSettings.Get("HeaderFile");
            }
            catch (Exception) { }
            if (!File.Exists(headerFile)) 
                File.WriteAllLines(headerFile, new string [] {"MemberFullName,MemberEmail,MemberPhone"});
            toTango = new ToTangoExport(token, headerFile);
        }

        private void InitializeDialog()
        {
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "ToTango";
            saveFileDialog1.Filter = "ToTango Config|*.ToTango";

            openFileDialog1.AddExtension = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.DefaultExt = "ToTango";
            openFileDialog1.Filter = "ToTango Config|*.ToTango";
            openFileDialog1.FileName = "";
        }

        private void loadFromFile(string FileName)
        {
            dataGridView.Rows.Clear();
            foreach (string line in File.ReadAllLines(FileName))
            {
                dataGridView.Rows.Add();
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.Cells[0].Value == null)
                    {
                        row.Cells[0].Value = line;
                        break;
                    }
                }
            }
        }

        private void writeToFile(string FileName)
        {
            List<string> lines = new List<string>();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string url = row.Cells[0].Value.ToString();
                    if (url.Length > 0)
                    {
                        lines.Add(url);
                    }
                }
            }
            File.WriteAllLines(FileName, lines);
        }

        private void UpdateSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void Download(string url, string outname)
        {
            this.status.Text = "Downloading...";
            this.status2.Text = "";
            this.Refresh();
            outname = this.toTango.Start(url, outname);
            this.status.Text = "Done!";
            this.status2.Text = outname;
        }
    }
}
