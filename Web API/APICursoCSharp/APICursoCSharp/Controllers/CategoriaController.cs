using System.Web.Http;
using Repositorio;
using Repositorio.Models;

namespace APICursoCSharp.Controllers
{
    public class CategoriaController : ApiController
    {
        private readonly CategoriaRepositorio _repositorio;

        public CategoriaController()
        {
            _repositorio = new CategoriaRepositorio();
        }

        // Buscando todas as categorias 
        // Exemplo "http://localhost:10421/api/Categoria"
        public IHttpActionResult Get()
        {
            var categorias = _repositorio.Get();
            return Ok(categorias);
        }

        // Buscando uma categoria específica
        // Exemplo "http://localhost:10421/api/Categoria?id=2"
        public IHttpActionResult Get(int id)
        {
            return Ok(_repositorio.Get(id));
        }

        // Inserindo categoria
        // Deste modo deve se mandar o parâmetro no BODY, usar postman com verbo POST
        public IHttpActionResult Post(Categoria categoria)
        {
            _repositorio.Post(categoria);
            return Ok();
        }

        // Atualizando categoria
        // Deste modo deve se mandar o parâmetro no BODY, usar postman com verbo PUT
        public IHttpActionResult Put(Categoria categoria)
        {
            _repositorio.Put(categoria);
            return Ok();
        }

        // Excluindo uma categoria
        // Exemplo "http://localhost:10421/api/Categoria?idCategoriaAntiga=2&idCategoriaNova=1", usar postman com verbo DELETE
        public IHttpActionResult Delete(int idCategoriaAntiga, int idCategoriaNova)
        {
            _repositorio.Delete(idCategoriaAntiga, idCategoriaNova);
            return Ok();
        }
    }
}