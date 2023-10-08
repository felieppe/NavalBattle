using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class UserManager
    {
        public List<Player> Players = new List<Player>();

        public UserManager() {}

        public void AddUser(Player player) {
            this.Players.Add(player);
        }
        public void RemoveUser(Player player) {
            this.Players.Remove(player);
        }
    }
}