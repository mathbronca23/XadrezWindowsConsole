﻿using System;
using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
            public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
            {

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

            //ACIMA
            Peca pecaOrigem = tab.RetornaMatrizPeca(posicao.linha, posicao.coluna);
            pos.DefinirValores(posicao.linha -1 , posicao.coluna);
            while(tab.posicaoValida(pos) && PodeMover(pos))
            {
                if(tab.RetornaMatrizPeca(pos) != null && tab.RetornaMatrizPeca(pos).cor != cor)
                {
                    Peca p = tab.RetornaMatrizPeca(pos);
                    if(p is Rei) 
                    {
                        mat[pos.linha, pos.coluna] = true;

                       while(p != pecaOrigem)
                        {                       
                            pos.linha = pos.linha +1;
                            p = tab.RetornaMatrizPeca(pos);
                            mat[pos.linha, pos.coluna] = true;
                        }

                        break;
                    }
                }
                pos.linha = pos.linha - 1;
            }

            //ABAIXO
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                if (tab.RetornaMatrizPeca(pos) != null && tab.RetornaMatrizPeca(pos).cor != cor)
                {
                    Peca p = tab.RetornaMatrizPeca(pos);
                    if (p is Rei)
                    {
                        while (p != pecaOrigem)
                        {                         
                            pos.linha = pos.linha - 1;
                            p = tab.RetornaMatrizPeca(pos);
                            mat[pos.linha, pos.coluna] = true;
                        }

                        break;
                    }
                }
                pos.linha = pos.linha + 1;
            }

            //DIREITA
            pos.DefinirValores(posicao.linha, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                if (tab.RetornaMatrizPeca(pos) != null && tab.RetornaMatrizPeca(pos).cor != cor)
                {
                    Peca p = tab.RetornaMatrizPeca(pos);
                    if (p is Rei)
                    {
                        while (p != pecaOrigem)
                        {                           
                            pos.coluna = pos.coluna - 1;
                            p = tab.RetornaMatrizPeca(pos);
                            mat[pos.linha, pos.coluna] = true;
                        }

                        break;
                    }
                }
                pos.coluna = pos.coluna + 1;
            }

            //ESQUERDA
            pos.DefinirValores(posicao.linha, posicao.coluna -1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                if (tab.RetornaMatrizPeca(pos) != null && tab.RetornaMatrizPeca(pos).cor != cor)
                {
                    Peca p = tab.RetornaMatrizPeca(pos);
                    if (p is Rei)
                    {
                        while (p != pecaOrigem)
                        {                           
                            pos.coluna = pos.coluna + 1;
                            p = tab.RetornaMatrizPeca(pos);
                            mat[pos.linha, pos.coluna] = true;
                        }

                        break;
                    }
                }
                pos.coluna = pos.coluna - 1;
            }

            return mat;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            //ACIMA
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            while(tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if(tab.RetornaMatrizPeca(pos) != null && tab.RetornaMatrizPeca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha - 1;
            }

            //ABAIXO
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.RetornaMatrizPeca(pos) != null && tab.RetornaMatrizPeca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha + 1;
            }

            //DIREITA
            pos.DefinirValores(posicao.linha, posicao.coluna +1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.RetornaMatrizPeca(pos) != null && tab.RetornaMatrizPeca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }

            //ESQUERDA
            pos.DefinirValores(posicao.linha, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.RetornaMatrizPeca(pos) != null && tab.RetornaMatrizPeca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }

            return mat;
        }

        public override string ToString()
            {
                return "T";
            }
    }
}