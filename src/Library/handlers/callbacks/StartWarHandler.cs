
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
    public class StartWarHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayHandler"/>.
        /// </summary>
        /// <param name="next"> El próximo "handler". </param>
        public StartWarHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "start_war" };
        }

        /// <summary>
        /// Procesa el mensaje "servers" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message"> El mensaje a procesar. </param>
        /// <param name="response"> La respuesta al mensaje procesado. </param>
        /// <returns> true si el mensaje fue procesado; false en caso contrario. </returns>
        protected override void InternalHandle(Message message, out Response response)
        {
            string serverID = message.Text.Split("start_war-")[1];

            Game game = ServerManager.Instance.GetGame(serverID);
            if (game != null) {
                string tid = message.From.Id.ToString();
                Player player = UserManager.Instance.GetPlayerById(utils.core.IdType.Telegram, tid);

                string answr = "";
                List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
                if (game.GetPlayers().Count == 2) {
                    answr = $"The war between {game.GetPlayers().ToArray()[0]} vs {game.GetPlayers().ToArray()[1]   } has started. Make yours attacks!";
                    game.SetStatus(utils.core.GameStatusType.WAITINGP1);

                    buttons.Add(new []
                    {
                        InlineKeyboardButton.WithCallbackData(text: $"Return to the board! ♟", callbackData: $"game-{game.GetGameId()}")
                    });
                } else {
                    answr = "It was not possible to start the war because is missing one player.";

                    buttons.Add(new []
                    {
                        InlineKeyboardButton.WithCallbackData(text: $"Return to the waiting room!", callbackData: $"game-{game.GetGameId()}")
                    });
                }

                InlineKeyboardMarkup inlineKeyboard = buttons.ToArray();
                response = new Response(ResponseType.Keyboard, answr, ikm: inlineKeyboard);
            } else { response = new Response(ResponseType.None, ""); }
        }
    }
}