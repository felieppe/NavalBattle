//---------------------------------------------------------------------------------
// <copyright file="PrinterTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using Library;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="Printer"/>.
    /// </summary>
[TestFixture]
    public class PrinterTests
    {
        private Board board;
        private int rows;
        private int columns;

        /// <summary>
        /// Crea un nuevo tablero para probar.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.rows = 10;
            this.columns = 10;
            board = new Board(rows, columns);
        }

        /// <summary>
        /// Test que prueba imprimir un tablero.
        /// </summary>
        [Test]
        public void TestPrint()
        {
            int rows = 3;
            int columns = 4;
            char[][] expectedBoard = new char[4][]
            {
                new char[] { ' ', 'A', 'B', 'C', 'D' },
                new char[] { '1', ' ', ' ', ' ', ' ' },
                new char[] { '2', ' ', ' ', ' ', ' ' },
                new char[] { '3', ' ', ' ', ' ', ' ' },
            };
            string expected = expectedBoard.ToString();
            Board board = new Board(rows, columns);

            board.InitializeBoard();
            char[][] actualBoard = board.GetBoard();
            string actual = actualBoard.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}