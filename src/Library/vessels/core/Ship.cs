namespace Library
{
    public class Ship : IShip
    {
        public string Name { get; set; }
        public int Length { get; set; }  // Corregir la propiedad Length
        public bool Sunken { get; set; }

        public Ship(string name, int length)  // Corregir el nombre del parámetro
        {
            this.Name = name;
            this.Length = length;  // Corregir la asignación de la propiedad Length
        }

        public void SetSunken(bool s)
        {
            this.Sunken = s;
        }

        public bool GetSunken()
        {
            return this.Sunken;
        }
    }
}

