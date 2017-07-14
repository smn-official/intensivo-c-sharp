using System;

namespace Polimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            Geladeira geladeira = new Geladeira();
            Frigobar frigobar = new Frigobar();
            Televisao televisao = new Televisao();

            //O mesmo método EmitirSom retorna resultados diferentes, isso é polimorfismo!
            geladeira.EmitirSom();//Retorno: Som da geladeira
            televisao.EmitirSom();//Retorno: Som da televisão
            frigobar.EmitirSom();//Retorno: Som do frigobar

            Console.ReadKey();
        }
    }
}
