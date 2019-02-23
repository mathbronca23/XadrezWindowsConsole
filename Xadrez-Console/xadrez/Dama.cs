using xadrez;
using tabuleiro;

namespace Xadrez_Console.xadrez
{
    class Dama : Peca
    {
        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "D";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.RetornaMatrizPeca(pos);
            return p == null || p.cor != cor;
        }



    }
}
