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

        private void AddInGamePlayers(Game game) {
            foreach (Player p in game.GetPlayers()) {
                InGamePlayers.Add(p);
            }
        }

        public Game NewGame() {
            if (!(this.Players.Count > 1)) { return null; }

            List<Player> AvailablePlayers = Players.Except(InGamePlayers).ToList();
            if (!(AvailablePlayers.Count > 1)) { return null; }

            Random rnd = new Random();
            int pIndex = 0, pIndex2 = 0;
            bool ready = false;
            while (!ready) {
                pIndex = rnd.Next(AvailablePlayers.Count);
                pIndex2 = rnd.Next(AvailablePlayers.Count);

                if (pIndex != pIndex2) { ready = true; }
            }

            Player player1 = AvailablePlayers[pIndex];
            Player player2 = AvailablePlayers[pIndex2];
            Game game = new Game(player1, player2);

            AddInGamePlayers(game);

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