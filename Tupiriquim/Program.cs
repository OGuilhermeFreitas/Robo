using System;

namespace Tupiriquim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strQuadrilatero, str_posicao_inicial, str_movimento;
            int minimoX = 0, minimoY = 0, maximoX, maximoY, posicaoXrobo, posicaoYrobo; ;
            char bussola;
            bool continuar;

            do
            {
                Console.Write(" Tupiniquim \nTamanho da área (por exemplo 5 5) : ");
                strQuadrilatero = Console.ReadLine();
                string[] quadrilatero = strQuadrilatero.Split(' ');
                maximoX = int.Parse(quadrilatero[0]);
                maximoY = int.Parse(quadrilatero[1]);

                Console.WriteLine("\nInforme a posição inicial do robo, por exemplo 1 1 N \n[N] Norte, [S] Sul, [L] Leste, [O] Oeste");               
                Console.Write("\nPosição Inicial: ");
                str_posicao_inicial = Console.ReadLine().ToUpper();
                string[] posicao_inicial = str_posicao_inicial.Split(' ');

                posicaoXrobo = int.Parse(posicao_inicial[0]);
                posicaoYrobo = int.Parse(posicao_inicial[1]);
                bussola = Convert.ToChar(posicao_inicial[2]);

                Console.WriteLine("\nInforme seus comandos ao robo, exemplo: EMEMEMEMM (por favoe, tenha certeza de digitar em CAPSLOCK) " +
                    "\n\t[M] Mover, [E] Esquerda, [D] Direita : ");         
                str_movimento = Console.ReadLine().ToUpper();
                char[] ordens = str_movimento.ToCharArray();

                for (int i = 0; i < ordens.Length; i++)
                {
                    if (ordens[i] == 'E')
                    {
                        switch (bussola)
                        {
                            case 'N':
                                bussola = 'O';
                                break;
                            case 'S':
                                bussola = 'L';
                                break;
                            case 'L':
                                bussola = 'N';
                                break;
                            case 'O':
                                bussola = 'S';
                                break;
                        }
                    }
                    if (ordens[i] == 'D')
                    {
                        switch (bussola)
                        {
                            case 'N':
                                bussola = 'L';
                                break;
                            case 'S':
                                bussola = 'O';
                                break;
                            case 'L':
                                bussola = 'S';
                                break;
                            case 'O':
                                bussola = 'N';
                                break;
                        }
                    }
                    if (ordens[i] == 'M')
                    {
                        if (bussola == 'N' && maximoY >= (posicaoYrobo + 1))
                        {
                            posicaoYrobo++;
                        }
                        else if (bussola == 'S' && minimoY <= (posicaoYrobo - 1))
                        {
                            posicaoYrobo--;
                        }
                        else if (bussola == 'L' && maximoX >= (posicaoXrobo + 1))
                        {
                            posicaoXrobo++;
                        }
                        else if (bussola == 'O' && minimoX <= (posicaoXrobo - 1))
                        {
                            posicaoXrobo--;
                        }
                    }
                }
                Console.WriteLine($"\nCoordenadas finais do robo: { posicaoXrobo} { posicaoYrobo } { bussola}");

                Console.Write("\n Use [S] para adicionar mais um robô para o mapeamento: ");
                char mRobo = char.Parse(Console.ReadLine());
                continuar = mRobo == 'S';
            }
            while (continuar == true);
            Console.ReadKey();
        }
    }
}
