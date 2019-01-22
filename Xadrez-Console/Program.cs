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
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.ColocarPeca(new Rei(tab, Cor.Branca), new Posicao(1, 7));
                tab.ColocarPeca(new Rei(tab, Cor.Branca), new Posicao(1, 4));
                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(2, 5));

                Tela.ImprimirTabuleiro(tab);
                Console.ReadLine();
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
