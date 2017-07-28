using CursoRepositorio.Models;
using System.Collections.Generic;

namespace CursoRepositorio
{
    public class ContaRepositorio
    {
        private readonly ConexaoBancoDados _conexao;

        public ContaRepositorio()
        {
            _conexao = new ConexaoBancoDados();
        }

        public IEnumerable<Conta> Buscar()
        {
            _conexao.ExecutarProcedure("GKSSP_SelContas");

            var contas = new List<Conta>();
            using (var leitor = _conexao.ExecuteReader())
            {
                while (leitor.Read())
                {
                    contas.Add(new Conta
                    {
                        IdConta = leitor.GetInt32(leitor.GetOrdinal("IdConta")),
                        Nome = leitor.GetString(leitor.GetOrdinal("Nome")),
                        DataCadastro = leitor.GetDateTime(leitor.GetOrdinal("DataCadastro")),
                        Usuario = new Usuario { Email = leitor.GetString(leitor.GetOrdinal("Email")) }
                    });
                }
            }

            return contas;
        }

        public Conta Buscar(int id)
        {
            _conexao.ExecutarProcedure("GKSSP_SelConta");
            _conexao.AddParametro("@IdConta", id);

            using (var leitor = _conexao.ExecuteReader())
                if (leitor.Read())
                    return new Conta
                    {
                        IdConta = leitor.GetInt32(leitor.GetOrdinal("IdConta")),
                        Nome = leitor.GetString(leitor.GetOrdinal("Nome")),
                        DataCadastro = leitor.GetDateTime(leitor.GetOrdinal("DataCadastro")),
                        Usuario = new Usuario { Email = leitor.GetString(leitor.GetOrdinal("Usuario")) }
                    };

            return null;
        }

        public void Inserir(Conta conta)
        {
            _conexao.ExecutarProcedure("GKSSP_InsConta");
            _conexao.AddParametro("@Nome", conta.Nome);
            _conexao.AddParametro("@IdUsuario", conta.IdUsuario);

            _conexao.ExecutarSemRetorno();
        }

        public void Atualizar(Conta conta)
        {
            _conexao.ExecutarProcedure("GKSSP_UpdConta");
            _conexao.AddParametro("@IdConta", conta.IdConta);
            _conexao.AddParametro("@Nome", conta.Nome);

            _conexao.ExecutarSemRetorno();
        }

    }
}