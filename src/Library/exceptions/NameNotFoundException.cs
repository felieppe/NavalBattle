using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Exceptions
{
    public class NameNotFoundException : Exception
    {
        public NameNotFoundException() : base() {}
        public NameNotFoundException(string message) : base(message) { }
        public NameNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}