using FortunaUnofficalAPI.Data;
using FortunaUnofficalAPI.Models.General;
using FortunaUnofficialAPI.Models.Containers;
using FortunaUnofficialAPI.Models.General;
using FortunaUnofficialAPI.Models.SAF;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace FortunaUnofficialAPI
{
    public static class WebApiConfig
    {
        public static object SpeciesAttribute { get; private set; }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            Debug.WriteLine("Database build start");
            DatabaseBuilder.BuildSpeciesDatabase();
            Debug.WriteLine("Database build end");

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
