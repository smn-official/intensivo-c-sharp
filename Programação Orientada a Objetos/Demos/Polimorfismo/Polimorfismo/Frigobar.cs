using System;

namespace Polimorfismo
{
    public class Frigobar : Geladeira //Como o Frigobar herdou de Geladeira, tem todas caracteristicas da classe Geladeira e da classe Eletronico
    {
        public bool Portatil { get; set; }//Especificação de propriedade

        public override void EmitirSom()//Sobrescrevendo método
        {
            Console.WriteLine("Som do frigobar");
        }
    }
}