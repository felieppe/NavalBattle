//---------------------------------------------------------------------------------
// <copyright file="MenuHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Library.handlers.core;
using Library.bot;
using Library.bot.core;

namespace Library.handlers
{
    /// <summary>
    /// Un "Handler" del patrón Chain of Responsibility que implementa el comando "/menu".
    /// </summary>
    public class MenuHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayHandler"/>.
        /// </summary>
        /// <param name="next"> El próximo "Handler". </param>
        public MenuHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "/menu" };
        }

        /// <summary>
        /// Procesa el mensaje "/menu" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message"> Mensaje a procesar. </param>
        /// <param name="response"> Respuesta al mensaje procesado. </param>
        /// <returns> true si el mensaje fue procesado; false en caso contrario. </returns>
        protected override void InternalHandle(Message message, out Response response)
        {
            User author = message.From;
            string answr = $"Select an option from the main menu:";

            InlineKeyboardMarkup inlineKeyboard = new(new[]
            {
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Create a game 🆕", callbackData: "/create"),
                },
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Join a game 🎯", callbackData: "/join"),
                },
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Quit ❌", callbackData: "/quit"),
                },
            });
            response = new Response(ResponseType.Keyboard, answr);
            response.SetKeyboard(inlineKeyboard);
        }
    }
}