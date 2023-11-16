using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Exceptions
{
    public class ConfigFileNotExistsException : Exception
    {
        public ConfigFileNotExistsException() : base() {}
        public ConfigFileNotExistsException(string message) : base(message) { }
        public ConfigFileNotExistsException(string message, Exception innerException) : base(message, innerException) { }
    }
}