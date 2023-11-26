using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.bot.core;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.bot
{
    public class Response
    {
        private ResponseType Type;
        private string Message;
        private string Return;
        private InlineKeyboardMarkup Keyboard;

        public Response(ResponseType type, string msg, string? ret = null, InlineKeyboardMarkup? ikm = null) {
            this.Type = type;
            this.Message = msg;
            this.Return = ret;
            this.Keyboard = ikm;
        }

        public void SetType(ResponseType type) {
            if (type != null) { this.Type = type; }
        }
        public void SetMessage(string msg) {
            if (!String.IsNullOrEmpty(msg)) { this.Message = msg; }
        }
        public void SetKeyboard(InlineKeyboardMarkup kb) {
            this.Keyboard = kb;
        }

        public ResponseType GetType() {
            return this.Type;
        }
        public string GetMessage() {
            return this.Message;
        }
        public InlineKeyboardMarkup GetKeyboard() {
            return this.Keyboard;
        }
    }
}