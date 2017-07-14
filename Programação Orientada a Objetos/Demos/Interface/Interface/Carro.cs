using System;

namespace Interface
{
    public class Carro : ICarro //Estou herdando de uma interface, logo sou obrigado a ter implementados todos métodos que há nela
    {
        public void Correr()
        {
            Console.WriteLine("Vrummmmm");
        }

        public void Freiar()
        {
            Console.WriteLine("Riiiiii");
        }

        public void Buzinar()
        {
            Console.WriteLine("Bibiiii");
        }
    }
}