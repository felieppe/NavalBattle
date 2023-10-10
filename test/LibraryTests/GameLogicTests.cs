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
        /// <summary>
        /// El tablero, con sus elementos respectivos (boardSize, rows y columns), para probar.
        /// </summary>
        private BoardSize boardSize;
        private Board board;
        private int rows;
        private int columns;

        /// <summary>
        /// Creamos los elementos necesarios para la prueba.
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
        /// Prueba los métodos PlaceShip(), Attack() y VerifyAttack() de la clase <see cref="GameLogic"/>.
        /// </summary>
        [Test]
        public void VerifyAttackWithShipReturnsTrue()
        {
            int ships = 3;
            Ship ship1 = new Ship("Submarine",1);

            GameLogic gameLogic = new GameLogic(this.board, this.boardSize, ships);
            gameLogic.PlaceShip(ship1,1, 2);
            gameLogic.Attack(1, 2);

            bool result = gameLogic.VerifyAttack(1, 2);
            Assert.IsTrue(result);
        }
        [Test]

        public void ValidPlaceShip()
        {
        
        int ships =2;
        GameLogic gameLogic = new GameLogic(this.board, this.boardSize, ships);
        Ship ship1 = new Ship("Submarine",1);
        Ship ship2 = new Ship("Submarine",1);

        gameLogic.PlaceShip(ship1, 5, 5); 
        bool result = gameLogic.PlaceShip(ship2, 5, 5);

       
        Assert.IsFalse(result);
        }
    }
}
