//---------------------------------------------------------------------------------
// <copyright file="Battleship.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
namespace Library
{
    /// <summary>
    /// Clase battleShip.
    /// </summary>
    public class Battleship : Ship
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Battleship"/>.
        /// </summary>
        public Battleship() : base("Battleship", 4)
        {
        }
    }
}

/// Esta clase cumple con el patron polimorfismo porque tiene comportamientos relacionados con los otros barcos, pero el tipo varía el tamaño.
/// Los barcos también cumplen con el principio de sustitución de Liskov, ya que si a un objeto de esta clase se lo sustituye por un objeto de tipo Ship, el programa funciona igual.