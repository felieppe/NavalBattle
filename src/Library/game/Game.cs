//---------------------------------------------------------------------------------
// <copyright file="Game.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Library.utils.core;

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
        /// <value> Id. </value>
        private string gameId;

        /// <summary>
        /// Nombre de la sesión.
        /// </summary>
        /// <value> String </value>
        private string name;

        /// <summary>
        /// Estado de la sesión.
        /// </summary>
        /// <value> GameStatusType </value>
        private GameStatusType status = GameStatusType.WAITING;

        /// <summary>
        /// Lista de coordenadas de los barcos en el juego.
        /// </summary>
        /// <value> Lista con elementos de tipo Coords. </value>
        private List<Coords> shipsCoords = new List<Coords>();

        /// <summary>
        /// Lista de barcos ubicados en el tablero del juego.
        /// </summary>
        /// <value> Lista con elementos de tipo Ship. </value>
        private List<Ship> ships = new List<Ship>();

        /// <summary>
        /// Lista de barcos ubicados en el tablero del juego.
        /// </summary>
        /// <value> Lista con elementos de tipo Ship. </value>
        private Dictionary<string, Player> Ownership = new Dictionary<string, Player>();

        /// <summary>
        /// Conteo de la cantidad de barcos que se pueden colocar
        /// </summary>
        private int totalShips = 0;

        /// <summary>
        /// Conteo de la cantidad de barcos que se pueden colocar
        /// </summary>
        public int Attacks {get; private set;}

        /// <summary>
        /// Lista de jugadores del juego.
        /// </summary>
        /// <value> Lista con elementos de tipo Player. </value>
        private List<Player> players = new List<Player>();

        /// <summary>
        /// Jugador administrador de la partida.
        /// </summary>
        public Player Admin { get; private set; }

        /// <summary>
        /// Jugador ganador de la partida.
        /// </summary>
        public Player Winner { get; private set; }

        /// <summary>
        /// Filas del tablero.
        /// </summary>
        public int rows { get; private set; }

        /// <summary>
        /// Columnas del tablero.
        /// </summary>
        public int columns { get; private set; }

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
            this.Attacks = 0;

            this.rows = rows;
            this.columns = columns;

            board1 = new Board(rows/2, columns/2);
            board2 = new Board(rows/2, columns/2);
            this.totalShips = totalShips;

            Guid uuid = Guid.NewGuid();
            SetGameId(uuid.ToString());
        }

        /// <summary>
        /// Agrega jugadores a la partida.
        /// </summary>
        /// <param name="player"> Jugador. </param>
        public void AddPlayer(Player player)
        {
            if (players.Count == 0 || (players.Count >= 1 && players.Count <= 2))
            {
                if (UserManager.Instance.GetPlayers().Contains(player))
                {
                    if (!UserManager.Instance.GetInGamePlayers().Contains(player))
                    { 
                        players.Add(player);
                        if (Admin == null) { Admin = player; }
                        
                        UserManager.Instance.AddInGamePlayer(player);
                    }
                }
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
                gameId = id;
            }
        }

        /// <summary>
        /// Establece el nombre de la sesión.
        /// </summary>
        /// <param name="name"> Nombre de la sesión. </param>
        public void SetGameSession(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                this.name = name;
            }
        }

        /// <summary>
        /// Establece el estado de la sesión.
        /// </summary>
        /// <param name="status"> Estado de la sesión. </param>
        public void SetStatus(GameStatusType status)
        {
            this.status = status;
        }
        
        /// <summary>
        /// Establece un jugador como administrador de la partida.
        /// </summary>
        /// <param name="admin"> Jugador administrador de la partida. </param>
        public void SetAdmin(Player admin)
        {
            Admin = admin;
            if (!players.Contains(admin))
            {
                players.Add(admin);
            }
        }

        /// <summary>
        /// Establece un jugador como ganador de la partida.
        /// </summary>
        /// <param name="winner"> Jugador ganador de la partida. </param>
        public void SetWinner(Player winner)
        {
            if (winner != null)
            {
                if (players.Contains(winner))
                {
                    Winner = winner;
                }
            }
        }

        /// <summary>
        /// Añade una propiedad a un jugador sobre un barco.
        /// </summary>
        /// <param name="id"> Id del barco. </param>
        /// <param name="owner"> Dueño del barco. </param>
        public void AddOwnerShip(string id, Player owner)
        {
            if (owner != null)
            {
                if (players.Contains(owner))
                {
                    Ownership.Add(id, owner);
                }
            }
        }

        /// <summary>
        /// Elimina un jugador del game.
        /// </summary>
        /// <param name="rp"> Jugador. </param>
        public void RemovePlayer(Player rp)
        {
            if (rp != null)
            { 
                players.Remove(rp);
                UserManager.Instance.RemovePlayer(rp);

                if (players.Count == 0)
                {
                    SetStatus(GameStatusType.FINISHED);
                    ServerManager.Instance.RemoveGame(gameId);
                }
                else
                {
                    SetAdmin(players.ToArray()[0]);
                }
            }
        }

        /// <summary>
        /// Establece el board1.
        /// </summary>
        /// <param name="b"> Tablero. </param>
        public void SetBoard1(Board b)
        {
            if (b != null) { board1 = b; }
        }

        /// <summary>
        /// Establece el board2.
        /// </summary>
        /// <param name="b"> Tablero. </param>
        public void SetBoard2(Board b)
        {
            if (b != null) { board2 = b; }
        }

        /// <summary>
        /// Agrega las coordenadas del barco.
        /// </summary>
        /// <param name="id"> Id del barco. </param>
        /// <param name="x"> Coordenada X. </param>
        /// <param name="y"> Coordenada Y. </param>
        public void AddShipCoords(string id, int x, int y)
        {
            Coords cs = new Coords(id, x, y);
            shipsCoords.Add(cs);
        }

        /// <summary>
        /// Agrega un barco. 
        /// </summary>
        /// <param name="ship"> Agrega un barco. </param>
        public void AddShip(Ship ship)
        {
            ships.Add(ship);
        }

        public void SumAttack() {
            this.Attacks += 1;
        }

        /// <summary>
        /// Actualiza el estado del barco. 
        /// </summary>
        /// <param name="ship"> Barco actual. </param>
        /// <param name="updated"> Barco actualizado. </param>
        public void UpdateShip(Ship ship, Ship updated)
        {
            ships[ships.IndexOf(ship)] = updated;
        }

        /// <summary>
        /// Devuelve la lista de jugadores.
        /// </summary>
        /// <returns> Lista de jugadores. </returns>
        public List<Player> GetPlayers()
        {
            return players;
        }

        /// <summary>
        /// Devuelve el Id del juego.
        /// </summary>
        /// <returns> Id del juego. </returns>
        public string GetGameId()
        {
            return gameId;
        }

        /// <summary>
        /// Devuelve el nombre de la sesión.
        /// </summary>
        /// <returns> String </returns>
        public string GetSessionName()
        {
            return name;
        }

        /// <summary>
        /// Devuelve el estado de la sesión.
        /// </summary>
        /// <returns> GameStatusType </returns>
        public GameStatusType GetStatus()
        {
            return status;
        }

        /// <summary>
        /// Devuelve las coordenadas del barco.
        /// </summary>
        /// <returns> Coordenadas del barco. </returns>
        public List<Coords> GetShipsCoords()
        {
            return shipsCoords;
        }

        /// <summary>
        /// Devuelve la lista de barcos.
        /// </summary>
        /// <returns> Lista de barcos. </returns>
        public List<Ship> GetShips()
        {
            return ships;
        }

        /// <summary>
        /// Devuelve la lista de barcos del jugador.
        /// </summary>
        /// <returns> Lista de barcos del jugador. </returns>
        public Dictionary<string, Player> GetOwnership()
        {
            return Ownership;
        }

        /// <summary>
        /// Devuelve la cantidad total de barcos.
        /// </summary>
        /// <returns> Cantidad de barcos total. </returns>
        public int GetTotalShips()
        {
            return totalShips;
        }

        /// <summary>
        /// Devuelve el tablero 1.
        /// </summary>
        /// <returns> Tablero 1. </returns>
        public Board GetBoard1()
        {
            return board1;
        }

        /// <summary>
        /// Devuelve el tablero 2.
        /// </summary>
        /// <returns> Tablero 2. </returns>
        public Board GetBoard2()
        {
            return board2;
        }

        /// <summary>
        /// Devuelve el administrador de la partida.
        /// </summary>
        /// <returns> Administrador de la partida. </returns>
        public Player GetAdmin()
        {
            return Admin;
        }
    }
}

/// Cumple con el patrón creator ya que crea instancias de board.