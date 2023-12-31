﻿using tabuleiro;

namespace tabuleiro
{
    internal abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get;protected set; }
        public int QtdMovimentos { get;protected set; }
        public Tabuleiro Tab { get;protected set; }
        
        public Peca(Tabuleiro tab, Cor cor)
        {
            Posicao = null;
            Tab = tab;
            Cor = cor;
            QtdMovimentos = 0;
        }

        public void incrementarQtdMovimentos()
        {
            QtdMovimentos++;
        }
        public void decrementarQtdMovimentos()
        {
            QtdMovimentos--;
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            foreach (var valor in mat)
            {
                if (valor)
                {
                    return true;
                }                
            }
            return false;
        }

        public bool movimentoPossivel(Posicao pos)
        {
            return movimentosPossiveis()[pos.Linha,pos.Coluna];
        }

        public abstract bool[,] movimentosPossiveis();

        
    }
}
