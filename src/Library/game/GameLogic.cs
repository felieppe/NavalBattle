//---------------------------------------------------------------------------------
// <copyright file="GameLogic.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Telegram.Bot.Requests;

namespace Library
{
    /// <summary>
    /// Esta clase contiene la lógica del juego.
    /// </summary>
    public class GameLogic
    {
        /// <summary>
        /// Instancia del juego.
        /// </summary>
        private Game game;

        /// <summary>
        /// Instancia del tablero 1.
        /// </summary>
        private Board board;

        /// <summary>
        /// filas del tablero.
        /// </summary>
        private int rows;

        /// <summary>
        /// Columnas del tablero.
        /// </summary>
        private int columns;

        /// <summary>
        /// Conteo del numero de ataques
        /// </summary>
        private int numberAttack = 1;

        private int sunkShip1;
        private int sunkShip2;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GameLogic"/>.
        /// </summary>
        /// <param name="game"> Juego. </param>
        /// <param name="board"> Tablero. </param>
        public GameLogic(Game game, Board board)
        {
            this.game = game;
            this.board = board;
            rows = this.board.GetRows();
            columns = this.board.GetColumns();
            //this.game.SetStatus(utils.core.GameStatusType.WAITING);
        }

        /// <summary>
        /// Verifica el ataque.
        /// </summary>
        /// <param name="column"> Columna ingresada. </param>
        /// <param name="row"> Fila ingresada. </param>
        /// <returns> Hit or miss (true or false). </returns>
        public bool VerifyAttack(int row, int column)
        {
            return board.GetBoard()[column][row] == 'S'; // "S" representa un barco.
        }

        /// <summary>
        /// Ubica los barcos al iniciar la partida.
        /// </summary>
        /// <param name="ship"> Barco. </param>
        /// <param name="row"> Fila del tablero. </param>
        /// <param name="column"> Columna del tablero. </param>
        /// <param name="facing"> Sentido hacia donde apunta el barco. </param>
        public bool PlaceShip(Ship ship, char row, int column, string facing)
        {
            if (!CheckBoundaries(LetterToNumber(row), column)) { return false; }
            Logger.Instance.Debug("ships count: " + game.GetShips().Count + " | total ships: " + game.GetTotalShips());
            if (game.GetShips().Count >= game.GetTotalShips()) { return false; }

            if (board.GetBoard()[column][LetterToNumber(row)] == 'S') { return false; }
            else
            {
                for (var x = 0; x < ship.Length; x++)
                {
                    switch (facing.ToUpper())
                    {
                        case "UP":
                            if (x == 0)
                            {
                                if (!CheckBoundaries(LetterToNumber(row), column - (ship.Length - 1))) { return false; }

                                for (var y = 1; y < ship.Length; y++)
                                {
                                    if (board.GetBoard()[column - y][LetterToNumber(row)] == 'S') { return false; }
                                }
                            }

                            //ship.AddCellCoord(LetterToNumber(row), column - x);
                            game.AddShipCoords(ship.GetShipId(), LetterToNumber(row), column - x);
                            board.GetBoard()[column - x][LetterToNumber(row)] = 'S';
                            break;
                        case "DOWN":
                            if (x == 0)
                            {
                                if (!CheckBoundaries(LetterToNumber(row), column + (ship.Length - 1))) { return false; }

                                for (var y = 1; y < ship.Length; y++)
                                {
                                    if (board.GetBoard()[column + y][LetterToNumber(row)] == 'S') { return false; }
                                }
                            }

                            game.AddShipCoords(ship.GetShipId(), LetterToNumber(row), column + x);
                            board.GetBoard()[column + x][LetterToNumber(row)] = 'S';
                            break;
                        case "RIGHT":
                            if (x == 0)
                            { 
                                if (!CheckBoundaries(LetterToNumber(row) + (ship.Length - 1), column)) { return false; } 

                                for (var y = 1; y < ship.Length; y++)
                                {
                                    if (board.GetBoard()[column][LetterToNumber(row) + y] == 'S') { return false; }
                                }
                            }

                            game.AddShipCoords(ship.GetShipId(), LetterToNumber(row) + x, column);
                            board.GetBoard()[column][LetterToNumber(row) + x] = 'S';
                            break;
                        case "LEFT":
                            if (x == 0) 
                            { 
                                if (!CheckBoundaries(LetterToNumber(row) - (ship.Length - 1), column)) { return false; }

                                for (var y = 1; y < ship.Length; y++) 
                                {
                                    if (board.GetBoard()[column][LetterToNumber(row) - y] == 'S') { return false; }
                                }
                            }
                            game.AddShipCoords(ship.GetShipId(), LetterToNumber(row) - x, column);
                            board.GetBoard()[column][LetterToNumber(row) - x] = 'S';
                            break;
                    }
                }
            }
            game.AddShip(ship);
            if (game.GetShips().Count == game.GetTotalShips())
            {
                game.SetStatus(utils.core.GameStatusType.INGAME);
            }
            return true;
        }
        
        /// <summary>
        /// Ataque.
        /// </summary>
        /// <param name="row"> Fila ingresada. </param>
        /// <param name="column"> Columna ingresada. </param>
        public void Attack(char row, int column)
        {
            if (VerifyAttack(LetterToNumber(row), column))
            {
                DestroyShip(LetterToNumber(row), column);
            }
            numberAttack += 1;
            
            Turn();
            CheckIfWinner();
        }

