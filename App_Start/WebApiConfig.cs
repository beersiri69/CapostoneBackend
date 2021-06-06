using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Backendtest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{Action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
           //var json = config.Formatters.JsonFormatter;
          // json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
           //config.Formatters.Remove(config.Formatters.XmlFormatter);

        }
    }
}
