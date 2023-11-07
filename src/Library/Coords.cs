//---------------------------------------------------------------------------------
// <copyright file="Coords.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

namespace Library
{
    /// <summary>
    /// Clase que representa las coordenadas del barco.
    /// </summary>
    public class Coords
    {
        /// <summary>
        /// Id del barco al que se le relaciona la coordenada.
        /// </summary>
        /// <value> Valor del Id del barco </value>
        private string ShipId;

        /// <summary>
        /// Coordenada X.
        /// </summary>
        /// <value> Integrer </value>
        private int X;

        /// <summary>
        /// Coordenada Y.
        /// </summary>
        /// <value> Integrer. </value>
        private int Y;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Coords"/>.
        /// </summary>
        /// <param name="id"> Id del barco. </param>
        /// <param name="x"> Coordenada x del barco. </param>
        /// <param name="y"> Coordenada y del barco. </param>
        public Coords(string id, int x, int y)
        {
            this.ShipId = id;
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Devuelve el Id del barco.
        /// </summary>
        /// <returns> Id del barco. </returns>
        public string GetShipId() { return this.ShipId; }

        /// <summary>
        /// Devuelve la coordenada x del barco.
        /// </summary>
        /// <returns> Coordenada x del barco. </returns>
        public int GetX() { return this.X; }

        /// <summary>
        /// Devuelve la coordenada y del barco.
        /// </summary>
        /// <returns> Coordenada y del barco. </returns>
        public int GetY() { return this.Y; }
    }
}