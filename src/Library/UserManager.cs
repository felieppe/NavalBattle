//---------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="Universidad Católica del Uruguay">
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
    /// Esta clase representa al administrador de usuarios.
    /// </summary>
    public class UserManager
    {
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
        /// Lista de juegos actuales.
        /// </summary>
        /// <typeparam name="Game"> Juego. </typeparam>
        private List<Game> ongoingGames = new List<Game>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UserManager"/>.
        /// </summary>
        public UserManager()
        {
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
                    pIndex = rnd.Next(availablePlayers.Count);
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
        public void AddPlayerToGame(Player player, object id)
        {
            if (id is Guid gameId)
            {
                // Buscar la partida en función del gameId
                Game game = FindGameById(gameId);

                if (game != null)
                {
                game.AddPlayer(player);
                }
                else
                {
                    throw new InvalidOperationException("Partida no encontrada.");// La partida no se encontró, manejar el error de alguna manera
                }
            }
            else
            {
                throw new ArgumentException("Identificador no válido.");// El identificador no es válido, manejar el error de alguna manera
            }
        }
        private Game FindGameById(Guid gameId)
        {
            // Itera a través de los juegos existentes y busca el juego con el gameId dado
            foreach (Game game in this.ongoingGames)
            {
                if (game.Id == game.Id)
                {
                    return game;
                }
            }
            return null; // Si no se encuentra el juego, devuelve null
        }
    }
}
