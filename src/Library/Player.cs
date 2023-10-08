using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Esta clase representa un jugador.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Id del jugador.
        /// </summary>
        /// <value>Id del jugador</value>
        private string Id {get; set;}
        /// <summary>
        /// Nombre de usuario del jugador
        /// </summary>
        /// <value>Username del jugador</value>
        private string Username {get; set;}
        
        /// <summary>
        /// Constructor de la clase Game.
        /// </summary>
        /// <param name="id"></param>
        public Player(string id) {
            this.Id = id;
        }

        /// <summary>
        /// Establece el ID del jugador.
        /// </summary>
        /// <param name="id"></param>
        public void SetId(string id) {
            if (!string.IsNullOrEmpty(id)) { this.Id = id; }
        }
        /// <summary>
        /// Establece el username del jugador.
        /// </summary>
        /// <param name="username"></param>
        public void SetUsername(string username) {
            if (!string.IsNullOrEmpty(username)) { this.Username = username; }
        }

        /// <summary>
        /// Obtiene el ID del jugador
        /// </summary>
        /// <returns>
        /// El ID del jugador.
        /// </returns>
        public string GetId() {
            return this.Id;
        }
        /// <summary>
        /// Obtiene el username del jugador
        /// </summary>
        /// <returns>
        /// El Username del jugador.
        /// </returns>
        public string GetUsername() {
            return this.Username;
        }
    }
}