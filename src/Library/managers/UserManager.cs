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
        /// Inicializa una nueva instancia de la clase <see cref="UserManager"/> si no existe una, de lo contrario devuelve la instancia que existe.
        /// </summary>
        public static UserManager Instance
        {
            get
            {
                if (instance == null) { instance = new UserManager(); }
                return instance;
            }
        }

        public UserManager()
        {
            List<Player> retrieved = Deserializer.Instance.Deserialize(DataType.Player);
            if (retrieved != null)
            {
                foreach (Player player in retrieved)
                {
                    players.Add(player);
                }

                Logger.Instance.Info($"UserManager loaded {retrieved.Count} players.");
            }
        }

        /// <summary>
        /// Añade un jugador a la lista de jugadores.
        /// </summary>
        /// <param name="player"> Player. </param>
        public void AddPlayer(Player player)
        {
            bool found = false;
            foreach (Player p in players)
            {
                if (p.GetTelegramId() == player.GetTelegramId() || p.GetId() == player.GetId()) { found = true; }
            }

            if (!found)
            {
                players.Add(player);
                Serializer.Instance.Serialize(DataType.Player, MethodType.POST, player: player);
            }
        }

        /// <summary>
        /// Elimina un jugador en especifico de la lista de jugadores.
        /// </summary>
        /// <param name="player"> Player. </param>
        public void RemovePlayer(Player player)
        {
            players.Remove(player);
            Serializer.Instance.Serialize(DataType.Player, MethodType.REMOVE, player: player);
        }

        /// <summary>
        /// Elimina un jugador en especifico de la lista de jugadores in-game.
        /// </summary>
        /// <param name="player"> Player. </param>
        public void RemoveInGamePlayer(Player player)
        {
            if (player != null) { inGamePlayers.Remove(player); }
        }

        /// <summary>
        /// Crea una partida con dos jugadores al azar que estén disponibles.
        /// </summary>
        /// <returns>
        /// Una partida.
        /// </returns>
        public Game NewGame(bool matchmaking, ServerManager manager)
        {
            if (matchmaking)
            {
                if (players.Count <= 0)
                {
                    return null;
                }

                List<Player> availablePlayers = players.Except(inGamePlayers).ToList();
                if (availablePlayers.Count < 1)
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

                AddInGamePlayers(game);
                manager.AddGame(game);

                return game;
            }
            else
            {
                Game game = new Game(8, 8, 6);
                manager.AddGame(game);

                return game;
            }
        }

        /// <summary>
        /// Obtiene los jugadores guardados.
        /// </summary>
        /// <returns>
        /// Lista con elementos de tipo Player.
        /// </returns>
        public List<Player> GetPlayers()
        {
            return players;
        }

        /// <summary>
        /// Obtiene los jugadores en juego guardados.
        /// </summary>
        /// <returns>
        /// Lista con elementos de tipo Player.
        /// </returns>
        public List<Player> GetInGamePlayers()
        {
            return inGamePlayers;
        }

        /// <summary>
        /// Obtiene un jugador mediante su id proporcionado.
        /// </summary>
        /// <param name="type"> Tipo de Id. </param>
        /// <param name="id"> Id del jugador. </param> 
        /// <returns> Player. </returns>
        public Player GetPlayerById(IdType type, string id)
        {
            switch (type)
            {
                case IdType.Normal:
                    foreach (Player p in players)
                    {
                        if (p.GetId() == id) { return  p; }
                    }
                    break;
                case IdType.Telegram:
                    foreach (Player p in players)
                    {
                        if (p.GetTelegramId() == id) { return  p; }
                    }
                    break;
            }
            return null;
        }

        /// <summary>
        /// Añade a los jugadores de un juego a la lista de jugadores en juego.
        /// </summary>
        /// <param name="game"> Ongoing games. </param>
        public void AddInGamePlayers(Game game)
        {
            foreach (Player p in game.GetPlayers())
            {
                inGamePlayers.Add(p);
            }
        }

        /// <summary>
        /// Añade al jugador a la lista de jugadores en juego.
        /// </summary>
        /// <param name="player"> Jugador. </param>
        public void AddInGamePlayer(Player player)
        {
            if (player != null) { inGamePlayers.Add(player); }
        }

        /// <summary>
        /// Agrega un jugador a una partida.
        /// </summary>
        /// <param name="player"> Jugador. </param>
        /// <param name="id"> Id del jugador. </param>
        public void AddPlayerToGame(Player player, string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Game game = ServerManager.Instance.GetGame(id);
                if (game != null)
                {
                    game.AddPlayer(player);
                }
            }
        }
    }
}

/// Cumple con el principio de responsabilidad única porque solo tiene la responsabilidad de gestionar usuarios y jugadores .
/// Cumple con el patrón Singleton porque solo se puede tener una única instancia de la clase.
