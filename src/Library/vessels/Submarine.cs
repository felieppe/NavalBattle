//---------------------------------------------------------------------------------
// <copyright file="Submarine.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
namespace Library
{
    /// <summary>
    /// Clase submarine.
    /// </summary>
    public class Submarine : Ship
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Submarine"/>.
        /// </summary>
        public Submarine() : base("Submarine", 1)
        {
        }
    }
}

/// Esta clase cumple con el patron polimorfismo porque tiene comportamientos relacionados con los otros barcos, pero según el tipo de barco en particular varía el tamaño.
/// Los barcos también cumplen con el principio de sustitución de Liskov, ya que si a un objeto de esta clase se lo sustituye por un objeto de tipo Ship, el programa funciona igual.