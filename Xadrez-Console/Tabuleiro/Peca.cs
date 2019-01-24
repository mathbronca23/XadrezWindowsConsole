namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }
        public bool selecao { get; private set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            qtdMovimentos = 0;
            selecao = false;
        }

        public void IncrementarQtdMovimentos()
        {
            qtdMovimentos++;
        }

        public void DecrementarQtdMovimentos()
        {
            qtdMovimentos--;
        }

        public abstract bool[,] MovimentosPossiveis();

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            
            for(int i = 0; i<tab.linhas; i++)
            {
                for(int j = 0; j<tab.colunas; j++)
                {
                    if(mat[i,j] == true)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.linha, pos.coluna];
        }

        public bool SelecionaPeca(bool selecao)
        {
            if(selecao == true)
            {
                return this.selecao = false;
            }
            else
            {
                return this.selecao = true;
            }            
        }
    }
}
