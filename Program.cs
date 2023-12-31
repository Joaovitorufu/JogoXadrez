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


                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partida);
                    
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tab.peca(origem).movimentosPossiveis();
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.Tab, posicoesPossiveis);


                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem,destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    catch(IndexOutOfRangeException e)
                    {
                        Console.WriteLine("Dados incorretos, digite enter e tente novamente");
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.imprimirPartida(partida);
                                   

            }catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}