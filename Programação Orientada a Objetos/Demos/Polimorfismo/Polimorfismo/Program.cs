using System;

namespace Polimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            Eletronico[] eletronicos = new Eletronico[3]; 

            Geladeira geladeira = new Geladeira();
            Frigobar frigobar = new Frigobar();
            Televisao televisao = new Televisao();

            eletronicos[0] = geladeira;
            eletronicos[1] = frigobar;
            eletronicos[2] = televisao;

            //O mesmo método EmitirSom que é um Eletronico retorna resultados diferentes, isso é polimorfismo!
            foreach (var eletronico in eletronicos)
            {
                eletronico.EmitirSom();
            }

            Console.ReadKey();
        }
    }
}
