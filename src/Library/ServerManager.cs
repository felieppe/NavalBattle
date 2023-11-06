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
            if (game != null) {this.Servers.Add(game);}
        }
        public void RemoveGame(string id) {
            
        }

        public List<Game> GetListing() {

        }
        
        public Game GetGame(string id) {

        }
    }
}