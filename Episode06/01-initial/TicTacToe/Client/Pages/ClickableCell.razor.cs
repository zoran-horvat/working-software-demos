using System;
using Microsoft.AspNetCore.Components;

namespace TicTacToe.Client.Pages
{
    public partial class ClickableCell
    {
        [Parameter] public Action Play { get; set; }

        private void Clicked() => this.Play();
    }
}