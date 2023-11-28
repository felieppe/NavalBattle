//---------------------------------------------------------------------------------
// <copyright file="WaitGameHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using System.Collections.Generic;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Library.handlers.core;
using Library.bot;
using Library.bot.core;
using Library.utils.core;

namespace Library.handlers
{
    /// <summary>
    /// Un "Handler" del patrón Chain of Responsibility que implementa el comando "wait_game".
    /// </summary>
    public class WaitGameHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayHandler"/>.
        /// </summary>
        /// <param name="next"> El próximo "Handler". </param>
        public WaitGameHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "wait_game" };
        }

        /// <summary>
        /// Procesa el mensaje "wait_game" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message"> El mensaje a procesar. </param>
        /// <param name="response"> La respuesta al mensaje procesado. </param>
        /// <returns> true si el mensaje fue procesado; false en caso contrario. </returns>
        protected override void InternalHandle(Message message, out Response response)
        {
            string serverID = message.Text.Split("wait_game-")[1];
            string answr = "You are currently in the waiting room of the game.";

            List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();

            Game game = ServerManager.Instance.GetGame(serverID);
            if (game != null)
            {
                string tid = message.From.Id.ToString();
                Player player = UserManager.Instance.GetPlayerById(IdType.Telegram, tid);

                if (player.Equals(game.GetAdmin()))
                {
                    buttons.Add(new []
                    {
                        InlineKeyboardButton.WithCallbackData(text: $"Start game ▶", callbackData: $"start_server-{game.GetGameId()}")
                    });
                }

                buttons.Add(new []
                {
                    InlineKeyboardButton.WithCallbackData(text: $"Leave game ❌", callbackData: $"leave_server-{game.GetGameId()}")
                });
            }
            else { response = new Response(ResponseType.None, ""); }

            InlineKeyboardMarkup inlineKeyboard = buttons.ToArray();
            response = new Response(ResponseType.Keyboard, answr);
            response.SetKeyboard(inlineKeyboard);
        }
    }
}