using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;

namespace BCReader
{
    class config
    {
        private XmlDocument doc;
        private string FileName;
        public config(string strFile)
        {
            try
            {
                FileName = strFile;
                doc = new XmlDocument();
                doc.Load(strFile);
            }
            catch
            {
            }
        }

        private string getnode(string xpath)
        {
                string strnode = "";
                try
                {
                    XmlNode node = doc.SelectSingleNode("/data" + xpath);
                    strnode = node.InnerText;
                }
                catch
                {
                }
                return strnode;
        }

        public string store_lastid
        {
            get
            {
                return getnode("/store/orders/lastid");
            }
            set
            {
                XmlNode node = doc.SelectSingleNode("/data/store/orders/lastid");
                node.InnerText = value;
                doc.Save(FileName);
            }

        }

        public string store_user
        {
            get
            {
                return getnode("/store/user");
            }

        }

        public string store_api
        {
            get
            {
                return getnode("/store/api");
            }

        }

        public string store_url
        {
            get
            {
                return getnode("/store/url");
            }
        }

        public string store_name
        {
            get
            {
                return getnode("/store/name");
            }
        }

        public string store_phone
        {
            get
            {
                return getnode("/store/phone");
            }
        }
        public string sms_url
        {
            get
            {
                return getnode("/sms/url");
            }
        }

        public string sms_user
        {
            get
            {
                return getnode("/sms/user");
            }
        }

        public string sms_pass
        {
            get
            {
                return getnode("/sms/pass");
            }
        }

    }
}
