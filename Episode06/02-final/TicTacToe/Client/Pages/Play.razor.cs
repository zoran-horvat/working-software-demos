using System;
using System.Linq;
using TicTacToe.Shared;

namespace TicTacToe.Client.Pages
{
    public partial class Play
    {
        private Board Board { get; set; } = new Board();

        public void Refresh() => StateHasChanged();

        private void Restart()
        {
            this.Board = this.Board.Clear();
            Refresh();
        }

        private void MakeMove(Cell at)
        {
            this.Board = this.Board.MakeMove(at);
            Console.WriteLine($"{this.Board.PlayableCells.Count()} playable cells");
            Refresh();
        }
    }
}
