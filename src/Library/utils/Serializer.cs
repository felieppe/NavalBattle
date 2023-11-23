using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Library.utils.core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Library.utils
{
    public class Serializer
    {
        private static Serializer instance;

        public static Serializer Instance {
            get {
                if (instance == null) { instance = new Serializer(); }
                return instance;
            }
        }

        public Serializer() {}

        #nullable enable
        public void Serialize(DataType opt, Game? game = null, Player? player = null) {
            string baseFolder = $"../../save/{Configuration.Instance.GetUsername()}";

            JObject obj = new JObject();
            switch (opt) {
                case DataType.Game:
                    if (game == null) { return; }

                    obj["id"] = "" + game.GetGameId();
                    obj["ships_coords"] = JsonConvert.SerializeObject(game.GetShipsCoords(), Formatting.Indented);
                    obj["ships"] = JsonConvert.SerializeObject(game.GetShips(), Formatting.Indented);
                    obj["total_ships"] = game.GetTotalShips();
                    obj["players"] = JsonConvert.SerializeObject(game.GetPlayers(), Formatting.Indented);
                    obj["admin"] = JsonConvert.SerializeObject(game.GetAdmin(), Formatting.Indented);
                    obj["board_size"] = ""; //JsonConvert.SerializeObject(game.GetBoardSize(), Formatting.Indented);
                    obj["board_1"] = JsonConvert.SerializeObject(game.GetBoard1(), Formatting.Indented);
                    obj["board_2"] = JsonConvert.SerializeObject(game.GetBoard2(), Formatting.Indented);

                    string file = $"{baseFolder}/servers/{game.GetGameId()}.json";
                    using (StreamWriter writer = new StreamWriter(file, true)) {
                        writer.WriteLine(obj.ToString());
                    }

                    Logger.Instance.Info("A game has just been saved!");
                    break;
                case DataType.Player:
                    if (player == null) { return; }

                    obj["id"] = player.GetId();
                    obj["username"] = player.GetUsername();

                    string playerFile = $"{baseFolder}/players/{player.GetId()}.json";
                    using (StreamWriter writer = new StreamWriter(playerFile, true)) {
                        writer.WriteLine(obj.ToString());
                    }

                    Logger.Instance.Info("A player has just been saved!");
                    break;
                }
        }
    }
}