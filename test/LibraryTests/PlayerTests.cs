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
        /// Crea un jugador para probar.
        /// </summary>
        [SetUp]
        public void Setup() {
            this.player = new Player("");
        }

        /// <summary>
        /// Prueba que SetId() establezca de forma correcta el Id al Player.
        /// </summary>
        [Test]
        public void SetIdTest()
        {
            Assert.NotNull(this.player);

            string newId = "5e5eb7ee-6600-11ee-8c99-0242ac120002";
            this.player.SetId(newId);

            Assert.True(newId.Equals(player.GetId()));
        }
    }
}