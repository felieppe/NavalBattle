//---------------------------------------------------------------------------------
// <copyright file="AttackShipHandler.cs" company="Universidad Católica del Uruguay">
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
    /// Un "Handler" del patrón Chain of Responsibility que implementa el comando "attack_ship".
    /// </summary>
    public class AttackShipHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayHandler"/>.
        /// </summary>
        /// <param name="next"> El próximo "Handler". </param>
        public AttackShipHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "attack_ship" };
        }

        /// <summary>
        /// Procesa el mensaje "attack_ship" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message"> El mensaje a procesar. </param>
        /// <param name="response"> La respuesta al mensaje procesado. </param>
        /// <returns> true si el mensaje fue procesado; false en caso contrario. </returns>
        protected override void InternalHandle(Message message, out Response response)
        {
            string data = message.Text.Split("attack_ship-")[1];
            string serverID = data.Split(",")[0];
            string coords = data.Split(",")[1];

            int row = int.Parse(coords.Split("/")[0]);
            int col = int.Parse(coords.Split("/")[1]);

            string answr = "";

            Game game = ServerManager.Instance.GetGame(serverID);
            if (game != null)
            {
                string tid = message.From.Id.ToString();
                Player player = UserManager.Instance.GetPlayerById(IdType.Telegram, tid);

                List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
                Board board = null;
                if (game.GetAdmin() == player)
                {
                    board = game.GetBoard2();
                }
                else { board = game.GetBoard1(); }

                char letter = (char)('A' + (col - 1));
                Logger.Instance.Info($"@{player.GetUsername()} want to attack a ship in {letter}/{row} in game '{game.GetSessionName()}'.");

                if (game.GetStatus() == GameStatusType.WAITINGP1)
                {
                    if (player == game.GetAdmin()) { Attack(game, board, letter, row, answr, out answr); }
                    else { answr = "Is the other player turn! Please wait and return to the board."; }
                }
                else if (game.GetStatus() == GameStatusType.WAITINGP2)
                {
                    if (player != game.GetAdmin()) { Attack(game, board, letter, row, answr, out answr); }
                    else { answr = "Is the other player turn! Please wait and return to the board."; }
                }

                buttons.Add(new []
                {
                    InlineKeyboardButton.WithCallbackData(text: $"Return to the board! ♟", callbackData: $"game-{game.GetGameId()}")
                });

                InlineKeyboardMarkup inlineKeyboard = buttons.ToArray();
                response = new Response(ResponseType.Keyboard, answr);
                response.SetKeyboard(inlineKeyboard);
            }
            else { response = new Response(ResponseType.None, ""); }
        }

        private void Attack(Game game, Board board, char letter, int row, string answr, out string final)
        {
            GameLogic gl = new GameLogic(game, board);
            gl.Attack(letter, row);

            answr = $"You attacked the {letter}{row} coordinate. Go back to the board and check if you did well with your attack!";
            final = answr;
        }
    }
}