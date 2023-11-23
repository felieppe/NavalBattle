//---------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Library.utils;
using Library.utils.core;

namespace Library
{
    /// <summary>
    /// Esta clase representa al administrador de usuarios.
    /// </summary>
    public class UserManager
    {
        private static UserManager instance;

        /// <summary>
        /// Lista de jugadores registrados en el UserManager.
        /// </summary>
        /// <value> Lista con elementos de tipo Player. </value>
        private List<Player> players = new List<Player>();

        /// <summary>
        /// Lista de jugadores que actualmente están jugando.
        /// </summary>
        /// <value> Lista con elementos de tipo Player. </value>
        private List<Player> inGamePlayers = new List<Player>();

        /// <summary>
        /// Instancia de Server Manager
        /// </summary>
        private ServerManager serverManager = ServerManager.Instance;

        public static UserManager Instance {
            get {
                if (instance == null) { instance = new UserManager(); }
                return instance;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UserManager"/>.
        /// </summary>
        public UserManager() {
            List<Player> retrieved = Deserializer.Instance.Deserialize(DataType.Game);
            foreach (Player player in retrieved) {
                this.players.Add(player);
            }
        }

        /// <summary>
        /// Añade un jugador a la lista de jugadores.
        /// </summary>
        /// <param name="player"> Player. </param>
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        /// <summary>
        /// Elimina un jugador en especifico de la lista de jugadores.
        /// </summary>
        /// <param name="player"> Player. </param>
        public void RemovePlayer(Player player)
        {
            this.players.Remove(player);
        }

        /// <summary>
        /// Crea una partida con dos jugadores al azar que estén disponibles.
        /// </summary>
        /// <returns>
        /// Una partida.
        /// </returns>
        public Game NewGame(bool matchmaking, ServerManager manager)
        {
            if (matchmaking) {
                if (!(this.players.Count >= 1))
                {
                    return null;
                }

                List<Player> availablePlayers = this.players.Except(this.inGamePlayers).ToList();
                if (!(availablePlayers.Count > 1))
                {
                    return null;
                }

                Random rnd = new Random();
                int pIndex = 0, pIndex2 = 0;
                bool ready = false;
                while (!ready)
                {
                    #pragma warning disable CA5394
                    pIndex = rnd.Next(availablePlayers.Count);
                    #pragma warning disable CA5394
                    pIndex2 = rnd.Next(availablePlayers.Count);

                    if (pIndex != pIndex2)
                    {
                        ready = true;
                    }
                }

                Player player1 = availablePlayers[pIndex];
                Player player2 = availablePlayers[pIndex2];
                Game game = new Game(8, 8, 6);
                game.AddPlayer(player1);
                game.AddPlayer(player2);

                this.AddInGamePlayers(game);
                manager.AddGame(game);

                return game;
            } else {
                Game game = new Game(8, 8, 6);
                manager.AddGame(game);

                return game;
            }
        }

        /// <summary>
        /// Obtiene los jugadores guardados.
        /// </summary>
        /// <returns>
        /// Una lista con elementos de tipo Player.
        /// </returns>
        public List<Player> GetPlayers()
        {
            return this.players;
        }

        /// <summary>
        /// Obtiene los jugadores en juego guardados.
        /// </summary>
        /// <returns>
        /// Una lista con elementos de tipo Player.
        /// </returns>
        public List<Player> GetInGamePlayers()
        {
            return this.inGamePlayers;
        }

        /// <summary>
        /// Añade a los jugadores de un juego a la lista de jugadores en juego.
        /// </summary>
        /// <param name="game"> Ongoing games. </param>
        private void AddInGamePlayers(Game game)
        {
            foreach (Player p in game.GetPlayers())
            {
                this.inGamePlayers.Add(p);
            }
        }

        /// <summary>
        /// Agrega un jugador a una partida.
        /// </summary>
        /// <param name="player"> Jugador. </param>
        /// <param name="id"> Id del jugador. </param>
        public void AddPlayerToGame(Player player, string id)
        {
            if (!String.IsNullOrEmpty(id)) {
                Game game = this.FindGameById(id);
                if (game != null) {
                    game.AddPlayer(player);
                }
            }
        }

        /// <summary>
        /// Busca un juego por el Id.
        /// </summary>
        /// <param name="gameId"> Id del juego. </param>
        /// <returns> Juego. </returns>
        private Game FindGameById(string gameId)
        {
            foreach (Game game in this.serverManager.GetListing()) {
                if (game.GetGameId() == gameId) {
                    return game;
                }
            }
            return null;
        }
    }
}