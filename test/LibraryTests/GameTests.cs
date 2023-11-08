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
        private Player admin;
        private object players;

        /// <summary>
        /// Crea un Game y dos players para probar.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.player = new Player();
            this.player2 = new Player();
            this.game = new Game(10, 10, 6);

            this.game.AddPlayer(player);
            this.game.SetAdmin(player2);
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
        /// Crear una nueva partida con valores ya predefinidos.
        /// </summary>
        [Test]
        public void NewPresetGame()
        {
            // Se busca que sea 10+1 porque el proyecto está pensado para que arranque a contar de uno y no de cero.
            Assert.AreEqual(10+1, this.game.GetBoard1().GetBoardSize().GetRows());
            Assert.AreEqual(10+1, this.game.GetBoard1().GetBoardSize().GetColumns());
        }

        /// <summary>
        /// Crear una nueva partida con valores personalizados.
        /// </summary>
        [Test]
        public void NewCustomGame()
        {
            Game game1 = new Game(20, 20, 9);
            Assert.AreEqual(20+1, game1.GetBoard1().GetBoardSize().GetRows());
            Assert.AreEqual(20+1, game1.GetBoard1().GetBoardSize().GetColumns());
        }

        /// <summary>
        /// Verifica que se establezca bien el Admin.
        /// </summary>
        [Test]
        public void SetAdminTest()
        {
            Player admin = new Player(); // Crea un nuevo jugador para el administrador
            this.game.SetAdmin(admin);

            Assert.AreEqual(admin, this.game.Admin);

            List<Player> gamePlayers = this.game.GetPlayers();
            Assert.Contains(admin, gamePlayers);
        }
    }
}