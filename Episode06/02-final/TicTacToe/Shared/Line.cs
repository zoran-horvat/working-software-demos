using System;

namespace TicTacToe.Shared
{
    public sealed class Line
    {
        public Cell From { get; }
        public Cell To { get; }

        private Line(Cell @from, Cell to)
        {
            this.From = @from;
            this.To = to;
        }

        public override bool Equals(object obj) =>
            obj is Line line &&
            line.From.Equals(this.From) &&
            line.To.Equals(this.To);

        public override int GetHashCode() =>
            HashCode.Combine(this.From, this.To);

        public static Line Row(int index) =>
            index < 0 || index >= Parameters.Dimension ? throw new ArgumentException(nameof(index))
            : new Line(new Cell(index, 0), new Cell(index, Parameters.Dimension - 1));

        public static Line Column(int index) =>
            index < 0 || index >= Parameters.Dimension ? throw new ArgumentException(nameof(index))
            : new Line(new Cell(0, index), new Cell(Parameters.Dimension - 1, index));

        public static Line Diagonal() =>
            new Line(new Cell(0, 0), new Cell(Parameters.Dimension - 1, Parameters.Dimension - 1));

        public static Line Antidiagonal() =>
            new Line(new Cell(0, Parameters.Dimension - 1), new Cell(Parameters.Dimension - 1, 0));
    }
}
