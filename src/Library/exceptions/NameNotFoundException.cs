//---------------------------------------------------------------------------------
// <copyright file="NameNotFoundException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using System;

namespace Library.Exceptions
{   /// <summary>
    /// Excepción por si no se encuentra el nombre en el archivo de configuración. 
    /// </summary>
    public class NameNotFoundException : Exception
    {
        public NameNotFoundException() : base() {}
        public NameNotFoundException(string message) : base(message) { }
        public NameNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}