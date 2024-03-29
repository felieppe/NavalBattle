//---------------------------------------------------------------------------------
// <copyright file="ServerManagerTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System.Collections.Generic;
using Library;
using Library.utils;
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
            Deserializer.Instance.Debug = true;
            Serializer.Instance.Debug = true;
            
            sm = new ServerManager();
        }

        /// <summary>
        /// Prueba la funcionalidad de AddGame() en ServerManager.
        /// </summary>
        [Test]
        public void AddGameTest() {
            Game game = new Game(10, 10, 5);
            sm.AddGame(game);

            string expectedGameId = game.GetGameId();
            Assert.IsNotNull(sm.GetGame(expectedGameId));
        }

        /// <summary>
        /// Prueba la funcionalidad de RemoveGame() en ServerManager.
        /// </summary>
        [Test]
        public void RemoveGameTest() {
            Game game = new Game(10, 10, 5);
            string gameId = game.GetGameId();
            sm.AddGame(game);

            int len = sm.GetListing().Count;
            Assert.AreEqual(1, len);

            sm.RemoveGame(gameId);
            len = sm.GetListing().Count;
            Assert.AreEqual(0, len);
        }

        /// <summary>
        /// Prueba la funcionalidad de GetListing() en ServerManager.
        /// </summary>
        [Test]
        public void GetListingTest() {
            Game game = new Game(10, 10, 5);
            sm.AddGame(game);

            List<Game> expectedGames = new List<Game>();
            expectedGames.Add(game);

            List<Game> games = sm.GetListing();
            Assert.AreEqual(games, expectedGames);
        }

        /// <summary>
        /// Prueba la funcionalidad de GetGame() en ServerManager.
        /// </summary>
        [Test]
        public void GetGameByIdTest() {
            Game game = new Game(10, 10, 5);
            sm.AddGame(game);

            Game game2 = new Game(15, 15, 10);
            sm.AddGame(game2);

            Assert.AreEqual(game2, sm.GetGame(game2.GetGameId()));
        }
    }
}