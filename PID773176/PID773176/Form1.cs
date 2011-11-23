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
using System.Threading;
using System.Reflection;

using GeoData.GeocodeService;
using GeoData.SearchService;
using GeoData.ImageryService;
using GeoData.RouteService;

namespace GeoData
{
    public partial class frmGeoData : Form
    {
        private bool runUnattended = false;
        private string getConfig(string strValue) 
        {
            try
            {
                return ConfigurationSettings.AppSettings[strValue];
            }
            catch { }
            return null;
        }

        public frmGeoData(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
            {
                if (args[0].ToLower().Contains("rununattended"))
                    runUnattended = true;
            }
        }

        private GeocodeResponse GeoCodeData(string address)
        {
            try
            {
                GeocodeRequest request = new GeocodeRequest();
                request.Credentials = new GeocodeService.Credentials();
                request.Credentials.ApplicationId = getConfig("BingApiKey");
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
                    return response;
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

        private void doEXECUTE()
        {
            foreach (DataGridViewRow rw in dataGridView.Rows)
            {
                if (rw.Cells[0].Value != null)
                {
                    GeocodeResponse response = GeoCodeData(rw.Cells[0].Value.ToString());
                    if (response != null)
                    {
                        rw.Cells["Latitude"].Value = response.Results[0].Locations[0].Latitude;
                        rw.Cells["Longitude"].Value = response.Results[0].Locations[0].Longitude;
                        rw.Cells["Confidence"].Value = response.Results[0].Confidence.ToString();
                        rw.Cells["CalculationMethod"].Value = response.Results[0].Locations[0].CalculationMethod;
                    }
                }
            }
        }

        private void eXECUTEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            if (dataGridView.Rows.Count == 1)
            {
                testConnString();
            }
            else
            {
                doEXECUTE();
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
                    string strAddressList = "Address\tLatitude\tLongitude\tConfidence\tCalculationMethod" + Environment.NewLine;
                    foreach (DataGridViewRow rw in dataGridView.Rows)
                    {
                        if (rw.Cells[0].Value != null)
                        {
                            for (int i = 0; i < rw.Cells.Count; i++)
                            {
                                strAddressList += rw.Cells[i].Value + "\t";
                            }
                            strAddressList += Environment.NewLine;
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

        private void testConnString()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(getConfig("inputConnString"));
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: With the connection " + ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        private void loadFromSQLStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;
            try
            {
                conn = new SqlConnection(getConfig("inputConnString"));
                conn.Open();
                SqlCommand cmd = new SqlCommand(getConfig("inputSPname"), conn);
                cmd.CommandType = CommandType.StoredProcedure;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dataGridView.Rows.Add(rdr["ADDRESS"], null, null,rdr["PassthroughID"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
                if (rdr != null) rdr.Close();
            }
        }

        private void OutputToSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(getConfig("outputConnString"));
                conn.Open();
                foreach (DataGridViewRow rw in dataGridView.Rows)
                {
                    if (rw.Cells[0].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand(getConfig("outputSPname"), conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        for (int i = 0; i < rw.Cells.Count; i++)
                        {
                            cmd.Parameters.Add(new SqlParameter(getConfig("outputSP_param"+(i+1)), rw.Cells[i].Value));
                        }
                        foreach (SqlParameter Parameter in cmd.Parameters)
                        {
                            if (Parameter.Value == null) Parameter.Value = DBNull.Value;
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        private void runUnattendedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long counter = 0;
            long max = 5;
            try
            {
                long temp = Convert.ToInt64(getConfig("UnattendedLoops"));
                max = temp;
            }
            catch { }

            do
            {
                loadFromSQLStripMenuItem_Click(sender, e);
                Refresh();
                eXECUTEToolStripMenuItem_Click(sender, e);
                Refresh();
                OutputToSQLToolStripMenuItem_Click(sender, e);
                Refresh();
                Thread.Sleep(250);
                dataGridView.Rows.Clear();
                Refresh();
                Thread.Sleep(250);
                counter++;
            }
            while (counter < max);

            if (getConfig("UnattendedClose") == "yes") this.Close();
        }

        private void frmGeoData_Shown(object sender, EventArgs e)
        {
            if (runUnattended)
            {
                runUnattendedToolStripMenuItem_Click(sender, e);
                runUnattended = false;
            }
        }

        private void frmGeoData_Load(object sender, EventArgs e)
        {
            Assembly thisAssem = Assembly.GetExecutingAssembly();
            string ver = thisAssem.GetName().Version.ToString();
            verInfo.Text = "v " + ver;
        }
    }
}
