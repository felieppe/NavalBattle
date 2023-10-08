using System;
using System.Collections.Generic;

namespace BattleShip
{
    public class GameLogic
    {
        private char[,] board;
        private BoardSize boardSize;
        private List<int> ShipCellList;

        public GameLogic(BoardSize size, int totalShips)
        {
            boardSize = size;
            InitializeBoard();
            InitializeShipCellList(totalShips);
        }

        private void InitializeBoard()
        {
            board = new char[boardSize.Rows, boardSize.Columns];
            for (int i = 0; i < boardSize.Rows; i++)
            {
                for (int j = 0; j < boardSize.Columns; j++)
                {
                    board[i, j] = "Empty"; /* "Empty" representa celdas vacías */
                }
            }
        }
        private void InitializeShipCellList(int totalShips)
        {
            ShipCellList = new List<int>();
            for (int i = 0; i < totalShips; i++)
            {
                ShipCellList.Add(1); // Inicializa la lista con la cantidad total de barcos
            }
        }
        public void DisplayBoard()
        {
            for (int i = 0; i < boardSize.Rows; i++)
            {
                for (int j = 0; j < boardSize.Columns; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public bool VerifyAttack(int row, int column)
        {
            return board[row, column] == 'S'; /* "S" representa un barco */
        }

        public void PlaceShip(int row, int column)
        {
            board[row, column] = 'B';
        }

        public void Attack(int row, int column)
        {
            if (VerifyAttack(row, column))
            {
                Console.WriteLine("Le diste a un barco.");
                VerifyShipCellList(); // Disminuir el número de barcos
            }
            else
            {
                Console.WriteLine("No le diste a ningun barco.");
            }
        }
        private void VerifyShipCellList()
        {
            if (ShipCellList.Count > 0)
            {
                ShipCellList[0]--; /* Se encarga de restar 1 al número restante de barcos */
                if (ShipCellList[0] == 0)
                {
                    ShipCellList.RemoveAt(0); /* Eliminar el barco si ya no quedan celdas */
                }
            }
        }
    }
}
