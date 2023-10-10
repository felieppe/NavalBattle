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
        private Board board;
        private BoardSize boardSize;
        private List<int> shipCellList;
        private int numberAttack;
        private List<Ship> Ships = new List<Ship>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GameLogic"/>.
        /// </summary>
        /// <param name="board">Tablero.</param>
        /// <param name="boardSize"> Tamaño del tablero. </param>
        /// <param name="totalShips"> Total de barcos que hay que hundir. </param>
        public GameLogic(Board board, BoardSize boardSize, int totalShips)
        {
            this.board = board;
            this.boardSize = boardSize;
            this.InitializeShipCellList(totalShips);
        }

        /// <summary>
        /// Verifica el ataque.
        /// </summary>
        /// <param name="column"> Columna ingresada. </param>
        /// <param name="row"> Fila ingresada. </param>
        /// <returns> Hit or miss (true or false). </returns>
        public bool VerifyAttack(int row, int column)
        {
            return this.board.GetBoard()[column][row] == 'S'; // "S" representa un barco.
        }

        /// <summary>
        /// Ubica los barcos al iniciar la partida.
        /// </summary>
        /// <param name="ship"> Barco. </param>
        /// <param name="row"> Fila del tablero. </param>
        /// <param name="column"> Columna del tablero. </param>
        /// <param name="facing"> Sentido hacia donde apunta el barco. </param>
        /// <returns></returns>
        public bool PlaceShip(Ship ship, char row, int column, string facing)
        {
            if (!CheckBoundaries(LetterToNumber(row), column)) { return false; }

            if (this.board.GetBoard()[column][LetterToNumber(row)] == 'S') { return false; }
            else
            {
                for (var x = 0; x < ship.Length; x++) {
                    switch (facing.ToUpper()) {
                        case "UP":
                            if (x == 0) {
                                if (!CheckBoundaries(LetterToNumber(row), column - (ship.Length - 1))) { return false; }

                                for (var y = 1; y < ship.Length; y++) {
                                    if (this.board.GetBoard()[column - y][LetterToNumber(row)] == 'S') { return false; }
                                }
                            }

                            ship.AddCellCoord(LetterToNumber(row), column - x);
                            this.board.GetBoard()[column - x][LetterToNumber(row)] = 'S';
                            break;
                        case "DOWN":
                            if (x == 0) {
                                if (!CheckBoundaries(LetterToNumber(row), column + (ship.Length - 1))) { return false; }

                                for (var y = 1; y < ship.Length; y++) {
                                    if (this.board.GetBoard()[column + y][LetterToNumber(row)] == 'S') { return false; }
                                }
                            }

                            ship.AddCellCoord(LetterToNumber(row), column + x);
                            this.board.GetBoard()[column + x][LetterToNumber(row)] = 'S';
                            break;
                        case "RIGHT":
                            if (x == 0) { 
                                if (!CheckBoundaries(LetterToNumber(row) + (ship.Length - 1), column)) { return false; } 

                                for (var y = 1; y < ship.Length; y++) {
                                    if (this.board.GetBoard()[column][LetterToNumber(row) + y] == 'S') { return false; }
                                }
                            }

                            ship.AddCellCoord(LetterToNumber(row) + x, column);
                            this.board.GetBoard()[column][LetterToNumber(row) + x] = 'S';
                            break;
                        case "LEFT":
                            if (x == 0) { 
                                if (!CheckBoundaries(LetterToNumber(row) - (ship.Length - 1), column)) { return false; }

                                for (var y = 1; y < ship.Length; y++) {
                                    if (this.board.GetBoard()[column][LetterToNumber(row) - y] == 'S') { return false; }
                                }
                            }

                            ship.AddCellCoord(LetterToNumber(row) - x, column);
                            this.board.GetBoard()[column][LetterToNumber(row) - x] = 'S';
                            break;
                    }
                }
            }

            this.Ships.Add(ship);
            return true;
        }
        
        /// <summary>
        /// Ataque.
        /// </summary>
        /// <param name="row"> Fila ingresada. </param>
        /// <param name="column"> Columna ingresada. </param>
        public void Attack(char row, int column)
        {
            if (this.VerifyAttack(LetterToNumber(row), column))
            {
                Console.WriteLine("Le diste a un barco.");

                this.DestroyShip(LetterToNumber(row), column);
                this.VerifyShipCellList(); // Disminuir el número de barcos.
            }
            else
            {
                Console.WriteLine("No le diste a ningún barco.");
            }
        }

        /// <summary>
        /// Devuelve el valor de la variable shipCellList.
        /// </summary>
        /// <returns> Lista con valores tipo int.</returns>
        public List<int> GetShipCellList()
        {
            return this.shipCellList;
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
        /// Devuelve el tablero actualizado por el GameLogic.
        /// </summary>
        /// <returns>El tablero</returns>
        public Board GetBoard()
        {
            return this.board;
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

        /// <summary>
        /// Devuelve el numero correspodiente a la letra en orden alfabetico.
        /// </summary>
        /// <param name="row">Fila</param>
        /// <returns>El tablero</returns>
        private int LetterToNumber(char row) {
            return char.ToUpper(row) - 'A' + 1;
        }

        /// <summary>
        /// Verifica que una coordenada no esté fuera de los limites del mapa.
        /// </summary>
        /// <param name="row">Fila</param>
        /// <param name="column">Columna</param>
        /// <returns>true/false</returns>
        private bool CheckBoundaries(int row, int column) {
            if ((row >= 1 && row <= 20) && ((column >= 1 && column <= 10) || (column >= 11 && column <= 20))) {
                return true;
            } else { return false; }
        }

        /// <summary>
        /// Destruye el barco del tablero.
        /// </summary>
        /// <param name="row">Fila</param>
        /// <param name="column">Columna</param>
        /// <returns>true/false</returns>
        private bool DestroyShip(int row, int column) {
            Ship foundedShip = null;
            foreach (Ship ship in this.Ships) {
                if (!ship.GetSunken()) {
                    foreach (int[] arr in ship.GetCoords()) {
                        int[] expected = { row, column };
                        if (arr[0] == expected[0] && arr[1] == expected[1]) {
                            foundedShip = ship;
                            this.Ships[this.Ships.IndexOf(ship)].Sink();

                            break;
                        }
                    }
                }
            }

            if (foundedShip != null) {
                foreach (int[] arr in foundedShip.GetCoords()) {
                    this.board.GetBoard()[arr[1]][arr[0]] = 'X';
                }
                return true;
            } else { return false; }
        }
    }
}
