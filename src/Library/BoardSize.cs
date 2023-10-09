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
/// Initializes a new instance of the <see cref="BoardSize"/> class.
/// </summary>
/// <param name="rows"> Rows. </param>
/// <param name="columns"> Columns. </param>
        public BoardSize(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
        }

        /// <summary>
        /// Board rows.
        /// </summary>
        public int Rows { get; private set; }

        /// <summary>
        /// Board columns.
        /// </summary>
        public int Columns { get; private set; }
    }
}