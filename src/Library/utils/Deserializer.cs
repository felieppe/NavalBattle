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
    public class Deserializer
    {
        private static Deserializer instance;

        public bool Debug;

        public static Deserializer Instance {
            get {
                if (instance == null) { instance = new Deserializer(); }
                return instance;
            }
        }

        public Deserializer(bool? debug = false) {
            this.Debug = (bool) debug;
        }

        public dynamic Deserialize(DataType opt) {
            if (this.Debug) { return null; }
            string baseFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\")) + $"/save/{Configuration.Instance.GetUsername()}";

            switch (opt) {
                case DataType.Game:
                    string serversFolder = $"{baseFolder}/servers/";
                    string[] files = Directory.GetFiles(serversFolder, "*.json");

                    List<Game> games = new List<Game>();

                    foreach (var file in files) {
                        string json = File.ReadAllText(file);
                        JObject obj = JObject.Parse(json);

                        // Retriving game data from JSON object
                        string id = obj["id"].ToString();
                        List<Coords> shipsCoords = JsonConvert.DeserializeObject<List<Coords>>(obj["ships_coords"].ToString());
                        List<Ship> ships = JsonConvert.DeserializeObject<List<Ship>>(obj["ships"].ToString());
                        int totalShips = obj["total_ships"].Value<int>();
                        List<Player> players = JsonConvert.DeserializeObject<List<Player>>(obj["players"].ToString());
                        Player admin = JsonConvert.DeserializeObject<Player>(obj["admin"].ToString());
                        int rows = obj["rows"].Value<int>();
                        int columns = obj["columns"].Value<int>();
                        Board board1 = JsonConvert.DeserializeObject<Board>(obj["board_1"].ToString());
                        Board board2 = JsonConvert.DeserializeObject<Board>(obj["board_2"].ToString());

                        // Cloning the game data to a new instance
                        Game game = new Game(rows, columns, totalShips);
                        
                        game.SetGameId(id);
                        game.SetAdmin(admin);
                        game.SetBoard1(board1);
                        game.SetBoard2(board2);

                        foreach (Coords coord in shipsCoords) {
                            game.AddShipCoords(coord.GetShipId(), coord.GetX(), coord.GetY());
                        }
                        foreach (Ship ship in ships) {
                            game.AddShip(ship);
                        }
                        foreach (Player player in players) {
                            game.AddPlayer(player);
                        }

                        // Adding game to the returnable games list
                        games.Add(game);
                    }

                    Logger.Instance.Info($"Has been retrieved {games.Count} games!");
                    return games;
                case DataType.Player:
                    string playersFolder = $"{baseFolder}/players/";
                    files = Directory.GetFiles(playersFolder, "*.json");

                    List<Player> playersList = new List<Player>();
                    
                    foreach (var file in files) {
                        string json = File.ReadAllText(file);
                        JObject obj = JObject.Parse(json);

                        // Retriving player data from JSON object
                        string id = obj["id"].ToString();
                        string tid = obj["tid"].ToString();
                        string username = obj["username"].ToString();

                        // Cloning the player data to a new instance
                        Player player = new Player();
                        
                        player.SetId(id);
                        player.SetTelegramId(tid);
                        player.SetUsername(username);

                        // Adding player to the returnable player list
                        playersList.Add(player);
                    }

                    Logger.Instance.Info($"Has been retrieved {playersList.Count} players!");
                    return playersList;
            }

            return null;
        } 
    }
}