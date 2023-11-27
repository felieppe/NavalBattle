using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.managers
{
    public class ChatManager
    {
        /// <summary>
        /// Instancia de Singleton
        /// </summary>
        /// <value> Instancia de ServerManager</value>
        private static ChatManager instance;

        public static ChatManager Instance
        {
            get
            {
                if (instance == null) { instance = new ChatManager(); }
                return instance;
            }
        }

        public ChatManager() {}
    }
}