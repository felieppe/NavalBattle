namespace BattleShip
{
    public class Ship
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public Ship(string name, int size)
        {
            this.Name = name;
            this.Size = size;
        }
    }
}
