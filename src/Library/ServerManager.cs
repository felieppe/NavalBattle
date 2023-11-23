//---------------------------------------------------------------------------------
// <copyright file="ServerManager.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    /// <summary>
    /// Clase que administra las partidas en curso.
    /// </summary>
    public class ServerManager
    {
        private static ServerManager instance;

        private List<Game> Servers = new List<Game>();

        public static ServerManager Instance {
            get {
                if (instance == null) { instance = new ServerManager(); }
                return instance;
            }
        }

        /// <summary>
        /// Agrega un juego al servidor.
        /// </summary>
        /// <param name="game"> Juego. </param>
        public void AddGame(Game game)
        {
            if (game != null)
            {
                bool duplicated = false;
                foreach (Game server in this.Servers)
                {
                    if (server.GetGameId() == game.GetGameId())
                    {
                        duplicated = true;
                        break;
                    }
                }

                if (!duplicated) { this.Servers.Add(game); }
            }
        }

        /// <summary>
        /// Elimina un juego del servidor.
        /// </summary>
        /// <param name="id"> Id del juego. </param>
        public void RemoveGame(string id)
        {
            Game g = this.Servers.FirstOrDefault(g => g.GetGameId() == id);
            if (g != null) {
                Servers.Remove(g);
            }           
        }

        /// <summary>
        /// Devuelve la lista de juegos.
        /// </summary>
        /// <returns> Lista de juegos. </returns>
        public List<Game> GetListing()
        {
            return this.Servers;
        }

        /// <summary>
        /// Devuelve un juego a partir de su Id.
        /// </summary>
        /// <param name="id"> Id del juego. </param>
        /// <returns> Juego. </returns>
        public Game GetGame(string id)
        {
            return this.Servers.FirstOrDefault(g => g.GetGameId() == id);
        }
    }
}

///Cumple con el patrón Expert porque tiene todos los datos que se necesitan para manejar los juegos.
///Cumple con el principio de responsabilidad única porque solo tiene la responsabilidad de administrar las partidas en curso.
