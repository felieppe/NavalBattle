using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class UserManager
    {
        private List<Player> Players = new List<Player>();
        private List<Player> InGamePlayers = new List<Player>();

        public UserManager() {}

        public void AddUser(Player player) {
            this.Players.Add(player);
        }
        public void RemoveUser(Player player) {
            this.Players.Remove(player);
        }

        public List<Player> GetPlayers() {
            return this.Players;
        }
        public List<Player> GetInGamePlayers() {
            return this.InGamePlayers;
        }
    }
}