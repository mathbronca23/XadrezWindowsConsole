using xadrez;
using tabuleiro;

namespace Xadrez_Console.xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab,cor)
        {

        }

        public override string ToString()
        {
            return "P";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.RetornaMatrizPeca(pos);
            return p == null || p.cor != cor;
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = tab.RetornaMatrizPeca(pos);
            return p != null && p.cor != cor;
        }

        private bool Livre(Posicao pos)
        {
            return tab.RetornaMatrizPeca(pos) == null;
        }

        public override bool[,] MovimentosPossiveisXequeMate()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                //NORDESTE (SOMENTE QUANDO EXISTIR INIMIGOS)
                pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && ExisteInimigo(pos) && tab.RetornaMatrizPeca(pos) is Rei)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //NOROESTE(SOMENTE QUANDO EXISTIR INIMIGOS)
                pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && ExisteInimigo(pos) && tab.RetornaMatrizPeca(pos) is Rei)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            else
            {
                //NORDESTE (SOMENTE QUANDO EXISTIR INIMIGOS)
                pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && ExisteInimigo(pos) && tab.RetornaMatrizPeca(pos) is Rei)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //NOROESTE(SOMENTE QUANDO EXISTIR INIMIGOS)
                pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && ExisteInimigo(pos) && tab.RetornaMatrizPeca(pos) is Rei)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }

            return mat;

        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                //ACIMA
                pos.DefinirValores(posicao.linha - 1, posicao.coluna);
                if (tab.posicaoValida(pos) && Livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //ACIMA DUAS CASAS
                pos.DefinirValores(posicao.linha - 2, posicao.coluna);
                if (tab.posicaoValida(pos) && Livre(pos) && qtdMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                    mat[pos.linha + 1, pos.coluna] = true;
                }

                //NORDESTE (SOMENTE QUANDO EXISTIR INIMIGOS)
                pos.DefinirValores(posicao.linha -1, posicao.coluna +1);
                if (tab.posicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //NOROESTE(SOMENTE QUANDO EXISTIR INIMIGOS)
                pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            else
            {
                //ABAIXO
                pos.DefinirValores(posicao.linha + 1, posicao.coluna);
                if (tab.posicaoValida(pos) && Livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //ABAIXO DUAS CASAS
                pos.DefinirValores(posicao.linha + 2, posicao.coluna);
                if (tab.posicaoValida(pos) && Livre(pos) && qtdMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                    mat[pos.linha - 1, pos.coluna] = true;
                }

                //SUDESTE (SOMENTE QUANDO EXISTIR INIMIGOS)
                pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //SUDOESTE(SOMENTE QUANDO EXISTIR INIMIGOS)
                pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }

            return mat; 
        }
    }
}
