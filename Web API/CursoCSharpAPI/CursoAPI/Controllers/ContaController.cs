using System;
using System.Web.Http;
using CursoRepositorio;
using CursoRepositorio.Models;

namespace CursoAPI.Controllers
{
    public class ContaController : ApiController
    {
        private readonly ContaRepositorio _contaRepositorio;

        public ContaController()
        {
            _contaRepositorio = new ContaRepositorio();
        }

        public IHttpActionResult Get()
        {
            try
            {
                var contas = _contaRepositorio.Buscar();
                return Ok(contas);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar contas: " + ex.Message);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_contaRepositorio.Buscar(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar a conta: " + ex.Message);
            }
        }

        public IHttpActionResult Post(Conta categoria)
        {
            try
            {
                _contaRepositorio.Inserir(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir categoria: " + ex.Message);
            }
        }

        public IHttpActionResult Put(Conta categoria)
        {
            try
            {
                _contaRepositorio.Atualizar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar a conta: " + ex.Message);
            }
        }

    }
}
