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
        public string LastCommand { get; private set; }

        public Chat(long id, ChatType type) {
            this.Id = id;
            this.Type = type;
        }

        public void SetLastCmd(string cmd) {
            if (!String.IsNullOrEmpty(cmd)) {
                this.LastCommand = cmd;
            
                // Update Chat in ChatManager
                Serializer.Instance.Serialize(DataType.Chat, method: MethodType.POST, chat: this);
            }
        }
    }
}