using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShip
{
    /// <summary>
    /// Clase Board.
    /// </summary>
    public class Board
    {
        private char[][] boards;
        private BoardSize boardSize;

/// <summary>
/// Constructor de la clase Board.
/// </summary>
/// <param name="boards"></param>
/// <param name="boardSize"></param>
        public Board(char[][] boards, BoardSize boardSize)
        {
            this.boards = boards;
            this.boardSize = boardSize;
        }

/// <summary>
/// Set de la clase Board.
/// </summary>
/// <param name="boards"></param>
/// <param name="boardSize"></param>
        public void SetBoard(char[][] boards, BoardSize boardSize)
        {
            this.boards = boards;
            this.boardSize = boardSize;
        }

/// <summary>
/// Get de la clase Board.
/// </summary>
/// <returns></returns>
        public char[][] GetBoard()
        {
            return this.boards;
        }
    }
}