using ConsoleApplication1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Explicação de por que coloquei a linguagem como uma classe e não como um elemento livre dentro da main:
 * A linguagem vai ter mais do que só a lista de variaveis, ela tera no mínimo uma lista de todas as variaveis
 * e o caractere inicial, colocando dentro de uma classe facilita a localização e compartimentação
 * Ass. Guilherme
 */



namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string Caminho = "C:\\Users\\guilherme.silveira\\Desktop\\a.txt";//Caminho para o arquivo de texto

            Console.WriteLine("Insira o caminho para o arquivo de texto:");//Pede para o Usuario Inserir o caminho para o arquivo
            //Caminho = Console.ReadLine();//Le o input so Usuario para o caminho

            Linguagem Lingua = new Linguagem(Caminho);//Cria a variavel equivalente a classe linguagem, eu botei a leitura do arquivo como o construtor
                                                      //Ja que a linguagem inteira é composta pelo conteudo do arquivo

            Console.WriteLine("------------------------------------------------------");


            Lingua.Print();

            Console.ReadKey();


        }

    }
}
