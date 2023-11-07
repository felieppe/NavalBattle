//---------------------------------------------------------------------------------
// <copyright file="Player.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using System;

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
        /// <value> Id. </value>
        private string Id { get; set; }

        /// <summary>
        /// Nombre de usuario del jugador.
        /// </summary>
        /// <value> Username. </value>
        private string Username { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Player"/>.
        /// </summary>
        public Player()
        {
            Guid uuid = Guid.NewGuid();
            this.SetId(uuid.ToString());
        }

        /// <summary>
        /// Establece el ID del jugador.
        /// </summary>
        /// <param name="id"> Id. </param>
        public void SetId(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                this.Id = id;
            }
        }

        /// <summary>
        /// Establece el username del jugador.
        /// </summary>
        /// <param name="username"> Username. </param>
        public void SetUsername(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                this.Username = username;
            }
        }

        /// <summary>
        /// Obtiene el ID del jugador.
        /// </summary>
        /// <returns> El ID del jugador. </returns>
        public string GetId()
        {
            return this.Id;
        }

        /// <summary>
        /// Obtiene el username del jugador.
        /// </summary>
        /// <returns> El Username del jugador. </returns>
        public string GetUsername()
        {
            return this.Username;
        }
    }
}

/// Cumple con el patrón Expert porque tiene todos los datos necesarios para crear un jugador.
/// Cumple con el principio abierto-cerrado, ya que se le pueden agregar funciones mediante herencia o composición, pero no es necesario modificar la clase.
