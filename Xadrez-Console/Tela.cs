using System;
using tabuleiro;
using xadrez;
using System.Collections.Generic;

namespace Xadrez_Console
{
    class Tela
    {
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
            Console.WriteLine();
        }

        private static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            ConsoleColor aux = Console.ForegroundColor;

            Console.WriteLine("Peças Capturadas:");
            Console.Write("Brancas: ");
            Console.ForegroundColor = ConsoleColor.White;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.ForegroundColor = aux;
            Console.WriteLine();                 
            Console.Write("Pretas: ");
            Console.ForegroundColor = ConsoleColor.Black;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void ImprimirConjunto(HashSet<Peca> pecas)
        {
            Console.Write("[");
            foreach(Peca peca in pecas)
            {
                Console.Write(peca + " ");
            }
            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();

            for (int i = 0; i<tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for(int j=0; j<tab.colunas; j++)
                {
                        ImprimirPeca(tab.RetornaMatrizPeca(i, j));                        
                }

                Console.WriteLine();
            }

            Console.WriteLine("  A B C D E F G H");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] PosicoesPossiveis)
        {
            ConsoleColor BackgroundColor = ConsoleColor.DarkGray;
            ConsoleColor HighlightBackgroundColor = ConsoleColor.DarkGreen;

            Console.BackgroundColor = BackgroundColor;
            Console.Clear();

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if(PosicoesPossiveis[i,j] == true)
                    {
                        Console.BackgroundColor = HighlightBackgroundColor;
                    }
                    else
                    {
                        Console.BackgroundColor = BackgroundColor;
                    }

                    ImprimirPeca(tab.RetornaMatrizPeca(i, j));
                }
                
                Console.WriteLine();
            }

            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = BackgroundColor;
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {

                if (peca.cor == Cor.Branca)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(peca);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(peca);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.Write(" ");
            }
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);

        }

    }
}
