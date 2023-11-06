using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="Player"/>.
    /// </summary>
    [TestFixture]
    public class ServerManagerTests
    {
        /// <summary>
        /// El ServerManager para probar.
        /// </summary>
        private ServerManager sm;

        /// <summary>
        /// Crea una instancia de la clase ServerManager.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.sm = new ServerManager();
        }

        /// <summary>
        /// Prueba la funcionalidad de AddGame() en ServerManager.
        /// </summary>
        [Test]
        public void AddGameTest() {
            Game game = new Game(10, 10, 5);
            this.sm.AddGame(game);

            string expectedGameId = game.GetGameId();
            Assert.IsNotNull(this.sm.GetGame(expectedGameId));
        }

        /// <summary>
        /// Prueba la funcionalidad de RemoveGame() en ServerManager.
        /// </summary>
        [Test]
        public void RemoveGameTest() {
            Game game = new Game(10, 10, 5);
            string gameId = game.GetGameId();
            this.sm.AddGame(game);

            int len = this.sm.GetListing().Count;
            Assert.AreEqual(1, len);

            this.sm.RemoveGame(gameId);
            len = this.sm.GetListing().Count;
            Assert.AreEqual(0, len);
        }

        /// <summary>
        /// Prueba la funcionalidad de GetListing() en ServerManager.
        /// </summary>
        [Test]
        public void GetListingTest() {
            Game game = new Game(10, 10, 5);
            this.sm.AddGame(game);

            List<Game> expectedGames = new List<Game>();
            expectedGames.Add(game);

            List<Game> games = this.sm.GetListing();
            Assert.AreEqual(games, expectedGames);
        }

        /// <summary>
        /// Prueba la funcionalidad de GetGame() en ServerManager.
        /// </summary>
        [Test]
        public void GetGameByIdTest() {
            Game game = new Game(10, 10, 5);
            this.sm.AddGame(game);

            Game game2 = new Game(15, 15, 10);
            this.sm.AddGame(game2);

            Assert.AreEqual(game2, this.sm.GetGame(game2.GetGameId()));
        }
    }
}