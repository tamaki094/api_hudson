using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CRUD_HUDSON
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();
            var cors = new EnableCorsAttribute("http://127.0.0.1:5500,https://127.0.0.1:5500", "*", "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
