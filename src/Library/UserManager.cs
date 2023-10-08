using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class UserManager
    {
        public List<string> Players = new List<string>();

        public UserManager() {}

        public void AddUser(Player player) {
            this.Players.Add(player);
        }
    }
}