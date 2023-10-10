//---------------------------------------------------------------------------------
// <copyright file="Printer.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Library
{
    /// <summary>
    /// Class Printer.
    /// </summary>
    public class Printer
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Printer"/>.
        /// </summary>
        public Printer() {}

        /// <summary>
        /// Imprime el tablero
        /// </summary>
        /// <param name="board">Tablero</param>
        public void Print(Board board)
        {
            for (int row = 0; row < board.GetBoardSize().Rows; row++)
            {
                for (int col = 0; col < board.GetBoardSize().Columns; col++)
                {
                    Console.Write(board.GetBoard()[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}