using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Bishop : ChessPiece
    {
        // Constructor
        public Bishop(int X, int Y, Color color) : base(X, Y, color)
        {
            MovementList.Add(new BishopMoveType());
        }
        public Bishop() : base()
        {
            MovementList.Add(new BishopMoveType());
        }

        // Method
        public override ChessPieceType GetPiecetype()
        {
            return ChessPieceType.B;
        }
    }
}
