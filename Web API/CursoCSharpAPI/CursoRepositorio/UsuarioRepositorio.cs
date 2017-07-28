using System.Collections.Generic;
using CursoRepositorio.Models;

namespace CursoRepositorio
{
    public class UsuarioRepositorio
    {
        private readonly ConexaoBancoDados _conexao;

        public UsuarioRepositorio()
        {
            _conexao = new ConexaoBancoDados();
        }

        public IEnumerable<Usuario> Buscar()
        {
            _conexao.ExecutarProcedure("GKSSP_SelUsuarios");

            var usuarios = new List<Usuario>();
            using (var leitor = _conexao.ExecuteReader())
            {
                while (leitor.Read())
                {
                    usuarios.Add(new Usuario
                    {
                        Email = leitor.GetString(leitor.GetOrdinal("Email")),
                        //FG_Ativo = leitor.GetByte(leitor.GetOrdinal("FG_Ativo"))
                    });
                }
            }

            return usuarios;
        }

        public Usuario Buscar(int id)
        {
            _conexao.ExecutarProcedure("GKSSP_SelUsuario");
            _conexao.AddParametro("@IdUsuario", id);

            using (var leitor = _conexao.ExecuteReader())
                if (leitor.Read())
                    return new Usuario
                    {
                        Email = leitor.GetString(leitor.GetOrdinal("Email")),
                        //FG_Ativo = leitor.GetByte(leitor.GetOrdinal("FG_Ativo"))
                    };

            return null;
        }

        public void Inserir(Usuario usuario)
        {
            _conexao.ExecutarProcedure("GKSSP_InsUsuario");
            _conexao.AddParametro("@Email", usuario.Email);
            _conexao.AddParametro("@Senha", usuario.Senha);

            _conexao.ExecutarSemRetorno();
        }

        public void Atualizar(Usuario usuario)
        {
            _conexao.ExecutarProcedure("GKSSP_InsUsuario");
            _conexao.AddParametro("@IdUsuario", usuario.IdUsuario);
            _conexao.AddParametro("@Email", usuario.Email);
            _conexao.AddParametro("@Senha", usuario.Senha);

            _conexao.ExecutarSemRetorno();
        }

        public void Excluir(int id)
        {
            _conexao.ExecutarProcedure("GKSSP_DelUsuario");
            _conexao.AddParametro("@IdUsuario", id);

            _conexao.ExecutarSemRetorno();
        }
    }
}