using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleforceValidator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
            var t = await GetSecurityToken(textBox_Key.Text, textBox_Secret.Text, textBox_User.Text, textBox_Passw.Text, textBox_Token.Text, textBox_Domain.Text);
            textBox_Resp.Visible = true;
            textBox_Resp.Text = t;
        }

        public static async Task<string> GetSecurityToken(string key, string secret, string user, string passw, string token, string domain)
        {
            string responseString = "";
            try
            {
                using (HttpClient authClient = new HttpClient())
                {
                    string loginPassword = passw + token;

                    HttpContent content = new FormUrlEncodedContent(new Dictionary<string, string>
                        {
                            { "grant_type", "password" },
                            { "client_id", key },
                            { "client_secret", secret },
                            { "username", user },
                            { "password", loginPassword }
                        }
                    );

                    HttpResponseMessage response = await authClient.PostAsync(domain + "/services/oauth2/token", content);
                    responseString = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return responseString;
        }
    }
}
