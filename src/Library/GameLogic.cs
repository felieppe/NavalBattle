
using System;
using System.Collections.Generic;

namespace BattleShip
{
    public class GameLogic
    {
        private char[][] board;
        private BoardSize boardSize;
        private List<int> shipCellList;

        public GameLogic(BoardSize boardSize, int totalShips)
        {
            this.boardSize = boardSize;
            this.InitializeBoard();
            this.InitializeShipCellList(totalShips);
        }

        public void DisplayBoard() // Va en printer
        {
            for (int i = 0; i < this.boardSize.Rows; i++)
            {
                for (int j = 0; j < this.boardSize.Columns; j++)
                {
                    Console.Write(this.board[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool VerifyAttack(int row, int column)
        {
            return this.board[row][column] == 'S'; /* "S" representa un barco */
        }

        public void PlaceShip(int row, int column)
        {
            this.board[row][column] = 'B';
        }

        public void Attack(int row, int column)
        {
            if (this.VerifyAttack(row, column))
            {
                Console.WriteLine("Le diste a un barco.");
                this.VerifyShipCellList(); // Disminuir el número de barcos
            }
            else
            {
                Console.WriteLine("No le diste a ningún barco.");
            }
        }

        private void InitializeBoard()
        {
            this.board = new char[this.boardSize.Rows][];
            for (int i = 0; i < this.boardSize.Rows; i++)
            {
                this.board[i] = new char[this.boardSize.Columns];
                for (int j = 0; j < this.boardSize.Columns; j++)
                {
                    this.board[i][j] = 'O'; /* O representa celdas vacías */
                }
            }
        }

        private void InitializeShipCellList(int totalShips)
        {
            this.shipCellList = new List<int>();
            for (int i = 0; i < totalShips; i++)
            {
                this.shipCellList.Add(1); // Inicializa la lista con la cantidad total de barcos
            }
        }

        private void VerifyShipCellList()
        {
            if (this.shipCellList.Count > 0)
            {
                this.shipCellList[0]--; /* Se encarga de restar 1 al número restante de barcos */
                if (this.shipCellList[0] == 0)
                {
                    this.shipCellList.RemoveAt(0); /* Eliminar el barco si ya no quedan celdas */
                }
            }
        }
    }
}
