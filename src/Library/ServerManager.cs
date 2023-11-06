using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class ServerManager
    {
        private List<Game> Servers = new List<Game>();

        public void AddGame(Game game) {
            if (game != null) {
                bool duplicated = false;
                foreach (Game server in this.Servers) {
                    if (server.GetGameId() == game.GetGameId()) {
                        duplicated = true;
                        break;
                    }
                }

                if (!duplicated) { this.Servers.Add(game); }
            }
        }
        public void RemoveGame(string id) {
            Game g = this.Servers.FirstOrDefault(g => g.GetGameId() == id);
            if (g != null) {
                Servers.Remove(g);
            }           
        }

        public List<Game> GetListing() {
            return this.Servers;
        }
        
        public Game GetGame(string id) {
            return this.Servers.FirstOrDefault(g => g.GetGameId() == id);
        }
    }
}