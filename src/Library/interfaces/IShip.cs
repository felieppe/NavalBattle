//---------------------------------------------------------------------------------
// <copyright file="IShip.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Interfaz IShip.
    /// </summary>
    public interface IShip
    {
        string Id { get; set; }

        /// <summary>
        /// Nombre.
        /// </summary>
        /// <value> Nombre del barco. </value>
        string Name { get; set; }

        /// <summary>
        /// Largo.
        /// </summary>
        /// <value> Largo del barco. </value>
        int Length { get; set; }

        /// <summary>
        /// Hundido.
        /// </summary>
        /// <value> Estado del barco. </value>
        bool Sunken { get; set; }

        /// <summary>
        /// Obtiene el estado del barco.
        /// </summary>
        /// <returns> El estado del barco. </returns>
        bool GetSunken();

        /// <summary>
        /// Establece el estado del barco.
        /// </summary>
        void Sink();
    }
}