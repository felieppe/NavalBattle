using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta clase representa un barco.
    /// </summary>
    public class Ship : IShip
    {
        /// <summary>
        /// Nombre del barco.
        /// </summary>
        /// <value> Nombre. </value>
        public string Name { get; set; }

        /// <summary>
        /// Tamaño del barco.
        /// </summary>
        /// <value> Tamaño. </value>
        public int Length { get; set; }

        /// <summary>
        /// Estado del hundimiento del barco.
        /// </summary>
        /// <value><c>true</c> si el barco está hundido, <c>false</c> en caso contrario.</value>
        public bool Sunken { get; set; }

        public List<int[]> Coords { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Ship"/>.
        /// </summary>
        /// <param name="name">Nombre del barco.</param>
        /// <param name="length">Tamaño del barco.</param>
        public Ship(string name, int length)
        {
            this.Name = name;
            this.Length = length;
        
            this.Coords = new List<int[]>();
        }

        /// <summary>
        /// Hundir el barco.
        /// </summary>
        public void Sink()
        {
            this.Sunken = true;
        }

        public void AddCellCoord(int row, int column) {
            int[] array = { row, column };
            Coords.Add(array);
        }

        public List<int[]> GetCoords() {
            return this.Coords;
        }

        /// <summary>
        /// Obtiene el estado de hundimiento del barco.
        /// </summary>
        /// <returns>
        /// El valor de la variable Sunken.
        /// </returns>
        public bool GetSunken()
        {
            return this.Sunken;
        }
    }
}

