using System;

namespace Polimorfismo
{
    public class Televisao : Eletronico //Como a Televisao herdou de Eletronico tem todas caracteristicas da classe Eletronico
    {
        public int QuantidadePolegadas { get; set; } //Especificação da geladeira

        public override void EmitirSom()//Sobrescrevendo método
        {
            Console.WriteLine("Som da televisão");
        }
    }
}