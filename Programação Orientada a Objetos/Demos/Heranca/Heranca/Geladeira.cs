using System;

namespace Heranca
{
    public class Geladeira : Eletronico //Herdando as propriedades/caracteristicas de Eletronico
    {
        public int QuantidadeLitros { get; set; } //Especificação da geladeira

        public override void EmitirSom()//Sobreposição de método
        {
            Console.WriteLine("Som da geladeira");
        }
    }
}