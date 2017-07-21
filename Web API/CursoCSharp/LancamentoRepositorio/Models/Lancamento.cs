using System;

namespace LancamentoRepositorio.Models
{
    public class Lancamento
    {
        public int IdLancamento { get; set; }
        public DateTime? DataEvento { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string Descricao { get; set; }
        public decimal? Valor { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdAcao { get; set; }
        public int? IdConta { get; set; }
        public byte? FG_Pago { get; set; }
    }
}
