//---------------------------------------------------------------------------------
// <copyright file="Game.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Esta clase representa una partida.
    /// </summary>
    public class Game
    {
        private string GameId;

        private List<Coords> ShipsCoords = new List<Coords>();

        private List<Ship> Ships = new List<Ship>();

        private int TotalShips;

        private Board board;

        /// <summary>
        /// Lista de jugadores del juego.
        /// </summary>
        /// <value> Lista con elementos de tipo Player. </value>
        private List<Player> Players = new List<Player>();
        
        /// <summary>
        /// Tamaño del tablero.
        /// </summary>
        public BoardSize boardSize1;
        public Board board1;
        public Board board2;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Game"/>.
        /// </summary>
        public Game(int rows, int columns, int totalShips)
        {
            this.boardSize1 = new BoardSize(rows, columns);
            this.board1 = new Board(boardSize1);
            this.board2 = new Board(boardSize1);
            GameLogic gameLogic1 = new GameLogic(board1, board2, boardSize1, totalShips);
            this.AddPlayer(player);
            BoardSize bs = new BoardSize(rows, columns);
            this.board = new Board(bs);

            Guid uuid = Guid.NewGuid();
            this.SetGameId(uuid.ToString());

            this.TotalShips = totalShips;
        }

        /// <summary>
        /// Agrega jugadores a la partida.
        /// </summary>
        public void AddPlayer(Player player)
        {
            if (this.Players.Count >= 2)
            {
                return;
            }
            else
            {
                this.Players.Add(player);
            }
        }
        
        public void SetGameId(string id) {
            if (!string.IsNullOrEmpty(id)) {
                this.GameId = id;
            }
        }

        public void AddShipCoords(int x, int y) {
            Coords cs = new Coords(x, y);
            this.ShipsCoords.Add(cs);
        }

        public void AddShip(Ship ship) {
            this.Ships.Add(ship);
        }

        public void UpdateShip(Ship ship, Ship updated) {
            this.Ships[this.Ships.IndexOf(ship)] = updated;
        }

        /// <summary>
        /// Id del jugador.
        /// </summary>
        /// <value> Id. </value>
        public object Id { get; set; }

        /// <summary>
        /// Obtiene los jugadores guardados.
        /// </summary>
        /// <returns>
        /// Una lista con elementos de tipo Player.
        /// </returns>
        public List<Player> GetPlayers()
        {
            return this.Players;
        }
 
        public string GetGameId() {
            return this.GameId;
        }
 
        public List<Coords> GetShipsCoords() {
            return this.ShipsCoords;
        }

        /// <summary>
        /// Devuelve la lista de barcos en el tablero.
        /// </summary>
        /// <returns> Lista con valores tipo Ship.</returns>
        public List<Ship> GetShips() 
        {
            return this.Ships;
        }

        public int GetTotalShips() {
            return this.TotalShips;
        }

        public Board GetBoard() {
            return this.board;
        }
    }
}