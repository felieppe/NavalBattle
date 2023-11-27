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
        /// El tablero, con sus elementos respectivos (rows y columns), para probar.
        /// </summary>
        private Board board;
        private int rows;
        private int columns;
        private Game game;
        private UserManager userManager;

        /// <summary>
        /// Creamos los elementos necesarios para la prueba.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            rows = 20;
            columns = 20;
            board = new Board(rows, columns);
            game = new Game(rows, columns, 3);
        }

        /// <summary>
        /// Prueba los métodos PlaceShip(), Attack() y VerifyAttack() de la clase <see cref="GameLogic"/>.
        /// </summary>
        [Test]
        public void AttackTest()
        {
            Submarine sub = new Submarine();

            GameLogic gameLogic = new GameLogic(game, board);
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
            GameLogic gameLogic = new GameLogic(game, board);
            
            Submarine sub = new Submarine();
            gameLogic.PlaceShip(sub, 'A', 2, "down"); 

            bool result = gameLogic.PlaceShip(sub, 'A', 30, "down");
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Prueba que el primer turno sea del jugador 1.
        /// </summary>
        [Test]
        public void FirstMoveTest()
        {
            GameLogic gameLogic = new GameLogic(game, board);

            Player player1 = new Player();
            Player player2 = new Player();
            game.AddPlayer(player1);
            game.AddPlayer(player2);
            Assert.AreEqual(1, gameLogic.GetNumberAttack());

            gameLogic.Attack('A', 1);
            Assert.AreEqual(2, gameLogic.GetNumberAttack());
        }

        /// <summary>
        /// Verifica que se pueda acceder a dos tableros
        /// </summary>
        [Test]
        public void AccessTwoBoardsTest()
        {
            Player player1 = new Player();
            Player player2 = new Player();
            
            Game game1 = new Game (12, 12, 9); 
            
            game1.AddPlayer(player1);
            game1.AddPlayer(player2);

            Assert.IsNotNull(game1.GetBoard1());
            Assert.IsNotNull(game1.GetBoard2());
        }
    }
}

