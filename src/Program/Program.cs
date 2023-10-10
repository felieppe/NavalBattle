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
            BoardSize bs = new BoardSize(20, 20);
            Board b = new Board(bs);

            int ships = 3;
            GameLogic gameLogic = new GameLogic(b, bs, ships);

            Battleship bship = new Battleship();
            gameLogic.PlaceShip(bship, 'H', 14, "up");

            Board glBoard = gameLogic.GetBoard();
            Printer pr = new Printer();
            pr.Print(glBoard);
        }
    }
}
