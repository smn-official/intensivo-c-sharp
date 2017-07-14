using System;

namespace Encapsulamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite um número de 1 a 9: ");
            var resposta = int.Parse(Console.ReadLine());

            Som.EmitirBeep(resposta); //Emitindo um som, não sabemos como, mas sabemos que é só chamar e passar o tanto de vezes que queremos o beep

            Console.ReadKey();
        }
    }
}
