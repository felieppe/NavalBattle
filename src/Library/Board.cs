//---------------------------------------------------------------------------------
// <copyright file="Board.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System;

namespace Library
{
    /// <summary>
    /// Clase tablero.
    /// </summary>
    public class Board
    {
        private BoardSize boardSize;
        private char[][] board;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Board"/>.
        /// </summary>
        /// <param name="boardSize"> Boardsize.</param>
        public Board(BoardSize boardSize)
        {
            this.boardSize = boardSize;
            this.InitializeBoard();
        }

        /// <summary>
        /// Nuevo tablero con índice de fila y columna.
        /// </summary>
        public void InitializeBoard()
        {
            Console.WriteLine(this.boardSize.Rows);
            int rows = this.boardSize.Rows;
            int columns = this.boardSize.Columns;

            this.board = new char[rows + 1][];
            for (int i = 0; i <= rows; i++)
            {
                this.board[i] = new char[columns + 1];
                for (int j = 0; j <= columns; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        this.board[i][j] = ' ';
                    }
                    else if (i == 0)
                    {
                        this.board[i][j] = (char)('A' + j - 1);
                    }
                    else if (j == 0)
                    {
                        this.board[i][j] = (char)('0' + i);
                    }
                    else
                    {
                        this.board[i][j] = ' ';
                    }
                }
            }
        }

        /// <summary>
        /// Set de la clase Board.
        /// </summary>
        /// <param name="b"> Tablero. </param>
        /// <param name="boardSize"> Tamaño del tablero. </param>
        public void SetBoard(char[][] b, BoardSize boardSize)
        {
            this.board = b;
            this.boardSize = boardSize;
        }

        /// <summary>
        /// Get de la clase Board.
        /// </summary>
        /// <returns> Tablero. </returns>
        public char[][] GetBoard()
        {
            return this.board; // Devuelve el tablero.
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