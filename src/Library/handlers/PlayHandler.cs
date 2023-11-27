//---------------------------------------------------------------------------------
// <copyright file="PlayHandler.cs" company="Universidad Católica del Uruguay">
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
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "play".
    /// </summary>
    public class PlayHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayHandler"/>.
        /// </summary>
        /// <param name="next"> El próximo "Handler". </param>
        public PlayHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "/play" };
        }

        /// <summary>
        /// Procesa el mensaje "play" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message"> Mensaje a procesar. </param>
        /// <param name="response"> Respuesta al mensaje procesado. </param>
        /// <returns> true si el mensaje fue procesado; false en caso contrario. </returns>
        protected override void InternalHandle(Message message, out Response response)
        {
            User author = message.From;
            string answr = $"Welcome @{author.Username}! I am Alfred the Chief and I invite you to play Naval Battle! 🤓";

            // Registering user...
            Player rp = new Player();
            rp.SetTelegramId("" + author.Id);
            rp.SetUsername(author.Username);

            UserManager.Instance.AddPlayer(rp);

            InlineKeyboardMarkup inlineKeyboard = new(new[]
            {
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Play 🎮", callbackData: "/menu"),
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