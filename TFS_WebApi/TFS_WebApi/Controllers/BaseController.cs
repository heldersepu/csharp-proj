using System;
using System.Configuration;
using System.Web.Http;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.Common;

namespace TFS_WebApi.Controllers
{
    public abstract class BaseController : ApiController
    {
        #region private Properties
        private string collectionUri
        {
            get
            {
                return ConfigurationManager.AppSettings["url"];
            }
        }

        private string accessToken
        {
            get
            {
                return ConfigurationManager.AppSettings["token"];
            }
        }
        #endregion

        protected string teamProjectName
        {
            get
            {
                return "Global";
            }
        }

        protected VssConnection vssConn
        {
            get
            {
                //return new VssConnection(new Uri(collectionUri), new VssCredentials());
                //return new VssConnection(new Uri(collectionUri), new VssOAuthCredential(accessToken));
                return new VssConnection(new Uri(collectionUri), new VssBasicCredential(string.Empty, accessToken));
            }
        }

        protected WorkItemTrackingHttpClient witClient
        {
            get
            {
                return vssConn.GetClient<WorkItemTrackingHttpClient>();
            }
        }
    }
}