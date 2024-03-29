//---------------------------------------------------------------------------------
// <copyright file="GameHandler.cs" company="Universidad Católica del Uruguay">
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
    /// Un "Handler" del patrón Chain of Responsibility que implementa el comando "game".
    /// </summary>
    public class GameHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayHandler"/>.
        /// </summary>
        /// <param name="next"> El próximo "Handler". </param>
        public GameHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "game" };
        }

        /// <summary>
        /// Procesa el mensaje "game" y retorna true; retorna false en caso contrario.
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
            if (game != null)
            {
                string tid = message.From.Id.ToString();
                Player player = UserManager.Instance.GetPlayerById(IdType.Telegram, tid);

                Board board = null;
                if (game.GetAdmin() == player)
                {
                    board = game.GetBoard1();
                }
                else { board = game.GetBoard2(); }

                if (game.GetStatus() == GameStatusType.STARTING_SERVER) { game.SetStatus(GameStatusType.GETTING_READY); }

                switch (game.GetStatus())
                {
                    case GameStatusType.GETTING_READY:
                        answr = "This is your board. Please select where do you want to place your ships!";

                        Printer(game, board, buttons, out buttons);
                        if (game.GetAdmin() == player) { buttons.Add(new [] { InlineKeyboardButton.WithCallbackData(text: "▶️ WAR! ◀️", callbackData: $"start_war-{game.GetGameId()}") }); }

                        break;
                    case GameStatusType.WAITINGP1:
                    case GameStatusType.WAITINGP2:
                        answr = "Make your attack! Select the coordinate you want to try your luck.";

                        if (game.GetAdmin() == player)
                        {
                            board = game.GetBoard2();
                        }
                        else { board = game.GetBoard1(); }

                        Printer(game, board, buttons, out buttons);
                        break; 
                    case GameStatusType.FINISHED:
                        answr = $"This game has finished! The winner of the game is @{game.Winner.GetUsername()}, thank you for playing.";

                        if (game.GetAdmin() == player)
                        {
                            board = game.GetBoard2();
                        }
                        else { board = game.GetBoard1(); }

                        Printer(game, board, buttons, out buttons);

                        buttons.Add(new []
                        {
                            InlineKeyboardButton.WithCallbackData(text: $"Return to the menu!", callbackData: $"/menu")
                        });
                        break;
                }

                InlineKeyboardMarkup inlineKeyboard = buttons.ToArray();
                response = new Response(ResponseType.Keyboard, answr);
                response.SetKeyboard(inlineKeyboard);
            }
            else {response = new Response(ResponseType.None, "");}
        }
        private void Printer(Game game, Board board, List<InlineKeyboardButton[]> buttons, out List<InlineKeyboardButton[]> final)
        {
            for (int row = 0; row < game.GetBoard1().GetRows(); row++)
            {
                List<InlineKeyboardButton> line = new List<InlineKeyboardButton>();
                for (int col = 0; col < game.GetBoard1().GetColumns(); col++)
                {                               
                    string buttonText = "";
                    string callbackData = "none";

                    switch (board.GetBoard()[row][col])
                    {
                        case ' ':
                            buttonText = "🌊";
                            if (game.GetStatus() == GameStatusType.GETTING_READY) { callbackData = $"place_ship-{game.GetGameId()},{row}/{col}"; } 
                            else if (game.GetStatus() == GameStatusType.WAITINGP1 || game.GetStatus() == GameStatusType.WAITINGP2) { callbackData = $"attack_ship-{game.GetGameId()},{row}/{col}"; }
                            break;
                        case 'S':
                            buttonText = "🚢";
                            if (game.GetStatus() == GameStatusType.GETTING_READY || game.GetStatus() == GameStatusType.FINISHED)
                            {
                                buttonText = "🚢";
                                callbackData = $"none";
                            }
                            else if (game.GetStatus() == GameStatusType.WAITINGP1 || game.GetStatus() == GameStatusType.WAITINGP2)
                            {
                                buttonText = "🌊";
                                callbackData = $"attack_ship-{game.GetGameId()},{row}/{col}";
                            }
                            break;
                        case 'X':
                            buttonText = "💥";
                            callbackData = $"none";
                            break;
                        default:
                            buttonText = game.GetBoard1().GetBoard()[row][col].ToString();
                            break;
                    }
                    if (row == 0 && col == 0)
                    {
                        buttonText = "⚫";
                        callbackData = "none";
                    }
                    line.Add(InlineKeyboardButton.WithCallbackData(text: buttonText, callbackData: callbackData));
                }
                buttons.Add(line.ToArray());
            }
            final = buttons;
        }
    }
}