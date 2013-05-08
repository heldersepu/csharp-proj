using System;
using System.IO;
using System.Web;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace BCReader
{
    class twitter
    {
        private string _twitterJsonUrl = "https://api.twitter.com/1.1/statuses/update.json";     
        private string _twitterUser = string.Empty;
        private string _twitterPass = string.Empty;
        
        public twitter(string userName, string userPassword)
        {
            _twitterUser = userName;
            _twitterPass = userPassword;
        }

        public string SendTwitterMessage(string message)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(_twitterJsonUrl);
                System.Net.ServicePointManager.Expect100Continue = false;
             
                string post = string.Empty;
                using (TextWriter writer = new StringWriter())
                {
                    writer.Write("status={0}", HttpUtility.UrlEncode(message));
                    post = writer.ToString();
                }
             
                SetRequestParams(request);
                request.Credentials = new NetworkCredential(_twitterUser, _twitterPass);
             
                using (Stream requestStream = request.GetRequestStream())
                {
                    using (StreamWriter writer = new StreamWriter(requestStream))
                    {
                        writer.Write(post);
                    }
                }
             
                WebResponse response = request.GetResponse();
                string content;
             
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        content = reader.ReadToEnd();
                    }
                }
                return content;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void SendTwitterMessage2(string message)
        {
            //GS - Get the oAuth params
            string status = HttpUtility.UrlEncode(message);
            string postBody = "status=" + Uri.EscapeDataString(status);

            string oauth_consumer_key = "hj2HOF2lls1X5REebRXbjQ";
            string consumerSecret = "BmgzVRz4AIGLF13INwPnoaUqueF32yc981GqX74Sf6U";

            string oauth_token = "1412861353-6eB0SExZws32l5NSUwx1qqYEnFNO4Z185fIt7XV";
            string oauth_token_secret = "JDRNR5Ipn2fgIbBgj5L1r7HTV70LPOCsXvVHpL1uSLM";

            string oauth_nonce = Convert.ToBase64String(
                new ASCIIEncoding().GetBytes(
                    DateTime.Now.Ticks.ToString()));

            string oauth_signature_method = "HMAC-SHA1";


            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            string oauth_timestamp = Convert.ToInt64(ts.TotalSeconds).ToString();

            string oauth_version = "1.0";

            //GS - When building the signature string the params
            //must be in alphabetical order. I can't be bothered
            //with that, get SortedDictionary to do it's thing
            SortedDictionary<string, string> sd =
                new SortedDictionary<string, string>();

            sd.Add("status", status);
            sd.Add("oauth_version", oauth_version);
            sd.Add("oauth_consumer_key", oauth_consumer_key);
            sd.Add("oauth_nonce", oauth_nonce);
            sd.Add("oauth_signature_method", oauth_signature_method);
            sd.Add("oauth_timestamp", oauth_timestamp);
            sd.Add("oauth_token", oauth_token);

            //GS - Build the signature string
            string baseString = String.Empty;
            baseString += "POST" + "&";
            baseString += Uri.EscapeDataString(_twitterJsonUrl) + "&";

            foreach (KeyValuePair<string, string> entry in sd)
            {
                baseString += Uri.EscapeDataString(entry.Key + "=" + entry.Value + "&");
            }

            //GS - Remove the trailing ambersand char, remember 
            //it's been urlEncoded so you have to remove the 
            //last 3 chars - %26
            baseString = baseString.Substring(0, baseString.Length - 3);

            //GS - Build the signing key
            string signingKey = Uri.EscapeDataString(consumerSecret) + "&" + Uri.EscapeDataString(oauth_token_secret);

            //GS - Sign the request
            HMACSHA1 hasher = new HMACSHA1(new ASCIIEncoding().GetBytes(signingKey));
            string signatureString = Convert.ToBase64String(hasher.ComputeHash(new ASCIIEncoding().GetBytes(baseString)));

            //GS - Instantiate a web request and populate the 
            //authorization header
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(_twitterJsonUrl);
            hwr.KeepAlive = false;

            string authorizationHeaderParams = String.Empty;
            authorizationHeaderParams += "OAuth ";
            authorizationHeaderParams += "oauth_nonce=" + "\"" + Uri.EscapeDataString(oauth_nonce) + "\",";
            authorizationHeaderParams += "oauth_signature_method=" + "\"" + Uri.EscapeDataString(oauth_signature_method) + "\",";
            authorizationHeaderParams += "oauth_timestamp=" + "\"" + Uri.EscapeDataString(oauth_timestamp) + "\",";
            authorizationHeaderParams += "oauth_consumer_key=" + "\"" + Uri.EscapeDataString(oauth_consumer_key) + "\",";
            authorizationHeaderParams += "oauth_token=" + "\"" + Uri.EscapeDataString(oauth_token) + "\",";
            authorizationHeaderParams += "oauth_signature=" + "\"" + Uri.EscapeDataString(signatureString) + "\",";
            authorizationHeaderParams += "oauth_version=" + "\"" + Uri.EscapeDataString(oauth_version) + "\"";
            hwr.Headers.Add("Authorization", authorizationHeaderParams);

            //GS - POST off the request
            hwr.Method = "POST";
            hwr.ContentType = "application/x-www-form-urlencoded";
            Stream stream = hwr.GetRequestStream();
            byte[] bodyBytes = new ASCIIEncoding().GetBytes(postBody);

            stream.Write(bodyBytes, 0, bodyBytes.Length);
            stream.Flush();
            stream.Close();
            hwr.Timeout = 3 * 60 * 1000;

            try
            {
                HttpWebResponse rsp = hwr.GetResponse() as HttpWebResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
        private void SetRequestParams(HttpWebRequest request)
        {
            request.Timeout = 500000;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Custom Twitter Application";
        }

    }


}
