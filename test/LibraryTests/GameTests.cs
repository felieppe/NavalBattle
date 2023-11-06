//---------------------------------------------------------------------------------
// <copyright file="GameTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System.Collections.Generic;
using Library;
using NUnit.Framework;

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
        private Player player;
        private Player player2;

        /// <summary>
        /// Crea un Game y dos players para probar.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.player = new Player("ce622ce8-6609-11ee-8c99-0242ac120002");
            this.player2 = new Player("d06ce532-6609-11ee-8c99-0242ac120002");
            this.game = new Game(10, 10, 6, this.player);
            this.game.AddPlayer(player2);
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
            foreach (Player p in gamePlayers)
            {
                Assert.True(expectedPlayers.Contains(p));
            }
        }

        /// <summary>
        /// Crear una nueva partida con valores predefinidos.
        /// </summary>
        [Test]
        public void NewPresetGame()
        {
            Game game1 = new Game(0, 0, 6, this.player);
            Assert.AreEqual(9, game1.GetRows);
            Assert.AreEqual(9, game1.GetColumns);
        }

        /// <summary>
        /// Crear una nueva partida con valores personalizados.
        /// </summary>
        [Test]
        public void NewCustomGame()
        {
            Game game1 = new Game(11, 11, 9, this.player);
            Assert.AreEqual(13, game1.GetRows);
            Assert.AreEqual(13, game1.GetColumns);
        }
    }
}