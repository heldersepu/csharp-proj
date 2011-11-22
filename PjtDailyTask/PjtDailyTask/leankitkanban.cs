using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Cache;

namespace PjtDailyTask
{
    class leankitkanban
    {
        private const string HOSTNAME = "qqdataservices";
        private const string BOARD_ID = "18343150";
        private const string API_URL = "http://" + HOSTNAME + ".leankitkanban.com/Kanban/Api/";
        private const string USERNAME = "hsepulveda@qqsolutions.com";
        private const string PASSWORD = "062266";
        private const int TIMEOUT = 15000;     

        private string DoWebRequest(string address, string method)
        {
            return DoWebRequest(address, method, string.Empty);
        }

        private string DoWebRequest(string address, string method, string body)
        {
            var request = (HttpWebRequest)WebRequest.Create(address);
            request.Method = method;
            request.Credentials = new NetworkCredential(USERNAME, PASSWORD);
            request.PreAuthenticate = true;
            request.Timeout = TIMEOUT;
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);

            if (method == "POST")
            {
                if (!string.IsNullOrEmpty(body))
                {
                    var requestBody = Encoding.UTF8.GetBytes(body);
                    request.ContentLength = requestBody.Length;
                    request.ContentType = "application/json";
                    using (var requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(requestBody, 0, requestBody.Length);
                    }
                }
                else
                {
                    request.ContentLength = 0;
                }
            }            

            string output = string.Empty;
            try
            {
                using (var response = request.GetResponse())
                {
                    using (var stream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(1252)))
                    {
                        output = stream.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    using (var stream = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        output = stream.ReadToEnd();
                    }
                }
                else if (ex.Status == WebExceptionStatus.Timeout)
                {
                    output = "Request timeout is expired.";
                }
            }
            return output;
        }

        public void CreateNewTask(string title, string desc)
        {
            string body = "{" +
               "\"Title\": \"" + title + "\"," +
               "\"Description\": \"" + desc + "\"," +
               "\"TypeId\": 18352071," +
               "\"Priority\": 1," +
               "\"Size\": 0," +
               "\"IsBlocked\": false," +
               "\"BlockReason\": \"\"," +
               "\"DueDate\": \"\"," +
               "\"ExternalSystemName\": \"Tracking\"," +
               "\"ExternalSystemUrl\": \"\"," +
               "\"Tags\": \"\"," +
               "\"ClassOfServiceId\": 0," +
               "\"ExternalCardID\": \"\"," +
               "\"AssignedUserIds\": []}";
            DoWebRequest(API_URL + "/Board/" + BOARD_ID + "/AddCard/Lane/18356118/Position/0", "POST", body);
        }

        public string GetBoardIdentifiers()
        {
        
            return DoWebRequest(API_URL + "/Board/" + BOARD_ID + "/GetBoardIdentifiers", "GET");
        }
        
        public void test()
        {
            CreateNewTask("title","description");
            //Console.WriteLine(GetBoardIdentifiers());
        }
    }
}
