using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.bot.core;

namespace Library.bot
{
    public class Response
    {
        private ResponseType Type;
        private string Message;

        public Response(ResponseType type, string msg) {
            this.Type = type;
            this.Message = msg;
        }

        public void SetType(ResponseType type) {
            if (type != null) { this.Type = type; }
        }

        public ResponseType GetType() {
            return this.Type;
        }
        public string GetMessage() {
            return this.Message;
        }
    }
}