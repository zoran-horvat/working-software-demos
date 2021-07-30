using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace TicTacToe.Shared
{
    public class Board
    {
        private ImmutableList<Cell> Moves { get; }

        public Board() : this(
            ImmutableList<Cell>.Empty, 
            new Dictionary<Board, int>(new BoardContentEqualityComparer()))
        {
        }

        private Board(ImmutableList<Cell> moves, Dictionary<Board, int> gameCounterCache)
        {
            this.Moves = moves;
            this.GameCounterCache = gameCounterCache;
        }

        public IEnumerable<Cell> HomeCells => this.Moves.WithParity(0);
        public IEnumerable<Cell> AwayCells => this.Moves.WithParity(1);

        public IEnumerable<Line> WinningLines =>
            this.HomeWinningLines.Concat(this.AwayWinningLines);

        public IEnumerable<Cell> PlayableCells =>
            this.WinningLines.Any() ? Enumerable.Empty<Cell>()
            : this.EmptyCells;

        private IEnumerable<Cell> EmptyCells =>
            Cell.RowWiseMatrix().Except(this.Moves);

        public Board MakeMove(Cell at) =>
            new Board(this.Moves.Add(at), this.GameCounterCache);

        private IEnumerable<Line> HomeWinningLines => this.LinesFor(this.HomeCells);
        private IEnumerable<Line> AwayWinningLines => this.LinesFor(this.AwayCells);

        private IEnumerable<Line> LinesFor(IEnumerable<Cell> moves) =>
            moves.SelectMany(move => move.Lines)
                .GroupBy(line => line)
                .Where(group => group.Count() == Parameters.Dimension)
                .Select(group => group.Key);

        private Dictionary<Board, int> GameCounterCache { get; }

        public int CountContinuations() =>
            this.CountContinuations(0);

        private int CountContinuations(int weight) =>
            Math.Max(
                this.GameCounterCache.TryGetValue(this, out int cached) ? cached : this.CalculateContinuations(),
                weight);

        private int CalculateContinuations()
        {
            int count = this.Successors.Sum(next => next.CountContinuations(1));
            this.GameCounterCache[this] = count;
            return count;
        }

        private IEnumerable<Board> Successors =>
            this.PlayableCells.Select(this.MakeMove);

        public Board Clear() =>
            new Board(ImmutableList<Cell>.Empty, this.GameCounterCache);
    }
}
