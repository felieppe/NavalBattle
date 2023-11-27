using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Library.bot;
using Library.utils.core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Library.utils
{
    public class Serializer
    {
        private static Serializer instance;

        public bool Debug;

        public static Serializer Instance {
            get {
                if (instance == null) { instance = new Serializer(); }
                return instance;
            }
        }

        public Serializer(bool? debug = false) {
            this.Debug = (bool) debug;
        }

        #nullable enable
        public void Serialize(DataType opt, MethodType method, Game? game = null, Player? player = null, Chat? chat = null) {
            if (this.Debug) { return; }
            string baseFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\")) + $"/save/{Configuration.Instance.GetUsername()}";

            JObject obj = new JObject();
            switch (opt) {
                case DataType.Game:
                    if (game == null) { return; }

                    string file = $"{baseFolder}/servers/{game.GetGameId()}.json";
                    if (method == MethodType.POST) {
                        obj["id"] = "" + game.GetGameId();
                        obj["ships_coords"] = JsonConvert.SerializeObject(game.GetShipsCoords(), Formatting.Indented);
                        obj["ships"] = JsonConvert.SerializeObject(game.GetShips(), Formatting.Indented);
                        obj["total_ships"] = game.GetTotalShips();
                        obj["players"] = JsonConvert.SerializeObject(game.GetPlayers(), Formatting.Indented);
                        obj["admin"] = JsonConvert.SerializeObject(game.GetAdmin(), Formatting.Indented);
                        obj["rows"] = game.rows;
                        obj["columns"] = game.columns;
                        obj["board_1"] = JsonConvert.SerializeObject(game.GetBoard1(), Formatting.Indented);
                        obj["board_2"] = JsonConvert.SerializeObject(game.GetBoard2(), Formatting.Indented);

                        using (StreamWriter writer = new StreamWriter(file, true)) {
                            writer.WriteLine(obj.ToString());
                        }

                        Logger.Instance.Info("A game has just been saved!");
                    } else {
                        if (File.Exists(file)) { 
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

                        using (StreamWriter writer = new StreamWriter(playerFile, true)) {
                            writer.WriteLine(obj.ToString());
                        }

                        Logger.Instance.Info("A player has just been saved!");
                    } else {
                        if (File.Exists(playerFile)) { 
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
                        obj["last_commands"] = JsonConvert.SerializeObject(chat.GetLastCommands(), Formatting.Indented);

                        using (StreamWriter writer = new StreamWriter(chatFile, true)) {
                            writer.WriteLine(obj.ToString());
                        }

                        Logger.Instance.Info("A chat has just been saved!");
                    } else {
                        if (File.Exists(chatFile)) { 
                            File.Delete(chatFile);
                            Logger.Instance.Info("A chat has just been removed!");
                        }
                    }

                    break;
            }
        }
    }
}