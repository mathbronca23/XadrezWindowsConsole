using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
            terminada = false;
            xeque = false;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.RetirarPeca(destino);
            p.DecrementarQtdMovimentos();
            if(pecaCapturada != null)
            {
                tab.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);             
            }

            tab.ColocarPeca(p, origem);

        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            tab.RetornaUltimaPecaJogada(origem);
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
           
            if (IsReiEmCheque(jogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em Xeque!");
            }
            if(IsReiEmCheque(CorAdversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            if(TesteXequeMate(CorAdversaria(jogadorAtual)))
            {             
                terminada = true;
            }
            else
            {
                turno++;
                MudaJogador();
            }
        }

        private void MudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }      
        }

        public void ValidaPosicaoDeOrigem(Posicao pos)
        {
            if(tab.RetornaMatrizPeca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça válida na posição de origem escolhida.");
            }
            if(tab.RetornaMatrizPeca(pos).cor != jogadorAtual)
            {
                throw new TabuleiroException("A peça de origem escolhida não corresponde ao jogador do turno, selecione uma peça que corresponda ao jogador do turno.");
            }
            if(!tab.RetornaMatrizPeca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existem movimentos possíveis para a peça escolhida, selecione uma peça válida.");
            }
        }

        public void ValidaPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if(!tab.RetornaMatrizPeca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Não é possível mover para a posição informada, informe uma posição válida.");
            }
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarQtdMovimentos();
            Peca pecacapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);

            if(pecacapturada != null)
            {
                capturadas.Add(pecacapturada);
            }

            return pecacapturada;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosition());
            pecas.Add(peca);
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach(Peca peca in capturadas)
            {
                if(peca.cor == cor)
                {
                    aux.Add(peca);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca peca in pecas)
            {
                if (peca.cor == cor)
                {
                    aux.Add(peca);
                }
            }

            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public bool IsReiEmCheque(Cor cor)
        {
            Peca r = Rei(cor);

            if(r == null)
            {
                throw new TabuleiroException("Não existe Rei disponível no tabuleiro.");
            }

            foreach (Peca p in PecasEmJogo(CorAdversaria(cor)))
            {
                bool[,] mat = p.MovimentosPossiveis();

                if(mat[r.posicao.linha,r.posicao.coluna])
                {
                    return true;
                }
            }

            return false;
        }

        private Cor CorAdversaria(Cor cor)
        {
            if(cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        public bool TesteXequeMate(Cor cor)
        {
            if(!IsReiEmCheque(cor))
            {
                return false;
            }
            else
            {
                foreach(Peca p in PecasEmJogo(cor))
                {
                    bool[,] mat = p.MovimentosPossiveis();
                    for(int i = 0; i<tab.linhas;i++)
                    {
                        for(int j = 0; j<tab.colunas;j++)
                        {
                            if(mat[i,j])
                            {
                                Posicao origem = p.posicao;
                                Posicao destino = new Posicao(i, j);
                                Peca pecaCapturada = ExecutaMovimento(origem,destino);
                                bool testeXeque = IsReiEmCheque(cor);
                                DesfazMovimento(origem, destino, pecaCapturada);
                                if(!testeXeque)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }

                return true;
            }
        }

        private Peca Rei(Cor cor)
        {
            foreach(Peca p in PecasEmJogo(cor))
            {
                if(p is Rei)
                {
                    return p;
                }
            }

            return null;
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));
            ColocarNovaPeca('f', 5, new Torre(tab, Cor.Branca));
            ColocarNovaPeca('d',4, new Torre(tab, Cor.Branca));
            ColocarNovaPeca('g', 4, new Torre(tab, Cor.Branca));
            ColocarNovaPeca('d', 8, new Torre(tab, Cor.Branca));
            ColocarNovaPeca('a', 6, new Torre(tab, Cor.Branca));

            ColocarNovaPeca('g', 7, new Rei(tab, Cor.Preta));
            ColocarNovaPeca('g', 8, new Torre(tab, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(tab, Cor.Preta));
            ColocarNovaPeca('h', 7, new Torre(tab, Cor.Preta));
        }

        public void TerminaPartida()
        {
            terminada = true;
        }
    }
}
