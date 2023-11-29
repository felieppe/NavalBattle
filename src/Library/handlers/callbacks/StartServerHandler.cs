//---------------------------------------------------------------------------------
// <copyright file="StartServerHandler.cs" company="Universidad Católica del Uruguay">
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
using Library.managers;

namespace Library.handlers
{
    /// <summary>
    /// Un "Handler" del patrón Chain of Responsibility que implementa el comando "start_server".
    /// </summary>
    public class StartServerHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayHandler"/>.
        /// </summary>
        /// <param name="next"> El próximo "Handler". </param>
        public StartServerHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "start_server" };
        }

        /// <summary>
        /// Procesa el mensaje "start_server" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message"> El mensaje a procesar. </param>
        /// <param name="response"> La respuesta al mensaje procesado. </param>
        /// <returns> true si el mensaje fue procesado; false en caso contrario. </returns>
        protected override void InternalHandle(Message message, out Response response)
        {
            string serverID = message.Text.Split("start_server-")[1];
            string answr = "The game has been started!";

            List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();

            Game game = ServerManager.Instance.GetGame(serverID);
            if (game != null)
            {
                string tid = message.From.Id.ToString();
                Player player = UserManager.Instance.GetPlayerById(IdType.Telegram, tid);
                Logger.Instance.Debug($"{game.GetAdmin().Username} | {player.Username}");
                if (game.GetAdmin() == player)
                {
                    if (game.GetPlayers().Count == 2)       // !=2 just for debug
                    {
                        game.SetStatus(GameStatusType.GETTING_READY);

                        buttons.Add(new []
                        {
                            InlineKeyboardButton.WithCallbackData(text: $"Go to the board! ♟", callbackData: $"game-{game.GetGameId()}")
                        });

                        Player otherPlayerIngame = null;
                        foreach (Player p in game.GetPlayers())
                        {
                            if (p != player) { otherPlayerIngame = p; }
                        }

                        bot.Chat otherPlayerChat = null;
                        foreach (bot.Chat c in ChatManager.Instance.Chats)
                        {
                            if (c.User == otherPlayerIngame) { otherPlayerChat = c; }
                        }

                        InlineKeyboardMarkup inlineKeyboard = buttons.ToArray();
                        response = new Response(ResponseType.Keyboard, answr);
                        response.SetKeyboard(inlineKeyboard);
                    }
                    else
                    {
                        answr = "It was not possible to start the server because is missing one player.";

                        buttons.Add(new []
                        {
                            InlineKeyboardButton.WithCallbackData(text: $"Return to the waiting room!", callbackData: $"game-{game.GetGameId()}")
                        });

                        InlineKeyboardMarkup inlineKeyboard = buttons.ToArray();
                        response = new Response(ResponseType.Keyboard, answr);
                        response.SetKeyboard(inlineKeyboard);
                    }
                }
                else {response = new Response(ResponseType.None, "");}
            }
            else {response = new Response(ResponseType.None, "");}
        }
    }
}