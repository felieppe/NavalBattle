using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.utils;
using Library.utils.core;
using Telegram.Bot.Types.Enums;

namespace Library.bot
{
    public class Chat : Telegram.Bot.Types.Chat
    {
        private List<string> LastCommands = new List<string>();

        public Chat(long id, ChatType type) {
            this.Id = id;
            this.Type = type;
        }

        public void AddLastCmd(string cmd) {
            if (!String.IsNullOrEmpty(cmd)) {
                if (this.LastCommands.Count >= 2) {this.LastCommands.RemoveAt(0); }
                this.LastCommands.Add(cmd);

                // Update this instance w/ Serializer
                Serializer.Instance.Serialize(DataType.Chat, method: MethodType.POST, chat: this);
            }
        }

        public List<string> GetLastCommands() {
            return this.LastCommands;
        }
    }
}