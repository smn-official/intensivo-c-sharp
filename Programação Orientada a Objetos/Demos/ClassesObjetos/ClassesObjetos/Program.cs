using System;

namespace ClassesObjetos
{
    class Program
    {
        static void Main(string[] args)
        {
            Bolo boloMorango = new Bolo("Delicioso bolo com frutas", "Morango", 30);//Instanciando nosso bolo com construtor

            Bolo boloChocolate = new Bolo();//Instanciando nosso bolo sem construtor
            boloChocolate.Descricao = "Saboroso, incrivel bolo";
            boloChocolate.Sabor = "Chocolate";

            boloMorango.ColocarCoberturaMaracuja(); //Colocando a cobertura de maracuja usando um método.
            boloChocolate.ColocarCoberturaChocolate(); //Colocando a cobertura de chocolate usando um método.

            boloMorango.ExibirDescricao();
            boloChocolate.ExibirDescricao();

            foreach (var saborCobertura in Bolo.ExibirCoberturas())//Usando um método static!
                Console.WriteLine($"Temos cobertura de {saborCobertura}");

            Console.ReadKey();
        }
    }
}
