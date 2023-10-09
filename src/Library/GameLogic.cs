git using System;
using System.Collections.Generic;

namespace Library
{
    public class GameLogic
    {
        private char[][] board;
        private BoardSize boardSize;
        private List<int> shipCellList;
        private int numberAttack;

        /// <summary>
        /// GameLogic Class
        /// </summary>
        /// <param name="boardSize"></param>
        /// <param name="totalShips"></param>
        public GameLogic(BoardSize boardSize, int totalShips)
        {
            this.boardSize = boardSize;
            this.InitializeShipCellList(totalShips);
        }

        /// <summary>
        /// Verifica el ataque.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public bool VerifyAttack(int row, int column)
        {
            return this.board[row][column] == 'S'; /* "S" representa un barco */
        }

        /// <summary>
        /// Posiciona barco
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void PlaceShip(int row, int column)
        {
            this.board[row][column] = 'B';
        }

        /// <summary>
        /// Ataque.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
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

        /// <summary>
        /// Crea una lista con la cantidad de barcos.
        /// </summary>
        /// <param name="totalShips"></param>
        private void InitializeShipCellList(int totalShips)
        {
            this.shipCellList = new List<int>();
            for (int i = 0; i < totalShips; i++)
            {
                this.shipCellList.Add(1); // Inicializa la lista con la cantidad total de barcos
            }
        }

        /// <summary>
        /// Si le pega a un barco disminuye en 1 la cantidad de barcos.
        /// </summary>
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

        /// <summary>
        /// Para que funcione el test.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object GetShipCellList()
        {
            throw new NotImplementedException();
        }
        public void Turn()
        {
            if (numberAttack % 2 == 0)
            {
                Console.WriteLine(numberAttack + " es par, turno del Jugador 2");
            }
            else
            {
                Console.WriteLine(numberAttack + " es impar, turno del Jugador 1");
            }
        }

        /// <summary>
        /// Para que funcione el test.
        /// </summary>
        /// <returns></returns>
        public object GetBoard()
        {
            throw new NotImplementedException();
        }
    }
}
