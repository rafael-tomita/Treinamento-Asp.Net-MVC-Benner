using System.Web.Mvc;
using System.Web.Routing;

namespace TreinamentoBenner
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Historico",
                url: "Arquivo/{data}",
                defaults: new { controller = "Historico", action = "Arquivo" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

