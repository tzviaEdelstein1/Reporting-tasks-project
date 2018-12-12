using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using _02_BLL;
namespace _03_UIL
{
    public static class WebApiConfig
    {
        public static object LogicEmail { get; private set; }

        public static void Register(HttpConfiguration config)
        {


            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            Task.Run(_02_BLL.LogicEmail.BeginTimer);
        }
    }
}
