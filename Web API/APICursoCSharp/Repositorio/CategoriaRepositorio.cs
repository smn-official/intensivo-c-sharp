using Repositorio.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System;

namespace Repositorio
{
    public class CategoriaRepositorio
    {
        private readonly DatabaseConnect _connect;
        public CategoriaRepositorio()
        {
            _connect = new DatabaseConnect();
        }

        public IEnumerable<Categoria> Get()
        {
            _connect.ExecutarProcedure("GKSSP_SelCategorias");
            
            var categorias = new List<Categoria>();
            using (var leitor = _connect.ExecuteReader())
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

        public Categoria Get(int id)
        {
            _connect.ExecutarProcedure("GKSSP_SelCategoria");   
            _connect.AddParametro("@IdCategoria", id);
            using (var leitor = _connect.ExecuteReader())
                if (leitor.Read())
                    return new Categoria
                    {
                        IdCategoria = leitor.GetInt32(leitor.GetOrdinal("IdCategoria")),
                        Nome = leitor.GetString(leitor.GetOrdinal("Nome"))
                    };

            return null;
        }

        public void Post(Categoria categoria)
        {
            _connect.ExecutarProcedure("GKSSP_InsCategoria");
            _connect.AddParametro("@Nome", categoria.Nome);
            _connect.ExecutarSemRetorno();
        }

        public void Put(Categoria categoria)
        {
            _connect.ExecutarProcedure("GKSSP_UpdCategoria");
            _connect.AddParametro("@IdCategoria", categoria.IdCategoria);
            _connect.AddParametro("@Nome", categoria.Nome);
            _connect.ExecutarSemRetorno();
        }

        public void Delete(int idCategoriaAntiga, int idCategoriaNova)
        {
            _connect.ExecutarProcedure("GKSSP_DelCategoria");
            _connect.AddParametro("@IdCategoriaAnt", idCategoriaNova);
            _connect.AddParametro("@IdCategoriaNova", idCategoriaNova);
            _connect.ExecutarSemRetorno();
        }
    }
}
