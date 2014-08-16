using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace absToTango
{
    /// <summary>
    /// Provides an easy way to export ToTango filters 
    /// </summary>
    class ToTangoExport
    {
        private string _token;
        private string _headers = "";
        private string _aliasHead = "";

        /// <summary>
        /// Initializes a new instance of the ToTangoExport class.
        /// </summary>
        /// <param name="token">Your ToTango API authentication key.</param>        
        /// <param name="headerFile">Your Mapping file.</param>
        public ToTangoExport(string token, string headerFile)
        {            
            this._token = token;
            foreach (string line in File.ReadAllLines(headerFile))
            {
                if ((line.Trim().Length > 0) && (!line.StartsWith("#")))
                {
                    if (this._headers == "")
                    {
                        this._headers = line.Replace("\t", "");
                        this._aliasHead = this._headers;
                    }
                    else
                    {
                        this._aliasHead = line.Replace("\t", "");
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Start the export on the given url
        /// </summary>
        /// <param name="url">The Url to the API, something like: https://app.totango.com/api/v1/accounts/active_list/10010/current.json</param>        
        /// <param name="outname">The name of the output file</param> 
        public void Start(string url, string outname)
        {
            List<string> lines = new List<string>();
            lines.Add(this._aliasHead);
            if (this._headers.Length > 0)
            {
                using (ToTangoReader tangoReader = new ToTangoReader(this._token, url))
                {
                    dynamic account = null;
                    do
                    {
                        account = tangoReader.ReadAccount();
                        if (account != null)
                        {
                            string line = "";
                            foreach (string attrib in this._headers.Split(','))
                            {
                                line += getAttrib(account, attrib) + ",";
                            }
                            lines.Add(line.TrimEnd(','));
                        }
                    }
                    while (account != null);
                }
            }
            File.WriteAllLines(outname, lines);
        }

        private string getAttrib(dynamic account, string attrib)
        {
            string ret = "";
            attrib = attrib.Trim();
            if (account.attributes[attrib] != null)
            {
                ret = account.attributes[attrib].value;
            }
            return ret;
        }
    }
}
