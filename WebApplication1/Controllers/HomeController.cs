using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        //O index é um método. Esse método pode, por exemplo, ser chamado pela URL do browser, adicionando /Home
        //na URL. A ação padrão é Index, por isso o app inicia na tela Index, como
        //especificado no App_Start/RouteConfig.cs. Ao adicionar /Home/About, o método About é
        //chamado, e ao adicionar /Home/Contact, o método Contact é adicionado

        public ActionResult Index()
        {
            return View();
            //Na pasta Views/Home, adicionei um arquivo cshtml do tipo MVC 5 View Page with (Layout Razor).
            //O nome do arquivo é Index.cshtml. O layout dessa página é especificado pelo layout padrão encontrado
            //na pasta Views/Shared, no arquivo _Layout.cshtml. Agora esse método aqui vai retornar um view template
        }

        public ActionResult About()
        {
            ViewBag.Message = "Descrição do aplicativo";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Patrick Dantas";

            return View();
        }


    }
}