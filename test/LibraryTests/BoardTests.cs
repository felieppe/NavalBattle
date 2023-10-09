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
        /// Board para probar.
        /// </summary>
        private Board board;
        private char[][] board1;
        private BoardSize bs;

        /// <summary>
        /// Crea un tablero para probar.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.board = new Board(this.board1, this.bs);
        }

        /// <summary>
        /// Prueba que el tablero creado sea igual al que se espera.
        /// </summary>
/*
        [Test]
        public void InitializeBoardTest()
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

            board.InitializeBoard();
            char[][] actualBoard = board.GetBoard();

            Assert.AreEqual(expectedBoard, actualBoard);
        }*/
    }
}