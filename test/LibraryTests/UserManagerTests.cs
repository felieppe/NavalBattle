//---------------------------------------------------------------------------------
// <copyright file="UserManagerTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Library;
using Library.utils;
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
        /// El ServerManager para probar.
        /// </summary>
        private ServerManager sm;

        /// <summary>
        /// Crea un UserManager para probar.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Deserializer.Instance.Debug = true;
            Serializer.Instance.Debug = true;

            sm = ServerManager.Instance;
            um = UserManager.Instance;
        } 

        /// <summary>
        /// Prueba el sistema de agregar jugadores a UserManager.
        /// </summary>
        [Test]
        public void AddPlayersTest()
        {
            Assert.NotNull(um);

            Player player = new Player();
            Player player2 = new Player();

            List<Player> expectedPlayers = new List<Player>
            {
                player,
                player2
            };

            um.AddPlayer(player);
            um.AddPlayer(player2);

            List<Player> umPlayers = um.GetPlayers();
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
            Assert.NotNull(um);

            Player player = new Player();
            Player player2 = new Player();

            List<Player> expectedPlayers = new List<Player>
            {
                player,
                player2
            };

            UserManager.Instance.AddPlayer(player);
            UserManager.Instance.AddPlayer(player2);

            Console.WriteLine("count: " + UserManager.Instance.GetPlayers().Count);

            Game game = UserManager.Instance.NewGame(true, ServerManager.Instance);
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
            Assert.NotNull(um);

            Player player = new Player();
            Player player2 = new Player();

            List<Player> expectedInGamePlayers = new List<Player>
            {
                player,
                player2
            };

            um.AddPlayer(player);
            um.AddPlayer(player2);
            Game game = um.NewGame(true, sm);

            List<Player> inGamePlayersList = um.GetInGamePlayers();
            foreach (Player p in inGamePlayersList)
            {
                Assert.True(expectedInGamePlayers.Contains(p));
            }
        }

        /// <summary>
        /// Test que agrega un jugador a una partida existente.
        /// </summary>
        [Test]
        public void AddPlayersToExistingGameTest()
        {
            Assert.NotNull(um);

            Player player = new Player();
            Player player2 = new Player();

            // Creamos un juego y añadimos un jugador, lo oficializamos agregandolo al ServerManager
            Game game = UserManager.Instance.NewGame(false, ServerManager.Instance);
            game.AddPlayer(player);
            sm.AddGame(game);

            // Revisamos que los valores esten bien.
            Assert.AreEqual(1, sm.GetGame(game.GetGameId()).GetPlayers().Count);
            Assert.True(sm.GetGame(game.GetGameId()).GetPlayers().Contains(player));

            // Agregamos otro jugador obteniendo el juego desde ServerManager y revisamos que se haya agregado correctamente.
            sm.GetGame(game.GetGameId()).AddPlayer(player2);
            Assert.AreEqual(2, sm.GetGame(game.GetGameId()).GetPlayers().Count);
            Assert.True(sm.GetGame(game.GetGameId()).GetPlayers().Contains(player2));
        }

        /// <summary>
        /// Test que verifica que user manager conecta dos jugadores en un juego de manera satisfactoria.
        /// </summary>
        [Test]
        public void ConnectTwoPlayersTest()
        {
            Assert.NotNull(UserManager.Instance);

            Player player1 = new Player();
            Player player2 = new Player();

            UserManager.Instance.AddPlayer(player1);
            UserManager.Instance.AddPlayer(player2);

            Game game = new Game(10, 10, 10);
            game.AddPlayer(player1);
            game.AddPlayer(player2);

            List<Player> gamePlayers = game.GetPlayers();
            Assert.IsTrue(gamePlayers.Contains(player1));
            Assert.IsTrue(gamePlayers.Contains(player2));
        }     
    }
}