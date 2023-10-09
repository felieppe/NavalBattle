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
        /// <summary>
        /// Lista de jugadores del juego.
        /// </summary>
        /// <value>Lista con elementos de tipo Player</value>
        private List<Player> Players = new List<Player>();

        /// <summary>
        /// Constructor de la clase Game.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public Game(Player p1, Player p2)
        {
            Players.Add(p1);
            Players.Add(p2);
        }

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
    }
}