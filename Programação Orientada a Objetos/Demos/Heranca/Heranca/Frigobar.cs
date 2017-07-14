using System;

namespace Heranca
{
    public class Frigobar : Geladeira
    {
        public bool Portatil { get; set; }//Especificação de propriedade

        public override void EmitirSom()//Sobreposição de método
        {
            Console.WriteLine("Som do frigobar");
        }
    }
}   