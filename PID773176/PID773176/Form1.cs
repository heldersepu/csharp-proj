using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using PID773176.GeocodeService;
using PID773176.SearchService;
using PID773176.ImageryService;
using PID773176.RouteService;

namespace PID773176
{    
    public partial class frmGeoData : Form
    {
        public frmGeoData()
        {
            InitializeComponent();
        }

        private GeocodeService.Location GeoCodeData(string address)
        {           
            try
            {
                GeocodeRequest request = new GeocodeRequest();
                request.Credentials = new GeocodeService.Credentials();
                request.Credentials.ApplicationId = ConfigurationSettings.AppSettings["BingApiKey"];
                request.Query = address;
                ConfidenceFilter[] filters = new ConfidenceFilter[1];
                filters[0] = new ConfidenceFilter();
                filters[0].MinimumConfidence = GeocodeService.Confidence.High;
                GeocodeOptions geocodeOptions = new GeocodeOptions();
                geocodeOptions.Filters = filters;
                request.Options = geocodeOptions;
                GeocodeServiceClient geocodeService = new GeocodeServiceClient("BasicHttpBinding_IGeocodeService");
                GeocodeResponse response = geocodeService.Geocode(request);
                if (response.Results.Length > 0)
                {
                    return response.Results[0].Locations[0];
                }
            }
            catch { }
            return null;            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Add(txbAddress.Text);
            txbAddress.Text = "";
        }

        private void txbAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnAdd_Click(sender, null);
            }
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            outputToolStripMenuItem.Enabled = true;
        }

        private void eXECUTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            foreach (DataGridViewRow rw in dataGridView.Rows)
            {
                if (rw.Cells[0].Value != null)
                {
                    GeocodeService.Location location = GeoCodeData(rw.Cells[0].Value.ToString());
                    if (location != null)
                    {
                        rw.Cells["Latitude"].Value = location.Latitude;
                        rw.Cells["Longitude"].Value = location.Longitude;
                    }
                    Refresh();
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void loadFromTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string allText = File.ReadAllText(openFileDialog.FileName);
                    foreach (string line in allText.Split('\r'))
                    {
                        if (line.Length > 4)
                        {
                            dataGridView.Rows.Add(line.Trim());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void OutputToTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string strAddressList = "Address\tLatitude\tLongitude" + Environment.NewLine;
                    foreach (DataGridViewRow rw in dataGridView.Rows)
                    {                        
                        if (rw.Cells[0].Value != null)
                        {
                            strAddressList += rw.Cells[0].Value + "\t" + 
                                             rw.Cells[1].Value + "\t" + 
                                             rw.Cells[2].Value + Environment.NewLine;
                            Refresh();
                        }
                    }
                    File.WriteAllText(saveFileDialog.FileName, strAddressList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not Write file to disk. Original error: " + ex.Message);
                }
            }            
        }

        private void loadFromSQLStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;
            try
            {
                conn = new SqlConnection(ConfigurationSettings.AppSettings["connectionString"]);
                conn.Open();
                SqlCommand cmd = new SqlCommand(ConfigurationSettings.AppSettings["inputSPname"], conn);
                cmd.CommandType = CommandType.StoredProcedure;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dataGridView.Rows.Add(rdr["ADDRESS"]);
                }
            }
            finally
            {
                if (conn != null) conn.Close();
                if (rdr != null) rdr.Close();
            }
        }
        
        private void OutputToSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //To Do
        }
    }
}
