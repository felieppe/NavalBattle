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
    public class CoordsTests
    {
        /// <summary>
        /// La clase Coords para probar.
        /// </summary>
        private Coords coordinates;

        /// <summary>
        /// Prueba que se establezca correctamente el ShipId en Coords.
        /// </summary>
        [Test]
        public void ShipIdTest() {
            this.coordinates = new Coords("123", 2, 2);
            Assert.AreEqual("123", this.coordinates.GetShipId());
        }

        /// <summary>
        /// Prueba que se establezca correctamente la coordenada X en Coords.
        /// </summary>
        [Test]
        public void XTest() {
            this.coordinates = new Coords("456", 5, 10);
            Assert.AreEqual(5, this.coordinates.GetX());
        }

        /// <summary>
        /// Prueba que se establezca correctamente la coordenada Y en Coords.
        /// </summary>
        [Test]
        public void YTest() {
            this.coordinates = new Coords("789", 50, 15);
            Assert.AreEqual(15, this.coordinates.GetY());
        }
    }
}