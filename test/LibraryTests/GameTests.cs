using Library;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="Game"/>.
    /// </summary>
    [TestFixture]
    public class GameTests
    {
        /// <summary>
        /// El Game y los Players para probar.
        /// </summary>
        private Game game;
        private Player player, player2;

        /// <summary>
        /// Crea un Game y dos players para probar.
        /// </summary>
        [SetUp]
        public void Setup() {
            this.player = new Player("ce622ce8-6609-11ee-8c99-0242ac120002");
            this.player2 = new Player("d06ce532-6609-11ee-8c99-0242ac120002");
            this.game = new Game(player, player2);
        }

        /// <summary>
        /// Prueba la clase Game y sí añade de forma correcta a los jugadores.
        /// </summary>
        [Test]
        public void InitGameTest()
        {
            Assert.NotNull(this.game);
            Assert.NotNull(this.player);
            Assert.NotNull(this.player2);

            List<Player> expectedPlayers = new List<Player>();
            expectedPlayers.Add(this.player);
            expectedPlayers.Add(this.player2);

            List<Player> gamePlayers = this.game.GetPlayers();
            foreach (Player p in gamePlayers) {
                Assert.True(expectedPlayers.Contains(p));
            }
        }
    }
}