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
        public string shipId { get; private set; }

        /// <summary>
        /// Coordenada X.
        /// </summary>
        public int x { get; private set; }

        /// <summary>
        /// Coordenada Y.
        /// </summary>
        public int y { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Coords"/>.
        /// </summary>
        /// <param name="id"> Id del barco. </param>
        /// <param name="x"> Coordenada X del barco. </param>
        /// <param name="y"> Coordenada Y del barco. </param>
        public Coords(string id, int x, int y)
        {
            shipId = id;
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Devuelve el Id del barco.
        /// </summary>
        /// <returns> Id del barco. </returns>
        public string GetShipId() { return shipId; }

        /// <summary>
        /// Devuelve la coordenada x del barco.
        /// </summary>
        /// <returns> Coordenada X del barco. </returns>
        public int GetX() { return x; }

        /// <summary>
        /// Devuelve la coordenada y del barco.
        /// </summary>
        /// <returns> Coordenada Y del barco. </returns>
        public int GetY() { return y; }
    }
}

/// Cumple con el principio de responsabilidad única porque solo se encarga de las coordenadas de los barcos.