using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Knight : ChessPiece
    {
        // Constructor
        public Knight (int X, int Y, Color color) : base(X, Y, color)
        {
            MovementList.Add(new KnightMoveType());
        }
        public Knight() : base()
        {
            MovementList.Add(new KnightMoveType());
        }

        // Method
        public override ChessPieceType GetPiecetype()
        {
            return ChessPieceType.N;
        }
    }
}
