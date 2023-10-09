//---------------------------------------------------------------------------------
// <copyright file="GameLogic.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System;
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
        /// Initializes a new instance of the <see cref="GameLogic"/> class.
        /// </summary>
        /// <param name="boardSize"> Board size. </param>
        /// <param name="totalShips"> Total ships to sink. </param>
        public GameLogic(BoardSize boardSize, int totalShips)
        {
            this.boardSize = boardSize;
            this.InitializeShipCellList(totalShips);
        }

        /// <summary>
        /// Verifica el ataque.
        /// </summary>
        /// <param name="row"> Row input. </param>
        /// <param name="column"> Column input. </param>
        /// <returns> Hit or miss (true or false). </returns>
        public bool VerifyAttack(int row, int column)
        {
            return this.board[row][column] == 'S'; /* "S" representa un barco */
        }

        /// <summary>
        /// Sets ship position.
        /// </summary>
        /// <param name="row"> Row input. </param>
        /// <param name="column"> Column input. </param>
        public void PlaceShip(int row, int column)
        {
            this.board[row][column] = 'B';
        }

        /// <summary>
        /// Ataque.
        /// </summary>
        /// <param name="row"> Row input. </param>
        /// <param name="column"> Column input. </param>
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
        /// Para que funcione el test.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object GetShipCellList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines which player has to attack.
        /// </summary>
        public void Turn()
        {
            if (this.numberAttack % 2 == 0)
            {
                Console.WriteLine(this.numberAttack + " es par, turno del Jugador 2");
            }
            else
            {
                Console.WriteLine(this.numberAttack + " es impar, turno del Jugador 1");
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

        /// <summary>
        /// Crea una lista con la cantidad de barcos.
        /// </summary>
        /// <param name="totalShips"> Number of ships to sink. </param>
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
    }
}
