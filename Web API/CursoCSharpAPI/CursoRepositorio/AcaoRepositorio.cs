using System.Collections.Generic;
using CursoRepositorio.Models;

namespace CursoRepositorio
{
    public class AcaoRepositorio
    {
        private readonly ConexaoBancoDados _conexao;

        public AcaoRepositorio()
        {
            _conexao = new ConexaoBancoDados();
        }

        public IEnumerable<Acao> Buscar()
        {
            _conexao.ExecutarProcedure("GKSSP_SelAcoes");

            var acoes = new List<Acao>();
            using (var leitor = _conexao.ExecuteReader())
            {
                while (leitor.Read())
                {
                    acoes.Add(new Acao
                    {
                        IdAcao = leitor.GetInt32(leitor.GetOrdinal("IdAcao")),
                        Nome = leitor.GetString(leitor.GetOrdinal("Nome"))
                    });
                }
            }

            return acoes;
        }

        public Acao Buscar(int id)
        {
            _conexao.ExecutarProcedure("GKSSP_SelAcao");
            _conexao.AddParametro("@IdAcao", id);

            using (var leitor = _conexao.ExecuteReader())
                if (leitor.Read())
                    return new Acao
                    {
                        IdAcao = leitor.GetInt32(leitor.GetOrdinal("IdAcao")),
                        Nome = leitor.GetString(leitor.GetOrdinal("Nome"))
                    };

            return null;
        }

        public void Inserir(Acao acao)
        {
            _conexao.ExecutarProcedure("GKSSP_InsAcao");
            _conexao.AddParametro("@Nome", acao.Nome);

            _conexao.ExecutarSemRetorno();
        }

        public void Atualizar(Acao acao)
        {
            _conexao.ExecutarProcedure("GKSSP_UpdAcao");
            _conexao.AddParametro("@IdAcao", acao.IdAcao);
            _conexao.AddParametro("@Nome", acao.Nome);

            _conexao.ExecutarSemRetorno();
        }

        public void Excluir(int id)
        {
            _conexao.ExecutarProcedure("GKSSP_DelAcao");
            _conexao.AddParametro("@IdAcao", id);

            _conexao.ExecutarSemRetorno();
        }
    }
}