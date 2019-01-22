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
 
                while(!partida.terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab);

                    Console.WriteLine();
                    Console.Write("Digite as coordenadas da peça que deseja mover: ");
                    Posicao origem = Tela.LerPosicaoXadrez().toPosition();

                    bool[,] PosicoesPossiveis = partida.tab.RetornaMatrizPeca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab,PosicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Digite as coordenadas de destino da peça:");
                    Posicao destino = Tela.LerPosicaoXadrez().toPosition();
                    partida.ExecutaMovimento(origem, destino);
                }

               
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
