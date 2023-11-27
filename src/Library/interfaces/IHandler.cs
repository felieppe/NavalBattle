//---------------------------------------------------------------------------------
// <copyright file="IHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using Telegram.Bot.Types;
using Library.bot;

namespace Library
{
    /// <summary>
    /// Interfaz IHandler.
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// Obtiene el próximo "Handler".
        /// </summary>
        /// <value> El "Handler" que será invocado si este "handler" no procesa el mensaje. </value>
        IHandler Next { get; set; }

        /// <summary>
        /// Procesa el mensaje o la pasa al siguiente "Handler" si existe.
        /// </summary>
        /// <param name="message"> Mensaje a procesar. </param>
        /// <param name="response"> Respuesta al mensaje procesado. </param>
        /// <returns> El "Handler" que procesó el mensaje si el mensaje fue procesado; null en caso contrario. </returns>
        IHandler Handle(Message message, out Response response);

        /// <summary>
        /// Retorna este "Handler" al estado inicial y cancela el próximo "Handler" si existe. Es utilizado para que los
        /// "Handlers" que procesan varios mensajes cambiando de estado entre mensajes puedan volver al estado inicial en
        /// caso de error por ejemplo.
        /// </summary>
        void Cancel(Message message);
    }
}