using System;
using System.IO;
using System.Xml;
using System.Net;
using System.Web;
using System.Text;
using System.Collections.Generic;

namespace BCReader
{
    public struct order
    {
        public long id;
        public string phone;
        public double total;

        public order(string str_id, string str_phone, string str_total) 
        {
            id = Convert.ToInt64(str_id);
            phone = "1" + Utils.onlyNumbers(str_phone);
            total = Convert.ToDouble(str_total);
        }
    }
    class BC
    {        
        private string api;
        private string user;
        private string url;
        private string lastid;
        public List<order> orders = new List<order>();

        public BC(string _api, string _user, string _url, string _lastid)
        {
            user = _user;
            api = _api;
            url = _url;
            lastid = _lastid;
            getOrders();
        }

        private void getOrders()
        {
            string strUrl = url + "/api/v2/orders.xml?min_id=" + lastid;
            // Retrieve orders only from today with min_date_created
            //strUrl = strUrl + "&min_date_created=" + DateTime.Now.ToString("ddd, dd MMM yyyy 00:00:00 0000");
            HttpWebRequest GETRequest = (HttpWebRequest)WebRequest.Create(strUrl);
            GETRequest.Headers.Add("Authorization", "Basic key");
            GETRequest.Method = "GET";
            NetworkCredential nc = new NetworkCredential(user, api);
            GETRequest.Credentials = nc;
            HttpWebResponse GETResponse = (HttpWebResponse)GETRequest.GetResponse();
            Stream GETResponseStream = GETResponse.GetResponseStream();
            StreamReader sr = new StreamReader(GETResponseStream);                        
            loadOrders(sr.ReadToEnd());
        }

        private void loadOrders(string xmlOrders)
        {
            if (xmlOrders.Trim().Length > 1)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlOrders);
                XmlNodeList nodeList = doc.SelectNodes("/orders/order");
                foreach (XmlNode node in nodeList)
                {
                    XmlNode nID = node.SelectSingleNode("id");
                    XmlNode nPhone = node.SelectSingleNode("billing_address/phone");
                    XmlNode nTotal = node.SelectSingleNode("total_inc_tax");
                    orders.Add(new order(nID.InnerText, nPhone.InnerText, nTotal.InnerText));
                }
            }
        }

        public Boolean newOrder
        { 
            get
            {
                return (orders.Count > 0); 
            }
        }

    }
}
