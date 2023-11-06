//---------------------------------------------------------------------------------
// <copyright file="BoardSize.cs" company="Universidad Católica del Uruguay">
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
                this.Rows = rows + 1;
            }
            else
            {
                this.Rows = 9;
            }
        
            if ((columns >= 10) && (columns <= 20) && (columns % 2 == 0))
            {
                this.Columns = columns + 1;
            }
            else
            {
                this.Columns = 9;
            }
        }

        /// <summary>
        /// Filas del tablero.
        /// </summary>
        public int Rows { get; private set; }

        /// <summary>
        /// Columnas del tablero.
        /// </summary>
        public int Columns { get; private set; }

        /// <summary>
        /// Establece el número de filas.
        /// </summary>
        /// <param name="rows"> Filas del tablero. </param>
        /// <returns> Número par de filas de tablero entre 8 y 20. </returns>
        public bool SetRows(int rows)
        {
            if ((rows >= 8) && (rows <= 20) && (rows % 2 == 0))
            {
                this.Rows = rows + 1;
                return true;
            }
            else
            {
                this.Rows = 9;
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
                this.Columns = columns + 1;
                return true;
            }
            else
            {
                this.Columns = 9;
                return false;
            }
        }

        /// <summary>
        /// Devuelve las filas del tablero.
        /// </summary>
        /// <returns> Las filas del tablero. </returns>
        public int GetRows()
        {
            return this.Rows;
        }

        /// <summary>
        /// Devuelve las columnas del tablero.
        /// </summary>
        /// <returns> Las columnas del tablero. </returns>
        public int GetColumns()
        {
            return this.Columns;
        }
    }
}