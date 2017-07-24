using System;
using System.Web.Http;
using CursoRepositorio;
using CursoRepositorio.Models;

namespace CursoAPI.Controllers
{
    public class AcaoController : ApiController
    {
        private readonly AcaoRepositorio _acaoRepositorio;

        public AcaoController()
        {
            _acaoRepositorio = new AcaoRepositorio();
        }

        public IHttpActionResult Get()
        {
            try
            {
                var acoes = _acaoRepositorio.Buscar();
                return Ok(acoes);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar ações: " + ex.Message);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_acaoRepositorio.Buscar(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar a ação: " + ex.Message);
            }
        }

        public IHttpActionResult Post(Acao categoria)
        {
            try
            {
                _acaoRepositorio.Inserir(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir ação: " + ex.Message);
            }
        }

        public IHttpActionResult Put(Acao categoria)
        {
            try
            {
                _acaoRepositorio.Atualizar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar a ação: " + ex.Message);
            }
        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _acaoRepositorio.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao excluir a ação: " + ex.Message);
            }
        }

    }
}
