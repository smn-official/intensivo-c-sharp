using System;

namespace Sobreposicao
{
    class Program
    {
        static void Main(string[] args)
        {
            Geladeira geladeira = new Geladeira();
            Frigobar frigobar = new Frigobar();
            Televisao televisao = new Televisao();

            geladeira.EmitirSom();//Retorno: Som da geladeira
            televisao.EmitirSom();//Retorno: Som da televisão
            frigobar.EmitirSom();//Retorno: Som do frigobar

            geladeira = new Frigobar();

            geladeira.EmitirSom();//Retorno: Som do frigobar, Aqui foi feita uma Sobreposição de método

            Console.ReadKey();
        }
    }
}
