//---------------------------------------------------------------------------------
// <copyright file="TokenNotFoundException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using System;

namespace Library.Exceptions
{   /// <summary>
    /// Excepción por si no se encuentra el token del bot en el archivo de configuración.
    /// </summary>
    public class TokenNotFoundException : Exception
    {
        public TokenNotFoundException() : base() {}
        public TokenNotFoundException(string message) : base(message) { }
        public TokenNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}