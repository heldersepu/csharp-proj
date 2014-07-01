using System;
using System.Net;
using Newtonsoft.Json;


namespace absToTango
{
    class ToTangoReader
    {
        private string _token;
        private string _url;
        private Int64 _pos;
        private Int64 _length;
        private Int64 _offset;
        private Int64 _total_items;
        private Int64 _item_count;
        private dynamic _dJSON;

        public ToTangoReader(string token, string url, int length)
        {
            this._token = token;
            this._url = url;
            this._pos = 0;
            this._length = length;
            this._offset = 0;
            this._item_count = 0;
            this.initJSON();
        }

        private void initJSON()
        {
            string url = this._url + "length=" + this._length + "&offset=" + this._offset;
            string json = "";
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Authorization", this._token);
                json = client.DownloadString(url);
            }
            this._dJSON = JsonConvert.DeserializeObject(json);
            this._item_count = (int)this._dJSON.current_item_count;
            this._total_items = (int)this._dJSON.total_items;

        }

        public dynamic ReadAccount()
        {
            dynamic dAccount = null;
            try
            {
                dAccount = this._dJSON.accounts[this._pos++];
            }
            catch (Exception e) 
            {
                dAccount = null;
            }
            return dAccount;
        }
    }
}
