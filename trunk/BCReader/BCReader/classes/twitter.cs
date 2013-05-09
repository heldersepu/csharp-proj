using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using Twitterizer;


namespace BCReader
{
    class twitter 
    {
        private OAuthTokens tokens;
        private Boolean doTweet = false;

        public twitter(string strDirPath)
        {
            string strFile = strDirPath + "\\twitter.xml";
            if (File.Exists(strFile))
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(strFile);
                    tokens = new OAuthTokens()
                    {
                        ConsumerKey = doc.SelectSingleNode("/twitter/ConsumerKey").InnerText,
                        ConsumerSecret = doc.SelectSingleNode("/twitter/ConsumerSecret").InnerText,
                        AccessToken = doc.SelectSingleNode("/twitter/AccessToken").InnerText,
                        AccessTokenSecret = doc.SelectSingleNode("/twitter/AccessTokenSecret").InnerText
                    };
                    doTweet = true;
                }
                catch
                { }
            }
        }

        public void SendUpdate(string store_name, order dOrder, string message)
        {
            try
            {
                if (doTweet)
                {
                    string tweet = store_name;
                    tweet += ":" + dOrder.id.ToString();
                    tweet += "; i:" + dOrder.items.ToString();
                    tweet += "; t:" + dOrder.total.ToString();
                    message = message.Replace("Sent queued message ID", "SentID");
                    tweet += message.Replace("SMSGlobal","");
                    TwitterStatus.Update(tokens, tweet);
                }
            }
            catch
            { }
        }
    }
}
