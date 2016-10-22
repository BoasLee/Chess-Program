using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Pawn : Pieces
    {
        //Constructor
        public Pawn(int X, int Y, Color color) : base(X, Y, color)
        {
        }

        // Method
        public override char GetPiecetype()
        {
            return 'p';
        }
        public override bool Move(Pieces[,] Board, int X, int Y)
        {
            if ((this.Y + 1 == Y && this.X == X && Board[X,Y] == null) || (this.NumberOfMoves== 0 && this.Y + 2 == Y && this.X == X && Board[X, this.Y + 1] == null && Board[X, Y] == null))
            {
                Board[this.X, this.Y] = null;
                this.Y = Y;
                Board[X, Y] = this;
                this.NumberOfMoves++;
                return true;
            }
            return false;
        }
        public override bool Capture(Pieces[,] Board, int X, int Y)
        {
            if ((this.X + 1 == X || this.X - 1 == X ) && this.Y + 1 == Y && Board[X, Y] != null)
            {
                if (this.PieceColor == Board[X, Y].GetColor())
                {
                    return false;
                }
                Board[this.X, this.Y] = null;
                Board[X,Y] = this;
                this.Y = Y;
                this.X = X;
                NumberOfMoves++;
                return true;
            }
            return false;
        }
    }
}
