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
            this.Rows = rows + 1;
            this.Columns = columns + 1;
        }

        /// <summary>
        /// Filas del tablero.
        /// </summary>
        public int Rows { get; private set; }

        /// <summary>
        /// Columnas del tablero.
        /// </summary>
        public int Columns { get; private set; }
    }
}