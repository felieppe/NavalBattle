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
        private Game game;
        private Board board;
        private Board board2;
        private BoardSize boardSize;
        private int numberAttack;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GameLogic"/>.
        /// </summary>
        /// <param name="game"=Juego.</param>
        /// <param name="board">Tablero.</param>
        /// <param name="boardSize"> Tamaño del tablero. </param>

        public GameLogic(Game game, Board board, Board board2)
        {
            this.game = game;
            this.board = board;
            this.board2 = board2;
            this.boardSize = board.GetBoardSize();
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
            if (this.game.GetShips().Count >= this.game.GetTotalShips()) { return false; }

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

                            //ship.AddCellCoord(LetterToNumber(row), column - x);
                            this.game.AddShipCoords(ship.GetId(), LetterToNumber(row), column - x);
                            this.board.GetBoard()[column - x][LetterToNumber(row)] = 'S';
                            break;
                        case "DOWN":
                            if (x == 0) {
                                if (!CheckBoundaries(LetterToNumber(row), column + (ship.Length - 1))) { return false; }

                                for (var y = 1; y < ship.Length; y++) {
                                    if (this.board.GetBoard()[column + y][LetterToNumber(row)] == 'S') { return false; }
                                }
                            }

                            this.game.AddShipCoords(ship.GetId(), LetterToNumber(row), column + x);
                            this.board.GetBoard()[column + x][LetterToNumber(row)] = 'S';
                            break;
                        case "RIGHT":
                            if (x == 0) { 
                                if (!CheckBoundaries(LetterToNumber(row) + (ship.Length - 1), column)) { return false; } 

                                for (var y = 1; y < ship.Length; y++) {
                                    if (this.board.GetBoard()[column][LetterToNumber(row) + y] == 'S') { return false; }
                                }
                            }

                            this.game.AddShipCoords(ship.GetId(), LetterToNumber(row) + x, column);
                            this.board.GetBoard()[column][LetterToNumber(row) + x] = 'S';
                            break;
                        case "LEFT":
                            if (x == 0) { 
                                if (!CheckBoundaries(LetterToNumber(row) - (ship.Length - 1), column)) { return false; }

                                for (var y = 1; y < ship.Length; y++) {
                                    if (this.board.GetBoard()[column][LetterToNumber(row) - y] == 'S') { return false; }
                                }
                            }

                            this.game.AddShipCoords(ship.GetId(), LetterToNumber(row) - x, column);
                            this.board.GetBoard()[column][LetterToNumber(row) - x] = 'S';
                            break;
                    }
                }
            }

            this.game.AddShip(ship);
            return true;
        }
        
        /// <summary>
        /// Ataque.
        /// </summary>
        /// <param name="row"> Fila ingresada. </param>
        /// <param name="column"> Columna ingresada. </param>
        public void Attack(char row, int column)
        {
            if (this.VerifyAttack(LetterToNumber(row), column)) {
                this.DestroyShip(LetterToNumber(row), column);
            }
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
        /// Devuelve el numero correspondiente a la letra en orden alfabético.
        /// </summary>
        /// <param name="row">Fila</param>
        /// <returns>El tablero</returns>
        private static int LetterToNumber(char row)
        {
            row = Char.ToUpper(row);
            return char.ToUpper(row) - 'A' + 1;
        }

        /// <summary>
        /// Verifica que una coordenada no esté fuera de los limites del mapa.
        /// </summary>
        /// <param name="row">Fila</param>
        /// <param name="column">Columna</param>
        /// <returns>true/false</returns>
        private static bool CheckBoundaries(int row, int column)
        {
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
        private bool DestroyShip(int row, int column)
        {
            Ship foundedShip = null;
            string foundedShipId = null;
            foreach (Ship ship in this.game.GetShips()) {
                string shipId = ship.GetId();
                Console.WriteLine("SHIP ID | " + shipId);
                if (!ship.GetSunken()) {
                    foreach (Coords coord in this.game.GetShipsCoords()) {
                        if (coord.GetShipId() != shipId) { break; }
                        int[] expected = { row, column };

                        //Console.WriteLine("EXPECTED | " + coord.GetX() + "/" + coord.GetY() + " -> " + expected[0] + "/" + expected[1]);
                        if (coord.GetX() == expected[0] && coord.GetY() == expected[1]) {
                            //Console.WriteLine("FOUNDED");
                            foundedShip = ship;
                            foundedShipId = shipId;

                            break;
                        }
                    }
                }
            }

            if (foundedShip != null)
            {
                List<Ship> ships = this.game.GetShips();
                            
                Ship updatedShip = ships[ships.IndexOf(foundedShip)];
                updatedShip.Sink();

                foreach (Coords coord in this.game.GetShipsCoords()) {
                    if (coord.GetShipId() != foundedShipId) { break; }
                    this.board.GetBoard()[coord.GetY()][coord.GetX()] = 'X';
                }

                this.game.UpdateShip(foundedShip, updatedShip);
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Devuelve el numero de ataques.
        /// </summary>
        /// <param name="numberAttack"> Npumero de ataques. </param>
        /// <returns> El número de ataques. </returns>
        public double GetNumberAttack()
        {
            return this.numberAttack;
        }
    }
}
