using System;
using System.Web.Http;
using CursoRepositorio;
using CursoRepositorio.Models;

namespace CursoAPI.Controllers
{
    public class LancamentoController : ApiController
    {
        private readonly LancamentoRepositorio _lancamentoRepositorio;

        public LancamentoController()
        {
            _lancamentoRepositorio = new LancamentoRepositorio();
        }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_lancamentoRepositorio.Buscar());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar lançamentos: " + ex.Message);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_lancamentoRepositorio.Buscar(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar lançamento: " + ex.Message);
            }
        }

        public IHttpActionResult Post(Lancamento lancamento)
        {
            try
            {
                _lancamentoRepositorio.Inserir(lancamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir lançamento: " + ex.Message);
            }
        }

        public IHttpActionResult Put(Lancamento lancamento)
        {
            try
            {
                _lancamentoRepositorio.Atualizar(lancamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar lançamento: " + ex.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                _lancamentoRepositorio.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao excluir lançamento: " + ex.Message);
            }
        }

    }
}