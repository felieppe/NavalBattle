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

        /// <summary>
        /// Lista de jugadores del juego.
        /// </summary>
        /// <value> Lista con elementos de tipo Player. </value>
        private List<Player> Players = new List<Player>();

        /// <summary>
        /// Jugador administrador de la partida.
        /// </summary>
        public Player Admin { get; private set; }

        public BoardSize boardSize1;

        /// <summary>
        /// Tablero del jugador 1.
        /// </summary>
        public Board board1;

        /// <summary>
        /// Tablero del jugador 2.
        /// </summary>
        public Board board2;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Game"/>.
        /// </summary>
        public Game(int rows, int columns, int totalShips, Player player)
        {
            this.Admin = admin;
            this.Players.Add(admin);

            this.boardSize1 = new BoardSize(rows, columns);
            this.board1 = new Board(boardSize1);
            this.board2 = new Board(boardSize1);
            GameLogic gameLogic1 = new GameLogic(board1, board2, boardSize1, totalShips);
            this.AddPlayer(player);
            Guid uuid = Guid.NewGuid();
            this.SetGameId(uuid.ToString());
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

        /// <summary>
        /// Set el Id del juego.
        /// </summary>
        /// <param name="id"> Id del juego. </param>
        public void SetGameId(string id) {
            if (!string.IsNullOrEmpty(id)) {
                this.GameId = id;
            }
        }
        
        /// <summary>
        /// /// Agrega un jugador como administrador de la partida.
        /// </summary>
        public void AddAdmin(Player admin)
        {
            this.Admin = admin;
            if (!this.Players.Contains(admin))
            {
                this.Players.Add(admin);
            }
        }

        public void SetGameId(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                this.GameId = id;
            }
        }

        /// <summary>
        /// Agrega las coordenadas del barco.
        /// </summary>
        /// <param name="x"> Coordenada x. </param>
        /// <param name="y"> Coordenada y. </param>
        public void AddShipCoords(int x, int y) {
            Coords cs = new Coords(x, y);
            this.ShipsCoords.Add(cs);
        }

        /// <summary>
        /// Agrega un barco. 
        /// </summary>
        /// <param name="ship"> Agrega un barco. </param>
        public void AddShip(Ship ship) {
            this.Ships.Add(ship);
        }

        /// <summary>
        /// Actualiza el estado del barco. 
        /// </summary>
        /// <param name="ship"> Barco actual. </param>
        /// <param name="updated"> Barco actualizado. </param>
        public void UpdateShip(Ship ship, Ship updated) {
            this.Ships[this.Ships.IndexOf(ship)] = updated;
        }

        public object Id { get; set; }

        public List<Player> GetPlayers()
        {
            return this.Players;
        }

        /// <summary>
        /// Devuelve el Id del juego.
        /// </summary>
        /// <returns> Id del juego. </returns>
        public string GetGameId()
        {
            return this.GameId;
        }

        /// <summary>
        /// Devuelve las coordenadas del barco.
        /// </summary>
        /// <returns> Las coordenadas del barco. </returns>
        public List<Coords> GetShipsCoords()
        {
            return this.ShipsCoords;
        }

        public List<Ship> GetShips()
        {
            return this.Ships;
        }

        /// <summary>
        /// Devuelve la cantidad de barcos.
        /// </summary>
        /// <returns> La cantidad de barcos. </returns>
        public int GetTotalShips() {
            return this.TotalShips;
        }

        /// <summary>
        /// Devuelve el tablero.
        /// </summary>
        /// <returns> El tablero. </returns>
        public Board GetBoard() {
            return this.board1;
        }
    }
}