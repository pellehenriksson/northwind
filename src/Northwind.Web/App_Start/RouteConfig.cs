using System.Web.Mvc;
using System.Web.Routing;

namespace Northwind.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "Employees",
                 url: "Employees/Page/{page}",
                 defaults: new { controller = "Employees", action = "Index", page = 1 },
                 constraints: new { page = @"\d+" });

            routes.MapRoute(
                name: "Orders",
                url: "Orders/Page/{page}",
                defaults: new { controller = "Orders", action = "Index", page = 1 },
                constraints: new { page = @"\d+" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
