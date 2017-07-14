using System;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            var carro = new Carro();
            carro.Correr();
            carro.Buzinar();
            carro.Freiar();

            Console.ReadKey();
        }
    }
}
