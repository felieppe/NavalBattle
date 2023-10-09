using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library{
    public class Printer
{
    private Board board;
    private int Width;
    private int Height;

    public Printer(Board board, int width, int height)
    {
        this.board = board;
        this.Width = width;
        this.Height = height;
    }

    public void Print()
    {
        while (true)
        {
            Console.Clear();

            StringBuilder s = new StringBuilder();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (board.GetCell(x, y))
                    {
                        s.Append("|X|");
                    }
                    else
                    {
                        s.Append("___");
                    }
                }
                s.Append("\n");
            }
        }
    }
}

}