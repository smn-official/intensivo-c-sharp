using CursoRepositorio;
using CursoRepositorio.Models;
using System;
using System.Web.Http;

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

        public IHttpActionResult Post(Conta conta)
        {
            try
            {
                _contaRepositorio.Inserir(conta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir categoria: " + ex.Message);
            }
        }

        public IHttpActionResult Put(Conta conta)
        {
            try
            {
                _contaRepositorio.Atualizar(conta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar a conta: " + ex.Message);
            }
        }

    }
}
