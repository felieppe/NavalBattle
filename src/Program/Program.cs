//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using Library;

namespace NavalBattle
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main() {
            int rows = 20;
            int columns = 20;
            int totalShips = 5;
            Game g = new Game(rows, columns, totalShips);

            GameLogic gameLogic = new GameLogic(g, g.GetBoard(), null);

            Battleship bship = new Battleship();
            Cruise cruise = new Cruise();
            gameLogic.PlaceShip(cruise, 'H', 5, "right");
            gameLogic.PlaceShip(bship, 'F', 3, "down");

            gameLogic.Attack('J', 5);

            Board glBoard = gameLogic.GetBoard();
            Printer pr = new Printer();
            pr.Print(glBoard);
        }
    }
}
