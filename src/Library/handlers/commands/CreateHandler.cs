
using System.Collections.Generic;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Library.handlers.core;
using Library.bot;
using Library.bot.core;
using Library.utils.core;
using System.Runtime.Intrinsics.Arm;

namespace Library.handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class CreateHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayHandler"/>.
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CreateHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "/create" };
        }

        /// <summary>
        /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out Response response)
        {
            User author = message.From;
            string answr = $"Game session was created successfully! Redirect you to the waiting room.";

            // Getting player from UM by TID.
            Player player = UserManager.Instance.GetPlayerById(IdType.Telegram, author.Id.ToString());

            if (!UserManager.Instance.GetInGamePlayers().Contains(player)) {
                // Creating game...
                Game game = new Game(10, 10, 10);
                game.SetGameSession($"{author.FirstName} game");
                game.AddPlayer(player); // Player will be admin of this game.

                ServerManager.Instance.AddGame(game);

                List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>
                {
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData(text: $"Waiting room 🚻", callbackData: $"wait_game-{game.GetGameId()}")
                    }
                };
                InlineKeyboardMarkup inlineKeyboard = buttons.ToArray();

                response = new Response(ResponseType.Keyboard, answr);
                response.SetKeyboard(inlineKeyboard);
            }
            else { response = new Response(ResponseType.Message, "You already joined a game!"); }
        }
    }
}