using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

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

                        Tela.ImprimirPartida(partida, PosicoesPossiveis);
                        Tela.ImprimirPartida(partida, partida.tab.RetornaPosicoesXequeMate(partida));
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }

                Console.ReadKey();
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
