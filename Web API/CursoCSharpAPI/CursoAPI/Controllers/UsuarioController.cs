using CursoRepositorio;
using CursoRepositorio.Models;
using System;
using System.Web.Http;

namespace CursoAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public UsuarioController()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        public IHttpActionResult Get()
        {
            try
            {
                var usuarios = _usuarioRepositorio.Buscar();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar os usuários: " + ex.Message);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_usuarioRepositorio.Buscar(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar o usuário: " + ex.Message);
            }
        }

        public IHttpActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepositorio.Inserir(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir usuário: " + ex.Message);
            }
        }

        public IHttpActionResult Put(Usuario usuario)
        {
            try
            {
                _usuarioRepositorio.Atualizar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar o usuário: " + ex.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                _usuarioRepositorio.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar o usuário: " + ex.Message);
            }
        }
    }
}
