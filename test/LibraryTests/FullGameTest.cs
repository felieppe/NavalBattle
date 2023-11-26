//---------------------------------------------------------------------------------
// <copyright file="FullGameTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using Library;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de un juego completo.
    /// </summary>
    [TestFixture]
    public class FullGameTest
    {
        /// <summary>
        /// Tablero para probar.
        /// </summary>
        private Board board;
        private int rows;
        private int columns;
        private Player player1;
        private Player player2;
        private Game game;
        private GameLogic gl;
        private Cruise cruise1;
        private Cruise cruise2;
        private Destroyer destroyer1;
        private Destroyer destroyer2;
        private Submarine sub1;
        private Submarine sub2;


        /// <summary>
        /// Crea un tablero para probar.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.rows = 12;
            this.columns = 6;
            this.board = new Board(rows, columns);
            this.game = new Game(rows, columns, 3);
            game.AddPlayer(player1);
            game.AddPlayer(player2);
            game.SetAdmin(player1);
            game.SetBoard1(board);
            this.gl = new GameLogic(game, board);
        }

        /// <summary>
        /// Prueba de un juego completo.
        /// </summary>
        [Test]
        public void GameTest()
        {
            gl.PlaceShip(cruise1, 'C', 3, "down");
            gl.PlaceShip(cruise2, 'I', 1, "right");
            gl.PlaceShip(destroyer1, 'A', 1, "down");
            gl.PlaceShip(destroyer2, 'J', 4, "right");
            gl.PlaceShip(sub1, 'B', 5, "down");
            gl.PlaceShip(sub2, 'G', 6, "down");
            gl.Attack('G', 6);
            gl.Attack('A', 1);
            gl.Attack('B', 3);
            gl.Attack('I', 2);
            gl.Attack('B', 1);
            gl.Attack('I', 3);
            gl.Attack('B', 3);
            gl.Attack('I', 1);
            gl.Attack('C', 3);
            gl.Attack('G', 4);
            gl.Attack('D', 3);
            gl.Attack('J', 4);
            gl.Attack('E', 3);
            gl.Attack('J', 5);
            gl.Attack('E', 2);
            gl.Attack('H', 1);
        }
    }
}