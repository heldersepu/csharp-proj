using System;
using System.IO;
using System.Net;
using System.Web;
using System.Text;
using System.Collections.Generic;

namespace BCReader
{
    class SMS
    {
        private string user;
        private string pass;
        private string url;
        
        public SMS(string _user, string _pass, string _url)
        {
            user = _user;
            pass = _pass;
            url = _url;
        }

        internal string send(string Phone, string Message)
        {
            // THIS PROCESS MUST NOT CRASH 
            // it might enter an infinife loop
            try
            {
                string strData = SMSGlobalData(Phone, Phone, Message);
                return SendSms(url, strData);
            }
            catch (Exception e)
            {
                return "error:" + e.Message;
            }
        }

        private string SMSGlobalData(string sPhone, string dPhone, string Message)
        {
            System.Text.StringBuilder postData = new System.Text.StringBuilder("action=sendsms");
            postData.Append("&user=");
            postData.Append(HttpUtility.UrlEncode(user));
            postData.Append("&password=");
            postData.Append(HttpUtility.UrlEncode(pass));
            postData.Append("&from=");
            postData.Append(HttpUtility.UrlEncode(sPhone));
            postData.Append("&to=");
            postData.Append(HttpUtility.UrlEncode(dPhone));
            postData.Append("&text=");
            postData.Append(HttpUtility.UrlEncode(Message));
            return postData.ToString();
        }

        private string SendSms(string smsUrl, string postData)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] data = encoding.GetBytes(postData);

            WebRequest smsRequest = WebRequest.Create(smsUrl);
            smsRequest.Method = "POST";
            smsRequest.ContentType = "application/x-www-form-urlencoded";
            smsRequest.ContentLength = data.Length;

            Stream smsDataStream = null;
            smsDataStream = smsRequest.GetRequestStream();
            smsDataStream.Write(data, 0, data.Length);
            smsDataStream.Close();

            WebResponse smsResponse = smsRequest.GetResponse();

            byte[] responseBuffer = new byte[smsResponse.ContentLength];
            int count = int.MaxValue;
            try
            {
                count = (int)smsResponse.ContentLength - 1;
            }
            catch { }
            smsResponse.GetResponseStream().Read(responseBuffer, 0, count);
            smsResponse.Close();

            return encoding.GetString(responseBuffer);
        }
    }
}
