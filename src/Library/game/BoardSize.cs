//---------------------------------------------------------------------------------
// <copyright file="BoardSize.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

namespace Library
{
    /// <summary>
    /// Clase para establecer las dimensiones del tablero.
    /// </summary>
    public class BoardSize
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BoardSize"/>.
        /// </summary>
        /// <param name="rows"> Filas. </param>
        /// <param name="columns"> Columnas. </param>
        public BoardSize(int rows, int columns)
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
        }

        /// <summary>
        /// Filas del tablero.
        /// </summary>
        public int rows { get; private set; }

        /// <summary>
        /// Columnas del tablero.
        /// </summary>
        public int columns { get; private set; }

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

/// Cumple con el principio de responsabilidad única, ya que solo se encarga del tamaño del tablero.