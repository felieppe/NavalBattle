//---------------------------------------------------------------------------------
// <copyright file="Game.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta clase representa una partida.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Id del juego.
        /// </summary>
        /// <value> Id </value>
        private string GameId;

        /// <summary>
        /// Lista de coordenadas de los barcos en el juego.
        /// </summary>
        /// <value> Lista con elementos de tipo Coords. </value>
        private List<Coords> ShipsCoords = new List<Coords>();

        /// <summary>
        /// Lista de barcos ubicados en el tablero del juego.
        /// </summary>
        /// <value> Lista con elementos de tipo Ship. </value>
        private List<Ship> Ships = new List<Ship>();

        /// <summary>
        /// Conteo de la cantidad de barcos que se pueden colocar
        /// </summary>
        /// <value> Integrer </value>
        private int TotalShips = 0;

        /// <summary>
        /// Lista de jugadores del juego.
        /// </summary>
        /// <value> Lista con elementos de tipo Player. </value>
        private List<Player> Players = new List<Player>();

        /// <summary>
        /// Jugador administrador de la partida.
        /// </summary>
        public Player Admin { get; private set; }

        /// <summary>
        /// Dimensiones del tablero.
        /// </summary>
        private BoardSize boardSize1;

        /// <summary>
        /// Tablero del jugador 1.
        /// </summary>
        private Board board1;

        /// <summary>
        /// Tablero del jugador 2.
        /// </summary>
        private Board board2;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Game"/>.
        /// </summary>
        public Game(int rows, int columns, int totalShips)
        {
            this.Admin = new Player();      // solo test esto cambiarlo después por player admin real en param

            this.boardSize1 = new BoardSize(rows, columns);
            this.board1 = new Board(boardSize1);
            this.board2 = new Board(boardSize1);

            this.TotalShips = totalShips;

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
        public void SetGameId(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                this.GameId = id;
            }
        }
        
        /// <summary>
        /// Establece un jugador como administrador de la partida.
        /// </summary>
        public void SetAdmin(Player admin)
        {
            this.Admin = admin;
            if (!this.Players.Contains(admin))
            {
                this.Players.Add(admin);
            }
        }

        /// <summary>
        /// Agrega las coordenadas del barco.
        /// </summary>
        /// <param name="id"> Id del barco. </param>
        /// <param name="x"> Coordenada x. </param>
        /// <param name="y"> Coordenada y. </param>
        public void AddShipCoords(string id, int x, int y)
        {
            Coords cs = new Coords(id, x, y);
            this.ShipsCoords.Add(cs);
        }

        /// <summary>
        /// Agrega un barco. 
        /// </summary>
        /// <param name="ship"> Agrega un barco. </param>
        public void AddShip(Ship ship)
        {
            this.Ships.Add(ship);
        }

        /// <summary>
        /// Actualiza el estado del barco. 
        /// </summary>
        /// <param name="ship"> Barco actual. </param>
        /// <param name="updated"> Barco actualizado. </param>
        public void UpdateShip(Ship ship, Ship updated)
        {
            this.Ships[this.Ships.IndexOf(ship)] = updated;
        }

        /// <summary>
        /// Devuelve la lista de jugadores.
        /// </summary>
        /// <returns> Lista de jugadores. </returns>
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
        /// <returns> Coordenadas del barco. </returns>
        public List<Coords> GetShipsCoords()
        {
            return this.ShipsCoords;
        }

        /// <summary>
        /// Devuelve la lista de barcos.
        /// </summary>
        /// <returns> Lista de barcos. </returns>
        public List<Ship> GetShips()
        {
            return this.Ships;
        }

        /// <summary>
        /// Devuelve la cantidad de barcos.
        /// </summary>
        /// <returns> La cantidad de barcos. </returns>
        public int GetTotalShips()
        {
            return this.TotalShips;
        }

        /// <summary>
        /// Devuelve el tablero 1.
        /// </summary>
        /// <returns> El tablero 1. </returns>
        public Board GetBoard1()
        {
            return this.board1;
        }

        /// <summary>
        /// Devuelve el tablero 2.
        /// </summary>
        /// <returns> El tablero 2. </returns>
        public Board GetBoard2()
        {
            return this.board2;
        }

        /// <summary>
        /// Devuelve el administrador de la partida.
        /// </summary>
        /// <returns> Administrador de la partida. </returns>
        public Player GetAdmin()
        {
            return this.Admin;
        }
    }
}