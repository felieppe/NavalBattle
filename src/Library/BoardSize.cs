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
            this.Rows = rows;
            this.Columns = columns;
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
        /// <returns> Número par de filas de tablero entre 10 y 20. </returns>
        public bool SetRows(int rows)
        {
            if ((rows >= 10) && (rows <= 20) && (rows % 2 == 0))
            {
                this.Rows = rows;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Establece el número de columnas.
        /// </summary>
        /// <param name="columns"> Columnas del tablero. </param>
        /// <returns> Número par de columnas de tablero entre 10 y 20. </returns>
        public bool SetColumns(int columns)
        {
            if ((columns >= 10) && (columns <= 20) && (columns % 2 == 0))
            {
                this.Columns = columns;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}