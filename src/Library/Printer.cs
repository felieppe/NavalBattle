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

        private void SplitBoardVisually(int rows) {
            string border = "";

            for (int x = 0; x < rows; x++) {
                border += "==";
            }

            Console.WriteLine(border);
        }

        /// <summary>
        /// Imprime el tablero
        /// </summary>
        /// <param name="board">Tablero</param>
        public void Print(Board board)
        {
            Console.Clear();
            for (int row = 0; row < board.GetBoardSize().Rows; row++)
            {
                if ((board.GetBoardSize().Rows / 2) + 1 == row) { SplitBoardVisually(board.GetBoardSize().Rows); }

                for (int col = 0; col < board.GetBoardSize().Columns; col++)
                {
                    Console.Write(board.GetBoard()[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}