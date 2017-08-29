using System.Web.Http;

namespace SwashbuckleSample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.MapRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            var tracing = config.EnableSystemDiagnosticsTracing();
            tracing.IsVerbose = true;
            tracing.MinimumLevel = System.Web.Http.Tracing.TraceLevel.Debug;
        }

        private static void MapRoutes(this HttpConfiguration config)
        {
            Swashbuckle.Sample.Controllers.WebApiConfig.Register(config);
        }
    }
}