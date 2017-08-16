using System.Web.Http;
using WebActivatorEx;
using WebApi560;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApi560
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
            .EnableSwagger(c =>
                {
                    c.ApiKey("Token")
                     .Description("Filling bearer token here")
                     .Name("Authorization")
                     .In("header");

                    c.SingleApiVersion("v2", "AppNameSpace");

                    //c.IncludeXmlComments(GetXmlCommentsPath());
                })
            .EnableSwaggerUi(c =>
                {
                    c.EnableApiKeySupport("Authorization", "header");
                });
        }

        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\AppNameSpace.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }

}
