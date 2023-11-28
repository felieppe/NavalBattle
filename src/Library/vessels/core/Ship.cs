using System;
using System.Collections.Generic;

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
        /// Dueño del barco.
        /// </summary>
        private bool Owner;

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
        /// <param name="owner"> Dueño del barco. </param>
        public Ship(string name, int length)
        {
            Name = name;
            Length = length;
            Owner = true;

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

        /// <summary>
        /// Devuelve el dueño del barco.
        /// </summary>
        /// <returns> Dueño del barco. </returns>
        public bool GetOwner()
        {
            return Owner;
        }
    }
}

///Cumple con el principio de responsabilidad única de representar la informacion de un barco y manejar su estado.

