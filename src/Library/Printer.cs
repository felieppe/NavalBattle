using System;
using System.Collections.Generic;
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
        private int width;
        private int height;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Printer(Board board, int width, int height)
        {
            this.board = board;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Impresora.
        /// </summary>
        public void Print()
        {
            while (true)
            {
                Console.Clear();

                StringBuilder s = new StringBuilder();
                for (int y = 0; y < this.height; y++)
                {
                    for (int x = 0; x < this.width; x++)
                    {
                        if (this.board.GetCell(x, y))
                        {
                            s.Append("|X|");
                        }
                        else
                        {
                            s.Append("___");
                        }
                    }

                    s.Append('\n');
                }
            }
        }
    }
}