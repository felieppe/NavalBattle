//---------------------------------------------------------------------------------
// <copyright file="UserManagerTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System.Collections.Generic;
using Library;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="UserManager"/>.
    /// </summary>
    [TestFixture]
    public class UserManagerTests
    {
        /// <summary>
        /// El UserManager para probar.
        /// </summary>
        private UserManager um;

        /// <summary>
        /// Crea un UserManager para probar.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.um = new UserManager();
        }

        /// <summary>
        /// Prueba el sistema de agregar jugadores a UserManager.
        /// </summary>
        [Test]
        public void AddPlayersTest()
        {
            Assert.NotNull(this.um);

            Player player = new Player("94b49998-6601-11ee-8c99-0242ac120002");
            Player player2 = new Player("98cdf916-6601-11ee-8c99-0242ac120002");

            List<Player> expectedPlayers = new List<Player>();
            expectedPlayers.Add(player);
            expectedPlayers.Add(player2);

            this.um.AddPlayer(player);
            this.um.AddPlayer(player2);

            List<Player> umPlayers = this.um.GetPlayers();
            foreach (Player p in umPlayers)
            {
                Assert.True(expectedPlayers.Contains(p));
            }
        }

        /// <summary>
        /// Prueba el sistema de crear un nuevo juego.
        /// </summary>
        [Test]
        public void NewGameTest()
        {
            Assert.NotNull(this.um);

            Player player = new Player("af546682-6603-11ee-8c99-0242ac120002");
            Player player2 = new Player("af546984-6603-11ee-8c99-0242ac120002");

            List<Player> expectedPlayers = new List<Player>();
            expectedPlayers.Add(player);
            expectedPlayers.Add(player2);

            this.um.AddPlayer(player);
            this.um.AddPlayer(player2);

            Game game = this.um.NewGame();
            List<Player> gamePlayers = game.GetPlayers();

            foreach (Player p in gamePlayers)
            {
                Assert.True(expectedPlayers.Contains(p));
            }
        }

        /// <summary>
        /// Prueba que se añadan de forma correcta los jugadores que están jugando actualmente.
        /// </summary>
        [Test]
        public void InGamePlayersTest()
        {
            Assert.NotNull(this.um);

            Player player = new Player("86f5a46e-6606-11ee-8c99-0242ac120002");
            Player player2 = new Player("8af786ea-6606-11ee-8c99-0242ac120002");

            List<Player> expectedInGamePlayers = new List<Player>();
            expectedInGamePlayers.Add(player);
            expectedInGamePlayers.Add(player2);

            this.um.AddPlayer(player);
            this.um.AddPlayer(player2);

            Game game = this.um.NewGame();

            List<Player> inGamePlayersList = this.um.GetInGamePlayers();
            foreach (Player p in inGamePlayersList)
            {
                Assert.True(expectedInGamePlayers.Contains(p));
            }
        }
    }
}