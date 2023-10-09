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
        /// Initializes a new instance of the <see cref="Printer"/> class.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public Printer(Board board, int rows, int columns)
        {
            this.board = board;
            this.rows = board.GetBoardSize().Rows;
            this.columns = board.GetBoardSize().Columns;
        }

        /// <summary>
        /// Impresora.
        /// </summary>
        public void Print()
        {
            while (true)
            {
                Console.Clear();

                for (int i = 0; i < this.board.GetBoardSize().Rows; i++)
                {
                    for (int j = 0; j < this.board.GetBoardSize().Columns; j++)
                    {
                        Console.WriteLine(this.board);
                    }
                }
            }
        }
    }
}