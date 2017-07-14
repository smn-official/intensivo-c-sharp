using System;

namespace Sobreposicao
{
    public class Geladeira : Eletronico //Como a Geladeira herdou de Eletronico tem todas caracteristicas da classe Eletronico
    {
        public int QuantidadeLitros { get; set; } //Especificação da geladeira

        public override void EmitirSom()//Sobrescrevendo método
        {
            Console.WriteLine("Som da geladeira");
        }
    }
}