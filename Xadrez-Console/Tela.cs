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

            if (!partida.terminada)
            {
                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                if (partida.xeque == true)
                {
                    Console.WriteLine("XEQUE!");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("XEQUE MATE!");
                Console.WriteLine("Partida terminada, Vencedor: " + partida.jogadorAtual);
            }   
        }

        private static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            ConsoleColor foreaux = Console.ForegroundColor;
            ConsoleColor backaux = Console.BackgroundColor;

            Console.WriteLine("Peças Capturadas:");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Brancas: ");            
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.ForegroundColor = foreaux;
            Console.BackgroundColor = backaux;
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Pretas: ");
            Console.ForegroundColor = ConsoleColor.Black;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = foreaux;
            Console.BackgroundColor = backaux;
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

        public static void ImprimeCoresTabuleiro(Peca[,] mat)
        {
            ConsoleColor cor1 = ConsoleColor.DarkGray;
            ConsoleColor cor2 = ConsoleColor.Gray;

            foreach( p in mat)
            {
                if(Console.BackgroundColor == cor1)
                {
                    Console.BackgroundColor = cor2;
                }
                else
                {
                    Console.BackgroundColor = cor1;
                }
            }
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

        public static void ImprimirTabuleiro(PartidaDeXadrez partida,Tabuleiro tab, bool[,] PosicoesPossiveis)
        {
            ConsoleColor BackgroundColor = ConsoleColor.DarkGray;

            if (partida.terminada != true)
            {
                ConsoleColor xadrez1 = ConsoleColor.Gray;
                ConsoleColor xadrez2 = ConsoleColor.DarkGray;
                ConsoleColor HighlightBackgroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = BackgroundColor;
                Console.Clear();

                for (int i = 0; i < tab.linhas; i++)
                {
                    Console.Write(8 - i + " ");
                    for (int j = 0; j < tab.colunas; j++)
                    {
                        if (PosicoesPossiveis[i, j] == true)
                        {
                            Console.BackgroundColor = HighlightBackgroundColor;
                        }
                        else
                        {
                            if(Console.BackgroundColor == xadrez1)
                            {
                                Console.BackgroundColor = xadrez2;
                            }
                            else
                            {
                                Console.BackgroundColor = xadrez1;
                            }
                        }

                        ImprimirPeca(tab.RetornaMatrizPeca(i, j));
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("  A B C D E F G H");
                Console.BackgroundColor = BackgroundColor;
            }
            else
            {
                Console.Clear();

                for (int i = 0; i < tab.linhas; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write(8 - i + " ");
                    Console.BackgroundColor = ConsoleColor.DarkGray;

                    for (int j = 0; j < tab.colunas; j++)
                    {
                        if (PosicoesPossiveis[i, j] == true)
                        {
                            if (tab.RetornaMatrizPeca(i, j) != null && tab.RetornaMatrizPeca(i, j).cor == partida.jogadorAtual)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (tab.RetornaMatrizPeca(i, j) != null && tab.RetornaMatrizPeca(i, j).cor != partida.jogadorAtual)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                            }
                        }
                        else
                        {
                            Console.BackgroundColor = BackgroundColor;
                        }

                        ImprimirPeca(tab.RetornaMatrizPeca(i, j));
                    }

                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("  A B C D E F G H");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = BackgroundColor;
            }
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
                    if (!peca.selecao == true)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(peca);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(peca);
                        peca.SelecionaPeca(peca.selecao);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                }
                else
                {
                    if (!peca.selecao == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(peca);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(peca);
                        peca.SelecionaPeca(peca.selecao);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }

                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.DarkGray;
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
