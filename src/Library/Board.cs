using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShip
{
    /// <summary>
    /// Clase Board.
    /// </summary>
    public class Board
    {
        private char[][] boards;
        private BoardSize boardSize;

        /// <summary>
        /// Constructor de la clase Board.
        /// </summary>
        /// <param name="boards"></param>
        /// <param name="boardSize"></param>
        public Board(char[][] boards, BoardSize boardSize)
        {
            this.boards = boards;
            this.boardSize = boardSize;
            this.InitializeBoard();
        }

        /// <summary>
        /// Inicializar la matriz del tablero con etiquetas de fila y columna.
        /// </summary>
        public void InitializeBoard()
        {
            int rows = this.boardSize.Rows;
            int columns = this.boardSize.Columns;

            this.boards = new char[rows + 1][];
            for (int i = 0; i <= rows; i++)
            {
                this.boards[i] = new char[columns + 1];
                for (int j = 0; j <= columns; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        this.boards[i][j] = ' ';
                    }
                    else if (i == 0)
                    {
                        this.boards[i][j] = (char)('A' + j - 1);
                    }
                    else if (j == 0)
                    {
                        this.boards[i][j] = (char)('0' + i);
                    }
                    else
                    {
                        this.boards[i][j] = ' ';
                    }
                }
            }
        }

/// <summary>
/// Set de la clase Board.
/// </summary>
/// <param name="boards"></param>
/// <param name="boardSize"></param>
        public void SetBoard(char[][] boards, BoardSize boardSize)
        {
            this.boards = boards;
            this.boardSize = boardSize;
        }

/// <summary>
/// Get de la clase Board.
/// </summary>
/// <returns></returns>
        public char[][] GetBoard()
        {
            return this.boards; // Devuelve el tablero.
        }
    }
}