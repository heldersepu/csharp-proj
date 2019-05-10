using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebApi_NetCore.Controllers;

namespace WebApi_NetCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Service", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.DocumentFilter<MyDocFilter>();
                c.DocumentFilter<InjectSamples>();


                var filePath = Path.Combine(System.AppContext.BaseDirectory, "doc.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            app.UseSwagger(c => {
                //c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
            });
            app.UseSwaggerUI(c => {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
            });
        }

        public class MyDocFilter : IDocumentFilter
        {
            public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
            {
                var path = swaggerDoc.Paths.Where(x => x.Key.Contains("TestEmail")).First().Value;
                var p = path.Operations[0].Parameters.Where(x => x.Name == "templateName").First();
                //p.Enum = new List<object>();
                //foreach (var item in TestEmailController.AllNotificationTypes.Select(x => x.Name))
                //{
                //    p.Enum.Add(item);
                //}
            }

            public void Apply()
            {
                throw new System.NotImplementedException();
            }
        }

        public class InjectSamples : IDocumentFilter
        {
            public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
            {
                var path = swaggerDoc.Paths.Where(x => x.Key.Contains("Values")).First().Value;
                var param = path.Operations.Where(x => x.Key.Equals("Post")).First().Value;
                //param.Extensions.Add("x-code-samples", new OpenApiExtension { "123456" });
            }
        }
    }
}
