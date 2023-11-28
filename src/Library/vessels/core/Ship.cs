//---------------------------------------------------------------------------------
// <copyright file="Ship.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using System;

namespace Library
{
    /// <summary>
    /// Esta clase representa un barco.
    /// </summary>
    public class Ship : IShip
    {
        /// <summary>
        /// Identificación del barco.
        /// </summary>
        /// <value> Identificación. </value>
        public string ShipId { get; set; }

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

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Ship"/>.
        /// </summary>
        /// <param name="name"> Nombre del barco. </param>
        /// <param name="length"> Tamaño del barco. </param>
        public Ship(string name, int length)
        {
            Name = name;
            Length = length;

            Guid uuid = Guid.NewGuid();
            ShipId = uuid.ToString();
        }

        /// <summary>
        /// Hundir el barco.
        /// </summary>
        public void Sink()
        {
            Sunken = true;
        }

        /// <summary>
        /// Obtiene el estado de hundimiento del barco.
        /// </summary>
        /// <returns>
        /// El valor de la variable Sunken.
        /// </returns>
        public bool GetSunken()
        {
            return Sunken;
        }

        /// <summary>
        /// Devuelve el Id del barco.
        /// </summary>
        /// <returns> Id del barco. </returns>
        public string GetShipId()
        {
            return ShipId;
        }
    }
}

///Cumple con el principio de responsabilidad única de representar la información de un barco y manejar su estado.