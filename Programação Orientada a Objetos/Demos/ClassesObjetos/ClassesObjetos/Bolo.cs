using System;

namespace ClassesObjetos
{
    public class Bolo
    {
        public Bolo()//Contrutor vazio, caso a gente queira instancia-lo sem receber nenhum parametro
        {
            
        }

        //Repare que estamos fazendo uma sobrecarga no contrutor!!!
        public Bolo(string descricao, string sabor, int tamanho)//Construtor, nossa bolo vai instanciar um objeto obrigatóriamente com descricao e sabor
        {
            Descricao = descricao;
            Sabor = sabor;
            Tamanho = tamanho;
        }

        public string Descricao { get;  set; }
        public string Sabor { get; set; }
        public int Tamanho { get; private set; }//Essa propriedade só pode ser setada na construção do objeto, repare no private no set
        private string Cobertura { get; set; }//Essa propriedade é privada, só pode ser alterada atravez de um método

        public static string[] ExibirCoberturas()//Método statico pra mostrar as coberturas disponiveis, sem precisar instanciar a classe
        {
            string[] coberturas = new string[2];
            coberturas[0] = "Chocolate";
            coberturas[1] = "Maracuja";
            return coberturas;
        }

        public void ColocarCoberturaChocolate()//Esse método é o que consegue encherga a corbertura e altera o valor dela
        {
            Cobertura = "Chocolate";
        }

        public void ColocarCoberturaMaracuja()//Esse método é o que consegue encherga a corbertura e altera o valor dela
        {
            Cobertura = "Maracuja";
        }

        public void ExibirDescricao()
        {
            Console.WriteLine($"Eu sou um {Descricao} com sabor de {Sabor} e com cobertura de {Cobertura}");
        }

        ~Bolo()//Usando o destrutor pra limpar o objeto da memória
        {
            Descricao = string.Empty; //Setando o valor de descrição como no inicio
        }

    }
}