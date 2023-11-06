//---------------------------------------------------------------------------------
// <copyright file="GameLogicTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Library;
using NUnit.Framework;
/*
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
            this.rows = 20;
            this.columns = 20;

            this.boardSize = new BoardSize(this.rows, this.columns);
            this.board = new Board(this.boardSize);
        }

        /// <summary>
        /// Prueba los métodos PlaceShip(), Attack() y VerifyAttack() de la clase <see cref="GameLogic"/>.
        /// </summary>
        [Test]
        public void AttackTest()
        {
            int ships = 3;
            Submarine sub = new Submarine();

            GameLogic gameLogic = new GameLogic(this.board, this.boardSize, ships);
            gameLogic.PlaceShip(sub, 'B', 2, "right");

            // Realiza el ataque
            gameLogic.Attack('B', 2);

            // Verifica si el barco se ha hundido
            bool hasHit = gameLogic.GetShips()[0].GetSunken();

            if (hasHit)
                {
                    Console.WriteLine("¡Has dado en un barco!");
                }
            else
                {
                    Console.WriteLine("No has dado en un barco.");
                }
            Assert.IsTrue(hasHit);
        }

        /// <summary>
        /// Verifica que el barco esté bien posicionado.
        /// </summary>
        [Test]
        public void ValidPlaceShipTest()
        {
            int ships =2;
            GameLogic gameLogic = new GameLogic(this.board, this.boardSize, ships);
            
            Submarine sub = new Submarine();
            gameLogic.PlaceShip(sub, 'A', 2, "down"); 

            bool result = gameLogic.PlaceShip(sub, 'A', 30, "down");
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Prueba que el primer turno sea del jugador 1.
        /// </summary>
        [Test]
        public void FirstMoveTest(){

            int ships = 2;
            GameLogic gameLogic = new GameLogic(this.board, this.boardSize, ships);

            BoardSize boardSize = new BoardSize(10,10);
            Board board = new Board(boardSize);

            UserManager userManager = new UserManager();
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            userManager.AddPlayer(player1);
            userManager.AddPlayer(player2);

        
            Assert.AreEqual(1, gameLogic.GetNumberAttack());

            gameLogic.Attack('A', 1);
            Assert.AreEqual(2, gameLogic.Turn());
        }
        
    }
}
*/

