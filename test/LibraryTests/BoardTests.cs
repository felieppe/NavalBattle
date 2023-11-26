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
        private int rows;
        private int columns;

        /// <summary>
        /// Crea un tablero para probar.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.rows = 10;
            this.columns = 10;
            this.board = new Board(rows, columns);
        }

        /// <summary>
        /// Prueba que el tablero creado sea igual al que se espera.
        /// </summary>
        [Test]
        public void InitializeBoardTest()
        {
            char[][] expectedBoard = new char[12][]
            {
                new char[] {' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K'},
                new char[] {'1', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                new char[] {'2', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                new char[] {'3', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                new char[] {'4', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                new char[] {'5', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                new char[] {'6', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                new char[] {'7', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                new char[] {'8', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                new char[] {'9', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                new char[] {':', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                new char[] {';', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            };

            Assert.AreEqual(expectedBoard, this.board.GetBoard());
        }

        /// <summary>
        /// Prueba que el tamaño del tablero creado sea válido.
        /// </summary>
        [Test]
        public void ValidBoardSizeTest()
        {
            bool validRows = board.SetRows(16);
            bool validColumns = board.SetColumns(7);

            Assert.IsTrue(validRows);
            Assert.IsTrue(validColumns);
        }

        /// <summary>
        /// Prueba que el tamaño del tablero creado no sea válido.
        /// </summary>
        [Test]
        public void InvalidBoardSizeTest()
        {
            bool invalidRows = board.SetRows(4);
            bool invalidColumns = board.SetColumns(15);

            Assert.IsFalse(invalidRows);
            Assert.IsFalse(invalidColumns);
        }
    }
}
