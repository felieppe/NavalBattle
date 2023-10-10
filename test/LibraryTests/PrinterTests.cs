//---------------------------------------------------------------------------------
// <copyright file="PrinterTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using Library;
using NUnit.Framework;
/*
namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="Printer"/>.
    /// </summary>
    [TestFixture]
    public class PrinterTests
    {
        private Board board;
        private char[][] board1;
        private BoardSize bs;

        [SetUp]
        public void SetUp()
        {
            this.board = new Board(this.board1, this.bs);
        }

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
            BoardSize boardSize = new BoardSize(rows, columns);
            Board board = new Board(this.board1, boardSize);

            board.InitializeBoard();
            char[][] actualBoard = board.GetBoard();
            string actual = actualBoard.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}*/