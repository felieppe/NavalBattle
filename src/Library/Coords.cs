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
        private string shipId;

        /// <summary>
        /// Coordenada X.
        /// </summary>
        /// <value> Integrar </value>
        private int x;

        /// <summary>
        /// Coordenada Y.
        /// </summary>
        /// <value> Integrar. </value>
        private int y;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Coords"/>.
        /// </summary>
        /// <param name="id"> Id del barco. </param>
        /// <param name="x"> Coordenada x del barco. </param>
        /// <param name="y"> Coordenada y del barco. </param>
        public Coords(string id, int x, int y)
        {
            this.shipId = id;
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Devuelve el Id del barco.
        /// </summary>
        /// <returns> Id del barco. </returns>
        public string GetShipId() { return this.shipId; }

        /// <summary>
        /// Devuelve la coordenada x del barco.
        /// </summary>
        /// <returns> Coordenada x del barco. </returns>
        public int GetX() { return this.x; }

        /// <summary>
        /// Devuelve la coordenada y del barco.
        /// </summary>
        /// <returns> Coordenada y del barco. </returns>
        public int GetY() { return this.y; }
    }
}

/// Cumple con el principio de responsabilidad única porque solo se encarga de las coordenadas de los barcos.