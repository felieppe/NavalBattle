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
        private Game game;

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

            this.game = new Game(rows, columns, 8);
        }

        /// <summary>
        /// Prueba los métodos PlaceShip(), Attack() y VerifyAttack() de la clase <see cref="GameLogic"/>.
        /// </summary>
        [Test]
        public void AttackTest()
        {
            int ships = 3;
            Submarine sub = new Submarine();

            GameLogic gameLogic = new GameLogic(this.game, this.board, null);
            gameLogic.PlaceShip(sub, 'B', 2, "right");

            // Realiza el ataque
            gameLogic.Attack('B', 2);

            // Verifica si el barco se ha hundido
            //bool hasHit = gameLogic.GetShips()[0].GetSunken();
            bool hasHit = gameLogic.GetGame().GetShips()[0].GetSunken();

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
            int ships = 2;
            GameLogic gameLogic = new GameLogic(this.game, this.board, null);
            
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
            GameLogic gameLogic = new GameLogic(this.game, this.board, null);

            BoardSize boardSize = new BoardSize(10,10);
            Board board = new Board(boardSize);

            UserManager userManager = new UserManager();
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            userManager.AddPlayer(player1);
            userManager.AddPlayer(player2);

        
            Assert.AreEqual(1, gameLogic.GetNumberAttack());

            gameLogic.Attack('A', 1);
            Assert.AreEqual(2, gameLogic.GetNumberAttack());
        }
        [Test]
        public void AccessTwoBoardsTest()
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            
            Game game1 = new Game (12, 12, 9); 
            
            game1.AddPlayer(player1);
            game1.AddPlayer(player2);

            Assert.IsNotNull(game1.board1);
            Assert.IsNotNull(game1.board2);

        }

    }
        
}

