//---------------------------------------------------------------------------------
// <copyright file="BoardTests.cs" company="Universidad Católica del Uruguay">
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
    public class BoardTests
    {
        /// <summary>
        /// Tablero para probar.
        /// </summary>
        private Board board;
        private BoardSize boardSize;
        private int rows;
        private int columns;

        /// <summary>
        /// Crea un tablero para probar.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.rows = 3;
            this.columns = 4;

            this.boardSize = new BoardSize(this.rows, this.columns);
            this.board = new Board(this.boardSize);
        }

        /// <summary>
        /// Prueba que el tablero creado sea igual al que se espera.
        /// </summary>
        [Test]
        public void InitializeBoardTest()
        {
            char[][] expectedBoard = new char[4][]
            {
                new char[] { ' ', 'A', 'B', 'C', 'D' },
                new char[] { '1', ' ', ' ', ' ', ' ' },
                new char[] { '2', ' ', ' ', ' ', ' ' },
                new char[] { '3', ' ', ' ', ' ', ' ' },
            };

            Assert.AreEqual(expectedBoard, this.board.GetBoard());
        }
    }
}