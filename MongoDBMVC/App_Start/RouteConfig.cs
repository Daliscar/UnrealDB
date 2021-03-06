using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UnrealDB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "UnrealDB.Controllers" } //FIX FOR MULTIPLE NAMESPACES https://stackoverflow.com/questions/5092589/having-issue-with-multiple-controllers-of-the-same-name-in-my-project "namespaces: new[] { "YourCompany.Controllers" }"
            );
        }
    }
}
