//---------------------------------------------------------------------------------
// <copyright file="GameLogic.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta clase contiene la lógica del juego.
    /// </summary>
    public class GameLogic
    {
        private char[][] board;
        private BoardSize boardSize;
        private List<int> shipCellList;
        private int numberAttack;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GameLogic"/>.
        /// </summary>
        /// <param name="board">Tablero.</param>
        /// <param name="boardSize"> Tamaño del tablero. </param>
        /// <param name="totalShips"> Total de barcos que hay que hundir. </param>
        public GameLogic(Board board, BoardSize boardSize, int totalShips)
        {
            this.board = board.GetBoard();
            this.boardSize = boardSize;
            this.InitializeShipCellList(totalShips);
        }

        /// <summary>
        /// Verifica el ataque.
        /// </summary>
        /// <param name="row"> Fila ingresada. </param>
        /// <param name="column"> Columna ingresada. </param>
        /// <returns> Hit or miss (true or false). </returns>
        public bool VerifyAttack(int row, int column)
        {
            return this.board[row][column] == 'S'; // "S" representa un barco.
        }

        /// <summary>
        /// Ubica los barcos al iniciar la partida.
        /// </summary>
        /// <param name="ship"> Barco. </param>
        /// <param name="row"> Fila del tablero. </param>
        /// <param name="column"> Columna del tablero. </param>
        /// <returns></returns>
        public bool PlaceShip(Ship ship, int row, int column)
        {
            if (this.board[row][column] == 'S')
            {
                return false;
            }
            else
            { 
                this.board[row][column]='S';
                return true;
            }
        }
        
        /// <summary>
        /// Ataque.
        /// </summary>
        /// <param name="row"> Fila ingresada. </param>
        /// <param name="column"> Columna ingresada. </param>
        public void Attack(int row, int column)
        {
            if (this.VerifyAttack(row, column))
            {
                Console.WriteLine("Le diste a un barco.");
                this.VerifyShipCellList(); // Disminuir el número de barcos.
            }
            else
            {
                Console.WriteLine("No le diste a ningún barco.");
            }
        }

        /// <summary>
        /// Para que funcione el test.
        /// </summary>
        /// <returns> Excepción. </returns>
        /// <exception cref="NotImplementedException"> Excepción si no está implementada la clase. </exception>
        public object GetShipCellList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determina el turno del jugador.
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
        /// <returns> Excepción. </returns>
        public object GetBoard()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Crea una lista con la cantidad de barcos.
        /// </summary>
        /// <param name="totalShips"> Cantidad de barcos para hundir. </param>
        private void InitializeShipCellList(int totalShips)
        {
            this.shipCellList = new List<int>();
            for (int i = 0; i < totalShips; i++)
            {
                this.shipCellList.Add(1); // Inicializa la lista con la cantidad total de barcos.
            }
        }

        /// <summary>
        /// Si le pega a un barco disminuye en 1 la cantidad de barcos.
        /// </summary>
        private void VerifyShipCellList()
        {
            if (this.shipCellList.Count > 0)
            {
                this.shipCellList[0]--; // Se encarga de restar 1 al número restante de barcos.
                if (this.shipCellList[0] == 0)
                {
                    this.shipCellList.RemoveAt(0); // Eliminar el barco si ya no quedan celdas.
                }
            }
        }
    }
}
