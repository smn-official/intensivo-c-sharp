using CursoRepositorio.Models;
using System.Collections.Generic;

namespace CursoRepositorio
{
    public class LancamentoRepositorio
    {
        private readonly ConexaoBancoDados _conexao;

        public LancamentoRepositorio()
        {
            _conexao = new ConexaoBancoDados();
        }

        public List<Lancamento> Buscar()
        {
            var listaLancamentos = new List<Lancamento>();

            _conexao.ExecutarProcedure("GKSSP_SelLancamentos");

            using (var leitor = _conexao.ExecuteReader())
            {
                while (leitor.Read())
                {
                    listaLancamentos.Add(new Lancamento
                    {
                        IdLancamento = leitor.GetInt32(leitor.GetOrdinal("IdLancamento")),
                        DataCadastro = leitor.GetDateTime(leitor.GetOrdinal("DataCadastro")),
                        Valor = leitor.GetDecimal(leitor.GetOrdinal("Valor")),
                        Descricao = leitor.GetString(leitor.GetOrdinal("Descricao")),
                        DataEvento = leitor.GetDateTime(leitor.GetOrdinal("DataEvento")),
                        Categoria = new Categoria { Nome = leitor.GetString(leitor.GetOrdinal("Categoria")) },
                        Conta = new Conta { Nome = leitor.GetString(leitor.GetOrdinal("Conta")) },
                        Usuario = new Usuario { Email = leitor.GetString(leitor.GetOrdinal("Usuario")) },
                        Acao = new Acao { Nome = leitor.GetString(leitor.GetOrdinal("Acao")) }
                    });
                }
            }

            return listaLancamentos;
        }

        public Lancamento Buscar(int id)
        {
            _conexao.ExecutarProcedure("GKSSP_SelLancamento");
            _conexao.AddParametro("@IdLancamento", id);

            using (var leitor = _conexao.ExecuteReader())
            {
                if (leitor.Read())
                {
                    return new Lancamento
                    {
                        IdLancamento = leitor.GetInt32(leitor.GetOrdinal("IdLancamento")),
                        DataCadastro = leitor.GetDateTime(leitor.GetOrdinal("DataCadastro")),
                        Valor = leitor.GetDecimal(leitor.GetOrdinal("Valor")),
                        Descricao = leitor.GetString(leitor.GetOrdinal("Descricao")),
                        DataEvento = leitor.GetDateTime(leitor.GetOrdinal("DataEvento")),
                        Categoria = new Categoria { Nome = leitor.GetString(leitor.GetOrdinal("Categoria")) },
                        Conta = new Conta { Nome = leitor.GetString(leitor.GetOrdinal("Conta")) },
                        Usuario = new Usuario { Email = leitor.GetString(leitor.GetOrdinal("Usuario")) },
                        Acao = new Acao { Nome = leitor.GetString(leitor.GetOrdinal("Acao")) }
                    };
                }
            }

            return null;
        }

        public void Inserir(Lancamento lancamento)
        {
            _conexao.ExecutarProcedure("GKSSP_InsLancamento");

            _conexao.AddParametro("@DataEvento", lancamento.DataEvento);
            _conexao.AddParametro("@Descricao", lancamento.Descricao);
            _conexao.AddParametro("@IdCategoria", lancamento.IdCategoria);
            _conexao.AddParametro("@IdAcao", lancamento.IdAcao);
            _conexao.AddParametro("@IdConta", lancamento.IdConta);
            _conexao.AddParametro("@Valor", lancamento.Valor);

            _conexao.ExecutarSemRetorno();
        }

        public void Atualizar(Lancamento lancamento)
        {
            _conexao.ExecutarProcedure("GKSSP_UpdLancamento");

            _conexao.AddParametro("@IdLancamento", lancamento.IdLancamento);
            _conexao.AddParametro("@DataEvento", lancamento.DataEvento);
            _conexao.AddParametro("@Descricao", lancamento.Descricao);
            _conexao.AddParametro("@IdCategoria", lancamento.IdCategoria);
            _conexao.AddParametro("@IdAcao", lancamento.IdAcao);
            _conexao.AddParametro("@IdConta", lancamento.IdConta);
            _conexao.AddParametro("@Valor", lancamento.Valor);

            _conexao.ExecutarSemRetorno();
        }

        public void Excluir(int id)
        {
            _conexao.ExecutarProcedure("GKSSP_InsLancamento");
            _conexao.AddParametro("@IdLancamento", id);

            _conexao.ExecutarSemRetorno();
        }
    }
}