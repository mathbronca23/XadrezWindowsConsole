using System;
using tabuleiro;

namespace Xadrez_Console
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for(int i = 0; i<tab.linhas; i++)
            {
                for(int j=0; j<tab.colunas; j++)
                {
                    if(tab.RetornaMatrizPeca(i,j)==null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.RetornaMatrizPeca(i, j) + " ");
                    }
               }

                Console.WriteLine();
            }
        }
    }
}
