//---------------------------------------------------------------------------------
// <copyright file="Board.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Board class.
    /// </summary>
    public class Board
    {
        private BoardSize boardSize;
        private char[][] boards;

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        /// <param name="boards"> Board. </param>
        /// <param name="boardSize"> Board Size. </param>
        public Board(char[][] boards, BoardSize boardSize)
        {
            this.boards = boards;
            this.boardSize = boardSize;
            this.InitializeBoard();
        }

        /// <summary>
        /// New board with row and column index.
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
/// <param name="boards"> Board. </param>
/// <param name="boardSize"> Board size. </param>
        public void SetBoard(char[][] boards, BoardSize boardSize)
        {
            this.boards = boards;
            this.boardSize = boardSize;
        }

/// <summary>
/// Get de la clase Board.
/// </summary>
/// <returns> boards. </returns>
        public char[][] GetBoard()
        {
            return this.boards; // Devuelve el tablero.
        }

/// <summary>
/// Devuelve tamaño del tablero.
/// </summary>
/// <returns> boardSize. </returns>
        public BoardSize GetBoardSize()
        {
            return this.boardSize;
        }
    }
}