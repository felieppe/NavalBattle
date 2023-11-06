//---------------------------------------------------------------------------------
// <copyright file="BoardSizeTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using Library;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="Board"/>.
    /// </summary>
    [TestFixture]
    public class BoardSizeTests
    {
        /// <summary>
        /// Tablero para probar.
        /// </summary>
        private BoardSize boardSize;
        private int rows;
        private int columns;

        /// <summary>
        /// Crea un tamaño de tablero para probar.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.rows = 0; 
            this.columns = 0;
            this.boardSize = new BoardSize(this.rows, this.columns);
        }

        /// <summary>
        /// Prueba que el tamaño del tablero creado sea válido.
        /// </summary>
        [Test]
        public void ValidBoardSizeTest()
        {
            bool validRows = boardSize.SetRows(16);
            bool validColumns = boardSize.SetColumns(18);

            Assert.IsTrue(validRows);
            Assert.IsTrue(validColumns);
        }

        /// <summary>
        /// Prueba que el tamaño del tablero creado no sea válido.
        /// </summary>
        [Test]
        public void InvalidBoardSizeTest()
        {
            bool invalidRows = boardSize.SetRows(4);
            bool invalidColumns = boardSize.SetColumns(15);

            Assert.IsFalse(invalidRows);
            Assert.IsFalse(invalidColumns);
        }
    }
}