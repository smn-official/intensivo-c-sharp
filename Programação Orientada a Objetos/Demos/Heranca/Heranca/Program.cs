namespace Heranca
{
    class Program
    {
        static void Main(string[] args)
        {
            Geladeira geladeira = new Geladeira();
            Frigobar frigobar = new Frigobar();
            Televisao televisao = new Televisao();

            geladeira.Valor = 1000;
            geladeira.Marca = "LG";

            frigobar.Valor = 850;
            frigobar.Marca = "LG";
            frigobar.Portatil = true;

            televisao.Valor = 1500;
            televisao.Marca = "SAMSUNG";
            televisao.QuantidadePolegadas = 60;
        }
    }
}
