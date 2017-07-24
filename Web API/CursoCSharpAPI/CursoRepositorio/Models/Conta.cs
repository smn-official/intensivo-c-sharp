using System;

namespace CursoRepositorio.Models
{
    public class Conta
    {
        public int IdConta { get; set; }
        public string Nome { get; set; }
        public DateTime? DataCadastro { get; set; }
        public int? IdUsuario { get; set; }

        //Vinculo
        public Usuario Usuario { get; set; }
    }
}