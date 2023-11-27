using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Exceptions
{   /// <summary>
    /// Excepción por si no se encuentra el nombre de usuario  
    /// </summary>
    public class UsernameNotFoundException : Exception
    {
        public UsernameNotFoundException() : base() {}
        public UsernameNotFoundException(string message) : base(message) { }
        public UsernameNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}