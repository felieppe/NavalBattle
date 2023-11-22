﻿//--------------------------------------------------------------------------------
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
using System.IO;

namespace NavalBattle   
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public class Program
    {
        private static Configuration Config;
        private static Logger Logger = Logger.Instance;
        private static TelegramBotClient Bot;

        private static IHandler Handler;

        private static void Setup() {
            Bot = new TelegramBotClient(Config.GetToken());

            _ = UserManager.Instance;
            _ = ServerManager.Instance;

            // Save folder setup
            string folderPath = "../../save";
            if (!Directory.Exists(folderPath)) { Directory.CreateDirectory(folderPath); }

            if (!Directory.Exists(folderPath + $"/{Config.GetUsername()}")) { Directory.CreateDirectory(folderPath + $"/{Config.GetUsername()}"); }
            if (!Directory.Exists(folderPath + $"/{Config.GetUsername()}/players")) { Directory.CreateDirectory(folderPath + $"/{Config.GetUsername()}/players"); }
            if (!Directory.Exists(folderPath + $"/{Config.GetUsername()}/servers")) { Directory.CreateDirectory(folderPath + $"/{Config.GetUsername()}/servers"); }
        }

        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main() {
            try {
                Config = new Configuration();
            } catch (Exception ex) {
                Console.WriteLine("ERROR: " + ex.Message);
                Environment.Exit(1);
            }

            Logger.Info($"Setting up @{Config.GetUsername()}...");
            Setup();

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

            Logger.Info($"@{Config.GetUsername()} is up!");

            Console.ReadLine();
            cts.Cancel();
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
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
                case ResponseType.Keyboard:
                    await Bot.SendTextMessageAsync(message.Chat.Id, response.GetMessage(), replyMarkup: response.GetKeyboard());
                    break;
            }
        }
        private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken) {
            Logger.Error(exception.Message);
            return Task.CompletedTask;
        }
    }
}
