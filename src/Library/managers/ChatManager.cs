using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.bot;
using Library.utils;
using Library.utils.core;

namespace Library.managers
{
    public class ChatManager
    {
        /// <summary>
        /// Instancia de Singleton
        /// </summary>
        /// <value> Instancia de ServerManager</value>
        private static ChatManager instance;

        public List<Chat> Chats {get; private set;}

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
            if (retrieved != null) { this.Chats = retrieved; }
        }

        public void AddChat(Chat chat) {
            if (chat != null) {
                if (!this.Chats.Contains(chat)) {
                    this.Chats.Add(chat);
                }
            }
        }

        public Chat GetChat(long id) {
            Chat chat = null;
            foreach (Chat c in this.Chats) {
                if (c.Id == id) { chat = c; break; }
            }

            return chat;
        }
    }
}