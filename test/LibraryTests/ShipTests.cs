//---------------------------------------------------------------------------------
// <copyright file="ShipTests.cs" company="Universidad Católica del Uruguay">
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
        public void Setup()
        {
            sub = new Submarine();
        }

        /// <summary>
        /// Prueba la funcionalidad del casteo entre clases gracias a la implementación de interfaces.
        /// </summary>
        [Test]
        public void InterfaceCastTest()
        {
            Assert.NotNull(sub);

            Ship ship;
            ship = (Ship)sub;

            Assert.True(ship.GetType().ToString() == "Library.Submarine");
        }

        /// <summary>
        /// Prueba la funcionalidad de SetSunken() y comprueba que establezca bien los valores.
        /// </summary>
        [Test]
        public void SetSunkenTest()
        {
            Assert.NotNull(sub);

            sub.Sink();

            Assert.True(sub.GetSunken());
        }
    }
}