using System;
using System.Web.Http;
using CursoRepositorio;
using CursoRepositorio.Models;

namespace CursoAPI.Controllers
{
    public class CategoriaController : ApiController
    {
        private readonly CategoriaRepositorio _categoriaRepositorio;

        public CategoriaController()
        {
            _categoriaRepositorio = new CategoriaRepositorio();
        }

        // Buscando todas as categorias 
        // Exemplo "http://localhost:10421/api/Categoria"
        public IHttpActionResult Get()
        {
            try
            {
                var categorias = _categoriaRepositorio.Buscar();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar categorias: " + ex.Message);
            }
        }

        // Buscando uma categoria específica
        // Exemplo "http://localhost:10421/api/Categoria?id=2"
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_categoriaRepositorio.Buscar(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar a categoria: " + ex.Message);
            }
        }

        // Inserindo categoria
        // Deste modo deve se mandar o parâmetro no BODY, usar postman com verbo POST
        public IHttpActionResult Post(Categoria categoria)
        {
            try
            {
                _categoriaRepositorio.Inserir(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir categoria: " + ex.Message);
            }
        }

        // Atualizando categoria
        // Deste modo deve se mandar o parâmetro no BODY, usar postman com verbo PUT
        public IHttpActionResult Put(Categoria categoria)
        {
            try
            {
                _categoriaRepositorio.Atualizar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar a categoria: " + ex.Message);
            }
        }

        // Excluindo uma categoria
        // Exemplo "http://localhost:10421/api/Categoria?idCategoriaAntiga=2&idCategoriaNova=1", usar postman com verbo DELETE
        public IHttpActionResult Delete(int idCategoria)
        {
            try
            {
                _categoriaRepositorio.Excluir(idCategoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar a categoria: " + ex.Message);
            }
        }
    }
}
