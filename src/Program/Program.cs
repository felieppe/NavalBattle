﻿//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
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
using Library.utils.core;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Linq;
using Library.managers;


namespace NavalBattle   
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public static class Program
    {
        private static Configuration Config;
        private static Logger Logger = Logger.Instance;
        private static TelegramBotClient Bot;
        private static IHandler Handler;

        private static void Setup() {
            Bot = new TelegramBotClient(Config.GetToken());

            // Save folder setup
            string folderPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\")) + "/save";
            if (!Directory.Exists(folderPath)) { Directory.CreateDirectory(folderPath); }

            if (!Directory.Exists(folderPath + $"/{Config.GetUsername()}")) { Directory.CreateDirectory(folderPath + $"/{Config.GetUsername()}"); }
            if (!Directory.Exists(folderPath + $"/{Config.GetUsername()}/players")) { Directory.CreateDirectory(folderPath + $"/{Config.GetUsername()}/players"); }
            if (!Directory.Exists(folderPath + $"/{Config.GetUsername()}/servers")) { Directory.CreateDirectory(folderPath + $"/{Config.GetUsername()}/servers"); }
            if (!Directory.Exists(folderPath + $"/{Config.GetUsername()}/chats")) { Directory.CreateDirectory(folderPath + $"/{Config.GetUsername()}/chats"); }
        
            // Starting new instances
            _ = UserManager.Instance;
            _ = ServerManager.Instance;
            _ = ChatManager.Instance;
        }

        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            try
            {
                Config = new Configuration();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                Environment.Exit(1);
            }

            Logger.Info($"Setting up @{Config.GetUsername()}...");
            Setup();

            var cts = new CancellationTokenSource();
            Handler =
                new PlayHandler(
                    new MenuHandler(
                        new ServersListHandler(
                            new ReturnHandler(
                                new ShowServerHandler(
                                    new ShowServerPlayersHandler(
                                        new JoinServerHandler(
                                            new CreateHandler(
                                                new WaitGameHandler(
                                                    new LeaveServerHandler(null)
            )))))))));

            Bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                new ReceiverOptions()
                {
                    AllowedUpdates = new UpdateType[] {
                        UpdateType.Message, UpdateType.CallbackQuery
                    }
                },
                cts.Token   
            );

            Logger.Info($"@{Config.GetUsername()} is up!");

            Console.ReadLine();
            cts.Cancel();
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                switch(update.Type) {
                    case UpdateType.Message:
                        await HandleMessageReceived(botClient, update.Message);
                        break;
                    case UpdateType.CallbackQuery:
                        await HandleCallbackReceived(botClient, update);
                        break;
                }
            }
            catch(Exception e)
            {
                await HandleErrorAsync(botClient, e, cancellationToken);
            }
        }
        private static async Task HandleMessageReceived(ITelegramBotClient botClient, Message message)
        {
            Logger.Info($"Received a message from {message.From.FirstName} saying: {message.Text}");

            CheckIfUserBusy(message, out message);
            Logger.Debug("final: " + message.Text);

            Response response = new Response(ResponseType.None, null); 
            Handler.Handle(message, out response);

            switch(response.GetType())
            {
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
        private static async Task HandleCallbackReceived(ITelegramBotClient botClient, Update update) {
            string data = update.CallbackQuery.Data;
            Logger.Info($"Received a callback from {update.CallbackQuery.From.FirstName}: {data}");

            Message msg = new Message();
            msg.Chat = update.CallbackQuery.Message.Chat;
            msg.MessageId = update.Id;
            msg.From = update.CallbackQuery.From;
            msg.Text = data;

            CheckIfUserBusy(msg, out msg);
            Logger.Debug("cllbk final: " + msg.Text);

            Response response = new Response(ResponseType.None, null); 
            Handler.Handle(msg, out response);

            switch (response.GetType()) {
                case ResponseType.Keyboard:
                    await Bot.DeleteMessageAsync(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId);
                    await Bot.SendTextMessageAsync(msg.Chat.Id, response.GetMessage(), replyMarkup: response.GetKeyboard());
                    break;
                case ResponseType.Return:
                    break;
            }
        }
        private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Logger.Error(exception.Message);
            return Task.CompletedTask;
        }

        private static string[] bypass = {"start_server", "leave_server", "wait_game"};
        private static void CheckIfUserBusy(Message message, out Message final) {
            string cmd = message.Text.Split("-")[0];
            if (!bypass.Contains(cmd)) {
                Player player = UserManager.Instance.GetPlayerById(IdType.Telegram, message.From.Id.ToString());
                if (player != null) {
                    foreach (Player p in UserManager.Instance.GetInGamePlayers()) {
                    }
                    if (UserManager.Instance.GetInGamePlayers().Contains(player)) { 
                        List<Library.Game> games = ServerManager.Instance.GetListing();
                        
                        Library.Game founded = null;
                        foreach (Library.Game game in games) {
                            if (game.GetPlayers().Contains(player)) { founded = game; Logger.Instance.Debug("Game founded!");}
                        }

                        if (founded != null) {
                            switch (founded.GetStatus()) {
                                case GameStatusType.INGAME:
                                    // Redirect to playable game. (WIP)
                                    break;
                                case GameStatusType.WAITING:
                                    message.Text = $"wait_game-{founded.GetGameId()}";
                                    break;
                            }
                        }
                    }
                }
            }

            final = message;
        }
    }
}
