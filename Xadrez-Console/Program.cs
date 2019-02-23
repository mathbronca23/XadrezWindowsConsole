using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PartidaDeXadrez partida = new PartidaDeXadrez();
            Console.ForegroundColor = ConsoleColor.Yellow;
            try
            {              
                while (!partida.terminada)
                {
                    try
                    {
                        Tela.ImprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Digite as coordenadas da peça que deseja mover: ");
                        Posicao origem = Tela.LerPosicaoXadrez().toPosition();
                        partida.ValidaPosicaoDeOrigem(origem);

                        bool[,] PosicoesPossiveis = partida.tab.RetornaMatrizPeca(origem).MovimentosPossiveis();
                        Peca peca = partida.tab.RetornaMatrizPeca(origem);
                        peca.SelecionaPeca(peca.selecao);

                        Console.Clear();
                        Tela.ImprimirPartida(partida, PosicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Digite as coordenadas de destino da peça: ");
                        Posicao destino = Tela.LerPosicaoXadrez().toPosition();
                        partida.ValidaPosicaoDeDestino(origem, destino);
                        partida.RealizaJogada(origem, destino);
                        Tela.ImprimirPartida(partida);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

            Tela.ImprimirPartida(partida, partida.tab.RetornaPosicoesXequeMate(partida));
            Console.ReadKey();
        }
    }
}
