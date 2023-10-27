using tabuleiro;
using System;
using xadrez;

namespace xadrez_console
{
    internal class Tela
    {
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