        /// <summary>
        /// Determina el turno del jugador.
        /// </summary>
        private void CheckIfWinner() {
            List<Ship> ships = game.GetShips();
            
            List<Ship> player1_ships = new List<Ship>();
            List<Ship> player2_ships = new List<Ship>();
            foreach (Ship ship in ships) {
                string shipId = ship.GetShipId();
                foreach (var dic in this.game.GetOwnership()) {
                    if (dic.Key == shipId) {
                        Player p = dic.Value;
                        if (p == game.GetAdmin()) {
                            player1_ships.Add(ship);
                        } else { player2_ships.Add(ship); }
                    }
                }
            }

            int player1_sunken = 0;
            foreach (Ship ship in player1_ships) {
                if (ship.GetSunken()) { player1_sunken += 1; }
            }
            if (player1_ships.Count == player1_sunken) {
                game.SetStatus(utils.core.GameStatusType.FINISHED);
                
                Player otherPlayer = null;
                foreach (Player p in game.GetPlayers()) {
                    if (p != game.GetAdmin()) { otherPlayer = p; }
                }

                game.SetWinner(otherPlayer);
                Logger.Instance.Info($"The winner of the game '{game.GetSessionName()}' is {game.Winner.GetUsername()}");
                return;
            }

            int player2_sunken = 0;
            foreach (Ship ship in player2_ships) {
                if (ship.GetSunken()) { player2_sunken += 1; }
            }
            if (player2_ships.Count == player2_sunken) {
                game.SetStatus(utils.core.GameStatusType.FINISHED);
                game.SetWinner(game.GetAdmin());

                Logger.Instance.Info($"The winner of the game '{game.GetSessionName()}' is {game.Winner.GetUsername()}");
                return;
            }
        }

        /// <summary>
        /// Determina el turno del jugador.
        /// </summary>
        public void Turn()
        {
            if (numberAttack % 2 == 0)
            {
                game.SetStatus(utils.core.GameStatusType.WAITINGP2);
                Console.WriteLine("Turno del Jugador 2.");
            }
            else
            {
                game.SetStatus(utils.core.GameStatusType.WAITINGP1);
                Console.WriteLine("Turno del Jugador 1.");
            }
        }

        /// <summary>
        /// Devuelve el tablero actualizado por el GameLogic.
        /// </summary>
        /// <returns> El tablero. </returns>
        public Board GetBoard()
        {
            return board;
        }

        /// <summary>
        /// Devuelve el número correspondiente a la letra en orden alfabético.
        /// </summary>
        /// <param name="row"> Fila. </param>
        /// <returns> El tablero. </returns>
        private static int LetterToNumber(char row)
        {
            row = char.ToUpper(row);
            return char.ToUpper(row) - 'A' + 1;
        }

        /// <summary>
        /// Verifica que una coordenada no esté fuera de los limites del mapa.
        /// </summary>
        /// <param name="row"> Fila. </param>
        /// <param name="column"> Columna. </param>
        /// <returns>true/false</returns>
        private static bool CheckBoundaries(int row, int column)
        {
            if (row >= 1 && row <= 20 && ((column >= 1 && column <= 10) || (column >= 11 && column <= 20)))
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Este método se encarga de buscar y destruir un barco en el tablero de juego en base a una coordenada dada.
        /// </summary>
        /// <param name="row"> Fila. </param>
        /// <param name="column"> Columna. </param>
        /// <returns> 
        /// Devuelve verdadero (true) si se destruye el barco en la coordenada especificada; 
        /// de lo contrario, devuelve falso (false). 
        /// </returns>
        private bool DestroyShip(int row, int column)
        {
            /*      DEBUG       */
            Console.WriteLine("\nCOORDENADAS: ");
            foreach (Coords coord in game.GetShipsCoords())
            {
                Console.WriteLine("X: " + coord.GetX() + "; Y: " + coord.GetY() + " | " + coord.GetShipId());
            }

            Ship foundedShip = null;
            string foundedShipId = null;
            foreach (Ship ship in game.GetShips())
            {
                string shipId = ship.GetShipId();
                /*      DEBUG       */
                Console.WriteLine("\nSHIP ID | " + shipId);
                Console.WriteLine("STATUS SUNKEN | " + ship.GetSunken());

                if (!ship.GetSunken())
                {
                    foreach (Coords coord in game.GetShipsCoords())
                    {
                        Console.WriteLine("IF | " + coord.GetShipId() + " \\ " + shipId);
                        if (coord.GetShipId() != shipId) { continue; }
                        int[] expected = { row, column };
                        /*      DEBUG       */
                        Console.WriteLine("EXPECTED | " + coord.GetX() + "/" + coord.GetY() + " -> " + expected[0] + "/" + expected[1]);

                        if (coord.GetX() == expected[0] && coord.GetY() == expected[1])
                        {
                            /*      DEBUG       */
                            Console.WriteLine("FOUNDED\n");

                            foundedShip = ship;
                            foundedShipId = shipId;
                            break;
                        }
                    }
                }

                if (foundedShip != null && foundedShipId != null) { break; }
            }

            if (foundedShip != null)
            {
                List<Ship> ships = game.GetShips();
                            
                Ship updatedShip = ships[ships.IndexOf(foundedShip)];
                updatedShip.Sink();

                foreach (Coords coord in game.GetShipsCoords())
                {
                    if (coord.GetShipId() != foundedShipId) { continue; }
                    this.board.GetBoard()[coord.GetY()][coord.GetX()] = 'X';
                }

                game.UpdateShip(foundedShip, updatedShip);
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Devuelve el número de ataques.
        /// </summary>
        /// <returns> El número de ataques. </returns>
        public double GetNumberAttack()
        {
            return numberAttack;
        }

        /// <summary>
        /// Devuelve el juego.
        /// </summary>
        /// <returns> Juego. </returns>
        public Game GetGame()
        {
            return game;
        }
    }
}

/// Cumple con el patrón Expert porque tiene todos los datos necesarios para poder manejar la lógica del juego.