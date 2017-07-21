using LancamentoRepositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancamentoRepositorio
{
    public class LancamentoRepository
    {
        private ConexaoBancoDados _conexao;

        public LancamentoRepository()
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
                        DataCadastro = leitor.GetDateTime(leitor.GetOrdinal("DataCadastro")),
                        IdLancamento = leitor.GetInt32(leitor.GetOrdinal("IdLancamento")),
                        DataEvento = leitor.GetDateTime(leitor.GetOrdinal("DataEvento")),
                        Valor = leitor.GetDecimal(leitor.GetOrdinal("Valor")),
                        Descricao = leitor.GetString(leitor.GetOrdinal("Descricao")),
                    });
                }
            }

            return listaLancamentos;
        }

        public void Post(Lancamento lancamento)
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

    }
}
