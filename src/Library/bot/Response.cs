using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}