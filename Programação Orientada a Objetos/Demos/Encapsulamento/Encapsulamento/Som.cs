using System;

namespace Encapsulamento
{
    public class Som
    {
        public static void EmitirBeep(int quantidade)
        {
            if (quantidade > 0 && quantidade < 10)
            {
                for (int i = 1; i <= quantidade; i++)
                {
                    Console.WriteLine("Beep número {0}.", i);
                    Console.Beep();
                }
            }
            else
                Console.WriteLine("Entre com um numero de 1 a 9");
        }

    }
}