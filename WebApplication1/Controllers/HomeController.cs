using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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