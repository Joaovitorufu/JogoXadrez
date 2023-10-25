﻿using tabuleiro;
using xadrez;
using xadrez_console.tabuleiro;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {


                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Rei(tab,Cor.Preta),new Posicao(3,4));
                

                



                Tela.imprimirTabuleiro(tab);

            }catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}