using System.Web.Mvc;
using System.Web.Routing;

namespace CROM.GC.web.application
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AccesoCuenta",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AccesoCuenta", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "CROM.Controllers.AccesoCuenta" }
            );

            routes.MapRoute(
                name: "Comercial",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Comercial", action = "TipoCambio", id = UrlParameter.Optional },
                namespaces: new[] { "CROM.Controllers.Comercial" }
            );


        }


    }
}