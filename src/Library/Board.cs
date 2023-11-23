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
        private int rows;
        private int columns;
        private char[][] board;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Board"/>.
        /// </summary>
        /// <param name="rows"> Filas. </param>
        /// <param name="columns"> Columnas. </param> 
        public Board(int rows, int columns)
        {
            if ((rows >= 10) && (rows <= 20) && (rows % 2 == 0))
            {
                this.rows = rows + 1;
            }
            else
            {
                this.rows = 9;
            }
        
            if ((columns >= 10) && (columns <= 20) && (columns % 2 == 0))
            {
                this.columns = columns + 1;
            }
            else
            {
                this.columns = 9;
            }
            this.InitializeBoard();
        }

        /// <summary>
        /// Nuevo tablero con índice de fila y columna.
        /// </summary>
        public void InitializeBoard()
        {
            int rows = this.GetRows();
            int columns = this.GetColumns();

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
        /// <param name="rows"> Filas. </param>
        /// <param name="columns"> Columnas. </param>
        public void SetBoard(Board b, int rows, int columns)
        {
            this.board = b.GetBoard();
            this.rows = rows;
            this.columns = columns;
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
        /// Establece el número de filas.
        /// </summary>
        /// <param name="rows"> Filas del tablero. </param>
        /// <returns> Número par de filas de tablero entre 8 y 20. </returns>
        public bool SetRows(int rows)
        {
            if ((rows >= 8) && (rows <= 20) && (rows % 2 == 0))
            {
                this.rows = rows + 1;
                return true;
            }
            else
            {
                this.rows = 9;
                return false;
            }
        }

        /// <summary>
        /// Establece el número de columnas.
        /// </summary>
        /// <param name="columns"> Columnas del tablero. </param>
        /// <returns> Número par de columnas de tablero entre 8 y 20. </returns>
        public bool SetColumns(int columns)
        {
            if ((columns >= 8) && (columns <= 20) && (columns % 2 == 0))
            {
                this.columns = columns + 1;
                return true;
            }
            else
            {
                this.columns = 9;
                return false;
            }
        }

        /// <summary>
        /// Devuelve las filas del tablero.
        /// </summary>
        /// <returns> Las filas del tablero. </returns>
        public int GetRows()
        {
            return this.rows;
        }

        /// <summary>
        /// Devuelve las columnas del tablero.
        /// </summary>
        /// <returns> Las columnas del tablero. </returns>
        public int GetColumns()
        {
            return this.columns;
        }
    }
}

/// Cumple con el principio de responsabilidad única, ya que sólo se encarga de crear tableros, y la clase BoardSize permite que, si se quisiera cambiar la manera de establecer dimensiones de tableros Board no tenga que cambiar.