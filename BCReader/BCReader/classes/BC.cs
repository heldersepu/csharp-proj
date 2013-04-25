using System;
using System.Collections.Generic;
using System.Text;

namespace BCReader
{
    class BC
    {
        private string api;
        private string url;

        public BC(string _api, string _url)
        {
            api = _api;
            url = _url;
        }

        public Boolean newOrder
        { 
            get
            {
                return true; 
            }
        }

    }
}
