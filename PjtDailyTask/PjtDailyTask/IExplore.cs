using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SHDocVw;
using mshtml;

namespace PjtDailyTask
{
    public class IExplore
    {
        private object empty = 0;
        private InternetExplorer IE = new InternetExplorer();
        public HTMLDocumentClass htmlDoc
        {
            get { return (HTMLDocumentClass)IE.Document; }
        }

        public IExplore()
        {
            string strpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string strLoginHtml = strpath + @"\Login.html";

            strLoginHtml = strLoginHtml.Replace(@"\", @"/");
            strLoginHtml = strLoginHtml.Replace(":", "$");
            strLoginHtml = "file://127.0.0.1/" + strLoginHtml;
            this.openWebPage(strLoginHtml);
        }

        public void show()
        {
            IE.Visible = true;
        }

        public void hide()
        {
            IE.Visible = false;
        }

        public void WaitUntilReady()
        {
            do 
            {
                System.Threading.Thread.Sleep(500); 
            } 
            while (IE.Busy);
        }


        public void openWebPage(string webpage)
        {
            object url = webpage;
            IE.Navigate2(ref url, ref empty, ref empty, ref empty, ref empty);
            this.WaitUntilReady();
        }        

        public void CloseWebPage()
        {
            IE.Quit();
        }

        public void ClickElement(string strAttrib, string strID, string strValue)
        {
            IHTMLElementCollection Tags = this.htmlDoc.getElementsByTagName("input");
            foreach (IHTMLElement cTag in Tags)
            {
                object objAtrib = cTag.getAttribute(strAttrib, 0);
                if (objAtrib != null)
                {
                    if (objAtrib.Equals(strID))
                    {
                        if (cTag.outerHTML.IndexOf(strValue) > 0)
                        {
                            cTag.click();
                            this.WaitUntilReady();
                            break;
                        }
                    }
                }
            }
        }

        public string GetUserID(string strUserName)
        {
            IHTMLElementCollection Tags = this.htmlDoc.getElementsByTagName("tr");
            string strUserId = "";
            foreach (IHTMLElement cTag in Tags)
            {
                if (cTag.innerHTML.Substring(0, 7).ToUpper().Equals("<TD ID="))
                {
                    if (cTag.innerText.IndexOf(strUserName) >= 0)
                    {
                        int pos = cTag.innerHTML.IndexOf("incrementAssignation(this,");
                        if (pos > 0)
                        {
                            strUserId = cTag.innerHTML.Substring(pos + 27, 3);
                            strUserId = strUserId.Replace("'", "");
                            break;
                        }
                    }
                }
            }
            return strUserId;
        }

        public void FillTask(string resume, string description)
        {
            var TaskNo = this.htmlDoc.getElementById("TASK_NUMBER").getAttribute("Value", 0);
            int ConvertIntTaskno = int.Parse(string.Format("{0}", TaskNo)) + 50;
            this.htmlDoc.getElementById("TASK_NUMBER").innerText = ConvertIntTaskno.ToString();
            this.htmlDoc.getElementById("TASK_RESUME").innerText = resume;
            this.htmlDoc.getElementById("TASK_DESC_CREATOR").innerText = description;
            this.htmlDoc.getElementById("TASK_DESC_CREATOR").style.display = "block";
            this.htmlDoc.getElementById("TASK_DESC_CREATOR___Frame").outerHTML = "";
        }

    }
}
