namespace CursoRepositorio.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public byte FG_Ativo { get; set; }
    }
}