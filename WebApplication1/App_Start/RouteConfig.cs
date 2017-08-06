using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default", 
                url: "{controller}/{action}/{id}", //Esse é o formato para as rotas passadas por URL.
                                                   //Por isso se eu adicionar /Home/Contact no Url, executo 
                                                   //o método Contact da classe Home.
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );//A rota padrão é a Home/Index

            routes.MapRoute(
                name: "Primeiro",
                url: "{controller}/{action}/{name}/{id}"
            );
        }
    }
}
