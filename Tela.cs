using tabuleiro;
using System;
using xadrez;
using System.Collections.Generic;

namespace xadrez_console
{
    internal class Tela
    {

        public static void imprimirPartida(PartidaDeXadrez partida)
        {

            imprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine("Jogador Atual: " + partida.JogadorAtual);

            if (partida.xeque)
            {
                Console.WriteLine($"JOGADOR {partida.JogadorAtual} EM XEQUE!" );
            }
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Pecas capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i< tab.Linhas; i++)
            {
                //imprime na tela a numeração da linha
                Console.Write(8-i+" "); 
                for (int j = 0; j < tab.Linhas; j++)
                {
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.Write("  A B C D E F G H");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis )
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++)
            {
                //imprime na tela a numeração da linha
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Linhas; j++)
                {
                    if (posicoesPossiveis[i,j] == true)
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                        
                        imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.Write("  A B C D E F G H");
            Console.BackgroundColor = fundoOriginal;
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {                
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            int linha = int.Parse(s[1] + "");
            char coluna = s[0];
            return new PosicaoXadrez(coluna,linha);
        }
    }
}
