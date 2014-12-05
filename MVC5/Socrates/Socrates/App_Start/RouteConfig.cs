using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Socrates
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            MapRoute(routes);
            
        }

        public static void MapRoute(RouteCollection routes)
        {
            routes.MapRoute(
                name: "cat",
                url: "cat/{cat}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Categ", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "HEllo",
                url: "foo/{message}",
                defaults: new { controller = "Home", action = "Hello", message = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
