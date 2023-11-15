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

        public ResponseType GetType() {
            return this.Type;
        }
    }
}