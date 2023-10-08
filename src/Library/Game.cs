using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class Game
    {
        private List<Player> Players = new List<Player>();

        public Game(Player p1, Player p2) {
            Players.Add(p1);
            Players.Add(p2);
        }

        public List<Player> GetPlayers() {
            return this.Players;
        }
    }
}