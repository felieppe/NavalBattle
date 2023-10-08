using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShip
{
    /// <summary>
    /// Clase para establecer las dimensiones del tablero.
    /// </summary>
    public class BoardSize
    {
        /// <summary>
        /// Filas del tablero.
        /// </summary> <summary>
        /// Columnas del tablero.
        /// </summary>
        /// <value></value>
        public int Rows { get; private set; }

        public int Columns { get; private set; }

/// <summary>
/// Dimensiones del tablero.
/// </summary>
/// <param name="rows"></param>
/// <param name="columns"></param>
        public BoardSize(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
        }
    }
}