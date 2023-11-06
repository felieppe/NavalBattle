using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class Coords
    {
        private string ShipId;
        private int X;
        private int Y;

        public Coords(string id, int x, int y) {
            this.ShipId = id;
            this.X = x;
            this.Y = y;
        }

        public string GetShipId() { return this.ShipId; }
        public int GetX() { return this.X; }
        public int GetY() { return this.Y; }
    }
}