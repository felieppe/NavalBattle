//---------------------------------------------------------------------------------
// <copyright file="Board.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System;
using System.Runtime.Serialization;

namespace Library
{
    /// <summary>
    /// La excepción levantada por un juego <see cref="Game"/> 
    /// </summary>
    [Serializable]
    public class NotEnoughPlayersException : Exception
    {
        /// <summary>
        /// La excepción levantada al querer iniciar una partida con menos de dos jugadores.
        /// </summary>
        public NotEnoughPlayersException()
        {
        }

        /// <summary>
        /// Crea una nueva excepción con el mensaje recibido como argumento.
        /// </summary>
        /// <param name="message"> El mensaje de la excepción. </param>
        public NotEnoughPlayersException(string message) : base(message)
        {
        }

        /// <summary>
        /// Crear una nueva excepción con el mensaje recibido como argumento, a partir de otra excepción
        /// que ocurrió antes y también se recibe como argumento.
        /// </summary>
        /// <param name="message">El mensaje de la excepción.</param>
        /// <param name="innerException">La excepción que provoca la creación de esta excepción.</param>
        public NotEnoughPlayersException(string message, Exception innerException)
        : base(message, innerException)
        {
        }

        /// <summary>
        /// Serializa la excepción.
        /// </summary>
        /// <param name="info">La <see cref="SerializationInfo"/> que tiene los datos del objeto.</param>
        /// <param name="context">El <see cref="StreamingContext"/> que tiene la información contextual del origen.</param>
        protected NotEnoughPlayersException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }
    }
}