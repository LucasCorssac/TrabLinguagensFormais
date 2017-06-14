using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsoleApplication1.Classes
{
    class Variaveis
    {
        String nome;//Nome da variavel     

        List<string> Regras = new List<string>();//Contem todas as regras da variavel em questão

        bool Terminal;//True se é uma variavel terminal, false se não é

        int Ponto;//Local do ponto, se ele é 1 ele esta a esquerda do primeiro item na variavel

        int Barra;//Numero após a barra

        float Fronteira;//Esta no arquivo, nao sei para que isso serve

        public Variaveis(string Pt1, string Pt2)
        {
            string[] Temp;//Variavel temporaria e privada usada só e unicamente para o line splite
            int Cont = 0;//Variavel para controlar quatas regras e qual o nome da variavel

            Temp = Pt1.Split('[');
            foreach(string Str in Temp)//Vai criar as regras e decobrir o nome
            {
                if(Str != "")//o primeiro item da tring é uma string vazia por que é assim que o split funciona, isso é para ignorar ele
                {
                    if(Cont == 0)//Se é o primeiro item a ser lido é o nome
                    {
                        nome = RemoveColchetes(Str);
                    }
                    else//se nao for é uma regra
                    {
                        Regras.Add(RemoveColchetes(Str));
                    }

                    Cont++;
                }
            }

            Temp = Pt2.Split('	');

            Fronteira = float.Parse(Temp[0], CultureInfo.InvariantCulture.NumberFormat);
        }

        /// <summary>
        /// Verifica se o ponto esta encostado na barra, retorna true se o numero do ponto é maior que o numero de itens na lista de regras, 
        /// logo ele esta imediatamente a esqueda da barra, retorna false se é menor e esta a esquerda de uma regra qualquer
        /// </summary>
        /// <returns></returns>
        bool PontoaEsquerda()
        {
            if (Regras.Count <= Ponto)
                return false;
            else
                return true;
        }

        private string RemoveColchetes(string Linha)//Criei para tirar os elemento entre [  ]
        {
            var Builder = new StringBuilder();//String builder, vou usar para montar a string a partir dos caracteres dentro das achaves
            char Atual = 'ß';//char a ser adcionado à string
            char Proximo = 'æ';//Proximo char para controle do while
            int Counter = 1;//Vai controlar qual char estamos, começa em 1 por que o 0 é o " " que deve ser ignorado

            do
            {
                Atual = Linha[Counter];//atual recebe o char que esta sendo analisado
                Proximo = Linha[Counter + 1];//recebe o char seguinte ao atualmente sendo analisado

                if (!Proximo.Equals(']'))//Se o o proximo é o final o atual é o espaço a ser ignorado
                {
                    Builder.Append(Atual);//Adciona a string o char atual que faz parte da letra
                }

                Counter++;
            } while (!(Proximo.Equals(']')));//Para quando o proximo char for o final, por que nao tem motivo para parcear ele

            return Builder.ToString();//Retorna a string contendo a palavra atual
        }

        public void Print()
        {
            Console.Write(nome);
            Console.Write(" > ");
            foreach (string Str in Regras)
                Console.Write(Str + " ");
            Console.WriteLine("; " + Fronteira.ToString());
        }
    }
}
