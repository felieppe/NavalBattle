using System;
using Library;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="Player"/>.
    /// </summary>
    [TestFixture]
    public class ShipTests
    {
        /// <summary>
        /// Un tipo de nave para probar.
        /// </summary>
        private Submarine sub;

        /// <summary>
        /// Crea un jugador para probar.
        /// </summary>
        [SetUp]
        public void Setup() {
            this.sub = new Submarine();
        }

        /// <summary>
        /// Prueba la funcionalidad del casteo entre clases gracias a la implementación de interfaces.
        /// </summary>
        [Test]
        public void InterfaceCastTest()
        {
            Assert.NotNull(this.sub);

            Ship ship;
            ship = (Ship) sub;
            
            Assert.True(ship.GetType().ToString() == "Library.Submarine");
        }
    }
}