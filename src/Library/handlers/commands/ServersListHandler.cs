//---------------------------------------------------------------------------------
// <copyright file="ServersListHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using System.Collections.Generic;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Library.handlers.core;
using Library.bot;
using Library.bot.core;

namespace Library.handlers
{
    /// <summary>
    /// Un "Handler" del patrón Chain of Responsibility que implementa los comandos "servers" y "join".
    /// </summary>
    public class ServersListHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayHandler"/>.
        /// </summary>
        /// <param name="next"> El próximo "Handler". </param>
        public ServersListHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "/servers", "/join" };
        }

        /// <summary>
        /// Procesa el mensaje "servers" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message"> Mensaje a procesar. </param>
        /// <param name="response"> Respuesta al mensaje procesado. </param>
        /// <returns> true si el mensaje fue procesado; false en caso contrario. </returns>
        protected override void InternalHandle(Message message, out Response response)
        {
            User author = message.From;
            string answr = $"This are the available servers to play! If you want to create one, go back.";

            List<Game> availableServers = ServerManager.Instance.GetListing();
            List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
            
            int x = 1;
            foreach (Game server in availableServers)
            {
                if (server.GetStatus() != utils.core.GameStatusType.FINISHED) {
                    buttons.Add(new []
                    {
                        InlineKeyboardButton.WithCallbackData(text: $"{x}. {server.GetSessionName()} ({server.GetPlayers().Count}/2)", callbackData: $"show_server-{server.GetGameId()}")
                    });
                    x += 1;
                }
            }

            if (x == 1)
            {
                buttons.Add(new []
                {
                    InlineKeyboardButton.WithCallbackData(text: $"No servers available! 🚮", callbackData: $"none")
                });
            }

            buttons.Add(new []
            {
                InlineKeyboardButton.WithCallbackData(text: $"Return 🔙", callbackData: $"return-/menu")
            });
            InlineKeyboardMarkup inlineKeyboard = buttons.ToArray();

            response = new Response(ResponseType.Keyboard, answr);
            response.SetKeyboard(inlineKeyboard);
        }
    }
}