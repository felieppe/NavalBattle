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
        public BoardSize BoardSize;
        public Board Board;
        private int Rows;
        private int Columns;

        /// <summary>
        /// El tablero para probar.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.Rows = 3;
            this.Columns = 4;

            this.BoardSize = new BoardSize(this.Rows, this.Columns);
            this.Board = new Board(this.BoardSize);
        }

        /// <summary>
        /// Prueba del método VerifyAttack.
        /// </summary>
        [Test]
        public void VerifyAttackWithShipReturnsTrue()
        {
            int ships = 3;

            GameLogic gameLogic = new GameLogic(this.Board, this.BoardSize, ships);
            gameLogic.PlaceShip(1, 2);
            gameLogic.Attack(1, 2);

            bool result = gameLogic.VerifyAttack(1, 2);
            Assert.IsTrue(result);
        }
    }
}
