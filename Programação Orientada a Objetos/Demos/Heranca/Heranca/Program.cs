using System;

namespace Heranca
{
    class Program
    {
        static void Main(string[] args)
        {
            Geladeira geladeira = new Geladeira();
            Frigobar frigobar = new Frigobar();
            Televisao televisao = new Televisao();

            geladeira.EmitirSom();//Como a Geladeira herdou de Eletronico tem todas caracteristicas da classe Eletronico
            televisao.EmitirSom();//Como a Televisao herdou de Eletronico tem todas caracteristicas da classe Eletronico
            frigobar.EmitirSom(); //Como o Frigobar herdou de Geladeira, tem todas caracteristicas da classe Geladeira e da classe Eletronico

            Console.ReadKey();
        }
    }
}
