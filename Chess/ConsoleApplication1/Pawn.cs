using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Pawn : ChessPiece
    {
        // Constructor
        public Pawn(int X, int Y, Color color) : base(X, Y, color)
        {
            MovementList.Add(new PawnMoveType());
        }
        public Pawn() : base()
        {
            MovementList.Add(new PawnMoveType());
        }

        // Method
        public override ChessPieceType GetPiecetype()
        {
            return ChessPieceType.P;
        }
        public override bool CheckCapture(ChessPiece[,] Board, int X, int Y)
        {
            int Direction, Xdiff;
            if (this.PieceColor == Color.White)
            {
                Direction = 1;
            }
            else
            {
                Direction = -1;
            }
            Xdiff = Math.Abs(this.X - X);
            if (Xdiff == 1 && this.Y + Direction == Y)
            {
                return true;
            }
            return false;
        }
    }
}
