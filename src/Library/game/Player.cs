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
        public string Id { get; private set; }

        /// <summary>
        /// Id del usuario de telegram, vinculado al jugador.
        /// </summary>
        /// <value> Id. </value>
        public string TelegramId { get; private set; }

        /// <summary>
        /// Nombre de usuario del jugador.
        /// </summary>
        /// <value> Username. </value>
        public string Username { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Player"/>.
        /// </summary>
        public Player()
        {
            Guid uuid = Guid.NewGuid();
            SetId(uuid.ToString());
        }

        /// <summary>
        /// Establece el ID del jugador.
        /// </summary>
        /// <param name="id"> Id del jugador. </param>
        public void SetId(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Id = id;
            }
        }

        /// <summary>
        /// Establece el Telegram ID del jugador.
        /// </summary>
        /// <param name="id"> Id de Telegram del jugador. </param>
        public void SetTelegramId(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                TelegramId = id;
            }
        }

        /// <summary>
        /// Establece el username del jugador.
        /// </summary>
        /// <param name="username"> Username del jugador. </param>
        public void SetUsername(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                Username = username;
            }
        }

        /// <summary>
        /// Obtiene el ID del jugador.
        /// </summary>
        /// <returns> ID del jugador. </returns>
        public string GetId()
        {
            return Id;
        }

        /// <summary>
        /// Obtiene el Telegram ID del jugador.
        /// </summary>
        /// <returns> Telegram ID del jugador. </returns>
        public string GetTelegramId()
        {
            return TelegramId;
        }

        /// <summary>
        /// Obtiene el username del jugador.
        /// </summary>
        /// <returns> Username del jugador. </returns>
        public string GetUsername()
        {
            return Username;
        }
    }
}

/// Cumple con el patrón Expert porque tiene todos los datos necesarios para crear un jugador.
/// Cumple con el principio abierto-cerrado, ya que se le pueden agregar funciones mediante herencia o composición, pero no es necesario modificar la clase.
