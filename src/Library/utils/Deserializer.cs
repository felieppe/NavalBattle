//---------------------------------------------------------------------------------
// <copyright file="Deserializer.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using Library.bot;
using Library.utils.core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bot.Types.Enums;

namespace Library.utils
{
     /// <summary>
    /// Clase que carga información.
    /// </summary>
    public class Deserializer
    {
        /// <summary>
        /// Instancia de Singleton.
        /// </summary>
        /// <value> Instancia de Deserializer. </value>
        private static Deserializer instance;

        /// <summary>
        /// Booleano de Debug.
        /// </summary>
        public bool Debug;


        public static Deserializer Instance
        {
            get
            {
                if (instance == null) { instance = new Deserializer(); }
                return instance;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="debug"> Booleano de debug. </param>
        public Deserializer(bool? debug = false)
        {
            Debug = (bool) debug;
        }

        /// <summary>
        /// Función que deserializa un archivo .json de una partida.
        /// </summary>
        /// <param name="opt"></param>
        /// <returns></returns>
        public dynamic Deserialize(DataType opt)
        {
            if (Debug) { return null; }
            string baseFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\")) + $"/save/{Configuration.Instance.GetUsername()}";

            switch (opt)
            {
                case DataType.Game:
                    string serversFolder = $"{baseFolder}/servers/";
                    string[] files = Directory.GetFiles(serversFolder, "*.json");

                    List<Game> games = new List<Game>();

                    foreach (var file in files)
                    {
                        string json = File.ReadAllText(file);
                        JObject obj = JObject.Parse(json);

                        // Retriving game data from JSON object
                        string id = obj["id"].ToString();
                        string name = obj["name"].ToString();
                        GameStatusType status = JsonConvert.DeserializeObject<GameStatusType>(obj["status"].ToString());
                        List<Coords> shipsCoords = JsonConvert.DeserializeObject<List<Coords>>(obj["ships_coords"].ToString());
                        List<Ship> ships = JsonConvert.DeserializeObject<List<Ship>>(obj["ships"].ToString());
                        Dictionary<string, Player> ownership = JsonConvert.DeserializeObject<Dictionary<string, Player>>(obj["ownership"].ToString());
                        int totalShips = obj["total_ships"].Value<int>();
                        List<Player> players = JsonConvert.DeserializeObject<List<Player>>(obj["players"].ToString());
                        Player admin = JsonConvert.DeserializeObject<Player>(obj["admin"].ToString());
                        Player winner = JsonConvert.DeserializeObject<Player>(obj["winner"].ToString());
                        int rows = obj["rows"].Value<int>();
                        int columns = obj["columns"].Value<int>();
                        Board board1 = JsonConvert.DeserializeObject<Board>(obj["board_1"].ToString());
                        Board board2 = JsonConvert.DeserializeObject<Board>(obj["board_2"].ToString());

                        // Cloning the game data to a new instance
                        Game game = new Game(rows, columns, totalShips);
                        
                        //Logger.Instance.Debug("ESTO ES EL PLAYER ADMIN: " + obj["admin"].ToString());

                        game.SetGameId(id);
                        game.SetGameSession(name);
                        game.SetStatus(status);
                        game.SetAdmin(admin);
                        game.SetWinner(winner);
                        game.SetBoard1(board1);
                        game.SetBoard2(board2);

                        foreach (Coords coord in shipsCoords)
                        {
                            game.AddShipCoords(coord.GetShipId(), coord.GetX(), coord.GetY());
                        }
                        foreach (Ship ship in ships)
                        {
                            game.AddShip(ship);
                        }
                        foreach (Player player in players)
                        {
                            game.AddPlayer(player);
                        }
                        foreach (var dic in ownership)
                        {
                            game.AddOwnerShip(dic.Key, dic.Value);
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
                    
                    foreach (var file in files)
                    {
                        string json = File.ReadAllText(file);
                        JObject obj = JObject.Parse(json);

                        // Retrieving player data from JSON object
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
                case DataType.Chat:
                    string chatsFolder = $"{baseFolder}/chats/";
                    files = Directory.GetFiles(chatsFolder, "*.json");

                    List<Chat> chats = new List<Chat>();

                    foreach (var file in files) {
                        string json = File.ReadAllText(file);
                        JObject obj = JObject.Parse(json);

                        // Retriving chat data from JSON object
                        long id = obj["id"].Value<long>();
                        ChatType type = JsonConvert.DeserializeObject<ChatType>(obj["type"].ToString());
                        Player user = JsonConvert.DeserializeObject<Player>(obj["user"].ToString());
                        List<string> lastCmds = JsonConvert.DeserializeObject<List<string>>(obj["last_commands"].ToString());

                        // Cloning the chat data to a new instance
                        Chat chat = new Chat(id, type, user);
                        
                        foreach (string cmd in lastCmds)
                        {
                            chat.AddLastCmd(cmd);
                        }

                        // Adding chat to the returnable chat list
                        chats.Add(chat);
                    }
                    Logger.Instance.Info($"Has been retrieved {chats.Count} chats!");
                    return chats;
            }
            return null;
        } 
    }
}