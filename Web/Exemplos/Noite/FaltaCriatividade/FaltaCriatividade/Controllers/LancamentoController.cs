using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaltaCriatividade.Controllers
{
    public class LancamentoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuscarGrid()
        {
            return View("_Grid");
        }
    }
}