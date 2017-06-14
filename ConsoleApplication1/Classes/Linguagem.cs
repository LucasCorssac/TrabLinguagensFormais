using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Classes
{
    class Linguagem
    {
        List<Variaveis> Lingua = new List<Variaveis>();//Lista de Variaveis que compoem a linguagem
        List<string> Terminais = new List<string>();
        List<string> Variaveis = new List<string>();
        string Inicial;


        /// <summary>
        /// Contrutor da classe linguagem,
        /// Recebe a string com o caminho para o arquivo de texto contendo a linguagem
        /// 
        /// </summary>
        /// <param name="Direc"></param>
        public Linguagem(String Direc)
        {
            int Counter = 1;//Contador usado para se diferenciar se estamos nos termineis(index 1), Variaveis(index 2), Inicial(Index 3) ou Regras(Index 4)
                            //Começa do 1 para facilitar
            string Line;//Vai receber as linhas do arquivo de texto
            string[] Temp;//Usada para armazenamento de strigs temporarias graças ao linesplit

            System.IO.StreamReader file = new System.IO.StreamReader(Direc);//Abre o arquivo de texto para leitura
            while ((Line = file.ReadLine()) != null)//Le o arquivo linha a linha
            {
                if (!(Line[0].Equals("#")))//Verifica se o primeiro char da linha é um #(simbolo para comentarios)
                {
                    switch (Counter)//Usei um Switch por que é mais fafcil de ivsualizar e mais eficiente que uma serie de IF's
                    {
                        #region case 1 do switch
                        case 1:
                            if(!(Char.ToUpper(Line[0]).Equals('T')))//Verifica se o primeira char da linha é o "T" de Terminais, se for ignora 
                                                                 //ja que é a palavra do arquivo e não tem nenhum uso e vai direto para o break
                            {
                                if (Char.ToUpper(Line[0]).Equals('V'))//Verifica se a primeira letra da palavra é o V de Variaveis, isso indica o inicio
                                                                      // da proxima parte do arquivo
                                    Counter++;//Sobre o counter para seguir em frente no switch na proxima linha
                                else//Uma vez aqui dentro pressupõe-se que não avera nada mais do que Terminais dentro de [  ], eu nao botei um failsafe
                                    //para isso por que acho que é demais
                                {
                                    Terminais.Add(RemoveColchetes(Line));
                                }
                            }
                            break;
                        #endregion
                        #region case 2 do switch
                        case 2:
                            if (Char.ToUpper(Line[0]).Equals('I'))//Verifica se a primeira letra da palavra é o I de Inicial, isso indica o inicio
                                                                  // da proxima parte do arquivo
                                Counter++;//Sobre o counter para seguir em frente no switch na proxima linha
                            else//Uma vez aqui dentro pressupõe-se que não avera nada mais do que Terminais dentro de [  ], eu nao botei um failsafe
                                //para isso por que acho que é demais
                            {
                                Variaveis.Add(RemoveColchetes(Line));
                            }
                            break;
                        #endregion
                        #region case 3 do switch
                        case 3:
                            if (Char.ToUpper(Line[0]).Equals('R'))//Verifica se a primeira letra da palavra é o R de Regras, isso indica o inicio
                                                                  // da proxima parte do arquivo
                                Counter++;//Sobre o counter para seguir em frente no switch na proxima linha
                            else//Uma vez aqui dentro pressupõe-se que não avera nada mais do que Terminais dentro de [  ], eu nao botei um failsafe
                                //para isso por que acho que é demais
                            {
                                Inicial = RemoveColchetes(Line);//Sim, eu estou usando a mesma lógica dos outros, POR QUE o arquivo nunca deve ter
                                                                //Mais do que um inicial, se tiver vai considerar o ultimo colocado, por que
                                                                //é melhor que travar tudo
                            }
                            break;
                        #endregion
                        #region case 4 do switch
                        case 4:
                            Temp = Line.Split(';');
                            Lingua.Add(new Variaveis(Temp[0], Temp[1]));//Adciona uma nova variavel usando o construtor de variaveis
                            break;
                        #endregion
                        case 5:
                            Console.WriteLine("/nDeu merda gente");//Index NUNCA deve ser maior que 4, ja que são 4 possiveis casos
                            Console.ReadLine();
                            return;
                    }
                }

            }

            file.Close();
        }

        private string RemoveColchetes(string Linha)//Criei para tirar os elemento entre [  ]
        {
            var Builder = new StringBuilder();//String builder, vou usar para montar a string a partir dos caracteres dentro das achaves
            char Atual = 'ß';//char a ser adcionado à string
            char Proximo = 'æ';//Proximo char para controle do while
            int Counter = 2;//Vai controlar qual char estamos, começa em 2 por que o 0 é o "[" e o 1 é o " " que deve ser ignorado

            do
            {
                Atual = Linha[Counter];//atual recebe o char que esta sendo analisado
                Proximo = Linha[Counter++];//recebe o char seguinte ao atualmente sendo analisado

                if (!Proximo.Equals(']'))//Se o o proximo é o final o atual é o espaço a ser ignorado
                {
                    Builder.Append(Atual);//Adciona a string o char atual que faz parte da letra
                }

            } while (!(Proximo.Equals(']')));//Para quando o proximo char for o final, por que nao tem motivo para parcear ele

            return Builder.ToString();//Retorna a string contendo a palavra atual
        }

        public void Print()//Função para printar lingua
        {
            Console.WriteLine("Inicial:");
            Console.WriteLine(Inicial);

            Console.WriteLine("Variaveis");
            foreach (string Str in Variaveis)
                Console.WriteLine(Str);

            Console.WriteLine("Terminais");
            foreach (string Str in Terminais)
                Console.WriteLine(Str);

            Console.WriteLine("Regras");
            foreach (Variaveis Var in Lingua)
                Var.Print();
        }
    }
}
