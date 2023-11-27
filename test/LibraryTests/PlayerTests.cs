//---------------------------------------------------------------------------------
// <copyright file="PlayerTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using Library;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="Player"/>.
    /// </summary>
    [TestFixture]
    public class PlayerTests
    {
        /// <summary>
        /// El jugador para probar.
        /// </summary>
        private Player player;

        /// <summary>
        /// Crea un jugador con Id vacío para probar.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            player = new Player();
        }

        /// <summary>
        /// Prueba que SetId() establezca de forma correcta el Id al Player.
        /// </summary>
        [Test]
        public void SetIdTest()
        {
            Assert.NotNull(this.player);

            string newId = "5e5eb7ee-6600-11ee-8c99-0242ac120002";
            player.SetId(newId);

            Assert.AreEqual(newId, player.GetId());
        }

        /// <summary>
        /// Prueba que SetUsername() establezca de forma correcta el Username al Player.
        /// </summary>
        [Test]
        public void SetUsernameTest()
        {
            Assert.NotNull(player);

            string newUsername = "Alfred000";
            player.SetUsername(newUsername);

            Assert.AreEqual(newUsername, player.GetUsername());
        }
    }
}