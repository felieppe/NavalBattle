namespace Library {
    public interface IShip {
        string Name {get; set;}
        int Lenght {get; set;}

        bool Sunken {get; set;}
        bool GetSunken();
    }
}