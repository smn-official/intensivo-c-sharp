using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class CategoriaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuscarGrid()
        {
            return PartialView("_Grid");
        }

        public ActionResult Cadastro()
        {
            return View("_Dados");
        }
    }
}
