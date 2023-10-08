using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class Game
    {
        private Player Player1 {get; set;}
        private Player Player2 {get; set;}

        public Game(Player p1, Player p2) {
            this.Player1 = p1;
            this.Player2 = p2;
        }
    }
}