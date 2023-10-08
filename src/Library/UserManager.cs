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

        public void AddPlayer(Player player) {
            this.Players.Add(player);
        }

        public void RemovePlayer(Player player) {
            this.Players.Remove(player);
        }

        private void AddInGamePlayers(Game game) {
            foreach (Player p in game.GetPlayers()) {
                InGamePlayers.Add(p);
            }
        }

        public Game NewGame() {
            if (!(this.Players.Count > 1)) { return null; }

            List<Player> availablePlayers = this.Players.Except(this.InGamePlayers).ToList();
            if (!(availablePlayers.Count > 1)) { return null; }

            Random rnd = new Random();
            int pIndex = 0, pIndex2 = 0;
            bool ready = false;
            while (!ready) {
                pIndex = rnd.Next(availablePlayers.Count);
                pIndex2 = rnd.Next(availablePlayers.Count);

                if (pIndex != pIndex2) { ready = true; }
            }

            Player player1 = availablePlayers[pIndex];
            Player player2 = availablePlayers[pIndex2];
            Game game = new Game(player1, player2);

            this.AddInGamePlayers(game);

            return game;
        }

        public List<Player> GetPlayers() {
            return this.Players;
        }

        public List<Player> GetInGamePlayers() {
            return this.InGamePlayers;
        }
    }
}