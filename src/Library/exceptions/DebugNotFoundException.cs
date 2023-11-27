using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Exceptions
{   /// <summary>
    /// Excepción por si no se encuentra información para hacer debug
    /// </summary>
    public class DebugNotFoundException : Exception
    {
        public DebugNotFoundException() : base() {}
        public DebugNotFoundException(string message) : base(message) { }
        public DebugNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}