//---------------------------------------------------------------------------------
// <copyright file="Serializer.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using System;
using System.IO;
using Library.bot;
using Library.utils.core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Library.utils
{
    /// <summary>
    /// Clase que guarda información.
    /// </summary>
    public class Serializer
    {
        /// <summary>
        /// Instancia de Singleton.
        /// </summary>
        /// <value> Instancia de Serializer. </value>
        private static Serializer instance;

        public bool Debug;

        public static Serializer Instance
        {
            get
            {
                if (instance == null) { instance = new Serializer(); }
                return instance;
            }
        }

        public Serializer(bool? debug = false)
        {
            Debug = (bool) debug;
        }
        #nullable enable
        public void Serialize(DataType opt, MethodType method, Game? game = null, Player? player = null, Chat? chat = null)
        {
            if (Debug) { return; }
            string baseFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\")) + $"/save/{Configuration.Instance.GetUsername()}";

            JObject obj = new JObject();
            switch (opt)
            {
                case DataType.Game:
                    if (game == null) { return; }

                    string file = $"{baseFolder}/servers/{game.GetGameId()}.json";
                    if (method == MethodType.POST)
                    {
                        obj["id"] = "" + game.GetGameId();
                        obj["name"] = game.GetSessionName();
                        obj["status"] = JsonConvert.SerializeObject(game.GetStatus(), Formatting.Indented);
                        obj["ships_coords"] = JsonConvert.SerializeObject(game.GetShipsCoords(), Formatting.Indented);
                        obj["ships"] = JsonConvert.SerializeObject(game.GetShips(), Formatting.Indented);
                        obj["ownership"] = JsonConvert.SerializeObject(game.GetOwnership(), Formatting.Indented);
                        obj["total_ships"] = game.GetTotalShips();
                        obj["players"] = JsonConvert.SerializeObject(game.GetPlayers(), Formatting.Indented);
                        obj["admin"] = JsonConvert.SerializeObject(game.GetAdmin(), Formatting.Indented);
                        obj["winner"] = JsonConvert.SerializeObject(game.Winner, Formatting.Indented);
                        obj["rows"] = game.rows;
                        obj["columns"] = game.columns;
                        obj["board_1"] = JsonConvert.SerializeObject(game.GetBoard1(), Formatting.Indented);
                        obj["board_2"] = JsonConvert.SerializeObject(game.GetBoard2(), Formatting.Indented);

                        using (StreamWriter writer = new StreamWriter(file, false))
                        {
                            writer.WriteLine(obj.ToString());
                        }

                        Logger.Instance.Info("A game has just been saved!");
                    }
                    else
                    {
                        if (File.Exists(file))
                        { 
                            File.Delete(file);
                            Logger.Instance.Info("A game has just been removed!");
                        }
                    }
                    break;
                case DataType.Player:
                    if (player == null) { return; }

                    string playerFile = $"{baseFolder}/players/{player.GetId()}.json";
                    if (method == MethodType.POST) {
                        obj["id"] = player.GetId();
                        obj["tid"] = player.GetTelegramId();
                        obj["username"] = player.GetUsername();

                        using (StreamWriter writer = new StreamWriter(playerFile, false))
                        {
                            writer.WriteLine(obj.ToString());
                        }

                        Logger.Instance.Info("A player has just been saved!");
                    }
                    else
                    {
                        if (File.Exists(playerFile))
                        { 
                            File.Delete(playerFile);
                            Logger.Instance.Info("A player has just been removed!");
                        }
                    }
                    break;
                case DataType.Chat:
                    if (chat == null) { return; }

                    string chatFile = $"{baseFolder}/chats/{chat.Id}.json";
                    if (method == MethodType.POST) {
                        obj["id"] = chat.Id;
                        obj["type"] = JsonConvert.SerializeObject(chat.Type, Formatting.Indented);
                        obj["user"] = JsonConvert.SerializeObject(chat.User, Formatting.Indented);
                        obj["last_commands"] = JsonConvert.SerializeObject(chat.GetLastCommands(), Formatting.Indented);

                        using (StreamWriter writer = new StreamWriter(chatFile, false))
                        {
                            writer.WriteLine(obj.ToString());
                        }

                        Logger.Instance.Info("A chat has just been saved!");
                    }
                    else
                    {
                        if (File.Exists(chatFile))
                        { 
                            File.Delete(chatFile);
                            Logger.Instance.Info("A chat has just been removed!");
                        }
                    }
                    break;
            }
        }
    }
}