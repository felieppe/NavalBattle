
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
    public class ShowServerPlayersHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayHandler"/>.
        /// </summary>
        /// <param name="next"> El próximo "handler". </param>
        public ShowServerPlayersHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "show_server_players" };
        }

        /// <summary>
        /// Procesa el mensaje "servers" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message"> El mensaje a procesar. </param>
        /// <param name="response"> La respuesta al mensaje procesado. </param>
        /// <returns> true si el mensaje fue procesado; false en caso contrario. </returns>
        protected override void InternalHandle(Message message, out Response response)
        {
            string serverID = message.Text.Split("show_server_players-")[1];
            Logger.Instance.Debug("Want to show the players list of: " + serverID);

            Game game = ServerManager.Instance.GetGame(serverID);
            if (game != null)
            {
                string answr = "This is the player list of the game you selected.";

                List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();

                // Showing players
                int x = 1;
                foreach (Player p in game.GetPlayers())
                {
                    buttons.Add(new []
                    {
                        InlineKeyboardButton.WithCallbackData(text: $"{x}. @{p.GetUsername()}", callbackData: $"none")
                    });
                }

                buttons.Add(new []
                {
                    InlineKeyboardButton.WithCallbackData(text: $"Return 🔙", callbackData: $"return-show_server-{game.GetGameId()}")
                });
                InlineKeyboardMarkup inlineKeyboard = buttons.ToArray();

                response = new Response(ResponseType.Keyboard, answr, ikm: inlineKeyboard);
            }
            else { response = new Response(ResponseType.None, ""); }
        }
    }
}