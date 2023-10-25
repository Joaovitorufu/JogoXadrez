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
                    if(tab.peca(i,j)== null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Tela.imprimirPeca(tab.peca(i,j));
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            Console.Write("  A B C D E F G H");
        }

        public static void imprimirPeca(Peca peca)
        {
            if(peca.Cor == Cor.Branca)
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
