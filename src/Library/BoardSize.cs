using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShip
{
    public class BoardSize
    {
        public int Rows { get; private set; }

        public int Columns { get; private set; }

        public BoardSize(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
        }
    }
}