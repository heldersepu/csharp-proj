using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!txbAddressList.Text.Contains(txbAddress.Text + Environment.NewLine))
            {                
                txbAddressList.Text = txbAddress.Text + Environment.NewLine + txbAddressList.Text;                
            }
            txbAddress.Text = "";
        }

        private void txbAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnAdd_Click(sender, null);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadFromTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Read text file
        }

        private void inputToSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eXECUTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string temp = "";
            for (int i = 0; i < txbAddressList.Lines.Count(); i++)
            {
                if (txbAddressList.Lines[i].Length > 5)
                {
                    temp = txbAddressList.Lines[i] + " = " + GeoCodeData(txbAddressList.Lines[i]) + Environment.NewLine + temp;
                }
            }
            txbAddressList.Text = temp;
        }
        
        private String GeoCodeData(string address)
        {
            string result = "No GeoData";
            try
            {
                GeocodeRequest geocodeRequest = new GeocodeRequest();
                geocodeRequest.Credentials = new GeocodeService.Credentials();
                geocodeRequest.Credentials.ApplicationId = "Anuqkpthyvyu9ni3Lb6dH9tWjpzFEjCoUYgxKgk_FwdPpq1ErB7VBUkUrmQlAss4";
                geocodeRequest.Query = address;
                ConfidenceFilter[] filters = new ConfidenceFilter[1];
                filters[0] = new ConfidenceFilter();
                filters[0].MinimumConfidence = GeocodeService.Confidence.High;
                GeocodeOptions geocodeOptions = new GeocodeOptions();
                geocodeOptions.Filters = filters;
                geocodeRequest.Options = geocodeOptions;
                GeocodeServiceClient geocodeService = new GeocodeServiceClient("BasicHttpBinding_IGeocodeService");
                GeocodeResponse geocodeResponse = geocodeService.Geocode(geocodeRequest);
                if (geocodeResponse.Results.Length > 0)
                    result = String.Format("Lat: {0} Lon: {1}",
                        geocodeResponse.Results[0].Locations[0].Latitude,
                        geocodeResponse.Results[0].Locations[0].Longitude);
            }
            catch { }             
            return result;            
        }
    }
}
