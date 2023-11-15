using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Exceptions
{
    public class TokenNotFoundException : Exception
    {
        public TokenNotFoundException() : base() {}
        public TokenNotFoundException(string message) : base(message) { }
        public TokenNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}