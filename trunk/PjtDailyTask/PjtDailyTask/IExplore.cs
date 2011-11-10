using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SHDocVw;
using mshtml;
using Microsoft.VisualBasic;

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
            if (!File.Exists(strLoginHtml)) 
            {
                this.createLogin(strLoginHtml);
            }
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

        public void createLogin(string strLoginHtml)
        {
            string UserName = Interaction.InputBox("Please enter your ACE username", "UserName", "", 10, 20);
            string PassWord = Interaction.InputBox("Please enter your ACE password", "PassWord", "", 10, 20);

            TextWriter HtmlFile = new StreamWriter(strLoginHtml, true);
            HtmlFile.WriteLine("<html> ");
            HtmlFile.WriteLine("<head> ");
            HtmlFile.WriteLine("<title>Login Page</title> ");
            HtmlFile.WriteLine("</head> ");
            HtmlFile.WriteLine("<body OnLoad=\"document.login.submit()\"> ");
            HtmlFile.WriteLine("<table border=\"0\" width=\"100%\" height=\"100%\"> ");
            HtmlFile.WriteLine("<tr> ");
            HtmlFile.WriteLine("  <td valign=\"center\" align=\"middle\"> ");
            HtmlFile.WriteLine("	<div class=\"loginbox\"> ");
            HtmlFile.WriteLine("	  <form action=\"http://qqprojects.com/server01/Login.asp\" method=\"post\" name=\"login\" target=\"_top\"> ");
            HtmlFile.WriteLine("		<table border=\"0\" width=\"240\" > ");
            HtmlFile.WriteLine("		  <tr> ");
            HtmlFile.WriteLine("			<td class=\"login_form_txt\" nowrap>Company</td> ");
            HtmlFile.WriteLine("			<td class=\"login_form_td\"> ");
            HtmlFile.WriteLine("			  <input type=\"hidden\" name=\"ret_page\" value=\"\"> <input type=\"hidden\" name=\"querystring\" value=\"\"> ");
            HtmlFile.WriteLine("			  <input type=\"hidden\" name=\"FormName\" value=\"LoginForm\"> <input type=\"text\" name=\"Company\" value=\"QuickQuote\" maxlength=\"50\" size=\"20\"></td> ");
            HtmlFile.WriteLine("		  </tr> ");
            HtmlFile.WriteLine("		  <tr> ");
            HtmlFile.WriteLine("			<td class=\"login_form_txt\">Username</td> ");
            HtmlFile.WriteLine("			<td class=\"login_form_td\"> ");
            HtmlFile.WriteLine("			  <input type=\"text\" name=\"Login\" value=\"" + UserName + "\" maxlength=\"50\" size=\"20\"></td> ");
            HtmlFile.WriteLine("		  </tr> ");
            HtmlFile.WriteLine("		  <tr> ");
            HtmlFile.WriteLine("			<td class=\"login_form_txt\" >Password</td> ");
            HtmlFile.WriteLine("			<td class=\"login_form_td\"> ");
            HtmlFile.WriteLine("			  <input type=\"password\" name=\"Password\" maxlength=\"50\" size=\"20\" value=\"" + PassWord + "\"></td> ");
            HtmlFile.WriteLine("		  </tr> ");
            HtmlFile.WriteLine("		  <tr> ");
            HtmlFile.WriteLine("			<td class=\"login_form_td\" colspan=\"2\" align=\"middle\"> ");
            HtmlFile.WriteLine("			  <input type=\"hidden\" name=\"FormAction\" value=\"login\"> <input type=\"hidden\" name=\"TASK_ID\" value=\"\"> ");
            HtmlFile.WriteLine("			  <input type=\"hidden\" name=\"GANTT\" value=\"\"> ");
            HtmlFile.WriteLine("			  <input type=\"hidden\" name=\"PROJECT_ID\" value=\"\">  ");
            HtmlFile.WriteLine("			  <input class=\"login_submit\" id=\"loginBtn\" name=\"loginBtn\" type=\"submit\" value=\"Connect\" > ");
            HtmlFile.WriteLine("		    </td> ");
            HtmlFile.WriteLine("		  </tr> ");
            HtmlFile.WriteLine("		</table> ");
            HtmlFile.WriteLine("	  </form> ");
            HtmlFile.WriteLine("	</div> ");
            HtmlFile.WriteLine("  </td> ");
            HtmlFile.WriteLine("</tr> ");
            HtmlFile.WriteLine("</table> ");
            HtmlFile.WriteLine("</body> ");
            HtmlFile.WriteLine("</html> ");
            HtmlFile.Close();
        }
    }
}
