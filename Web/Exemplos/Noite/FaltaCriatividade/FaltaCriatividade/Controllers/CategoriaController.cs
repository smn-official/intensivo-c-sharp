using FaltaCriatividade.Infra;
using FaltaCriatividade.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaltaCriatividade.Controllers
{
    public class CategoriaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuscarGrid()
        {
            try
            {
                var resposta = Requisicao.Get("http://localhost:5000/api/Categoria");
                if (!resposta.IsSuccessStatusCode)
                    return View("Error", "Erro ao buscar categorias");

                var categorias = JsonConvert.DeserializeObject<IEnumerable<CategoriaViewModel>>(
                    resposta.Content.ReadAsStringAsync().Result);

                return PartialView("_Grid", categorias);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        public ActionResult BuscarDados(int? idCategoria)
        {
            try
            {
                var categoria = new CategoriaViewModel();

                if (idCategoria.HasValue)
                {
                    var resposta = Requisicao.Get("http://localhost:5000/api/Categoria?id=" + idCategoria);
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
    }
}