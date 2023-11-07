//---------------------------------------------------------------------------------
// <copyright file="Destroyer.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
namespace Library
{
    /// <summary>
    /// Clase destroyer.
    /// </summary>
    public class Destroyer : Ship
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Destroyer"/>.
        /// </summary>
        public Destroyer() : base("Destroyer", 2)
        {
        }
    }
}
/// Esta clase cumple con el patron polimorfismo porque tiene comportamientos relacionados con los otros barcos, pero el tipo varía el tamaño.
/// Los barcos también cumplen con el principio de sustitución de Liskov, ya que si a un objeto de esta clase se lo sustituye por un objeto de tipo Ship, el programa funciona igual.