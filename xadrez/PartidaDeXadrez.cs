using System;
using tabuleiro;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro;
using xadrez_console.xadrez;

namespace xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro Tab { get;private set;}
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public bool xeque { get; private set; }



        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            Pecas.Add(peca);
        }


        private void colocarPecas()
        {
            //colocando pecas brancas
            //torres
            colocarNovaPeca('a', 1, new Torre(Tab, Cor.Branca));
            colocarNovaPeca('h', 1, new Torre(Tab, Cor.Branca));
            //cavalos
            colocarNovaPeca('b', 1, new Cavalo(Tab, Cor.Branca));
            colocarNovaPeca('g', 1, new Cavalo(Tab, Cor.Branca));
            //bispo
            colocarNovaPeca('c', 1, new Bispo(Tab, Cor.Branca));
            colocarNovaPeca('f', 1, new Bispo(Tab, Cor.Branca));
            //rei
            colocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));
            //rainha
            colocarNovaPeca('e', 1, new Rainha(Tab, Cor.Branca));
            //peoes
            colocarNovaPeca('a', 2, new Peao(Tab, Cor.Branca));
            colocarNovaPeca('b', 2, new Peao(Tab, Cor.Branca));
            colocarNovaPeca('c', 2, new Peao(Tab, Cor.Branca));
            colocarNovaPeca('d', 2, new Peao(Tab, Cor.Branca));
            colocarNovaPeca('e', 2, new Peao(Tab, Cor.Branca));
            colocarNovaPeca('f', 2, new Peao(Tab, Cor.Branca));
            colocarNovaPeca('g', 2, new Peao(Tab, Cor.Branca));
            colocarNovaPeca('h', 2, new Peao(Tab, Cor.Branca));





            //colocando pecas pretas
            //torres
            colocarNovaPeca('a', 8, new Torre(Tab, Cor.Preta));
            colocarNovaPeca('h', 8, new Torre(Tab, Cor.Preta));
            //cavalos
            colocarNovaPeca('g', 8, new Cavalo(Tab, Cor.Preta));
            colocarNovaPeca('b', 8, new Cavalo(Tab, Cor.Preta));
            //bispos
            colocarNovaPeca('f', 8, new Bispo(Tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Bispo(Tab, Cor.Preta));
            //rei
            colocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));
            //Rainha
            colocarNovaPeca('e', 8, new Rainha(Tab, Cor.Preta));
            //peoes
            colocarNovaPeca('a', 7, new Peao(Tab, Cor.Preta));
            colocarNovaPeca('b', 7, new Peao(Tab, Cor.Preta));
            colocarNovaPeca('c', 7, new Peao(Tab, Cor.Preta));
            colocarNovaPeca('d', 7, new Peao(Tab, Cor.Preta));
            colocarNovaPeca('e', 7, new Peao(Tab, Cor.Preta));
            colocarNovaPeca('f', 7, new Peao(Tab, Cor.Preta));
            colocarNovaPeca('g', 7, new Peao(Tab, Cor.Preta));
            colocarNovaPeca('h', 7, new Peao(Tab, Cor.Preta));




        }

        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            
            Peca p = Tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pecaCapturada = Tab.retirarPeca(destino);
            Tab.colocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem,Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tab.retirarPeca(destino);
            p.decrementarQtdMovimentos();
            if(pecaCapturada != null)
            {
                Tab.colocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            Tab.colocarPeca(p, origem);
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {

            Peca pecaCapturada = executaMovimento(origem, destino);
            if (estaEmXeque(JogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Voce não pode se colocar em xeque");
            }

            if (estaEmXeque(corAdversaria(JogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }
            if (testeXequemate(corAdversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                mudaJogador();

            }

            
        }


        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in Pecas)
            {
                if(x.Cor == cor)
                {
                    aux.Add(x);
                }

            }
            //ExceptWith --> retira as pecas capturadas da cor especificada.
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in Capturadas)
            {
                if(x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public bool estaEmXeque(Cor cor)
        {
            Peca r = rei(cor);
            if(r == null)
            {
                throw new TabuleiroException("Não tem rei da cor" + cor + " no tabuleiro!");
            }
            foreach (Peca x in pecasEmJogo(corAdversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[r.Posicao.Linha, r.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testeXequemate(Cor cor)
        {
            if (!estaEmXeque(cor))
            {
                return false;
            }
            foreach(Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.movimentosPossiveis();
                for(int i = 0; i < Tab.Linhas; i++)
                {
                    for( int j = 0; j < Tab.Colunas; j ++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executaMovimento(origem,destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private Cor corAdversaria(Cor cor)
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

        private Peca rei (Cor cor)
        {
            foreach (Peca x in pecasEmJogo(cor))
            {
                if(x is Rei)
                {
                    return x;
                }
            }
                return null;
        }

        private void mudaJogador()
        {
            if(JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if(Tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");

            }
            if(JogadorAtual != Tab.peca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!Tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existe movimentos possivel para essa peça!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem,Posicao destino)
        {
            if(!Tab.peca(origem).movimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino invalida!");
            }
        }
    }
}
