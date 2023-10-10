//---------------------------------------------------------------------------------
// <copyright file="GameLogicTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using Library;
using NUnit.Framework;

namespace BattleShip.Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="GameLogic"/>.
    /// </summary>
    [TestFixture]
    public class GameLogicTests
    {
        private Board board;
        private char[][] board1;
        private GameLogic gameLogic1;
        private BoardSize bs;

        /// <summary>
        /// El tablero para probar.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.board = new Board(this.board1, this.bs);
            this.gameLogic1 = new GameLogic(this.bs, 3);
        }

        /// <summary>
        /// Prueba del método VerifyAttack.
        /// </summary>
        [Test]
        public void VerifyAttackWithShipReturnsTrue()
        {
            var boardSize = new BoardSize(5, 5);
            var gameLogic = new GameLogic(boardSize, 3);
            var row = 1;
            var column = 2;
            this.gameLogic1.PlaceShip(row, column);

            var result = gameLogic.VerifyAttack(row, column);

            Assert.IsTrue(result);
        }
    }
}
