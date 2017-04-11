using System;
using System.Configuration;
using System.Web.Http;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.Client;
using Microsoft.VisualStudio.Services.Common;

namespace TFS_WebApi.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected string collectionUri
        {
            get
            {
                return ConfigurationManager.AppSettings["url"];
            }
        }

        protected string accessToken
        {
            get
            {
                return ConfigurationManager.AppSettings["token"];
            }
        }

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