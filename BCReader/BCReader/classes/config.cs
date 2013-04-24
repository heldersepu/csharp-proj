using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;

namespace BCReader
{
    class config
    {
        private XmlDocument doc;
        public config(string strFile)
        {
            try
            {
                doc = new XmlDocument();
                doc.Load(strFile);
            }
            catch
            {
            }        
        }

        public string store_api
        {
            get
            {
                XmlNode node = doc.SelectSingleNode("/store/api");
                return node.InnerText;
            }
        }

        public string store_url
        {
            get
            {
                XmlNode node = doc.SelectSingleNode("/store/url");
                return node.InnerText;
            }
        }
    }
}
