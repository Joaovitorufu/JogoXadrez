using tabuleiro;
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

                PosicaoXadrez pos = new PosicaoXadrez('a', 1);

                Console.WriteLine(pos.toPosicao());



                Tela.imprimirTabuleiro(tab);

            }catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}