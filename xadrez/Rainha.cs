using tabuleiro;

namespace xadrez_console.xadrez
{
    internal class Rainha : Peca
    {
        public Rainha(Tabuleiro tab, Cor cor) : base(tab, cor)
        {}

        public override string ToString()
        {
            return "Q";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != this.Cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != this.Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            //abaixo
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != this.Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }
            //direita
            pos.definirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != this.Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            //esquerda
            pos.definirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != this.Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            //diagonal direita inferior
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != this.Cor)
                {
                    break;
                }
                pos.Linha += 1;
                pos.Coluna += 1;
            }

            //diagonal esquerda inferior
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != this.Cor)
                {
                    break;
                }
                pos.Linha += 1;
                pos.Coluna -= 1;
            }
            //diagonal esquerda superior
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != this.Cor)
                {
                    break;
                }
                pos.Linha -= 1;
                pos.Coluna -= 1;
            }
            //diagonal direita superior
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != this.Cor)
                {
                    break;
                }
                pos.Linha += 1;
                pos.Coluna -= 1;
            }


            return mat;
        }
    }
}
