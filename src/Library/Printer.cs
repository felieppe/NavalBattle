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
        private Board board;
        private int rows;
        private int columns;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Printer"/>.
        /// </summary>
        /// <param name="board"> Tablero. </param>
        public Printer(Board board)
        {
            this.board = board;
            this.rows = this.board.GetBoardSize().Rows;
            this.columns = this.board.GetBoardSize().Columns;
        }

        /// <summary>
        /// Impresora.
        /// </summary>
        public void Print()
        {
            for (int row = 0; row < this.board.GetBoardSize().Rows; row++)
            {
                for (int col = 0; col < this.board.GetBoardSize().Columns; col++)
                {
                    Console.Write(this.board.GetBoard()[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}