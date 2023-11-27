
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
    /// Un "handler" del patrón Chain of Responsibility que implementa los comandos "servers" y "join".
    /// </summary>
    public class LeaveServerHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayHandler"/>.
        /// </summary>
        /// <param name="next"> El próximo "handler". </param>
        public LeaveServerHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "leave_server" };
        }

        /// <summary>
        /// Procesa el mensaje "servers" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message"> El mensaje a procesar. </param>
        /// <param name="response"> La respuesta al mensaje procesado. </param>
        /// <returns> true si el mensaje fue procesado; false en caso contrario. </returns>
        protected override void InternalHandle(Message message, out Response response)
        {
            string serverID = message.Text.Split("leave_server-")[1];
            string answr = "You successfully leave the game!";

            List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();

            Game game = ServerManager.Instance.GetGame(serverID);
            if (game != null)
            {
                string tid = message.From.Id.ToString();
                Player player = UserManager.Instance.GetPlayerById(IdType.Telegram, tid);

                if (UserManager.Instance.GetInGamePlayers().Contains(player))
                {
                    int before_count = game.GetPlayers().Count;
                    game.RemovePlayer(player);

                    if (before_count > game.GetPlayers().Count)
                    {
                        buttons.Add(new []
                        {
                            InlineKeyboardButton.WithCallbackData(text: $"Return to menu", callbackData: $"/menu")
                        });

                        InlineKeyboardMarkup inlineKeyboard = buttons.ToArray();
                        response = new Response(ResponseType.Keyboard, answr);
                        response.SetKeyboard(inlineKeyboard);
                    }
                    else { response = new Response(ResponseType.None, ""); }
                }
                else { response = new Response(ResponseType.None, ""); }
            }
            else { response = new Response(ResponseType.None, ""); }
        }
    }
}