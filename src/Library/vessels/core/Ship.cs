namespace Library
{
    public class Ship : IShip
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public bool Sunken { get; set; }

        public Ship(string name, int length)
        {
            this.Name = name;
            this.Length = length;
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

