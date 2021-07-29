using Microsoft.AspNetCore.Components;
using System;
using TicTacToe.Shared;

namespace TicTacToe.Client.Pages
{
    public partial class WinningLine
    {
        [Parameter] public Line Line { get; set; }

        public int FromX(int padding) => 
            this.Line.From.Column * 325 + 150 - (105 + padding) * XDirection;

        public int FromY(int padding) => 
            this.Line.From.Row * 325 + 150 - (105 + padding) * YDirection;

        public int ToX(int padding) => 
            this.Line.To.Column * 325 + 150 + (105 + padding) * XDirection;

        public int ToY(int padding) => 
            this.Line.To.Row * 325 + 150 + (105 + padding) * YDirection;

        private int XDirection =>
            Math.Sign(this.Line.To.Column - this.Line.From.Column);

        private int YDirection =>
            Math.Sign(this.Line.To.Row - this.Line.From.Row);
    }
}
