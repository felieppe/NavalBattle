using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class Coords
    {
        private int X;
        private int Y;

        public Coords(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public void GetX() { return this.X; }
        public void GetY() { return this.Y; }
    }
}