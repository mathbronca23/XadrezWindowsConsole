using tabuleiro;
using xadrez;

namespace Xadrez_Console.xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "B";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.RetornaMatrizPeca(pos);
            return p == null || p.cor != cor;
        }


        public override bool[,] MovimentosPossiveisXequeMate()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Peca pecaOrigem = tab.RetornaMatrizPeca(posicao.linha, posicao.coluna);
            Posicao pos = new Posicao(0, 0);

            //NO
            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.RetornaMatrizPeca(pos) != null && tab.RetornaMatrizPeca(pos).cor != cor)
                {
                    Peca p = tab.RetornaMatrizPeca(pos);
                    if (p is Rei)
                    {
                        mat[pos.linha, pos.coluna] = true;

                        while (p != pecaOrigem)
                        {
                            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
                            p = tab.RetornaMatrizPeca(pos);
                            mat[pos.linha, pos.coluna] = true;
                        }

                        break;
                    }
                }
                pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
            }

            //NE
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.RetornaMatrizPeca(pos) != null && tab.RetornaMatrizPeca(pos).cor != cor)
                {
                    Peca p = tab.RetornaMatrizPeca(pos);
                    if (p is Rei)
                    {
                        mat[pos.linha, pos.coluna] = true;

                        while (p != pecaOrigem)
                        {
                            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
                            p = tab.RetornaMatrizPeca(pos);
                            mat[pos.linha, pos.coluna] = true;
                        }

                        break;
                    }

                    pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
                }
            }

            //SE
            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.RetornaMatrizPeca(pos) != null && tab.RetornaMatrizPeca(pos).cor != cor)
                {
                    Peca p = tab.RetornaMatrizPeca(pos);
                    if (p is Rei)
                    {
                        mat[pos.linha, pos.coluna] = true;

                        while (p != pecaOrigem)
                        {
                            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
                            p = tab.RetornaMatrizPeca(pos);
                            mat[pos.linha, pos.coluna] = true;
                        }

                        break;
                    }
                }
                pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
            }

            //SO
            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.RetornaMatrizPeca(pos) != null && tab.RetornaMatrizPeca(pos).cor != cor)
                {
                    Peca p = tab.RetornaMatrizPeca(pos);
                    if (p is Rei)
                    {
                        mat[pos.linha, pos.coluna] = true;

                        while (p != pecaOrigem)
                        {
                            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
                            p = tab.RetornaMatrizPeca(pos);
                            mat[pos.linha, pos.coluna] = true;
                        }

                        break;
                    }

                    pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
                }                        
            }
            ///////////////////////////////////
            return mat;
        }


        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            //NO
            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.RetornaMatrizPeca(pos) != null && tab.RetornaMatrizPeca(pos).cor != cor)
                {
                    break;
                }

                pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
            }

            //NE
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.RetornaMatrizPeca(pos) != null && tab.RetornaMatrizPeca(pos).cor != cor)
                {
                    break;
                }

                pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
            }

            //SE
            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.RetornaMatrizPeca(pos) != null && tab.RetornaMatrizPeca(pos).cor != cor)
                {
                    break;
                }

                pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
            }

            //SO
            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.RetornaMatrizPeca(pos) != null && tab.RetornaMatrizPeca(pos).cor != cor)
                {
                    break;
                }

                pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
            }

            ///////////////////////////////////
            return mat;
        }

    }
}
