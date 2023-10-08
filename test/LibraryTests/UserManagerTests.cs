using Library;
using NUnit.Framework;
using System.Collections.Generic;

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
        public void Setup() {
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
            foreach (Player p in umPlayers) {
                Assert.True(expectedPlayers.Contains(p));
            }
        }
    }
}