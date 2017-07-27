using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Infra;
using Newtonsoft.Json;
using System.Collections;
using HelloWorld.ViewModels;

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
            try
            {
                var resposta = Requisicao.Get("http://localhost:5000/api/Categoria");
                if (!resposta.IsSuccessStatusCode)
                    return View("Error", "Erro ao buscar api");

                var categorias = JsonConvert
                    .DeserializeObject<IEnumerable<CategoriaViewModel>>(
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
                    var resposta = Requisicao
                        .Get("http://localhost:5000/api/Categoria?id=" + idCategoria);

                    if (!resposta.IsSuccessStatusCode)
                        return View("Error", "Erro ao buscar dados");

                    categoria = JsonConvert.DeserializeObject<CategoriaViewModel>(
                        resposta.Content.ReadAsStringAsync().Result);
                }
                return View("_Dados", categoria);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        public ActionResult Post(CategoriaViewModel categoria)
        {
            try
            {
                var resposta = Requisicao.Post("http://localhost:5000/api/Categoria", 
                    categoria);

                if (!resposta.IsSuccessStatusCode)
                    return View("Error", "Erro ao inserir categoria");

                Response.StatusCode = 200;
                Response.TrySkipIisCustomErrors = true;

                return Content("");
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        public ActionResult Put(CategoriaViewModel categoria)
        {
            try
            {
                var resposta = Requisicao.Put("http://localhost:5000/api/Categoria",
                    categoria);

                if (!resposta.IsSuccessStatusCode)
                    return View("Error", "Erro ao atualizar categoria");

                Response.StatusCode = 200;
                Response.TrySkipIisCustomErrors = true;

                return Content("");
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
    }
}
