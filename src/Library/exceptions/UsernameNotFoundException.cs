//---------------------------------------------------------------------------------
// <copyright file="UsernameNotFoundException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using System;

namespace Library.Exceptions
{   /// <summary>
    /// Excepción por si no se encuentra el nombre de usuario en el archivo de configuración. 
    /// </summary>
    public class UsernameNotFoundException : Exception
    {
        public UsernameNotFoundException() : base() {}
        public UsernameNotFoundException(string message) : base(message) { }
        public UsernameNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}