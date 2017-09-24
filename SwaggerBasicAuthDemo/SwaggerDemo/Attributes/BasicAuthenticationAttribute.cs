using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SwaggerDemo.Attributes
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ActionContext"></param>
        public override void OnAuthorization(HttpActionContext ActionContext)
        {

            // Validate if user exists
            if (ActionContext.Request.Headers.Authorization == null)
            {
                ActionContext.Response = ActionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                // Gets header parameters  
                string authenticationString = ActionContext.Request.Headers.Authorization.Parameter;
                string originalString = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationString));

                // Gets username and password  
                string username = originalString.Split(':')[0];
                string password = originalString.Split(':')[1];

                // Validate username and password  
                if (username.ToLower() == "demo" && password.ToLower() == "demo")
                {
                    // returns unauthorized error  
                    ActionContext.Response = ActionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }

            base.OnAuthorization(ActionContext);
        }
    }
}