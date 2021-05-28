using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tarea2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //Datos que se mostraran en vista About
            ViewBag.Message = "Tarea 2 Programacion N-Capas";
            ViewBag.Nombre = "Oscar Alejandro Estrada Corena";
            ViewBag.Carnet = "00064318";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}