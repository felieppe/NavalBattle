using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.bot;
using Library.utils;
using Library.utils.core;

namespace Library.managers
{
    /// <summary>
    /// Clase que 
    /// </summary>
    public class ChatManager
    {
        /// <summary>
        /// Instancia de Singleton
        /// </summary>
        /// <value> Instancia de ChatManager</value>
        private static ChatManager instance;
        /// <summary>
        /// Lista de partidas.
        /// </summary>
        /// <value> Lista de partidas. </value>
    
        public List<Chat> Chats {get; private set;}
         /// <summary>
        /// Inicializa una instancia de la clase <see cref="ChatManager"/> si no existe una, de lo contrario devuelve esa instancia.
        /// </summary>
        /// <value></value>

        public static ChatManager Instance
        {
            get
            {
                if (instance == null) { instance = new ChatManager(); }
                return instance;
            }
        }

        public ChatManager() {
            List<Chat> retrieved = Deserializer.Instance.Deserialize(DataType.Chat);
            if (retrieved != null) { Chats = retrieved; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"> Id del juego. </param>
        /// <returns>  </returns>

        public void AddChat(Chat chat) {
            if (chat != null) {
                if (!Chats.Contains(chat)) {
                    Chats.Add(chat);
                    Serializer.Instance.Serialize(DataType.Chat, MethodType.POST, chat: chat);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"> Id del juego. </param>
        /// <returns>. </returns>
        public Chat GetChat(long id) {
            Chat chat = null;
            foreach (Chat c in Chats) {
                if (c.Id == id) { chat = c; break; }
            }

            return chat;
        }
    }
}

///Cumple con el principio de responsabilidad única, la clase tiene una única razón para cambiar que es gestionar la lógica de los chats y no tiene responsabilidades adicionales.
///Cumple con el patrón Singleton porque solo se puede tener una única instancia de la clase.
