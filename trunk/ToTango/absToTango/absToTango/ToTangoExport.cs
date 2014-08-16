using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace absToTango
{
    /// <summary>
    /// Provides an easy way to export ToTango filters 
    /// </summary>
    class ToTangoExport
    {
        private string _token;
        /// <summary>
        /// Initializes a new instance of the ToTangoExport class.
        /// </summary>
        /// <param name="token">Your ToTango API authentication key.</param>
        
        public ToTangoExport(string token)
        {
            this._token = token;
        }

        /// <summary>
        /// Start the export on the given url
        /// </summary>
        /// <param name="url">The Url to the API, something like: https://app.totango.com/api/v1/accounts/active_list/10010/current.json</param>        
        public void Start(string url)
        {
            dynamic account = null;
            using (ToTangoReader tangoReader = new ToTangoReader(this._token, url))
            {
                do
                {
                    account = tangoReader.ReadAccount();
                    if (account != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(account.totango_id);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" " + getAttrib(account, "MemberFullName"));
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" " + getAttrib(account, "MemberPhone"));
                    }
                    else if (tangoReader.Error)
                    {
                        Console.WriteLine(tangoReader.ErrorMessage);
                    }
                }
                while (account != null);
            }
        }

        private string getAttrib(dynamic account, string attrib)
        {
            string ret = "";
            if (account.attributes[attrib] != null)
            {
                ret = account.attributes[attrib].value;
            }
            return ret;
        }
    }
}
