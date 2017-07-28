using System.Collections.Generic;
using CursoRepositorio.Models;

namespace CursoRepositorio
{
    public class CategoriaRepositorio
    {
        private readonly ConexaoBancoDados _conexao;
        public CategoriaRepositorio()
        {
            _conexao = new ConexaoBancoDados();
        }

        public IEnumerable<Categoria> Buscar()
        {
            _conexao.ExecutarProcedure("GKSSP_SelCategorias");

            var categorias = new List<Categoria>();
            using (var leitor = _conexao.ExecuteReader())
            {
                while (leitor.Read())
                {
                    categorias.Add(new Categoria
                    {
                        IdCategoria = leitor.GetInt32(leitor.GetOrdinal("IdCategoria")),
                        Nome = leitor.GetString(leitor.GetOrdinal("Nome"))
                    });
                }
            }

            return categorias;
        }

        public Categoria Buscar(int id)
        {
            _conexao.ExecutarProcedure("GKSSP_SelCategoria");
            _conexao.AddParametro("@IdCategoria", id);
            using (var leitor = _conexao.ExecuteReader())
                if (leitor.Read())
                    return new Categoria
                    {
                        IdCategoria = leitor.GetInt32(leitor.GetOrdinal("IdCategoria")),
                        Nome = leitor.GetString(leitor.GetOrdinal("Nome"))
                    };

            return null;
        }

        public void Inserir(Categoria categoria)
        {
            _conexao.ExecutarProcedure("GKSSP_InsCategoria");
            _conexao.AddParametro("@Nome", categoria.Nome);
            _conexao.ExecutarSemRetorno();
        }

        public void Atualizar(Categoria categoria)
        {
            _conexao.ExecutarProcedure("GKSSP_UpdCategoria");
            _conexao.AddParametro("@IdCategoria", categoria.IdCategoria);
            _conexao.AddParametro("@Nome", categoria.Nome);
            _conexao.ExecutarSemRetorno();
        }

        public void Excluir(int idCategoria)
        {
            _conexao.ExecutarProcedure("GKSSP_DelCategoria");
            _conexao.AddParametro("@IdCategoria", idCategoria);
            _conexao.ExecutarSemRetorno();
        }
    }
}