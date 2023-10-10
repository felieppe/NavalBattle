//---------------------------------------------------------------------------------
// <copyright file="Board.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
namespace Library
{
    /// <summary>
    /// Clase tablero.
    /// </summary>
    public class Board
    {
        private BoardSize boardSize;
        private char[][] boards;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Board"/>.
        /// </summary>
        /// <param name="boards"> Board. </param>
        /// <param name="boardSize"> Board Size. </param>
        public Board(char[][] boards, BoardSize boardSize)
        {
            this.boards = boards;
            this.boardSize = boardSize;
        }

        /// <summary>
        /// Nuevo tablero con índice de fila y columna.
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
        /// <param name="boards"> Tablero. </param>
        /// <param name="boardSize"> Tamaño del tablero. </param>
        public void SetBoard(char[][] boards, BoardSize boardSize)
        {
            this.boards = boards;
            this.boardSize = boardSize;
        }

        /// <summary>
        /// Get de la clase Board.
        /// </summary>
        /// <returns> Tablero. </returns>
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