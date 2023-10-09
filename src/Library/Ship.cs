namespace Library
{
    public class Ship
    {
        public string Name { get; set; }
        public int Lenght { get; set; }
        public Ship(string name, int lenght)
        {
            this.Name = name;
            this.Lenght = lenght;
        }
    }
}
