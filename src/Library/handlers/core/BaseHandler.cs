//---------------------------------------------------------------------------------
// <copyright file="BaseHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using System;
using System.Linq;
using Telegram.Bot.Types;
using Library.bot;
using Library.bot.core;

namespace Library.handlers.core
{
    /// <summary>
    /// Base para los Handlers.
    /// </summary>
    public abstract class BaseHandler : IHandler
    {
        /// <summary>
        /// Obtiene el próximo "Handler".
        /// </summary>
        /// <value> El "Handler" que será invocado si este "handler" no procesa el mensaje. </value>
        public IHandler Next { get; set; }

        /// <summary>
        /// Obtiene o asigna el conjunto de palabras clave que este "Handler" puede procesar.
        /// </summary>
        /// <value> Array de palabras clave. </value>
        public string[] Keywords { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>.
        /// </summary>
        /// <param name="next"> El próximo "Handler". </param>
        public BaseHandler(IHandler next)
        {
            Next = next;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/> con una lista de comandos.
        /// </summary>
        /// <param name="keywords"> Lista de comandos. </param>
        /// <param name="next"> Próximo "Handler".</param>
        public BaseHandler(string[] keywords, BaseHandler next)
        {
            Keywords = keywords;
            Next = next;
        }

        /// <summary>
        /// Este método debe ser sobrescrito por las clases sucesores. La clase sucesora procesa el mensaje y asigna
        /// la respuesta al mensaje.
        /// </summary>
        /// <param name="message"> Mensaje a procesar. </param>
        /// <param name="response"> Respuesta al mensaje procesado. </param>
        protected abstract void InternalHandle(Message message, out Response response);

        /// <summary>
        /// Este método puede ser sobrescrito en las clases sucesores que procesan varios mensajes cambiando de estado
        /// entre mensajes deben sobrescribir este método para volver al estado inicial. En la clase base no hace nada.
        /// </summary>
        protected virtual void InternalCancel(Message message)
        {
            // Intencionalmente en blanco.
        }

        /// <summary>
        /// Determina si este "Handler" puede procesar el mensaje. En la clase base se utiliza el array
        /// <see cref="Keywords"/> para buscar el texto en el mensaje ignorando mayúsculas y minúsculas. Las
        /// clases sucesores pueden sobrescribir este método para proveer otro mecanismo para determina si procesan o no
        /// un mensaje.
        /// </summary>
        /// <param name="message"> Mensaje a procesar.</param>
        /// <returns> true si el mensaje puede ser procesado; false en caso contrario. </returns>
        protected virtual bool CanHandle(Message message)
        {
            // Cuando no hay palabras clave este método debe ser sobrescrito por las clases sucesoras y por lo tanto
            // este método no debería haberse invocado.
            if (Keywords == null || Keywords.Length == 0)
            {
                throw new InvalidOperationException("No hay palabras clave que puedan ser procesadas");
            }

<<<<<<< HEAD
            return Keywords.Any(s => message.Text.Equals(s, StringComparison.InvariantCultureIgnoreCase));
=======
            List<string> kws = new List<string>();
            string[] splitted = message.Text.Split(" ");
            foreach (string s in splitted) {
                kws.Add(s.Split("-")[0]);
            }

            foreach (string keyword in kws) {
                foreach (string handled in this.Keywords) { if (keyword == handled) { return true; } }
            }
            return false;
>>>>>>> 130e6caf9191761934f45e25028bd936745bdf3c
        }

        /// <summary>
        /// Procesa el mensaje o lo pasa al siguiente "Handler" si existe.
        /// </summary>
        /// <param name="message"> Mensaje a procesar. </param>
        /// <param name="response"> Respuesta al mensaje procesado. </param>
        /// <returns> El "Handler" que procesó el mensaje si el mensaje fue procesado; null en caso contrario. </returns>
        public IHandler Handle(Message message, out Response response)
        {
            if (CanHandle(message))
            {
                InternalHandle(message, out response);
                return this;
            }
            else if (Next != null)
            {
                return Next.Handle(message, out response);
            }
            else
            {
                response = new Response(ResponseType.None, null);
                return null;
            }
        }

        /// <summary>
        /// Retorna este "Handler" al estado inicial. En los "Handler" sin estado no hace nada. Los "Handlers" que
        /// procesan varios mensajes cambiando de estado entre mensajes deben sobrescribir este método para volver al
        /// estado inicial.
        /// </summary>
        public virtual void Cancel(Message message)
        {
            InternalCancel(message);
            if (Next != null)
            {
                Next.Cancel(message);
            }
        }
    }
}