
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
    public class JoinServerHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlayHandler"/>.
        /// </summary>
        /// <param name="next"> El próximo "handler". </param>
        public JoinServerHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "join_server" };
        }

        /// <summary>
        /// Procesa el mensaje "servers" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message"> El mensaje a procesar. </param>
        /// <param name="response"> La respuesta al mensaje procesado. </param>
        /// <returns> true si el mensaje fue procesado; false en caso contrario. </returns>
        protected override void InternalHandle(Message message, out Response response)
        {
            string serverID = message.Text.Split("join_server-")[1];
            Logger.Instance.Debug("Want to join the game: " + serverID);

            Game game = ServerManager.Instance.GetGame(serverID);
            if (game != null) {
                string answr = "";

                string tid = message.From.Id.ToString();
                Player player = UserManager.Instance.GetPlayerById(IdType.Telegram, tid);

                if (player != null) {
                    game.AddPlayer(player);

                    // Redirect a gamemenu-sessionid
                    response = new Response(ResponseType.None, answr);
                } else { response = new Response(ResponseType.None, ""); }
            } else { response = new Response(ResponseType.None, ""); }
        }
    }
}