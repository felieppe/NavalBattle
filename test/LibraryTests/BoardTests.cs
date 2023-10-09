using System;
using BattleShip;
using Library;
using System.Collections.Generic;
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
        /// Board para probar.
        /// </summary>
        private Board board;
        private char[][] board1;
        private BoardSize bs;

        /// <summary>
        /// Crea un tablero para probar.
        /// </summary> <summary>
        [SetUp]
        public void SetUp()
        {
            this.board = new Board(this.board1, this.bs);
        }

        /// <summary>
        /// Prueba que el tablero creado sea igual al que se espera.
        /// </summary> <summary>
        [Test]
        public void InitializeBoardsTest()
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

            BoardSize boardSize = new BoardSize(rows, columns);
            Board board = new Board(this.board1, boardSize);

            board.InitializeBoards();
            char[][] actualBoard = board.GetBoard();

            Assert.AreEqual(expectedBoard, actualBoard);
        }
    }
}