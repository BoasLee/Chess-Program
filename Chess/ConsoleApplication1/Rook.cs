using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Rook : ChessPiece
    {
        // Constructor
        public Rook(int X, int Y, Color color) : base(X, Y, color)
        {
            MovementList.Add(new RookMoveType());
        }
        public Rook() : base()
        {
            MovementList.Add(new RookMoveType());
        }

        // Method
        public override ChessPieceType GetPiecetype()
        {
            return ChessPieceType.R;
        }
    }
}
