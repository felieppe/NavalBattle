//---------------------------------------------------------------------------------
// <copyright file="Printer.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System;

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
        /// Imprime una linea horizontal que divide el tablero en dos.
        /// </summary>
        /// <param name="rows"> Número de filas del tablero. </param>
        private static void SplitBoardVisually(int rows) {
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
            for (int row = 0; row < board.GetBoardSize().GetRows(); row++)
            {
                if ((board.GetBoardSize().GetRows() / 2) + 1 == row) { SplitBoardVisually(board.GetBoardSize().GetRows()); }

                for (int col = 0; col < board.GetBoardSize().GetColumns(); col++)
                {
                    Console.Write(board.GetBoard()[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
/// Cumple con EXPERT porque tiene todos los datos que necesita para imprimir, y cumple con el principio de responsabilidad única porque sólo tiene la responsabilidad de imprimir en consola.