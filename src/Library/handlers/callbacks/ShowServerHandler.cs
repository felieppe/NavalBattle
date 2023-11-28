
using System.Collections.Generic;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Library.handlers.core;
using Library.bot;
using Library.bot.core;

namespace Library.handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa los comandos "servers" y "join".
    /// </summary>
    public class ShowServerHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayHandler"/>.
        /// </summary>
        /// <param name="next"> El próximo "handler". </param>
        public ShowServerHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "show_server" };
        }

        /// <summary>
        /// Procesa el mensaje "servers" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message"> El mensaje a procesar. </param>
        /// <param name="response"> La respuesta al mensaje procesado. </param>
        /// <returns> true si el mensaje fue procesado; false en caso contrario. </returns>
        protected override void InternalHandle(Message message, out Response response)
        {
            string serverID = message.Text.Split("show_server-")[1];
            Logger.Instance.Debug("Want to show the game: " + serverID);

            Game game = ServerManager.Instance.GetGame(serverID);
            if (game != null)
            {
                string answr = "This is the information about the game session you want to join.";

                List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>
                {
                    // Session name
                    new[]
                {
                    InlineKeyboardButton.WithCallbackData(text: $"Session name: {game.GetSessionName()}", callbackData: $"none")
                },

                    // Players count
                    new[]
                {
                    InlineKeyboardButton.WithCallbackData(text: $"Players: {game.GetPlayers().Count}/2", callbackData: $"show_server_players-{game.GetGameId()}")
                },

                    // Separator
                    new[]
                {
                    InlineKeyboardButton.WithCallbackData(text: $"------------------", callbackData: $"join_server-{game.GetGameId()}")
                }
                };

                // Join button
                if (game.GetPlayers().Count < 2) {
                    buttons.Add(new []
                    {
                        InlineKeyboardButton.WithCallbackData(text: $"Join ⏩", callbackData: $"join_server-{game.GetGameId()}")
                    });
                }

                buttons.Add(new []
                {
                    InlineKeyboardButton.WithCallbackData(text: $"Return 🔙", callbackData: $"return-/servers")
                });
                InlineKeyboardMarkup inlineKeyboard = buttons.ToArray();

                response = new Response(ResponseType.Keyboard, answr, ikm: inlineKeyboard);
            }
            else { response = new Response(ResponseType.None, ""); }
        }
    }
}