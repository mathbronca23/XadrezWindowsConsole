namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca RetornaMatrizPeca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca RetornaMatrizPeca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if(existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }

            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos)
        {
            if (RetornaMatrizPeca(pos) == null)
            {
                return null;
            }
            else
            {
                Peca aux = RetornaMatrizPeca(pos);
                aux.posicao = null;
                pecas[pos.linha, pos.coluna] = null;
                return aux;
            }
        }

        public bool posicaoValida(Posicao pos)
        {
            if(pos.linha<0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return RetornaMatrizPeca(pos) != null;
        }

        public void validarPosicao(Posicao pos)
        {
            if(!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }

        public Peca RetornaPecaSelecionada(Posicao origem)
        {
            return RetornaMatrizPeca(origem); 
        }

        public bool[,] RetornaMatrizParaRei(Peca origem)
        {
            bool[,] mat = new bool[linhas, colunas];

            Posicao pos = new Posicao(0, 0);

            for(int i = 0; i<linhas; i++)
            {
                for(int j = 0; j<colunas; j++)
                {

                }
            }

        }
    }
}
