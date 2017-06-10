using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Classes
{
    class Variaveis
    {
        String nome;//Nome da variavel

        List<string> Regras = new List<string>();//Contem todas as regras da variavel em questão

        bool Final;//True se é uma variavel final, false se não é

        int Ponto;//Local do ponto, se ele é 1 ele esta a esquerda do primeiro item na variavel

        int Barra;//Numero após a barra

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
    }
}
