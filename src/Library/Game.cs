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

        /// <summary>
        /// Lista de jugadores del juego.
        /// </summary>
        /// <value> Lista con elementos de tipo Player. </value>
        private List<Player> Players = new List<Player>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Game"/>.
        /// </summary>
        public Game(int rows, int columns, int totalShips, Player player)
        {
            BoardSize boardSize1 = new BoardSize(rows, columns);
            Board board1 = new Board(boardSize1);
            GameLogic gameLogic1 = new GameLogic(board1, boardSize1, totalShips);
            this.AddPlayer(player);
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
    }
}