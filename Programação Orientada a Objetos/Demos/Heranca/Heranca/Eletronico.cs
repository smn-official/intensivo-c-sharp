namespace Heranca
{
    public abstract class Eletronico //Criando uma super class, o abstract após o public, indica que ela não pode ser instanciada, apenas herdada.
    {
        public string Marca { get; set; }
        public int Valor { get; set; }
        private int Watts { get; set; }//Ninguem que herdar de Eletronico, terá a caracteristica Watts, pois o modificador de acesso é private
        protected int Caracteristica { get; set; }//O modificador de acesso protected, faz passar a caracteristicas pra quem herdar
    }
}