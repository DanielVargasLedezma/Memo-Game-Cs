using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Game
{
    class TableController
    {
        private readonly Table table;
        private int num_movimientos;
        private int num_parejas;
        private int consecutive_moves;

        public TableController()
        {
            table = new Table();
            num_movimientos = 0;
            num_parejas = 0;
        }

        public int Num_Movimientos
        {
            get { return num_movimientos; }
            set { num_movimientos = value; }
        }

        public int Num_Parejas
        {
            get { return num_parejas; }
            set { num_parejas = value; }
        }
        
        public int Consecutive_Moves
        {
            get { return consecutive_moves; }
            set { consecutive_moves = value; }
        }

        public bool RevealIfPossible(int row, int col)
        {
            for (int i = 0; i < table.Row_Count; i++)
            {
                for (int j = 0; j < table.Col_Count; j++)
                {
                    if (i == row && j == col)
                    {
                        if (table.Casillas[i, j].Estado == 1)
                        {
                            table.Casillas[i, j].Estado = 2;

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public void HideRevealed()
        {
            table.HideRevealed();
        }

        public bool CheckIfRevealedAreEquals()
        {
            return table.CheckIfRevealedAreEquals();
        }

        public char GetValue(int i, int j)
        {
            return table.Casillas[i, j].Letra;
        }

        public int GetState(int i, int j)
        {
            return table.Casillas[i, j].Estado;
        }

        public int GetCols()
        {
            return table.Col_Count;
        }

        public int GetRows()
        {
            return table.Row_Count;
        }

        public int[] PosRevealed()
        {
            return table.ObtenerPosicionesRevealed();
        }

        public void DiscoverIn(int[] posiciones)
        {
            table.DiscoverIn(posiciones);
        }
    }
}
