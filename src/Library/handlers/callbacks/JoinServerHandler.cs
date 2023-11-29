//---------------------------------------------------------------------------------
// <copyright file="JoinServerHandler.cs" company="Universidad Católica del Uruguay">
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
    /// Un "Handler" del patrón Chain of Responsibility que implementa el comando "join_server".
    /// </summary>
    public class JoinServerHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayHandler"/>.
        /// </summary>
        /// <param name="next"> El próximo "Handler". </param>
        public JoinServerHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "join_server" };
        }

        /// <summary>
        /// Procesa el mensaje "join_server" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message"> El mensaje a procesar. </param>
        /// <param name="response"> La respuesta al mensaje procesado. </param>
        /// <returns> true si el mensaje fue procesado; false en caso contrario. </returns>
        protected override void InternalHandle(Message message, out Response response)
        {
            string serverID = message.Text.Split("join_server-")[1];
            Logger.Instance.Debug("Want to join the game: " + serverID);

            List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();

            Game game = ServerManager.Instance.GetGame(serverID);
            Logger.Instance.Debug("t1");
            if (game != null)
            {
                Logger.Instance.Debug("t2");
                string answr = "";

                string tid = message.From.Id.ToString();
                Player player = UserManager.Instance.GetPlayerById(IdType.Telegram, tid);

                Logger.Instance.Debug($"debug player: {UserManager.Instance.GetPlayers().ToArray()[0].TelegramId}");
                Logger.Instance.Debug($"");

                if (player != null)
                {
                    Logger.Instance.Debug("t3");
                    // Redirect a gamemenu-sessionid
                    if (!game.GetPlayers().Contains(player))
                    {
                        Logger.Instance.Debug("t4");
                        game.AddPlayer(player);
                        answr = $"You successfully joined the game {game.GetSessionName()}! Please, go to the waiting room.";

                        buttons.Add(new []
                        {
                            InlineKeyboardButton.WithCallbackData(text: $"Go to the waiting room!", callbackData: $"wait_game-{game.GetGameId()}")
                        });
                    }
                    else
                    {
                        Logger.Instance.Debug("t5");
                        answr = "Somehow, it was not possible to join you to the game. Go back to the menu.";
                        buttons.Add(new []
                        {
                            InlineKeyboardButton.WithCallbackData(text: $"Go back to the menu", callbackData: $"/menu")
                        });
                    }

                    InlineKeyboardMarkup inlineKeyboard = buttons.ToArray();
                    response = new Response(ResponseType.Keyboard, answr);
                    response.SetKeyboard(inlineKeyboard);
                }
                else { response = new Response(ResponseType.None, ""); }
            }
            else { response = new Response(ResponseType.None, ""); }
        }
    }
}