//---------------------------------------------------------------------------------
// <copyright file="GameLogicTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System;
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
        private char[][] board1;
        /*private Board board;
        private char[][] board1;
        private GameLogic gameLogic1;
        private BoardSize boardSize;
        private int rows = 4;
        private int columns = 4;*/

        /// <summary>
        /// El tablero para probar.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            /*this.boardSize = new BoardSize(rows, columns);
            this.board = new Board(this.board1, this.boardSize);
            this.gameLogic1 = new GameLogic(this.board1, this.boardSize, 3);
        */}

        /// <summary>
        /// Prueba del método VerifyAttack.
        /// </summary>
        [Test]
        public void VerifyAttackWithShipReturnsTrue()
        {   
            // boardtest.cs
            int rows = 3;
            int columns = 4;

            BoardSize boardSize = new BoardSize(rows, columns);
            Board board = new Board(boardSize);

            char[][] actualBoard = board.GetBoard();

            GameLogic gameLogic = new GameLogic(actualBoard, boardSize, 3);
            gameLogic.PlaceShip(1, 2);
            gameLogic.Attack(1, 2);

            bool result = gameLogic.VerifyAttack(1, 2);
            
            Assert.IsTrue(result);
        }
    }
}
