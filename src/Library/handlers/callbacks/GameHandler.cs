
using System.Collections.Generic;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Library.handlers.core;
using Library.bot;
using Library.bot.core;
using Library.utils.core;
using Library.managers;

namespace Library.handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa los comandos "servers" y "join".
    /// </summary>
    public class GameHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayHandler"/>.
        /// </summary>
        /// <param name="next"> El próximo "handler". </param>
        public GameHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "game" };
        }

        /// <summary>
        /// Procesa el mensaje "servers" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message"> El mensaje a procesar. </param>
        /// <param name="response"> La respuesta al mensaje procesado. </param>
        /// <returns> true si el mensaje fue procesado; false en caso contrario. </returns>
        protected override void InternalHandle(Message message, out Response response)
        {
            string serverID = message.Text.Split("game-")[1];
            string answr = "";

            List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();

            Game game = ServerManager.Instance.GetGame(serverID);
            if (game != null) {
                string tid = message.From.Id.ToString();
                Player player = UserManager.Instance.GetPlayerById(utils.core.IdType.Telegram, tid);


                Board board = null;
                if (game.GetAdmin() == player) {
                    board = game.GetBoard1();
                } else { board = game.GetBoard2(); }

                Logger.Instance.Debug("rows; " + game.GetBoard1().rows + " ; col: " + game.GetBoard1().columns);

                switch (game.GetStatus()) {
                    case GameStatusType.INGAME:
                        answr = "This is your board. Please select where do you want to place your ships!";

                        for (int row = 0; row < (game.GetBoard1().GetRows()); row++) {
                            
                            List<InlineKeyboardButton> line = new List<InlineKeyboardButton>();
                            for (int col = 0; col < (game.GetBoard1().GetColumns()); col++) {                               
                                string buttonText = "";
                                string callbackData = "none";

                                switch (board.GetBoard()[row][col]) {
                                    case ' ':
                                        buttonText = "🌊";
                                        callbackData = $"place_ship-{game.GetGameId()},{row}/{col}";
                                        break;
                                    case 'S':
                                        buttonText = "🚢";
                                        callbackData = $"none";
                                        break;
                                    default:
                                        buttonText = game.GetBoard1().GetBoard()[row][col].ToString();
                                        break;
                                }

                                if (row == 0 && col == 0) {
                                    buttonText = "⚫";
                                    callbackData = "none";
                                }

                                line.Add(InlineKeyboardButton.WithCallbackData(text: buttonText, callbackData: callbackData));
                            }

                            buttons.Add(line.ToArray());
                        }

                        if (game.GetAdmin() == player) { buttons.Add(new [] { InlineKeyboardButton.WithCallbackData(text: "▶️ WAR! ◀️", callbackData: $"start_war-{game.GetGameId()}") }); }

                        break;
                }

                // Chequear si es el ultimo barquito q puede poner el jugador

                InlineKeyboardMarkup inlineKeyboard = buttons.ToArray();
                response = new Response(ResponseType.Keyboard, answr);
                response.SetKeyboard(inlineKeyboard);
            } else {response = new Response(ResponseType.None, "");}
        }
    }
}