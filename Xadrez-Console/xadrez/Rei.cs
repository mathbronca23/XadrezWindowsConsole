using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
            
        }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.RetornaMatrizPeca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            //ACIMA
            pos.DefinirValores(posicao.linha -1, posicao.coluna);
            if(tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //NORDESTE
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //DIREITA
            pos.DefinirValores(posicao.linha, posicao.coluna +1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //ACIMA
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //SUDESTE
            pos.DefinirValores(posicao.linha + 1, posicao.coluna +1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //ABAIXO
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //SUDOESTE
            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //ESQUERDA
            pos.DefinirValores(posicao.linha, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //NOROESTE
            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }
    }
}
