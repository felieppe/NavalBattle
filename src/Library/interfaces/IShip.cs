namespace Library {
    public interface IShip {
        string Name {get; set;}
        int Length {get; set;}

        bool Sunken {get; set;}
        bool GetSunken();

        void SetSunken(bool s);
    }
}