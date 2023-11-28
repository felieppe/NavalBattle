//---------------------------------------------------------------------------------
// <copyright file="PlaceShipHandler.cs" company="Universidad Católica del Uruguay">
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
    /// Un "Handler" del patrón Chain of Responsibility que implementa el comando "place_ship".
    /// </summary>
    public class PlaceShipHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayHandler"/>.
        /// </summary>
        /// <param name="next"> El próximo "Handler". </param>
        public PlaceShipHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "place_ship" };
        }

        /// <summary>
        /// Procesa el mensaje "place_ship" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message"> El mensaje a procesar. </param>
        /// <param name="response"> La respuesta al mensaje procesado. </param>
        /// <returns> true si el mensaje fue procesado; false en caso contrario. </returns>
        protected override void InternalHandle(Message message, out Response response)
        {
            string data = message.Text.Split("place_ship-")[1];
            string serverID = data.Split(",")[0];
            string coords = data.Split(",")[1];

            int row = int.Parse(coords.Split("/")[0]);
            int col = int.Parse(coords.Split("/")[1]);

            string answr = "";

            List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();

            Game game = ServerManager.Instance.GetGame(serverID);
            if (game != null)
            {
                string tid = message.From.Id.ToString();
                Player player = UserManager.Instance.GetPlayerById(utils.core.IdType.Telegram, tid);

                Board board = null;
                if (game.GetAdmin() == player)
                {
                    board = game.GetBoard1();
                }
                else { board = game.GetBoard2(); }

                // Place ship and then
                char letter = (char)('A' + (col - 1));
                Logger.Instance.Info($"@{player.GetUsername()} want to place a ship in {letter}/{row} in game '{game.GetSessionName()}'.");

                GameLogic gl = new GameLogic(game, board);
                Submarine sub = new Submarine();

                bool placed = gl.PlaceShip(sub, letter, row, "up");

                if (placed)
                {
                    answr = $"You placed a ship in {letter}{row}. Go back to the fight!";
                }
                else { answr = $"You are not able to place a ship in {letter}{row}. Go back to the fight!"; }

                buttons.Add(new []
                {
                    InlineKeyboardButton.WithCallbackData(text: $"Return to the board! ♟", callbackData: $"game-{game.GetGameId()}")
                });

                InlineKeyboardMarkup inlineKeyboard = buttons.ToArray();
                response = new Response(ResponseType.Keyboard, answr);
                response.SetKeyboard(inlineKeyboard);
                
            }
            else {response = new Response(ResponseType.None, "");}
        }
    }
}