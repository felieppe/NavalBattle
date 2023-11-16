//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Globalization;
using System;
using Library;
using Library.handlers;
using Library.bot;
using Library.bot.core;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace NavalBattle
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public class Program
    {
        private static Configuration Config = new Configuration();
        private static Logger Logger = new Logger(Config);
        private static TelegramBotClient Bot;

        private static IHandler Handler;

        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main() {
            Logger.Info($"Setting up @{Config.GetUsername()}...");

            Bot = new TelegramBotClient(Config.GetToken());
            var cts = new CancellationTokenSource();

            Handler = new PlayHandler(null);

            Bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                new ReceiverOptions()
                {
                    AllowedUpdates = Array.Empty<UpdateType>()
                },
                cts.Token
            );

            Logger.Info($"{Config.GetUsername()} is up!");

            Console.ReadLine();
            cts.Cancel();
        }

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try {
                if (update.Type == UpdateType.Message) {
                    await HandleMessageReceived(botClient, update.Message);
                }
            }
            catch(Exception e) {
                await HandleErrorAsync(botClient, e, cancellationToken);
            }
        }
        private static async Task HandleMessageReceived(ITelegramBotClient botClient, Message message) {
            Logger.Info($"Received a message from {message.From.FirstName} saying: {message.Text}");

            Response response = new Response(ResponseType.None, null); 
            Handler.Handle(message, out response);

            switch(response.GetType()) {
                case ResponseType.Message:
                    if (!string.IsNullOrEmpty(response.GetMessage())) {
                        await Bot.SendTextMessageAsync(message.Chat.Id, response.GetMessage());
                    }
                    break;
            }
        }
        public static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken) {
            Logger.Error(exception.Message);
            return Task.CompletedTask;
        }
    }
}
