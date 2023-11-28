//---------------------------------------------------------------------------------
// <copyright file="ReturnHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using Telegram.Bot.Types;
using Library.handlers.core;
using Library.bot;
using Library.bot.core;

namespace Library.handlers
{
    /// <summary>
    /// Un "Handler" del patrón Chain of Responsibility que implementa el comando "return".
    /// </summary>
    public class ReturnHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayHandler"/>.
        /// </summary>
        /// <param name="next"> El próximo "Handler". </param>
        public ReturnHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "return" };
        }

        /// <summary>
        /// Procesa el mensaje "return" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message"> El mensaje a procesar. </param>
        /// <param name="response"> La respuesta al mensaje procesado. </param>
        /// <returns> true si el mensaje fue procesado; false en caso contrario. </returns>
        protected override void InternalHandle(Message message, out Response response)
        {
            string whereReturn = message.Text.Split("return-")[1];
            response = new Response(ResponseType.Return, "", ret: whereReturn);
        }
    }
}