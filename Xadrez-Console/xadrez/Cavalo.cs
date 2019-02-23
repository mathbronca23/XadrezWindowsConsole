using tabuleiro;
using xadrez;

namespace Xadrez_Console.xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "C";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.RetornaMatrizPeca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] MovimentosPossiveisXequeMate()
        {        
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            //MOVE 01
            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 2);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                if(tab.RetornaMatrizPeca(pos) is Rei)
                {
                    mat[pos.linha, pos.coluna] = true;
                    mat[pos.linha, pos.coluna + 1] = true;
                    mat[pos.linha, pos.coluna + 2] = true;
                    mat[pos.linha +1, pos.coluna + 2] = true;
                }             
            }

            //MOVE 02
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 2);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                if (tab.RetornaMatrizPeca(pos) is Rei)
                {
                    mat[pos.linha, pos.coluna] = true;
                    mat[pos.linha, pos.coluna - 1] = true;
                    mat[pos.linha, pos.coluna - 2] = true;
                    mat[pos.linha + 1, pos.coluna - 2] = true;
                }
            }

            //MOVE 03
            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 2);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                if (tab.RetornaMatrizPeca(pos) is Rei)
                {
                    mat[pos.linha, pos.coluna] = true;
                    mat[pos.linha, pos.coluna + 1] = true;
                    mat[pos.linha, pos.coluna + 2] = true;
                    mat[pos.linha - 1, pos.coluna + 2] = true;
                }
            }

            //MOVE 04
            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 2);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                if (tab.RetornaMatrizPeca(pos) is Rei)
                {
                    mat[pos.linha, pos.coluna] = true;
                    mat[pos.linha, pos.coluna - 1] = true;
                    mat[pos.linha, pos.coluna - 2] = true;
                    mat[pos.linha - 1, pos.coluna - 2] = true;
                }
            }

            //MOVE 05
            pos.DefinirValores(posicao.linha - 2, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                if (tab.RetornaMatrizPeca(pos) is Rei)
                {
                    mat[pos.linha, pos.coluna] = true;
                    mat[pos.linha, pos.coluna + 1] = true;
                    mat[pos.linha + 1, pos.coluna] = true;
                    mat[pos.linha + 2, pos.coluna] = true;
                }
            }

            //MOVE 06
            pos.DefinirValores(posicao.linha - 2, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                if (tab.RetornaMatrizPeca(pos) is Rei)
                {
                    mat[pos.linha, pos.coluna] = true;
                    mat[pos.linha, pos.coluna - 1] = true;
                    mat[pos.linha + 1, pos.coluna] = true;
                    mat[pos.linha + 2, pos.coluna] = true;
                }
            }

            //MOVE 07
            pos.DefinirValores(posicao.linha + 2, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                if (tab.RetornaMatrizPeca(pos) is Rei)
                {
                    mat[pos.linha, pos.coluna] = true;
                    mat[pos.linha, pos.coluna + 1] = true;
                    mat[pos.linha - 1, pos.coluna] = true;
                    mat[pos.linha - 2, pos.coluna] = true;
                }
            }

            //MOVE 08
            pos.DefinirValores(posicao.linha + 2, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                if (tab.RetornaMatrizPeca(pos) is Rei)
                {
                    mat[pos.linha, pos.coluna] = true;
                    mat[pos.linha, pos.coluna - 1] = true;
                    mat[pos.linha - 1, pos.coluna] = true;
                    mat[pos.linha - 2, pos.coluna] = true;
                }
            }

            return mat;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            //MOVE 01
            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 2);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna]= true;
            }

            //MOVE 02
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 2);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //MOVE 03
            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 2);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //MOVE 04
            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 2);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //MOVE 05
            pos.DefinirValores(posicao.linha - 2, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //MOVE 06
            pos.DefinirValores(posicao.linha - 2, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //MOVE 07
            pos.DefinirValores(posicao.linha + 2, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //MOVE 08
            pos.DefinirValores(posicao.linha + 2, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }
    }
}
