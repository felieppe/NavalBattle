//---------------------------------------------------------------------------------
// <copyright file="Chat.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using System.Collections.Generic;
using Library.utils;
using Library.utils.core;
using Telegram.Bot.Types.Enums;

namespace Library.bot
{   /// <summary>
    /// Establece el chat entre el bot y el usuario, "Player 1"/"Player 2"
    /// considerando id, type y user .
    /// </summary>
    public class Chat : Telegram.Bot.Types.Chat
    {
        /// <summary>
        /// Usuario.
        /// </summary>
        public Player User {get; private set;}
        private List<string> LastCommands = new List<string>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Chat"/>.
        /// </summary>
        /// <param name="id"> Id. </param>
        /// <param name="type"> Tipo de chat. </param>
        /// <param name="player"> Jugador. </param>
        public Chat(long id, ChatType type, Player player)
        {
            Id = id;
            Type = type;
            User = player;
        }

        /// <summary>
        /// Agrega el último comando ejecutado a una lista.
        /// </summary>
        /// <param name="cmd"> Comando. </param>
        public void AddLastCmd(string cmd)
        {
            if (!string.IsNullOrEmpty(cmd))
            {
                if (LastCommands.Count >= 2) {LastCommands.RemoveAt(0); }
                LastCommands.Add(cmd);

                // Update this instance w/ Serializer
                Serializer.Instance.Serialize(DataType.Chat, method: MethodType.POST, chat: this);
            }
        }

        /// <summary>
        /// Devuelve la lista de comandos.
        /// </summary>
        /// <returns> Lista de comandos. </returns>
        public List<string> GetLastCommands()
        {
            return LastCommands;
        }
    }
}