using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Board
    {
        private char[][] boards;
        private BoardSize boardSize;

        public Board(char[][] boards, BoardSize boardSize)
        {
            this.boards = boards;
            this.boardSize = boardSize;
        }

        public void SetBoard(char[][] boards, BoardSize boardSize)
        {
            this.boards = boards;
            this.boardSize = boardSize;
        }

        public char[][] GetBoard()
        {
            return this.boards;
        }
    }
}