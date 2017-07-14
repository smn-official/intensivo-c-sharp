using System;

namespace Heranca
{
    public class Televisao : Eletronico //Herdando as propriedades/caracteristicas de Eletronico
    {
        public int QuantidadePolegadas { get; set; } //Especificação da geladeira

        public override void EmitirSom()//Sobreposição de método
        {
            Console.WriteLine("Som da televisão");
        }
    }
}