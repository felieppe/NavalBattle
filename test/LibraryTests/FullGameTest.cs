//---------------------------------------------------------------------------------
// <copyright file="FullGameTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using Library;
using Library.utils;
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
        private Printer printer;

        /// <summary>
        /// Crea un tablero para probar.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            Deserializer.Instance.Debug = true;
            Serializer.Instance.Debug = true;
            rows = 12;
            columns = 6;
            cruise1 = new Cruise();
            cruise2 = new Cruise();
            destroyer1 = new Destroyer();
            destroyer2 = new Destroyer();
            sub1 = new Submarine();
            sub2 = new Submarine();
            board = new Board(rows, columns);
            game = new Game(rows, columns, 6);
            game.AddPlayer(player1);
            game.AddPlayer(player2);
            game.SetAdmin(player1);
            game.SetBoard1(board);
            gl = new GameLogic(game, board);
            printer = new Printer();
        }

        /// <summary>
        /// Prueba de un juego completo.
        /// </summary>
        [Test]
        public void GameTest()
        {
            gl.PlaceShip(cruise1, 'C', 3, "down");
            printer.Print(board);
            gl.PlaceShip(cruise2, 'A', 9, "right");
            printer.Print(board);
            gl.PlaceShip(destroyer1, 'A', 1, "down");
            printer.Print(board);
            gl.PlaceShip(destroyer2, 'A', 10, "right");
            printer.Print(board);
            gl.PlaceShip(sub1, 'E', 2, "down");
            printer.Print(board);
            gl.PlaceShip(sub2, 'F', 7, "down");
            printer.Print(board);
            gl.Attack('F', 7);
            printer.Print(board);
            gl.Attack('A', 1);
            printer.Print(board);
            gl.Attack('B', 3);
            printer.Print(board);
            gl.Attack('B', 9);
            printer.Print(board);
            gl.Attack('A', 2);
            printer.Print(board);
            gl.Attack('C', 9);
            printer.Print(board);
            gl.Attack('C', 3);
            printer.Print(board);
            gl.Attack('A', 9);
            printer.Print(board);
            gl.Attack('C', 3);
            printer.Print(board);
            gl.Attack('F', 7);
            printer.Print(board);
            gl.Attack('C', 4);
            printer.Print(board);
            gl.Attack('A', 10);
            printer.Print(board);
            gl.Attack('C', 5);
            printer.Print(board);
            gl.Attack('B', 10);
            printer.Print(board);
            gl.Attack('B', 5);
            printer.Print(board);
            gl.Attack('A', 8);
            printer.Print(board);
            gl.Attack('E', 2);
            printer.Print(board);
        }
    }
}