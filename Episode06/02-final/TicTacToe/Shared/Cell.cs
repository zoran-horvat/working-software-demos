using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Shared
{
    public sealed class Cell : IComparable<Cell>
    {
        public int Row { get; }
        public int Column { get; }

        public Cell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public IEnumerable<Line> Lines
        {
            get
            {
                yield return Line.Row(this.Row);
                yield return Line.Column(this.Column);

                if (this.Row == this.Column) yield return Line.Diagonal();
                if (this.Row + this.Column + 1 == Parameters.Dimension) yield return Line.Antidiagonal();
            }
        }

        public static IEnumerable<Cell> RowWiseMatrix() =>
            Enumerable
                .Range(0, Parameters.Size)
                .Select(offset => new Cell(offset / Parameters.Dimension, offset % Parameters.Dimension));

        public override bool Equals(object obj) =>
            obj is Cell cell &&
            cell.Row == this.Row &&
            cell.Column == this.Column;

        public override int GetHashCode() =>
            HashCode.Combine(this.Row, this.Column);

        public int CompareTo(Cell other) =>
            other is null ? 1
            : this.Row.CompareTo(other.Row) == 0 ? this.Column.CompareTo(other.Column)
            : this.Row.CompareTo(other.Row);
    }
}
