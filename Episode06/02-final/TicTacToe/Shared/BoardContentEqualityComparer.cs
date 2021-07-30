using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Shared
{
    class BoardContentEqualityComparer : IEqualityComparer<Board>
    {
        public bool Equals(Board x, Board y) =>
            this.HomeCells(x).SequenceEqual(this.HomeCells(y)) &&
            this.AwayCells(x).SequenceEqual(this.AwayCells(y));

        public int GetHashCode(Board obj) =>
            this.AllMoves(obj)
                .Select(cell => cell.GetHashCode())
                .Aggregate(0, HashCode.Combine);

        private IEnumerable<Cell> AllMoves(Board board) =>
            this.HomeCells(board).Concat(this.AwayCells(board));

        private IEnumerable<Cell> HomeCells(Board board) =>
            board.HomeCells.OrderBy(cell => cell);

        private IEnumerable<Cell> AwayCells(Board board) =>
            board.AwayCells.OrderBy(cell => cell);
    }
}
