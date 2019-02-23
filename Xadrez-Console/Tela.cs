using System;
using System.Text;
using tabuleiro;
using xadrez;
using System.Collections.Generic;

namespace Xadrez_Console
{
    class Tela
    {
        public static void ImprimirPartida(PartidaDeXadrez partida, bool[,] posicoesPossiveis)
        {

            ImprimirTabuleiro(partida, partida.tab, posicoesPossiveis);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();

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

        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.tab);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();

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
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.ForegroundColor = foreaux;
            Console.BackgroundColor = backaux;
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Pretas: ");
            Console.ForegroundColor = ConsoleColor.White;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = foreaux;
            Console.BackgroundColor = backaux;
        }

        public static void ImprimirConjunto(HashSet<Peca> pecas)
        {
            Console.Write("[");
            foreach (Peca peca in pecas)
            {
                Console.Write(peca + " ");
            }
            Console.Write("]");
        }

        private static void CriaQuadrosTabuleiro(int linha, ConsoleColor quadro1, ConsoleColor quadro2)
        {
            if (linha % 2 == 0)
            {
                if (Console.BackgroundColor == quadro1)
                {
                    Console.BackgroundColor = quadro2;
                }
                else
                {
                    Console.BackgroundColor = quadro1;
                }
            }
            else
            {
                if (Console.BackgroundColor == quadro2)
                {
                    Console.BackgroundColor = quadro1;
                }
                else
                {
                    Console.BackgroundColor = quadro2;
                }
            }
        }

        private static void CriaQuadrosTabuleiro(int linha, ConsoleColor quadro1, ConsoleColor quadro2, ConsoleColor lastColor)
        {
            if (lastColor == ConsoleColor.DarkCyan)
            {
                Console.BackgroundColor = quadro1;
            }
            else
            {
                Console.BackgroundColor = quadro2;
            }
        }

        public static void ImprimirTabuleiro(Tabuleiro tab)
        {

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.Write("                           ");
            Console.WriteLine("  A B C D E F G H");

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write("                           ");
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.colunas; j++)
                {
                    CriaQuadrosTabuleiro(i, ConsoleColor.DarkYellow, ConsoleColor.DarkCyan);
                    ImprimirPeca(tab.RetornaMatrizPeca(i, j));

                    if (j == tab.colunas - 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" " + (8 - i));
                    }
                }

                Console.WriteLine();
            }

            Console.Write("                           ");
            Console.WriteLine("  A B C D E F G H");
        }

        public static void ImprimirTabuleiro(PartidaDeXadrez partida, Tabuleiro tab, bool[,] PosicoesPossiveis)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            // Draw A - H Row Header.
            Console.Write("                           ");
            Console.WriteLine("  A B C D E F G H");

            if (!partida.terminada == true)
            {
                for (int i = 0; i < tab.linhas; i++)
                {
                    Console.Write("                           ");
                    Console.Write(8 - i + " ");
                    for (int j = 0; j < tab.colunas; j++)
                    {
                        CriaQuadrosTabuleiro(i, ConsoleColor.DarkYellow, ConsoleColor.DarkCyan);

                        ConsoleColor lastColor = Console.BackgroundColor;

                        //Fill valid destination squares for selected piece.
                        if (PosicoesPossiveis[i, j] == true)
                        {
                            CriaQuadrosTabuleiro(i, ConsoleColor.DarkGray, ConsoleColor.Gray, Console.BackgroundColor);
                        }

                        ImprimirPeca(tab.RetornaMatrizPeca(i, j));
                        Console.BackgroundColor = lastColor;

                        //Draw the number column in right side of table.
                        if (j == tab.colunas - 1)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" " + (8 - i));
                        }
                    }

                    Console.WriteLine();
                }

                //Draw A - H Footer.
                Console.Write("                           ");
                Console.WriteLine("  A B C D E F G H");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();

                Console.Write("                           ");
                Console.WriteLine("  A B C D E F G H");

                for (int i = 0; i < tab.linhas; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("                           ");
                    Console.Write(8 - i + " ");

                    for (int j = 0; j < tab.colunas; j++)
                    {
                        CriaQuadrosTabuleiro(i, ConsoleColor.DarkYellow, ConsoleColor.DarkCyan);
                        ConsoleColor lastColor = Console.BackgroundColor;

                        if (PosicoesPossiveis[i, j] == true)
                        {
                            if (tab.RetornaMatrizPeca(i, j) != null && tab.RetornaMatrizPeca(i, j).cor == partida.jogadorAtual)
                            {
                                CriaQuadrosTabuleiro(i, ConsoleColor.Red, ConsoleColor.Red, Console.BackgroundColor);
                            }
                            else if (tab.RetornaMatrizPeca(i, j) != null && tab.RetornaMatrizPeca(i, j).cor != partida.jogadorAtual)
                            {
                                CriaQuadrosTabuleiro(i, ConsoleColor.Red, ConsoleColor.Red, Console.BackgroundColor);
                            }
                            else
                            {
                                CriaQuadrosTabuleiro(i, ConsoleColor.Red, ConsoleColor.Red, Console.BackgroundColor);
                            }
                        }

                        ImprimirPeca(tab.RetornaMatrizPeca(i, j));
                        Console.BackgroundColor = lastColor;

                        if (j == tab.colunas - 1)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" " + (8 - i));
                        }
                    }

                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("                           ");
                Console.WriteLine("  A B C D E F G H");
            }
        }

        public static void ImprimirPeca(Peca peca)
        {
            ConsoleColor backaux = Console.BackgroundColor;

            if (peca == null)
            {
                Console.Write("  ");
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
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
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
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(peca);
                        peca.SelecionaPeca(peca.selecao);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }

                Console.Write(" ");
                Console.BackgroundColor = backaux;
            }
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);

        }

        public static void CreateLogoHeader()
        {
            StringBuilder s1 = new StringBuilder();
            StringBuilder s2 = new StringBuilder();
            ConsoleColor defaultcolor = Console.ForegroundColor;

            s1.AppendLine(" _____ _____ _____ _____ _____ __    _____    _____ _____ _____ _____ _____  ");
            s1.AppendLine("|     |     |   | |   __|     |  |  |   __|  |     |  |  |   __|   __|   __| ");
            s1.AppendLine("|   --|  |  | | | |__   |  |  |  |__|   __|  |   --|     |   __|__   |__   | ");
            s1.AppendLine("|_____|_____|_|___|_____|_____|_____|_____|  |_____|__|__|_____|_____|_____| ");
            s2.AppendLine("                _____ _____ _____ _____        ___     ___ ");
            s2.AppendLine("               |   __|  _  |     |   __|   _ _|_  |   |   |");
            s2.AppendLine("               |  |  |     | | | |   __|  | | |_| |_ _| | |");
            s2.AppendLine(@"               |_____|__|__|_|_|_|_____|   \_/|_____|_|___|");

            Console.WriteLine(s1);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(s2);
            Console.ForegroundColor = defaultcolor;
        }
    }
}
