using System.Web.Http;
using WebActivatorEx;
using SwashbuckleSample;
using Swashbuckle.Application;
using System.IO;
using System;
using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Web.Http.Description;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SwashbuckleSample
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "SwashbuckleSample");

                        c.OAuth2("oauth2")
                            .Description("OAuth2 Implicit Grant")
                            .Flow("accessCode")
                            .AuthorizationUrl("http://www.facebook.com/dialog/oauth/?client_id=183620338840937&redirect_uri=http%3A%2F%2Fswashbuckletest.azurewebsites.net%2Fswagger")
                            .TokenUrl("https://graph.facebook.com/oauth/access_token?client_id=183620338840937&redirect_uri=http%3A%2F%2Fswashbuckletest.azurewebsites.net%2Fswagger&client_secret=de81460e907d213dcc4271aa7b1ae88a&grant_type=client_credentials");
                            //.Scopes(scopes =>
                            //{
                            //    scopes.Add("read", "Read access to protected resources");
                            //    scopes.Add("write", "Write access to protected resources");
                            //});

                        c.OperationFilter<AssignOAuth2SecurityRequirements>();
                        c.PrettyPrint();

                        foreach (var name in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "SwashbuckleSample*.XML", SearchOption.AllDirectories))
                        {
                            c.IncludeXmlComments(name);
                        }
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocExpansion(DocExpansion.List);

                        c.EnableOAuth2Support(
                            clientId: "183620338840937",
                            clientSecret: "de81460e907d213dcc4271aa7b1ae88a",
                            realm: "swaggertestapp",
                            appName: "swaggertestapp"
                        );
                    });
        }

        public class AssignOAuth2SecurityRequirements : IOperationFilter
        {
            public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
            {
                var actFilters = apiDescription.ActionDescriptor.GetFilterPipeline();
                if (actFilters.Select(f => f.Instance).OfType<AllowAnonymousAttribute>().Any())
                    return; // must be an anonymous method

                if (operation.security == null)
                    operation.security = new List<IDictionary<string, IEnumerable<string>>>();

                var oAuthRequirements = new Dictionary<string, IEnumerable<string>>
                {
                    {"oauth2", new List<string> {}}
                };
                operation.security.Add(oAuthRequirements);
            }
        }
    }
}
