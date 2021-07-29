namespace TicTacToe.Shared
{
    public class Cell
    {
        public int Row { get; }
        public int Column { get; }

        public Cell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}
