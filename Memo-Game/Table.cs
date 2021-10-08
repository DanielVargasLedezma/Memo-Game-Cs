using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Game
{
    class Table
    {
        private readonly Casilla[,] casillas;
        private readonly int row_count;
        private readonly int col_count;

        private readonly Random _random;

        public Table()
        {
            _random = new Random();

            row_count = 4;
            col_count = 4;

            casillas = new Casilla[row_count, col_count];

            for(int i = 0; i < row_count; i++)
            {
                for(int j = 0; j < col_count; j++)
                {
                    casillas[i, j] = new Casilla();
                }
            }

            RandomizarTablero();
        }

        public Table(int rows, int cols)
        {
            _random = new Random();

            row_count = rows;
            col_count = cols;

            casillas = new Casilla[row_count, col_count];

            for (int i = 0; i < row_count; i++)
            {
                for (int j = 0; j < col_count; j++)
                {
                    casillas[i, j] = new Casilla();
                }
            }

            RandomizarTablero();
        }

        public int Col_Count
        {
            get { return col_count; }
        }

        public int Row_Count
        {
            get { return col_count; }
        }

        public Casilla[,] Casillas
        {
            get { return casillas; }
        }

        private int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        private void RandomizarTablero()
        {
            int total = col_count * row_count;

            int tam = total / 2;

            char[] letras = new char[tam]; 
            
            char inicio = 'A';

            for (int i = 0; i < tam; i++)
            {
                letras[i] = inicio;

                inicio++;
            }

            int numRand, contador = 0;

            for (int i = 0; i < row_count; i++)
            {
                for (int j = 0; j < col_count; j++)
                {
                    numRand = RandomNumber(0, tam);

                    while (CheckIfTwice(letras[numRand]))
                    {
                        numRand = RandomNumber(0, tam);
                    }

                    casillas[i, j].Letra = letras[numRand];

                    contador++;

                    if (contador == total)
                    {
                        break;
                    }
                }
            }
        }

        private bool CheckIfTwice(char letra)
        {
            int contador = 0;

            for (int i = 0; i < row_count; i++)
            {
                for (int j = 0; j < col_count; j++)
                {
                    if (casillas[i, j].Letra == letra)
                    {
                        contador++;

                        if (contador == 2)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool CheckIfValidRow(int row)
        {
            if (row < row_count && row >= 0)
            {
                return true;
            }

            return false;
        }

        public bool CheckIfValidCol(int col)
        {
            if (col < col_count && col >= 0)
            {
                return true;
            }

            return false;
        }

        public void HideRevealed()
        {
            for (int i = 0; i < row_count; i++)
            {
                for (int j = 0; j < col_count; j++)
                {
                    if (casillas[i, j].Estado == 2)
                    {
                        casillas[i, j].Estado = 1;
                    }
                }
            }
        }

        public bool CheckIfRevealedAreEquals()
        {
            int i_first = -1, j_first = -1;

            for (int i = 0; i < row_count; i++)
            {
                for (int j = 0; j < col_count; j++)
                {
                    if (casillas[i, j].Estado == 2)
                    {
                        i_first = i;
                        j_first = j;
                        break;
                    }
                }
            }

            for (int i = 0; i < row_count; i++)
            {
                for (int j = 0; j < col_count; j++)
                {
                    if (i != i_first || j != j_first)
                    {
                        if (casillas[i, j].Estado == 2)
                        {
                            if (casillas[i, j].Letra == casillas[i_first, j_first].Letra)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        public int[] ObtenerPosicionesRevealed()
        {
            int[] posiciones = new int[4];

            for(int i = 0; i < 4; i++)
            {
                posiciones[i] = -1;
            }

            for (int i = 0; i < row_count; i++)
            {
                for (int j = 0; j < col_count; j++)
                {
                    if (casillas[i, j].Estado == 2)
                    {
                        posiciones[0] = i;
                        posiciones[1] = j;
                    }
                }
            }

            for (int i = 0; i < row_count; i++)
            {
                for (int j = 0; j < col_count; j++)
                {
                    if (i != posiciones[0] || j != posiciones[1])
                    {
                        if (casillas[i, j].Estado == 2)
                        {
                            posiciones[2] = i;
                            posiciones[3] = j;
                            return posiciones;
                        }
                    }
                }
            }

            return posiciones;
        }

        public void DiscoverIn(int[] posiciones)
        {
            casillas[posiciones[0], posiciones[1]].Estado = 3;
            casillas[posiciones[2], posiciones[3]].Estado = 3;
        }
    }
}
