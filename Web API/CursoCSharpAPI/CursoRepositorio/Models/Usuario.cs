using System.Text.RegularExpressions;

namespace CursoRepositorio.Models
{
    public class Usuario
    {
        public Usuario()
        {

        }

        public Usuario(string email, string senha, string senhaConfirmacao)
        {
            Email = email;
            Senha = senha;
            SenhaConfirmacao = senhaConfirmacao;
        }

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string SenhaConfirmacao { get; set; }

        public byte FG_Ativo { get; set; }

        public bool UsuarioValido()
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match retorno = regex.Match(Email);

            if (retorno.Success && (Senha != null && Senha.Trim() != "" && Senha.Length <= 6))
                return true;
            else
                return false;
        }
    }
}