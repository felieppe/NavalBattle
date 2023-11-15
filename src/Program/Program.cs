//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Globalization;
using System;
using Library;

namespace NavalBattle
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public class Program
    {
        private static Configuration Config = new Configuration();
        private static Logger Logger = new Logger(config);
        private static TelegramClientBot Bot;

        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main() {
            Logger.Info($"Setting up @{Config.GetUsername()}...");

            bot = new TelegramClientBot(Config.GetToken());
            var cts = new CancellationTokenSource();

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
        }
    }
}
