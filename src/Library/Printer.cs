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