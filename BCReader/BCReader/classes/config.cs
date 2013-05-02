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
        private bool encrypt;
        public config(string strFile)
        {
            try
            {
                FileName = strFile;
                doc = new XmlDocument();
                doc.Load(strFile);
                encrypt = (getnode("/ncrypt").ToLower() == "true");
            }
            catch
            {
            }
        }

        private string getnode(string xpath, bool isEncrypted = false)
        {
            string strnode = "";
            try
            {
                XmlNode node = doc.SelectSingleNode("/data" + xpath);
                if (isEncrypted)
                {
                    strnode = Utils.Decrypt(node.InnerText);
                }
                else
                {
                    strnode = node.InnerText;
                }
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
                return getnode("/store/user", encrypt);
            }

        }

        public string store_api
        {
            get
            {
                return getnode("/store/api", encrypt);
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
                return getnode("/sms/user", encrypt);
            }
        }

        public string sms_pass
        {
            get
            {
                return getnode("/sms/pass", encrypt);
            }
        }

        public string sms_message
        {
            get
            {
                return getnode("/sms/message");
            }
        }

        public bool active
        {
            get
            {
                return (getnode("/active").ToLower() == "true");
            }
        }
    }
}
