//---------------------------------------------------------------------------------
// <copyright file="ConfigFileNotExistsException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using System;

namespace Library.Exceptions
{
    /// <summary>
    /// Excepción por si el archivo de configuración no existe.
    /// </summary>
    public class ConfigFileNotExistsException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ConfigFileNotExistsException"/>.
        /// </summary>
        public ConfigFileNotExistsException() : base() {}
        public ConfigFileNotExistsException(string message) : base(message) { }
        public ConfigFileNotExistsException(string message, Exception innerException) : base(message, innerException) { }
    }
}