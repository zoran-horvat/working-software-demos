using TicTacToe.Shared;

namespace TicTacToe.Client.Pages
{
    public partial class Play
    {
        private Board Board { get; set; } = new Board();

        public void Refresh() => StateHasChanged();

        private void Restart()
        {
            Refresh();
        }
    }
}
